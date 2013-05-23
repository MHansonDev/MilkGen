using System;
using System.Drawing;
using System.Windows.Forms;

public class MilkForm : Form
{

    // Preset Save Panel
    Panel saveBox;
    TextBox presetNameTB;


    // Shape & Wave Tab Controls
    ShapeTabs shapeTabs;
    WaveTabs waveTabs;

    // General Setting Variables
    float zoom;     // Inward/Outward Motion
                    // [0.9 = zoom out 10%]
                    // [1.0 = no zoom]
                    // [1.1 = zoom in 10%]

    float rot;      // Rotation Magnitude
                    // [0.1 = slightly right]
                    // [-0.1 = slightly left]

    float warp;     // Warp Magnitude
                    // [1 = normal warp]
                    // [2 = major warp]

    float warpSpeed;    // Warp Animation Speed
                        // [? ... ?]

    float warpScale;    // Warp Scaling
                        // [? ... ?]

    float warpX, warpY; // Horizontal/Vertical Warp Source
                        // [0 = left]
                        // [0.5 = center]
                        // [1 = right]

    float motionX, motionY; // Horizontal/Vertical Motion Magnitude
                            // [-0.01 = move left 1% per frame]
                            // [0.01 = move right 1% per frame]

    float stretchX, stretchY;   // Horizontal/Vertical Stretch Magnitude
                                // [0.99 = shrink 1%]
                                // [1.01 = stretch 1%]

    int waveMode;   // WaveForm Choice
                    // [0, 1, 2, 3, 4, 5, 6, 7]

    float waveX, waveY;     // Horizontal/Vertical WaveForm Position
                            // [0 = left]
                            // [1 = right]

    float waveScale;    // WaveForm Scale
                        // [0 ...]

    float waveAlpha;    // WaveForm Alpha
                        // [? ... ?]

    float waveSmoothing;    // WaveForm Smoothing
                            // [0 ... 1]

    float waveParam;    // WaveForm Parameter?
                        // [? ... ?]

    float waveAlphaStart;   // Modify WaveForm Alpha Start?
                            // [? ... ?]

    float waveAlphaEnd;     // Modify WaveForm Alpha End
                            // [? ... ?]


    float waveR, waveG, waveB, waveA;   // WaveForm Red/Green/Blue/Opacity
                                        // [0 = no color]
                                        // [1 = full R/G/B/A]

    float oBorderSize;  // Thickness Of Outer Border
                        // [0 ... 0.5]

    float oBR, oBG, oBB, oBA;   // Outer Border Color/Opacity
                                // [0 = no color]
                                // [1 = full R/G/B/A]

    float iBorderSize;  // Thickness Of Inner Border
                        // [0 ... 0.5]

    float iBR, iBG, iBB, iBA;   // Inner Border Color/Opacity
                                // [0 = no color]
                                // [1 = full R/G/B/A]

    int mVector;    // Motion Vector Boolean
                    // [0 = No Vectors]
                    // [1 = Vectors On]

    float mVectorX, mVectorY;     // # Of X/Y Motion Vectors
                                // X: [0 ... 64]
                                // Y: [0 ... 48]

    float mVectorLen;     // Length Of Motion Vectors
                        // [0 = no trail]
                        // [1 = normal]
                        // [2 = double...]

    float mVectorR, mVectorG, mVectorB, mVectorA;   // Motion Vector Color/Opacity
                                                    // [0 = no color]
                                                    // [1 = full R/G/B/A]

    float mVectorOffsetX, mVectorOffsetY;   // Motion Vector X/Y Offset
                                            // [-1 ... 1]

    float decay;    // Controls Eventual Fade To Black
                    // [0 = no fade]
                    // [0.9 = super fade]

    float gamma;    // Controls Brightness
                    // [1 = normal]
                    // [2 = double...]

    float echoZoom; // Controls Size Of Second Graphics Layer
                    // [0 ...]

    float echoAlpha;    // Controls Opacity Of Second Graphics Layer
                        // [0 = transparent]
                        // [0.5 = half-mix]
                        // [1 = opaque]

    int echoOrient;     // Selects Orientation For Second Graphics Layer
                        // [0 = normal]
                        // [1 = flip on]
                        // [2 = flip on]
                        // [3 = flip on both]

    int brighten, darken;   // Brightens/Darkens Parts Of The Image
                            // [0 / 1]

    int invert;     // Invert Colors
                    // [1 = invert colors]
                    // [0 = no invert]

    int solarize;   // Emphasize Midrange Colors
                    // [0 / 1]

    int waveDots;   // WaveForm Dots Boolean
                    // [1 = WaveForm Drawn As Dots]
                    // [0 = WaveForm Drawn As Lines]

    int waveThick;  // WaveForm Double Thick Boolean
                    // [1 = WaveForm Drawn Double Thickness]
                    // [0 = WaveForm Drawn Normal Thickness]

    int waveAdditive;   // WaveForm Drawn Additively
                        // Saturates Image To White
                        // [1 = Additive]
                        // [0 = Non-Additive]

    int WaveBrighten;   // Brightens WaveForm
                        // [1 = All colors scalled till either r/g/b reaches 1]
                        // [0 = Normal]



    public MilkForm()
    {
        // Create Shape & Wave Tabs
        shapeTabs = new ShapeTabs(this);
        waveTabs = new WaveTabs(this);

        // Create New Preset Button
        Button newPreset = new Button();
        newPreset.Text = "New";
        newPreset.Location = new Point(7, 19);
        newPreset.Click += newPresetClicked;

        // Create Preset Selection Button
        Button browseButton = new Button();
        browseButton.Text = "Open";
        browseButton.Location = new Point(7, 45);
        browseButton.Click += browsePresetClicked;

        // Create Preset Save Button
        Button showSave = new Button();
        showSave.Location = new Point(652, 11);
        showSave.Image = new Bitmap("C:\\Users\\User\\Desktop\\Dev\\Milkdrop\\save.jpg");
        showSave.ImageAlign = ContentAlignment.MiddleCenter;
        showSave.Width = 25;
        showSave.Height = 26;
        showSave.FlatStyle = FlatStyle.Flat;
        showSave.FlatAppearance.BorderSize = 0;
        showSave.Click += showSaveBox;

        // Create Save Name Panel
        saveBox = new Panel();
        saveBox.Location = new Point(474, 18);
        saveBox.Size = new Size(165, 70);
        saveBox.BackColor = Color.Black;
        saveBox.ForeColor = Color.White;
        saveBox.BorderStyle = BorderStyle.Fixed3D;
        saveBox.BringToFront();
        saveBox.Visible = false;

        // Create New Preset Name TextBox
        presetNameTB = new TextBox();
        presetNameTB.Location = new Point(30, 10);
        presetNameTB.Text = "test";
        presetNameTB.Parent = saveBox;

        // Create Save Button
        Button save = new Button();
        save.Location = new Point(39, 38);
        save.Text = "Save";
        save.Parent = saveBox;
        save.Click += panelSaveClicked;

        // Create Cancel Quit Button
        Button cancel = new Button();
        cancel.Location = new Point(142, 2);
        cancel.Width = 16;
        cancel.Height = 16;
        cancel.Image = new Bitmap("C:\\Users\\User\\Desktop\\Dev\\Milkdrop\\close.jpg");
        cancel.ImageAlign = ContentAlignment.MiddleCenter;
        cancel.UseVisualStyleBackColor = true;
        cancel.FlatStyle = FlatStyle.Flat;
        cancel.FlatAppearance.BorderSize = 0;
        cancel.Parent = saveBox;
        cancel.Click += cancelSave;

        // Add Preset Selection Controls
        Controls.Add(newPreset);
        Controls.Add(browseButton);
        Controls.Add(showSave);
        Controls.Add(saveBox);


        // Window Properties
        BackColor = Color.Black;
        ForeColor = Color.White;
        Size = new Size(700, 600);


        // Basic settings control group box
        GroupBox buttonBox = new GroupBox();
        buttonBox.Parent = this;
        buttonBox.BackColor = Color.Black;
        buttonBox.ForeColor = Color.White;
        buttonBox.Dock = DockStyle.Top;
        buttonBox.Text = " General Settings ";

        
        // General Setting Value Boxes
        GSettingBox zoomGB = new GSettingBox(this, buttonBox, 90, 20, "zoom", 0, 200, 100);
        GSettingBox rotGB = new GSettingBox(this, buttonBox, 90, 45, "rot", 0, 200, 100);
        GSettingBox warpGB = new GSettingBox(this, buttonBox, 90, 70, "warp", 0, 200, 100);
        GSettingBox decayGB = new GSettingBox(this, buttonBox, 170, 20, "decay", 0, 100, 90);
        GSettingBox gammaGB = new GSettingBox(this, buttonBox, 170, 45, "gamma", 0, 200, 100);
        GSettingBox motionGB = new GSettingBox(this, buttonBox, 170, 70, "motion", 0, 100, 50);
        GSettingBox stretchGB = new GSettingBox(this, buttonBox, 250, 20, "stretch", 0, 200, 100);
        GSettingBox waveGB = new GSettingBox(this, buttonBox, 250, 45, "wave", 0, 50, 0);     


        this.Text = "Milkdrop2 Visualization Generator";
        resetParameters();
    }


    public static void Main()
    {
        // Setup MilkForm
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MilkForm milkForm = new MilkForm();
        milkForm.DoubleBuffered = true;

        try
        {
            Application.Run(milkForm);
        }
        catch (Exception eX)
        {
            Console.WriteLine(eX.Message);
        }
    }

    //////////////////////////////////////////////////////////
    // Rewrite Milkdrop Parameters
    public void reWrite()
    {
        // Initial .milk Parameters
        string[] parameters = {"[preset00]",
                                  "fDecay=" + decay.ToString(),
                                  "fGammaAdj=" + gamma.ToString(),
                                  "nWaveMode=" + waveMode.ToString(),
                                  "bAdditiveWaves=" + waveAdditive.ToString(),
                                  "bWaveDots=" + waveDots.ToString(),
                                  "bWaveThick=" + waveThick.ToString(),
                                  "bDarken=" + darken.ToString(),
                                  "bBrighten=" + brighten.ToString(),
                                  "bInvert=" + invert.ToString(),
                                  "bSolarize=" + solarize.ToString(),
                                  "bMotionVectorsOn=" + mVector.ToString(),
                                  "nMotionVectorsX=" + mVectorX.ToString(),
                                  "nMotionVectorsY=" + mVectorY.ToString(),
                                  "mv_l=" + mVectorLen.ToString(),
                                  "mv_r=" + mVectorR.ToString(),
                                  "mv_g=" + mVectorG.ToString(),
                                  "mv_b=" + mVectorB.ToString(),
                                  "mv_a=" + mVectorA.ToString(),
                                  "fVideoEchoAlpha=" + echoAlpha.ToString(),
                                  "nVideoEchoOrientation=" + echoOrient.ToString(),
                                  "fVideoEchoZoom=" + echoZoom.ToString(),
                                  "fWaveScale=" + waveScale.ToString(),
                                  "fWaveAlpha=" + waveAlpha.ToString(),
                                  "fWaveSmoothing=" + waveSmoothing.ToString(),
                                  "fWaveParam=" + waveParam.ToString(),
                                  "fModWaveAlphaStart=" + waveAlphaStart.ToString(),
                                  "fModWaveAlphaEnd=" + waveAlphaEnd.ToString(),
                                  "fWarpAnimSpeed=" + warpSpeed.ToString(),
                                  "fWarpScale=" + warpScale.ToString(),
                                  "zoomexp=1.000",
                                  "fShader=0.000",
                                  "zoom=" + zoom.ToString(),
                                  "rot=" + rot.ToString(),
                                  "cx=" + warpX.ToString(),
                                  "cy=" + warpY.ToString(),
                                  "dx=" + motionX.ToString(),
                                  "dy=" + motionY.ToString(),
                                  "sx=" + stretchX.ToString(),
                                  "sy=" + stretchY.ToString(),
                                  "warp=" + warp.ToString(),
                                  "sx=" + stretchX.ToString(),
                                  "sy=" + stretchY.ToString() ,
                                  "wave_r=" + waveR.ToString(),
                                  "wave_g=" + waveG.ToString(),
                                  "wave_b=" + waveB.ToString(),
                                  "wave_x=" + waveX.ToString(),
                                  "wave_y=" + waveY.ToString(),
                                  "ob_size=" + oBorderSize.ToString(),
                                  "ob_r=" + oBR.ToString(),
                                  "ob_g=" + oBG.ToString(),
                                  "ob_b=" + oBB.ToString(),
                                  "ob_a=" + oBA.ToString(),
                                  "ib_size=" + iBorderSize.ToString(),
                                  "ib_r=" + iBR.ToString(),
                                  "ib_g=" + iBG.ToString(),
                                  "ib_b=" + iBB.ToString(),
                                  "ib_a=" + iBA.ToString()};

        // Write Parameters To Active Preset
        string sourcePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        string[] files = System.IO.Directory.GetFiles(sourcePath);
        string fileName = System.IO.Path.GetFileName(files[0]);
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        System.IO.File.WriteAllLines(sourceFile, parameters);
        shapeTabs.reWrite();
        waveTabs.reWrite();
    }

    // Reset Parameter Values For New Preset
    public void resetParameters()
    {
        // Set General Preset Setting Values
        zoom = (float)0.0;
        rot = (float)0.0;
        decay = (float)0.9;
        warp = (float)0.01;
        warpSpeed = (float)1.0;
        warpScale = (float)1.33;
        warpX = (float)0.5;
        warpY = (float)0.5;
        motionX = (float)0.0;
        motionY = (float)0.0;
        stretchX = (float)1.0;
        stretchY = (float)1.0;
        gamma = (float)1.0;
        echoZoom = (float)1.0;
        echoAlpha = (float)0.0;
        echoOrient = 3;
        darken = 0;
        brighten = 0;
        solarize = 0;
        invert = 0;

        // Waveform Setting Values
        waveMode = 7;
        waveScale = (float)0.0;
        waveAlpha = (float)0.0;
        waveAlphaEnd = (float)0.0;
        waveAlphaStart = (float)0.0;
        waveParam = (float)0.0;
        waveX = (float)0.5;
        waveY = (float)0.5;
        waveR = (float)0.0;
        waveG = (float)1.0;
        waveB = (float)0.0;
        waveA = (float)1.0;
        waveDots = 0;
        waveThick = 0;
        waveAdditive = 1;
        waveSmoothing = 0;
        
        // Motion Vector Setting Values
        mVector = 0;
        mVectorX = (float)0.0;
        mVectorY = (float)0.0;
        mVectorLen = (float)0.9;
        mVectorOffsetX = (float)0.0;
        mVectorOffsetY = (float)0.0;
        mVectorR = (float)0.0;
        mVectorG = (float)0.0;
        mVectorB = (float)1.0;
        mVectorA = (float)1.0;

        // Border Setting Values
        oBorderSize = (float)0.0;
        iBorderSize = (float)0.0;
        oBR = (float)0.0;
        oBG = (float)1.0;
        oBB = (float)0.0;
        oBA = (float)1.0;
        iBR = (float)1.0;
        iBG = (float)0.0;
        iBB = (float)0.0;
        iBA = (float)1.0;
    }


    // Change General Setting Value
    public void changeVal(string setting, float newVal)
    {
        if (setting.Contains("zoom"))
            zoom = newVal;
        else if (setting.Contains("rot"))
            rot = newVal;
        else if (setting.Contains("warp"))
            warp = newVal;
        else if (setting.Contains("warpSpd"))
            warpSpeed = newVal;
        else if (setting.Contains("warpMag"))
            warpScale = newVal;
        else if (setting.Contains("warpX"))
            warpX = newVal;
        else if (setting.Contains("warpY"))
            warpY = newVal;
        else if (setting.Contains("decay"))
            decay = newVal;
        else if (setting.Contains("gamma"))
            gamma = newVal;
        else if (setting.Contains("motionX"))
            motionX = newVal;
        else if (setting.Contains("motionY"))
            motionY = newVal;
        else if (setting.Contains("stretchX"))
            stretchX = newVal;
        else if (setting.Contains("stretchY"))
            stretchY = newVal;
        else if (setting.Contains("Mode"))
            waveMode = (int)newVal;
        else if (setting.Contains("WaveX"))
            waveX = newVal;
        else if (setting.Contains("WaveY"))
            waveY = newVal;
        else if (setting.Contains("WaveSpeed"))
            waveAlpha = newVal;
        else if (setting.Contains("WaveScale"))
            waveScale = newVal;
        else if (setting.Contains("WaveR"))
            waveR = newVal;
        else if (setting.Contains("WaveG"))
            waveG = newVal;
        else if (setting.Contains("WaveB"))
            waveB = newVal;
        else if (setting.Contains("WaveSmooth"))
            waveSmoothing = newVal;
        else if (setting.Contains("WaveStart"))
            waveAlphaStart = newVal;
        else if (setting.Contains("WaveEnd"))
            waveAlphaEnd = newVal;
        else if (setting.Contains("WaveParam"))
            waveParam = newVal;
        reWrite();
    }


    // Replace Active Preset With A New Preset
    public void newPresetClicked(object sender, EventArgs e)
    {
        deleteContents();
        string presetPath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        System.IO.File.Create(presetPath + "preset.milk").Close();
    }

    // Replace Active Preset With Chosen Preset
    public void browsePresetClicked(object sender, EventArgs e)
    {
        OpenFileDialog browseDialog = new OpenFileDialog();
        browseDialog.Title = "Browse Milkdrop Preset";
        browseDialog.Filter = "MILK Files|*.milk";
        string savePath = @"C:\Users\User\Desktop\Dev\milkdrop\saved\";
        string activePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        browseDialog.InitialDirectory = savePath;
        browseDialog.ShowHelp = true;
        if (browseDialog.ShowDialog() == DialogResult.OK)
        {
            string fileToOpen = browseDialog.FileName;
            System.IO.FileInfo File = new System.IO.FileInfo(browseDialog.FileName);
            string sourceFile = fileToOpen;
            string destFile = activePath + "preset.milk";

            if (System.IO.File.Exists(destFile))
                System.IO.File.Delete(destFile);
            System.IO.File.Copy(sourceFile, destFile);
        }
    }

    // Copy Old Preset To Saved Directory
    public void copyContents()
    {
        string sourcePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        string destPath = @"C:\Users\User\Desktop\Dev\milkdrop\saved\";
        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);

            // Move Saved File To Saved Directory
            foreach (string s in files)
            {
                string fileName = System.IO.Path.GetFileName(s);
                string sourceFile = sourcePath + fileName;
                string destFile = destPath + presetNameTB.Text + ".milk";
                if (System.IO.File.Exists(destFile))
                    System.IO.File.Delete(destFile);
                System.IO.File.Copy(sourceFile, destFile);
            }
        }
    }

    // Delete Presets From Active Directory
    public void deleteContents()
    {
        string activePath = @"C:\Users\User\Desktop\Dev\milkdrop\active\";
        string presetPath = activePath + presetNameTB.Text + ".milk";
        // If File Exists In Active Directory -> Delete
        if (System.IO.File.Exists(presetPath))
            System.IO.File.Delete(presetPath);
    }

    // Show Save Panel
    public void showSaveBox(object sender, EventArgs e)
    {
        saveBox.Visible = true;
    }

    // Save Presets From Active To Saved Directory
    public void panelSaveClicked(object sender, EventArgs e)
    {
        copyContents();
        saveBox.Visible = false;
    }

    public void cancelSave(object sender, EventArgs e)
    {
        saveBox.Visible = false;
    }

}