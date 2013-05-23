using System;
using System.Drawing;
using System.Windows.Forms;

public class Wave
{
    // Parent Form
    public MilkForm mForm;

    // Wave Tabs
    public TabPage tab;
    public WaveTabs tabControl;

    // Wave Number
    public string waveNum;

    // Enable Checkbox / Boolean
    public CheckBox enable;
    public bool enabled;

    ///////////////////////////
    // General Wave Settings //
    ///////////////////////////
    //
    //
    //////////////////////////
    //
    // Setting Variable
    public Setting[] settings;
    public int perFrameNum;


    //////////////////////////
    //
    // SettingStrip:
    //
    // Wave X & Y Position
    public SettingStrip xSS, ySS;

    // Wave Red
    public SettingStrip redSS;

    // Wave Green
    public SettingStrip greenSS;

    // Wave Blue
    public SettingStrip blueSS;

    // Wave Opacity
    public SettingStrip opacitySS;

    // Wave Samples
    public SettingStrip sampleSS;

    //////////////////////////////////////


    // Constructor
    public Wave(MilkForm m, TabPage t, WaveTabs tC, string num)
    {
        tab = t;
        mForm = m;
        tabControl = tC;
        waveNum = num;

        perFrameNum = 1;

        // Create Settings
        settings = new Setting[7];

        // X Position Setting
        settings[0] = new Setting("x", (float)0.5, 10);

        // Y Position Setting
        settings[1] = new Setting("y", (float)0.5, 10);

        // Red Setting
        settings[2] = new Setting("red", 1, 10);

        // Green Setting
        settings[3] = new Setting("green", 0, 10);

        // Blue Setting
        settings[4] = new Setting("blue", 0, 10);

        // Opacity Setting
        settings[5] = new Setting("opacity", 1, 10);

        // Sample Setting
        settings[6] = new Setting("samples", 256, 1);


        // Wave Font;
        Font waveFont = new Font("Arial", 10, FontStyle.Bold);

        // Create Enable CheckBox
        enable = new CheckBox();
        enabled = false;
        enable.Location = new Point(10, 4);
        enable.Text = "Enabled";
        enable.Parent = tab;
        enable.Font = waveFont;
        enable.CheckedChanged += new EventHandler(enableChk);

        // Create SettingStrip For Various Settings

        // X Position SettingStrip
        Separator sep0 = new Separator(new Point(0, 35), "tab", tab);
        xSS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 55), "X Position", 0, 100, 50, 0);
        Separator sep1 = new Separator(new Point(0, 95), "tab", tab);

        // Y Position SettingStrip
        ySS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 115), "Y Position", 0, 100, 50, 1);
        Separator sep2 = new Separator(new Point(0, 155), "tab", tab);

        // Red SettingStrip
        redSS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 175), "Red", 0, 100, 100, 2);
        Separator sep3 = new Separator(new Point(0, 215), "tab", tab);

        // Green SettingStrip
        greenSS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 235), "Green", 0, 100, 0, 3);
        Separator sep4 = new Separator(new Point(0, 275), "tab", tab);

        // Blue SettingStrip
        blueSS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 295), "Blue", 0, 100, 0, 4);
        Separator sep5 = new Separator(new Point(0, 335), "tab", tab);

        // Opacity SettingStrip
        opacitySS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 355), "Opacity", 0, 100, 100, 5);
        Separator sep6 = new Separator(new Point(0, 395), "tab", tab);

        // Sample SettingStrip
        sampleSS = new SettingStrip(mForm, tab, 1, null, tC, null, this, new Point(100, 415), "Samples", 0, 512000, 256000, 6);
    }


    //////////////////////////////////////////////
    // Return The Value Of The Specified Setting
    public float getVal(string setting)
    {
        if (setting.Contains("X"))
            return settings[0].getValue();
        else if (setting.Contains("Y"))
            return settings[1].getValue();
        else if (setting.Contains("Red"))
            return settings[2].getValue();
        else if (setting.Contains("Green"))
            return settings[3].getValue();
        else if (setting.Contains("Blue"))
            return settings[4].getValue();
        else if (setting.Contains("Opacity"))
            return settings[5].getValue();
        else if (setting.Contains("Samples"))
            return settings[6].getValue();
        else
            return 0;
    }

    ///////////////////////////////////////////////
    // Changes A Specified Setting's Value
    public void changeVal(int sIndx, object value)
    {
        settings[sIndx].changeVal((float)value);
    }

    //////////////////////////////////////////
    // Enable Checkbox Event Handler
    public void enableChk(object sender, EventArgs e)
    {
        if (enabled == false)
        {
            enabled = true;
            mForm.reWrite();
        }

        else
        {
            enabled = false;
            mForm.reWrite();
        }
    }

    /////////////////////////////////
    // Return Enabled Boolean
    public bool isEnabled()
    {
        return enabled;
    }

    /////////////////////////////////
    // Set per_frame Number
    public void setPNum(int val)
    {
        perFrameNum = val;
    }

    /////////////////////////////////
    // Write Wave Parameters
    public void write()
    {
        // Wave Parameters
        string wName = "wavecode_" + waveNum + "_";
        string[] parameters = {wName + "enabled=1",
                               wName + "x=" + getVal("X Position"),
                               wName + "y=" + getVal("Y Position"),
                               wName + "r=" + getVal("Red"),
                               wName + "g=" + getVal("Green"),
                               wName + "b=" + getVal("Blue"),
                               wName + "a=" + getVal("Opacity"),
                               wName + "samples=" + getVal("Samples")
                              };

        // Write Parameters To .milk File
        string sourcePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        string[] files = System.IO.Directory.GetFiles(sourcePath);
        string fileName = System.IO.Path.GetFileName(files[0]);
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        System.IO.File.AppendAllLines(sourceFile, parameters);

        // For Each setting:
        for (int i = 0; i < settings.Length; i++)
        {
            // Set Reactive Boolean
            bool isReactive = settings[i].isReactive();
            // Get Reaction Attribute (bass/mid/etc.)
            string rAttrI = settings[i].getRAttr();
            // Get Reaction Intensity
            string intensity = settings[i].getIntensity().ToString() + ";";
            if (rAttrI.Contains("B"))
                rAttrI = "bass_att / " + intensity;
            else if (rAttrI.Contains("M"))
                rAttrI = "mid_att / " + intensity;
            else if (rAttrI.Contains("T"))
                rAttrI = "treb_att / " + intensity;
            else if (rAttrI.Contains("O"))
                rAttrI = "sin(time) / " + intensity;
            else
                rAttrI = "(bass + mid + treb) / " + intensity;
            string reactType = settings[i].getRType();
            string setting;
            string reactOp;
            bool doNothing = false;
            // Get Reaction Operation (+ / -)
            if (reactType.Contains("Increase"))
                reactOp = " + ";
            else if (reactType.Contains("Decrease"))
                reactOp = " - ";
            else
            {
                reactOp = "";
                doNothing = true;
            }

            // Get Reaction Setting
            String tempSet = settings[i].getName();
            setting = "=" + tempSet + "=" + tempSet + reactOp;

            if (!doNothing)
            {
                string[] reactCode = { "wave_" + waveNum + "_per_frame" + perFrameNum + setting + rAttrI };
                perFrameNum++;
                System.IO.File.AppendAllLines(sourceFile, reactCode);
            }
        }
        perFrameNum = 1;
    }
}
