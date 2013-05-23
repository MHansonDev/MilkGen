using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

public class ReactBox : Panel
{
    // Main Form
    public MilkForm mForm;

    // Shape TabPage
    public TabPage tab;

    // TabControl
    public ShapeTabs shapeTabs;
    public WaveTabs waveTabs;

    // Working Shape
    public Shape shape;

    // Reaction Type ComboBox
    public ComboBox rCmBx;

    // Reaction Intensity TrackBar
    public TrackBar intensity;

    // Reaction Attribute RadioButtons
    public RadioButton bassRButton, midRButton, trebRButton, oscRButton, beatRButton, noRButton;

    // Setting Index
    public int settingIndx;

    // Setting Label
    public Label setLabl;

    public ReactBox(MilkForm m, TabPage t, ShapeTabs sTabs, WaveTabs wTabs, Shape s, Wave w, int sIndx, string setL)
    {
        mForm = m;
        tab = t;
        shapeTabs = sTabs;
        shape = s;
        settingIndx = sIndx;
        this.Visible = false;


        // Create Reaction Label Font
        Font rFont = new Font("Courier New", 15, FontStyle.Bold);

        // React Label
        Label rLabel = new Label();
        rLabel.Text = setL + " Reaction";
        rLabel.Location = new Point(10, 10);
        rLabel.AutoSize = true;
        rLabel.Font = rFont;
        this.Controls.Add(rLabel);


        // Quit Button
        Button quitButton = new Button();
        quitButton.Image = new Bitmap("C:\\Users\\User\\Desktop\\Dev\\Milkdrop\\back.jpg");
        quitButton.ImageAlign = ContentAlignment.MiddleCenter;
        quitButton.UseVisualStyleBackColor = true;
        quitButton.Location = new Point(265, 5);
        quitButton.Size = new Size(17, 17);
        quitButton.FlatStyle = FlatStyle.Flat;
        quitButton.FlatAppearance.BorderSize = 0;
        quitButton.Click += quitClicked;
        this.Controls.Add(quitButton);


        // Reaction Selection
        rCmBx = new ComboBox();
        rCmBx.Parent = this;
        rCmBx.Location = new Point(110, 50);
        rCmBx.Items.Add("Increase");
        rCmBx.Items.Add("Decrease");
        rCmBx.Items.Add("Do Nothing");
        rCmBx.SelectedValue = "Do Nothing";


        // Bass Reaction RadioButton;
        bassRButton = new RadioButton();
        bassRButton.Location = new Point(10, 95);
        bassRButton.Text = "Bass Reactive";
        bassRButton.CheckedChanged += new System.EventHandler(this.reactionChecked);
        this.Controls.Add(bassRButton);

        // Mid Reaction RadioButton;
        midRButton = new RadioButton();
        midRButton.Location = new Point(10, 114);
        midRButton.Text = "Mid Reactive";
        midRButton.CheckedChanged += new System.EventHandler(this.reactionChecked);
        this.Controls.Add(midRButton);

        // Treb Reaction RadioButton
        trebRButton = new RadioButton();
        trebRButton.Location = new Point(10, 133);
        trebRButton.Text = "Treb Reactive";
        trebRButton.CheckedChanged += new System.EventHandler(this.reactionChecked);
        this.Controls.Add(trebRButton);

        // Oscillation Reaction RadioButton
        oscRButton = new RadioButton();
        oscRButton.Location = new Point(10, 152);
        oscRButton.Text = "Oscillation";
        oscRButton.CheckedChanged += new System.EventHandler(this.reactionChecked);
        this.Controls.Add(oscRButton);

        // Beat Detection RadioButton
        beatRButton = new RadioButton();
        beatRButton.Location = new Point(10, 171);
        beatRButton.Text = "Beat Detection";
        beatRButton.CheckedChanged += new System.EventHandler(this.reactionChecked);
        this.Controls.Add(beatRButton);

        
        // Reaction Intensity TrackBar
        intensity = new TrackBar();
        intensity.Orientation = Orientation.Horizontal;
        intensity.Location = new Point(120, 130);
        intensity.Size = new Size(100, 10);
        intensity.TickStyle = TickStyle.None;
        intensity.BackColor = Color.Black;
        intensity.Padding = new Padding(2, 2, 2, 2);
        intensity.Margin = new Padding(0, 5, 0, 5);
        intensity.TickFrequency = 10;
        intensity.Maximum = 0;
        intensity.Minimum = -30;
        intensity.Value = -10;
        intensity.ValueChanged += new EventHandler(intensityChanged);
        this.Controls.Add(intensity);


        // Separator Bevel Line
        Label sepLine = new Label();
        sepLine.Location = new Point(0, 90);
        sepLine.AutoSize = false;
        sepLine.Height = 2;
        sepLine.Width = 300;
        sepLine.BorderStyle = BorderStyle.Fixed3D;
        this.Controls.Add(sepLine);


        // Intensity Label
        Label intensityL = new Label();
        intensityL.Text = "INTENSITY";
        intensityL.Location = new Point(130, 110);
        this.Controls.Add(intensityL);


        // React Button
        Button reactButton = new Button();
        reactButton.Text = "REACT";
        reactButton.Location = new Point(230, 165);
        reactButton.Size = new Size(60, 24);
        reactButton.Click += reactClicked;
        reactButton.BringToFront();
        this.Controls.Add(reactButton);


        // ReactBox Settings
        this.Size = new Size(300, 200);
        this.Location = new Point(6, 40);
        this.BackColor = Color.Black;
        this.ForeColor = Color.White;
        this.BorderStyle = BorderStyle.Fixed3D;
        this.Parent = tab;
        this.BringToFront();
    }

    //////////////////////////////////////
    // Quit Clicked EventHandler
    public void quitClicked(object sender, EventArgs e)
    {
        {
            this.Visible = false;
        }
    }

    ///////////////////////////////////////
    // React Clicked EventHandler
    public void reactClicked(object sender, EventArgs e)
    {
        shape.settings[settingIndx].changeRType(rCmBx.Text);
        mForm.reWrite();
    }

    //////////////////////////////////////
    // Intensity TrackBar Value Changed
    public void intensityChanged(object sender, EventArgs e)
    {
        shape.settings[settingIndx].changeIntensity(Math.Abs(intensity.Value));
        shapeTabs.reWrite();
    }

    //////////////////////////////////////
    // Reaction Attribute Changed
    public void reactionChecked(object sender, EventArgs e)
    {
        RadioButton button = (RadioButton)sender;
        if (button.Checked)
        {
            shape.settings[settingIndx].setReactive();
            shape.settings[settingIndx].changeRType(rCmBx.Text);
            shape.settings[settingIndx].changeRAttr(button.Text);
        }

        if (rCmBx.Text.Contains("Nothing"))
            shape.settings[settingIndx].setNotReactive();
    }


    //////////////////////////////////////
    /// Set ReactBox Visible
    public void setVisible()
    {
        this.Visible = true;
        shapeTabs.reWrite();
    }
}
