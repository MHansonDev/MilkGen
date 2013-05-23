using System;
using System.Drawing;
using System.Windows.Forms;

public class GSettingBox
{
    MilkForm mForm;
    Panel panel;
    Button settingButton;
    Label settingLabel;
    TrackBar settingBar;
    Label valueLabel;

    // Warp Variables
    TrackBar warpXTB, warpYTB, warpScaleTB, warpSpeedTB;
    Label warpXValL, warpYValL, warpScaleValL, warpSpeedValL;

    // Motion Variables
    TrackBar mYTB;
    Label mXValL, mYValL;

    // Stretch Variables
    TrackBar sYTB;
    Label sXValL, sYValL;

    // Wave Variables
    TrackBar waveXTB, waveYTB, waveScaleTB, waveSpeedTB, waveRTB, waveGTB, waveBTB;
    TrackBar waveSmoothTB, waveStartTB, waveEndTB, waveParamTB;

    Label waveXValL, waveYValL, waveScaleValL, waveSpeedValL, waveRValL, waveGValL, waveBValL;
    Label waveSmoothValL, waveStartValL, waveEndValL, waveParamValL;


    public GSettingBox(MilkForm m, GroupBox bb, int x, int y, string name, int min, int max, int val)
    {
        // Set Main Form
        mForm = m;

        // Create Setting Modification Button
        settingButton = new Button();
        settingButton.Location = new Point(x, y);
        settingButton.Text = name;
        settingButton.Parent = bb;
        settingButton.Click += showBox;

        // Create General Setting Modification Panel
        panel = new Panel();
        panel.Size = new Size(200, 70);
        panel.Location = new Point(230, 17);
        panel.BackColor = Color.White;
        panel.ForeColor = Color.Black;
        panel.BorderStyle = BorderStyle.Fixed3D;
        panel.Parent = mForm;
        panel.Visible = false;
        panel.BringToFront();

        // Set Panel Font
        Font pFont = new Font("Arial", 10, FontStyle.Bold);

        // Add Setting Label To Panel
        settingLabel = new Label();
        settingLabel.Text = name;
        settingLabel.Font = pFont;
        settingLabel.Location = new Point(18, 7);
        settingLabel.Parent = panel;


        // Add TrackBar To Panel
        settingBar = new TrackBar();
        settingBar.Orientation = Orientation.Horizontal;
        settingBar.Size = new Size(147, 16);
        settingBar.Location = new Point(14, 40);
        settingBar.TickStyle = TickStyle.None;
        settingBar.BackColor = Color.White;
        settingBar.ForeColor = Color.Black;
        settingBar.TickFrequency = 10;
        settingBar.Minimum = min;
        settingBar.Maximum = max;
        settingBar.Value = val;
        settingBar.Parent = panel;
        settingBar.ValueChanged += new EventHandler(settingChange);


        // Add Value TextBox
        valueLabel = new Label();
        valueLabel.Location = new Point(160, 40);
        valueLabel.Text = ((float)val/(float)100).ToString();
        valueLabel.Font = pFont;
        valueLabel.Parent = panel;


        // Add React Button


        
        // Add Quit Button
        Button quitButton = new Button();
        quitButton.Location = new Point(178, 6);
        quitButton.Size = new Size(16, 16);
        quitButton.Image = new Bitmap("C:\\Users\\User\\Desktop\\Dev\\Milkdrop\\close2.jpg");
        quitButton.ImageAlign = ContentAlignment.MiddleCenter;
        quitButton.UseVisualStyleBackColor = true;
        quitButton.FlatAppearance.BorderSize = 0;
        quitButton.Parent = panel;
        quitButton.Click += exitPanel;


        // Modify GSettingBox For "Warp" Setting
        if (settingButton.Text.Contains("warp"))
        {
            // Reset Panel Size
            panel.Size = new Size(330, 170);
            // Reset Main TrackBar Values
            settingBar.Orientation = Orientation.Vertical;
            settingBar.Height = 100;
            settingBar.Width = 5;
            settingBar.Location = new Point(25, 25);
            settingBar.BringToFront();
            // Relocate Main Setting Label
            settingLabel.Size = new Size(50, 25);
            // Relocate Main Value Label
            valueLabel.Location = new Point(23, 135);
            valueLabel.Size = new Size(28, 25);
            // Relocate Quit Button
            quitButton.Location = new Point(306, 6);

            // Create Warp X Label
            Label warpXLabel = new Label();
            warpXLabel.Location = new Point(93, 8);
            warpXLabel.Text = "X";
            warpXLabel.Size = new Size(19, 25);
            warpXLabel.Parent = panel;

            // Create Warp X TrackBar 
            warpXTB = new TrackBar();
            warpXTB.Location = new Point(91, 25);
            warpXTB.Height = 100;
            warpXTB.Orientation = Orientation.Vertical;
            warpXTB.TickStyle = TickStyle.None;
            warpXTB.TickFrequency = 10;
            warpXTB.Minimum = 0;
            warpXTB.Maximum = 100;
            warpXTB.Value = 50;
            warpXTB.ValueChanged += new EventHandler(xChanged);
            warpXTB.Parent = panel;

            // Create Warp X Value Label
            warpXValL = new Label();
            warpXValL.Location = new Point(90, 135);
            warpXValL.Size = new Size(25, 25);
            warpXValL.Text = "0.5";
            warpXValL.Parent = panel;

            // Create Warp Y Position Label
            Label warpYLabel = new Label();
            warpYLabel.Location = new Point(148, 8);
            warpYLabel.Text = "Y";
            warpYLabel.Size = new Size(19, 25);
            warpYLabel.Parent = panel;

            // Create Warp Y TrackBar
            warpYTB = new TrackBar();
            warpYTB.Location = new Point(146, 25);
            warpYTB.Height = 100;
            warpYTB.Orientation = Orientation.Vertical;
            warpYTB.TickStyle = TickStyle.None;
            warpYTB.TickFrequency = 10;
            warpYTB.Minimum = 0;
            warpYTB.Maximum = 100;
            warpYTB.Value = 50;
            warpYTB.ValueChanged += new EventHandler(yChanged);
            warpYTB.Parent = panel;

            // Create Warp Y Value Label
            warpYValL = new Label();
            warpYValL.Location = new Point(146, 135);
            warpYValL.Size = new Size(25, 25);
            warpYValL.Text = "0.5";
            warpYValL.Parent = panel;

            // Create Warp Speed Label
            Label warpSpeedLabel = new Label();
            warpSpeedLabel.Location = new Point(193, 8);
            warpSpeedLabel.Text = "Speed";
            warpSpeedLabel.Size = new Size(40, 25);
            warpSpeedLabel.Parent = panel;

            // Create Warp Speed TrackBar
            warpSpeedTB = new TrackBar();
            warpSpeedTB.Location = new Point(201, 25);
            warpSpeedTB.Height = 100;
            warpSpeedTB.Orientation = Orientation.Vertical;
            warpSpeedTB.TickStyle = TickStyle.None;
            warpSpeedTB.TickFrequency = 10;
            warpSpeedTB.Minimum = 0;
            warpSpeedTB.Maximum = 200;
            warpSpeedTB.Value = 100;
            warpSpeedTB.ValueChanged += new EventHandler(speedChanged);
            warpSpeedTB.Parent = panel;

            // Create Warp Speed Value Label
            warpSpeedValL = new Label();
            warpSpeedValL.Location = new Point(200, 135);
            warpSpeedValL.Size = new Size(25, 25);
            warpSpeedValL.Text = ("1.0");
            warpSpeedValL.Parent = panel;

            // Create Warp Scale Label
            Label warpScaleLabel = new Label();
            warpScaleLabel.Location = new Point(250, 8);
            warpScaleLabel.Text = "Scale";
            warpScaleLabel.Size = new Size(40, 25);
            warpScaleLabel.Parent = panel;

            // Create Warp Scale TrackBar
            warpScaleTB = new TrackBar();
            warpScaleTB.Location = new Point(255, 25);
            warpScaleTB.Height = 100;
            warpScaleTB.Orientation = Orientation.Vertical;
            warpScaleTB.TickStyle = TickStyle.None;
            warpScaleTB.TickFrequency = 10;
            warpScaleTB.Minimum = 0;
            warpScaleTB.Maximum = 200;
            warpScaleTB.Value = 100;
            warpScaleTB.ValueChanged += new EventHandler(scaleChanged);
            warpScaleTB.Parent = panel;

            // Create Warp Scale Value Label
            warpScaleValL = new Label();
            warpScaleValL.Location = new Point(254, 135);
            warpScaleValL.Size = new Size(25, 25);
            warpScaleValL.Text = "1.0";
            warpScaleValL.Parent = panel;
        }

        // Modify GSettingBox For "Motion" Setting
        if (settingButton.Text.Contains("motion"))
        {
            // Resize Main Panel
            panel.Size = new Size(220, 170);
            // Hide Old Setting Label
            settingLabel.Visible = false;
            valueLabel.Visible = false;
            // Relocate Quit Button
            quitButton.Location = new Point(196, 6);

            // Create New Motion X Label
            Label mXL = new Label();
            mXL.Location = new Point(15, 13);
            mXL.Text = "Motion X";
            mXL.Size = new Size(55, 25);
            mXL.Parent = panel;

            // Modify Motion X TrackBar
            settingBar.Orientation = Orientation.Vertical;
            settingBar.Location = new Point(24, 30);
            settingBar.Height = 100;
            settingBar.Width = 5;
            settingBar.ValueChanged += new EventHandler(mXChanged);

            // Create Motion X Value Label
            mXValL = new Label();
            mXValL.Location = new Point(23, 135);
            mXValL.Text = "0.0";
            mXValL.Size = new Size(25, 25);
            mXValL.Parent = panel;

            // Create New Motion Y Label
            Label mYL = new Label();
            mYL.Location = new Point(101, 13);
            mYL.Text = "Motion Y";
            mYL.Size = new Size(55, 25);
            mYL.Parent = panel;

            // Create Motion Y TrackBar
            mYTB = new TrackBar();
            mYTB.Location = new Point(109, 35);
            mYTB.Height = 100;
            mYTB.Orientation = Orientation.Vertical;
            mYTB.TickStyle = TickStyle.None;
            mYTB.TickFrequency = 10;
            mYTB.Minimum = 0;
            mYTB.Maximum = 200;
            mYTB.Value = 100;
            mYTB.ValueChanged += new EventHandler(mYChanged);
            mYTB.Parent = panel;

            // Create Motion Y Value Label
            mYValL = new Label();
            mYValL.Location = new Point(108, 135);
            mYValL.Text = "0.0";
            mYValL.Size = new Size(25, 25);
            mYValL.Parent = panel;
        }


        // Modify GSettingBox For "Stretch" Settingz
        if (settingButton.Text.Contains("stretch"))
        {
            // Resize Main Panel
            panel.Size = new Size(220, 170);
            // Hide Old Setting Label
            settingLabel.Visible = false;
            valueLabel.Visible = false;
            // Relocate Quit Button
            quitButton.Location = new Point(196, 6);

            // Create New Stretch X Label
            Label sXL = new Label();
            sXL.Location = new Point(15, 13);
            sXL.Text = "stretch X";
            sXL.Size = new Size(55, 25);
            sXL.Parent = panel;

            // Modify Stretch X TrackBar
            settingBar.Orientation = Orientation.Vertical;
            settingBar.Location = new Point(24, 30);
            settingBar.Height = 100;
            settingBar.Width = 5;
            settingBar.ValueChanged += new EventHandler(sXChanged);

            // Create Stretch X Value Label
            sXValL = new Label();
            sXValL.Location = new Point(23, 135);
            sXValL.Text = "1.0";
            sXValL.Size = new Size(25, 25);
            sXValL.Parent = panel;

            // Create New Stretch Y Label
            Label sYL = new Label();
            sYL.Location = new Point(101, 13);
            sYL.Text = "stretch Y";
            sYL.Size = new Size(55, 25);
            sYL.Parent = panel;

            // Create Motion Y TrackBar
            sYTB = new TrackBar();
            sYTB.Location = new Point(109, 35);
            sYTB.Height = 100;
            sYTB.Orientation = Orientation.Vertical;
            sYTB.TickStyle = TickStyle.None;
            sYTB.TickFrequency = 10;
            sYTB.Minimum = 0;
            sYTB.Maximum = 200;
            sYTB.Value = 100;
            sYTB.ValueChanged += new EventHandler(sYChanged);
            sYTB.Parent = panel;

            // Create Motion Y Value Label
            sYValL = new Label();
            sYValL.Location = new Point(108, 135);
            sYValL.Text = "1.0";
            sYValL.Size = new Size(25, 25);
            sYValL.Parent = panel;
        }


        //##################################################################################

        // Modify GSettingBox For "Wave" Setting
        if (settingButton.Text.Contains("wave"))
        {
            // Reset Panel Size
            panel.Size = new Size(423, 325);
            // Reset Main TrackBar Values
            settingBar.Orientation = Orientation.Vertical;
            settingBar.Height = 100;
            settingBar.Width = 5;
            settingBar.Minimum = 0;
            settingBar.Maximum = 7;
            settingBar.Value = 0;
            settingBar.Location = new Point(25, 25);
            settingBar.BringToFront();
            settingBar.ValueChanged += new EventHandler(modeWaveChanged);
            // Relocate Main Setting Label
            settingLabel.Size = new Size(50, 25);
            settingLabel.Text = "Mode";
            // Relocate Main Value Label
            valueLabel.Location = new Point(25, 135);
            valueLabel.Size = new Size(28, 25);
            // Relocate Quit Button
            quitButton.Location = new Point(400, 6);

            // Create Wave X Label
            Label waveXLabel = new Label();
            waveXLabel.Location = new Point(93, 8);
            waveXLabel.Text = "X";
            waveXLabel.Size = new Size(19, 25);
            waveXLabel.Parent = panel;

            // Create Wave X TrackBar 
            waveXTB = new TrackBar();
            waveXTB.Location = new Point(91, 25);
            waveXTB.Height = 100;
            waveXTB.Orientation = Orientation.Vertical;
            waveXTB.TickStyle = TickStyle.None;
            waveXTB.TickFrequency = 10;
            waveXTB.Minimum = 0;
            waveXTB.Maximum = 100;
            waveXTB.Value = 50;
            waveXTB.ValueChanged += new EventHandler(xWaveChanged);
            waveXTB.Parent = panel;

            // Create Wave X Value Label
            waveXValL = new Label();
            waveXValL.Location = new Point(90, 135);
            waveXValL.Size = new Size(25, 25);
            waveXValL.Text = "0.5";
            waveXValL.Parent = panel;

            // Create Wave Y Position Label
            Label waveYLabel = new Label();
            waveYLabel.Location = new Point(148, 8);
            waveYLabel.Text = "Y";
            waveYLabel.Size = new Size(19, 25);
            waveYLabel.Parent = panel;

            // Create Wave Y TrackBar
            waveYTB = new TrackBar();
            waveYTB.Location = new Point(146, 25);
            waveYTB.Height = 100;
            waveYTB.Orientation = Orientation.Vertical;
            waveYTB.TickStyle = TickStyle.None;
            waveYTB.TickFrequency = 10;
            waveYTB.Minimum = 0;
            waveYTB.Maximum = 100;
            waveYTB.Value = 50;
            waveYTB.ValueChanged += new EventHandler(yWaveChanged);
            waveYTB.Parent = panel;

            // Create Wave Y Value Label
            waveYValL = new Label();
            waveYValL.Location = new Point(146, 135);
            waveYValL.Size = new Size(25, 25);
            waveYValL.Text = "0.5";
            waveYValL.Parent = panel;

            // Create Wave Speed Label
            Label waveSpeedLabel = new Label();
            waveSpeedLabel.Location = new Point(193, 8);
            waveSpeedLabel.Text = "Speed";
            waveSpeedLabel.Size = new Size(40, 25);
            waveSpeedLabel.Parent = panel;

            // Create Wave Speed TrackBar
            waveSpeedTB = new TrackBar();
            waveSpeedTB.Location = new Point(201, 25);
            waveSpeedTB.Height = 100;
            waveSpeedTB.Orientation = Orientation.Vertical;
            waveSpeedTB.TickStyle = TickStyle.None;
            waveSpeedTB.TickFrequency = 10;
            waveSpeedTB.Minimum = 0;
            waveSpeedTB.Maximum = 200;
            waveSpeedTB.Value = 100;
            waveSpeedTB.ValueChanged += new EventHandler(speedWaveChanged);
            waveSpeedTB.Parent = panel;

            // Create Wave Speed Value Label
            waveSpeedValL = new Label();
            waveSpeedValL.Location = new Point(200, 135);
            waveSpeedValL.Size = new Size(25, 25);
            waveSpeedValL.Text = ("1.0");
            waveSpeedValL.Parent = panel;

            // Create Wave Scale Label
            Label waveScaleLabel = new Label();
            waveScaleLabel.Location = new Point(250, 8);
            waveScaleLabel.Text = "Scale";
            waveScaleLabel.Size = new Size(40, 25);
            waveScaleLabel.Parent = panel;

            // Create Wave Scale TrackBar
            waveScaleTB = new TrackBar();
            waveScaleTB.Location = new Point(255, 25);
            waveScaleTB.Height = 100;
            waveScaleTB.Orientation = Orientation.Vertical;
            waveScaleTB.TickStyle = TickStyle.None;
            waveScaleTB.TickFrequency = 10;
            waveScaleTB.Minimum = 0;
            waveScaleTB.Maximum = 200;
            waveScaleTB.Value = 100;
            waveScaleTB.ValueChanged += new EventHandler(scaleWaveChanged);
            waveScaleTB.Parent = panel;

            // Create Wave Scale Value Label
            waveScaleValL = new Label();
            waveScaleValL.Location = new Point(254, 135);
            waveScaleValL.Size = new Size(25, 25);
            waveScaleValL.Text = "1.0";
            waveScaleValL.Parent = panel;

            // Create Wave Red Label
            Label waveRL = new Label();
            waveRL.Location = new Point(297, 8);
            waveRL.Text = "Red";
            waveRL.Size = new Size(40, 25);
            waveRL.Parent = panel;

            // Create Wave Red TrackBar;
            waveRTB = new TrackBar();
            waveRTB.Location = new Point(305, 25);
            waveRTB.Height = 100;
            waveRTB.Orientation = Orientation.Vertical;
            waveRTB.TickStyle = TickStyle.None;
            waveRTB.TickFrequency = 10;
            waveRTB.Minimum = 0;
            waveRTB.Maximum = 100;
            waveRTB.Value = 0;
            waveRTB.ValueChanged += new EventHandler(waveRChanged);
            waveRTB.Parent = panel;

            // Create Wave Red Value Label
            waveRValL = new Label();
            waveRValL.Location = new Point(304, 135);
            waveRValL.Size = new Size(25, 25);
            waveRValL.Text = "0.0";
            waveRValL.Parent = panel;

            // Create Wave Green Label
            Label waveGL = new Label();
            waveGL.Location = new Point(348, 8);
            waveGL.Text = "Green";
            waveGL.Size = new Size(45, 25);
            waveGL.Parent = panel;

            // Create Wave Green TrackBar
            waveGTB = new TrackBar();
            waveGTB.Location = new Point(360, 25);
            waveGTB.Height = 100;
            waveGTB.Orientation = Orientation.Vertical;
            waveGTB.TickStyle = TickStyle.None;
            waveGTB.Minimum = 0;
            waveGTB.Maximum = 100;
            waveGTB.Value = 100;
            waveGTB.ValueChanged += new EventHandler(waveGChanged);
            waveGTB.Parent = panel;

            // Create Wave Green Value Label
            waveGValL = new Label();
            waveGValL.Location = new Point(357, 135);
            waveGValL.Size = new Size(25, 25);
            waveGValL.Text = "1.0";
            waveGValL.Parent = panel;

            // Create Wave Blue Label
            Label waveBL = new Label();
            waveBL.Location = new Point(23, 165);
            waveBL.Text = "Blue";
            waveBL.Size = new Size(45, 25);
            waveBL.Parent = panel;

            // Create Wave Blue TrackBar
            waveBTB = new TrackBar();
            waveBTB.Location = new Point(25, 182);
            waveBTB.Height = 100;
            waveBTB.Orientation = Orientation.Vertical;
            waveBTB.TickStyle = TickStyle.None;
            waveBTB.Minimum = 0;
            waveBTB.Maximum = 100;
            waveBTB.Value = 100;
            waveBTB.ValueChanged += new EventHandler(waveBChanged);
            waveBTB.Parent = panel;

            // Create Wave Blue Value Label
            waveBValL = new Label();
            waveBValL.Location = new Point(25, 287);
            waveBValL.Text = "0.0";
            waveBValL.Size = new Size(25, 25);
            waveBValL.Parent = panel;
            
            // Create Wave Smoothing Label
            Label waveSmoothL = new Label();
            waveSmoothL.Location = new Point(78, 165);
            waveSmoothL.Text = "Smooth";
            waveSmoothL.Size = new Size(45, 25);
            waveSmoothL.Parent = panel;

            // Create Wave Smoothing TrackBar
            waveSmoothTB = new TrackBar();
            waveSmoothTB.Location = new Point(87, 182);
            waveSmoothTB.Height = 100;
            waveSmoothTB.Orientation = Orientation.Vertical;
            waveSmoothTB.TickStyle = TickStyle.None;
            waveSmoothTB.Minimum = 0;
            waveSmoothTB.Maximum = 100;
            waveSmoothTB.Value = 100;
            waveSmoothTB.ValueChanged += new EventHandler(waveSmoothChanged);
            waveSmoothTB.Parent = panel;

            // Create Wave Smoothing Value Label
            waveSmoothValL = new Label();
            waveSmoothValL.Location = new Point(87, 287);
            waveSmoothValL.Text = "0.0";
            waveSmoothValL.Size = new Size(25, 25);
            waveSmoothValL.Parent = panel;

            // Create WaveAlphaStart Label
            Label waveStartL = new Label();
            waveStartL.Location = new Point(145, 165);
            waveStartL.Text = "Start";
            waveStartL.Size = new Size(45, 25);
            waveStartL.Parent = panel;

            // Create WaveAlphaStart TrackBar
            waveStartTB = new TrackBar();
            waveStartTB.Location = new Point(150, 182);
            waveStartTB.Height = 100;
            waveStartTB.Orientation = Orientation.Vertical;
            waveStartTB.TickStyle = TickStyle.None;
            waveStartTB.Minimum = 0;
            waveStartTB.Maximum = 100;
            waveStartTB.Value = 0;
            waveStartTB.ValueChanged += new EventHandler(waveStartChanged);
            waveStartTB.Parent = panel;

            // Create WaveAlphaStart Value Label
            waveStartValL = new Label();
            waveStartValL.Location = new Point(150, 287);
            waveStartValL.Text = "0.0";
            waveStartValL.Size = new Size(25, 25);
            waveStartValL.Parent = panel;

            // Create WaveAlphaEnd Label
            Label waveEndL = new Label();
            waveEndL.Location = new Point(198, 165);
            waveEndL.Text = "End";
            waveEndL.Size = new Size(35, 25);
            waveEndL.Parent = panel;
            
            // Create WaveAlphaEnd TrackBar
            waveEndTB = new TrackBar();
            waveEndTB.Location = new Point(200, 182);
            waveEndTB.Height = 100;
            waveEndTB.Orientation = Orientation.Vertical;
            waveEndTB.TickStyle = TickStyle.None;
            waveEndTB.Minimum = 0;
            waveEndTB.Maximum = 100;
            waveEndTB.Value = 0;
            waveEndTB.ValueChanged += new EventHandler(waveEndChanged);
            waveEndTB.Parent = panel;

            // Create WaveAlphaEnd Value Label
            waveEndValL = new Label();
            waveEndValL.Location = new Point(200, 287);
            waveEndValL.Text = "0.0";
            waveEndValL.Size = new Size(25, 25);
            waveEndValL.Parent = panel;

            // Create Wave Parameter Label
            Label waveParamL = new Label();
            waveParamL.Location = new Point(247, 165);
            waveParamL.Text = "Param";
            waveParamL.Size = new Size(35, 25);
            waveParamL.Parent = panel;

            // Create Wave Parameter TrackBar
            waveParamTB = new TrackBar();
            waveParamTB.Location = new Point(250, 182);
            waveParamTB.Height = 100;
            waveParamTB.Orientation = Orientation.Vertical;
            waveParamTB.TickStyle = TickStyle.None;
            waveParamTB.Minimum = 0;
            waveParamTB.Maximum = 100;
            waveParamTB.Value = 0;
            waveParamTB.ValueChanged += new EventHandler(waveParamChanged);
            waveParamTB.Parent = panel;

            // Create Wave Parameter Value Label
            waveParamValL = new Label();
            waveParamValL.Location = new Point(250, 287);
            waveParamValL.Text = "0.0";
            waveParamValL.Size = new Size(25, 25);
            waveParamValL.Parent = panel;

        }

        //##################################################################

    }

    public void showBox(object sender, EventArgs e)
    {
        panel.Visible = true;
    }

    public void exitPanel(object sender, EventArgs e)
    {
        panel.Visible = false;
    }


    public void settingChange(object sender, EventArgs e)
    {
        if (settingLabel.Text.Contains("rot"))
        {
            valueLabel.Text = (((float)settingBar.Value / (float)100) - 1).ToString();
            mForm.changeVal(settingButton.Text, (((float)settingBar.Value / (float)100) - 1));
        }

        else
        {
            valueLabel.Text = ((float)settingBar.Value / (float)100).ToString();
            mForm.changeVal(settingButton.Text, ((float)settingBar.Value / (float)100));
        }
    }


    public void xChanged(object sender, EventArgs e)
    {
        float newVal = (float)warpXTB.Value / (float)100;
        warpXValL.Text = newVal.ToString();
        mForm.changeVal("warpX", newVal);
    }

    public void yChanged(object sender, EventArgs e)
    {
        float newVal = (float)warpYTB.Value / (float)100;
        warpYValL.Text = newVal.ToString();
        mForm.changeVal("warpY", newVal);
    }

    public void speedChanged(object sender, EventArgs e)
    {
        float newVal = (float)warpSpeedTB.Value / (float)100;
        warpSpeedValL.Text = newVal.ToString();
        mForm.changeVal("warpSpd", newVal);
    }

    public void scaleChanged(object sender, EventArgs e)
    {
        float newVal = (float)warpScaleTB.Value / (float)100;
        warpScaleValL.Text = newVal.ToString();
        mForm.changeVal("warpMag", newVal);
    }

    public void mXChanged(object sender, EventArgs e)
    {
        float newVal = (float)((settingBar.Value - 50) / (float)100);
        mXValL.Text = newVal.ToString();
        mForm.changeVal("motionX", newVal);
    }

    public void mYChanged(object sender, EventArgs e)
    {
        float newVal = (float)((mYTB.Value - 50) / (float)100);
        mYValL.Text = newVal.ToString();
        mForm.changeVal("motionY", newVal);
    }

    public void sXChanged(object sender, EventArgs e)
    {
        float newVal = (float)settingBar.Value / (float)100;
        sXValL.Text = newVal.ToString();
        mForm.changeVal("stretchX", newVal);
    }

    public void sYChanged(object sender, EventArgs e)
    {
        float newVal = (float)sYTB.Value / (float)100;
        sYValL.Text = newVal.ToString();
        mForm.changeVal("stretchY", newVal);
    }

    public void modeWaveChanged(object sender, EventArgs e)
    {
        int newVal = settingBar.Value;
        valueLabel.Text = ((int)newVal).ToString();
        mForm.changeVal("Mode", newVal);
    }

    public void xWaveChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveXTB.Value / (float)100;
        waveXValL.Text = newVal.ToString();
        mForm.changeVal("WaveX", newVal);
    }

    public void yWaveChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveYTB.Value / (float)100;
        waveYValL.Text = newVal.ToString();
        mForm.changeVal("WaveY", newVal);
    }

    public void speedWaveChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveSpeedTB.Value / (float)100;
        waveSpeedValL.Text = newVal.ToString();
        mForm.changeVal("WaveSpeed", newVal);
    }

    public void scaleWaveChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveScaleTB.Value / (float)100;
        waveScaleValL.Text = newVal.ToString();
        mForm.changeVal("WaveScale", newVal);
    }

    public void waveRChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveRTB.Value / (float)100;
        waveRValL.Text = newVal.ToString();
        mForm.changeVal("WaveR", newVal);
    }

    public void waveGChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveGTB.Value / (float)100;
        waveGValL.Text = newVal.ToString();
        mForm.changeVal("WaveG", newVal);
    }

    public void waveBChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveBTB.Value / (float)100;
        waveBValL.Text = newVal.ToString();
        mForm.changeVal("WaveB", newVal);
    }

    public void waveSmoothChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveSmoothTB.Value / (float)100;
        waveSmoothValL.Text = newVal.ToString();
        mForm.changeVal("WaveSmooth", newVal);
    }

    public void waveStartChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveStartTB.Value / (float)100;
        waveStartValL.Text = newVal.ToString();
        mForm.changeVal("WaveStart", newVal);
    }

    public void waveEndChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveEndTB.Value / (float)100;
        waveEndValL.Text = newVal.ToString();
        mForm.changeVal("WaveEnd", newVal);
    }

    public void waveParamChanged(object sender, EventArgs e)
    {
        float newVal = (float)waveParamTB.Value / (float)100;
        waveParamValL.Text = newVal.ToString();
        mForm.changeVal("WaveParam", newVal);
    }
        
}