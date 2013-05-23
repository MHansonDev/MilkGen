using System;
using System.Drawing;
using System.Windows.Forms;


public class Shape
{
    // Parent Form
    public MilkForm mForm;

    // Shape Tabs
    public TabPage tab;
    public ShapeTabs tabControl;

    // Shape Number
    public string shapeNum;

    // Enable Checkbox / Boolean
    public CheckBox enable;
    public bool enabled;

    ////////////////////////////
    // General Shape Settings //
    ////////////////////////////
    //
    //
    ////////////////////////////
    //
    // Settings Variable:
    public Setting[] settings;
    public int perFrameNum;


    ////////////////////////////
    //
    // SettingStrip:
    //
    // X & Y POSITION -
    public SettingStrip xSS, ySS;

    // SHAPE SIZE - 
    public SettingStrip sizeSS;

    // SHAPE SIDES - 
    public SettingStrip sidesSS;

    // SHAPE ANGLE - 
    public SettingStrip angleSS;

    // INNER RED - 
    public SettingStrip iRedSS;

    // OUTER RED - 
    public SettingStrip oRedSS;

    // INNER GREEN - 
    public SettingStrip iGreenSS;

    // OUTER GREEN - 
    public SettingStrip oGreenSS;

    // INNER BLUE - 
    public SettingStrip iBlueSS;

    // OUTER BLUE - 
    public SettingStrip oBlueSS;

    // BORDER RED - 
    public SettingStrip bRedSS;

    // BORDER GREEN - 
    public SettingStrip bGreenSS;

    // BORDER BLUE - 
    public SettingStrip bBlueSS;

    // BORDER OPACITY - 
    public SettingStrip bOpacitySS;

    // INNER OPACITY - 
    public SettingStrip iOpacitySS;

    // OUTER OPACITY - 
    public SettingStrip oOpacitySS;


    /////////////////////////////


    // Constructor
    // Parameters: Shape Tabs and Main Form
    public Shape(MilkForm m, TabPage t, ShapeTabs tC, string num, float x, float y)
    {
        tab = t;
        mForm = m;
        tabControl = tC;
        shapeNum = num;

        perFrameNum = 1;

        // Create Settings
        settings = new Setting[20];

        // X Position Setting
        settings[0] = new Setting("x", x, 10);
        // Y Position Setting
        settings[1] = new Setting("y", y, 10);
        // Sides Setting
        settings[2] = new Setting("sides", 3, (float)0.25);
        // Size Setting
        settings[3] = new Setting("rad", (float)0.2, 10);
        // Angle Setting
        settings[4] = new Setting("ang", 0, (float)0.25);
        // Inner Red Setting
        settings[5] = new Setting("r", 0, 10);
        // Outer Red Setting
        settings[6] = new Setting("r2", 0, 10);
        // Inner Green Setting
        settings[7] = new Setting("g", 0, 10);
        // Outer Green Setting
        settings[8] = new Setting("g2", 0, 10);
        // Inner Blue Setting
        settings[9] = new Setting("b", 1, 10);
        // Outer Blue Setting
        settings[10] = new Setting("b2", 1, 10);
        // Border Red Setting
        settings[11] = new Setting("border_r", 0, 10);
        // Border Green Setting
        settings[12] = new Setting("border_g", 0, 10);
        // Border Blue Setting
        settings[13] = new Setting("border_b", 0, 10);
        // Border Opacity Setting
        settings[14] = new Setting("border_a", 0, 10);
        // Inner Opacity Setting
        settings[15] = new Setting("a", 0, 10);
        // Outer Opacity Setting
        settings[16] = new Setting("a2", 0, 10);
        // Border Thick Setting
        settings[17] = new Setting("thick", 0, 0);
        // Additive Setting
        settings[18] = new Setting("additive", 0, 0);
        // Textured Setting
        settings[19] = new Setting("textured", 0, 0);


        // Shape Font;
        Font shapeFont = new Font("Arial", 10, FontStyle.Bold);

        // Create Enable CheckBox
        enable = new CheckBox();
        enabled = false;
        enable.Location = new Point(10, 4);
        enable.Text = "Enabled";
        enable.Parent = tab;
        enable.Font = shapeFont;
        enable.CheckedChanged += new EventHandler(enableChk);

        // Create SettingStrip For Various Settings
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        //
        // X Position SettingStrip
        Separator sep0 = new Separator(new Point(0, 35), "tab", tab);
        xSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 55), "X Position", 0, 100, 50, 0);
        Separator sep1 = new Separator(new Point(0, 95), "tab", tab);

        // Y Position SettingStrip
        ySS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 115), "Y Position", 0, 100, 50, 1);
        Separator sep2 = new Separator(new Point(0, 155), "tab", tab);

        // Sides SettingStrip
        sidesSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 175), "Sides", 3, 40, 3, 2);
        Separator sep3 = new Separator(new Point(0, 215), "tab", tab);

        // Size SettingStrip
        sizeSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 235), "Size", 0, 100, 20, 3);
        Separator sep4 = new Separator(new Point(0, 275), "tab", tab);

        // Angle SettingStrip
        angleSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 295), "Angle", 0, 628, 0, 4);
        Separator sep5 = new Separator(new Point(0, 335), "tab", tab);

        // Inner Red SettingStrip
        iRedSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 355), "Inner Red", 0, 100, 0, 5);
        Separator sep6 = new Separator(new Point(0, 395), "tab", tab);

        // Outer Red SettingStrip
        oRedSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 415), "Outer Red", 0, 100, 0, 6);
        Separator sep7 = new Separator(new Point(0, 455), "tab", tab);

        // Inner Green SettingStrip
        iGreenSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 475), "Inner Green", 0, 100, 0, 7);
        Separator sep8 = new Separator(new Point(0, 515), "tab", tab);

        // Outer Green SettingStrip
        oGreenSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 535), "Outer Green", 0, 100, 0, 8);
        Separator sep9 = new Separator(new Point(0, 575), "tab", tab);

        // Inner Blue SettingStrip
        iBlueSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 595), "Inner Blue", 0, 100, 100, 9);
        Separator sep10 = new Separator(new Point(0, 635), "tab", tab);

        // Outer Blue SettingStrip
        oBlueSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 655), "Outer Blue", 0, 100, 100, 10);
        Separator sep11 = new Separator(new Point(0, 695), "tab", tab);

        // Border Red SettingStrip
        bRedSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 715), "Border Red", 0, 100, 0, 11);
        Separator sep12 = new Separator(new Point(0, 755), "tab", tab);

        // Border Green SettingStrip
        bGreenSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 775), "Border Green", 0, 100, 0, 12);
        Separator sep13 = new Separator(new Point(0, 815), "tab", tab);

        // Border Blue SettingStrip
        bBlueSS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 835), "Border Blue", 0, 100, 100, 13);
        Separator sep14 = new Separator(new Point(0, 875), "tab", tab);

        // Border Opacity SettingStrip
        bOpacitySS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 895), "Border Opacity", 0, 100, 0, 14);
        Separator sep15 = new Separator(new Point(0, 935), "tab", tab);

        // Inner Opacity SettingStrip
        iOpacitySS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 955), "Inner Opacity", 0, 100, 100, 15);
        Separator sep16 = new Separator(new Point(0, 995), "tab", tab);

        oOpacitySS = new SettingStrip(mForm, tab, 0, tC, null, this, null, new Point(100, 1015), "Outer Opacity", 0, 100, 100, 16);
    }


    //////////////////////////////////////////////
    // Return The Value Of The Specified Setting
    public float getVal(string setting)
    {
        if (setting.Contains("X"))
            return settings[0].getValue();
        else if (setting.Contains("Y"))
            return settings[1].getValue();
        else if (setting.Contains("Sides"))
            return settings[2].getValue();
        else if (setting.Contains("Size"))
            return settings[3].getValue();
        else if (setting.Contains("Angle"))
            return settings[4].getValue();
        else if (setting.Contains("Inner Red"))
            return settings[5].getValue();
        else if (setting.Contains("Outer Red"))
            return settings[6].getValue();
        else if (setting.Contains("Inner Green"))
            return settings[7].getValue();
        else if (setting.Contains("Outer Green"))
            return settings[8].getValue();
        else if (setting.Contains("Inner Blue"))
            return settings[9].getValue();
        else if (setting.Contains("Outer Blue"))
            return settings[10].getValue();
        else if (setting.Contains("Border Red"))
            return settings[11].getValue();
        else if (setting.Contains("Border Green"))
            return settings[12].getValue();
        else if (setting.Contains("Border Blue"))
            return settings[13].getValue();
        else if (setting.Contains("Border Opacity"))
            return settings[14].getValue();
        else if (setting.Contains("Inner Opacity"))
            return settings[15].getValue();
        else if (setting.Contains("Outer Opacity"))
            return settings[16].getValue();
        else
            return 0;
    }


    //////////////////////////////////////
    // Changes A Specified Setting's Value
    public void changeVal(int sIndx, object value)
    {
        if (settings[sIndx].getName().Contains("sides"))
            settings[sIndx].changeVal((int)value);
        else
            settings[sIndx].changeVal((float)value);
    }


    ///////////////////////////////////////////////////////
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


    ////////////////////////////////
    // Return Enabled Boolean
    public bool isEnabled()
    {
        return enabled;
    }

    ///////////////////////////////
    // Set per_frame Number
    public void setPNum(int val)
    {
        perFrameNum = val;
    }

    ////////////////////////////////
    // Write Shape Parameters
    public void write()
    {
        // Shape Parameters
        string sName = "shapecode_" + shapeNum + "_";
        string[] parameters = {sName + "enabled=1",
                               sName + "x=" + getVal("X Position"),
                               sName + "y=" + getVal("Y Position"),
                               sName + "sides=" + getVal("Sides"),
                               sName + "rad=" + getVal("Size"),
                               sName + "ang=" + getVal("Angle"),
                               sName + "r=" + getVal("Inner Red"),
                               sName + "r2=" + getVal("Outer Red"),
                               sName + "g=" + getVal("Inner Green"),
                               sName + "g2=" + getVal("Outer Green"),
                               sName + "b=" + getVal("Inner Blue"),
                               sName + "b2=" + getVal("Outer Blue"),
                               sName + "border_r=" + getVal("Border Red"),
                               sName + "border_g=" + getVal("Border Green"),
                               sName + "border_b=" + getVal("Border Blue")
                              };

        // Write Parameters To .milk File
        string sourcePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        string[] files = System.IO.Directory.GetFiles(sourcePath);
        string fileName = System.IO.Path.GetFileName(files[0]);
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        System.IO.File.AppendAllLines(sourceFile, parameters);

        // For Each Setting:
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
                string[] reactCode = { "shape_" + shapeNum + "_per_frame" + perFrameNum + setting + rAttrI };
                perFrameNum++;
                System.IO.File.AppendAllLines(sourceFile, reactCode);
            }
        }
        perFrameNum = 1;
    }
}
