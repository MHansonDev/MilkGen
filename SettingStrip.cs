using System;
using System.Drawing;
using System.Windows.Forms;

public class SettingStrip
{
    MilkForm mForm;

    // Parent Tab
    TabPage tab;

    // Working Shape/Wave
    Shape shape;
    Wave wave;

    // Shape/Wave Tabs Controls
    ShapeTabs shapeTabs;
    WaveTabs waveTabs;

    // User Control
    UserControl uControl;

    // TrackBar Variables
    TrackBar tBar;      // TrackBar
    string tBarTxt;     // TrackBar Text
    Label tBarValL;     // TrackBar Value Label
    Label tBarSetL;     // TrackBar Setting Label

    // Reaction Variables
    Button react;
    ReactBox rBox;

    // Strip Index
    int stripIndx;
    // Shape/Wave Type
    int swType;

    // Constructor
    public SettingStrip(MilkForm m, TabPage t, int swT, ShapeTabs sTabs, WaveTabs wTabs, Shape s, Wave w, Point tL, string tt, int tMin, int tMax, int tVal, int indx)
    {
        mForm = m;
        tab = t;
        shape = s;
        tBarTxt = "   " + tt;
        shapeTabs = sTabs;
        waveTabs = wTabs;
        shape = s;
        wave = w;
        stripIndx = indx;
        swType = swT;

        Font tblFont = new Font("Arial", 8, FontStyle.Bold);

        // Initialize TrackBar
        tBar = new TrackBar();
        tBar.Parent = tab;
        tBar.Text = tt;
        tBar.Orientation = Orientation.Horizontal;
        tBar.Size = new Size(84, 16);
        tBar.TickStyle = TickStyle.None;
        tBar.BackColor = Color.Black;
        tBar.ForeColor = Color.Black;
        tBar.Padding = new Padding(2, 2, 2, 2);
        tBar.Margin = new Padding(0, 5, 0, 5);
        tBar.Left = 1;
        tBar.TickFrequency = 10;
        tBar.Minimum = tMin;
        tBar.Maximum = tMax;
        tBar.Value = tVal;
        tBar.ValueChanged += new EventHandler(tick);

        // Create TrackBar Setting Label
        tBarSetL = new Label();
        tBarSetL.Text = tBarTxt;
        tBarSetL.Location = new Point(tL.X - 105, tL.Y + 2);
        tBarSetL.Size = new Size(100, 20);
        tBarSetL.Font = tblFont;
        tBarSetL.Parent = tab;

        // Create TrackBar Value Label
        tBarValL = new Label();
        if (tBarTxt.Contains("Sides"))
            tBarValL.Text = tVal.ToString();
        else
            tBarValL.Text = ((float)tVal / (float)100.0).ToString();
        tBarValL.Location = new Point(tL.X + 103, tL.Y + 3);
        tBarValL.Parent = tab;
        tBarValL.Size = new Size(28, 17);
        tBarValL.BorderStyle = BorderStyle.Fixed3D;

        // Ceate UserControl
        uControl = new UserControl();
        uControl.Size = new Size(93, 27);
        uControl.BackColor = Color.Black;
        uControl.Location = new Point(tL.X + 5, tL.Y);
        uControl.Parent = tab;
        uControl.BorderStyle = BorderStyle.Fixed3D;
        uControl.Controls.Add(tBar);

        // Set TrackBar Location Inside UserControl
        tBar.Location = new Point(3, 0);

        // Create Reaction Button
        react = new Button();
        react.Image = new Bitmap("C:\\Users\\User\\Desktop\\Dev\\Milkdrop\\react.jpg");
        react.ImageAlign = ContentAlignment.MiddleCenter;
        react.UseVisualStyleBackColor = true;
        react.Width = 65;
        react.Height = 12;
        react.Location = new Point(tL.X + 139, tL.Y + 5);
        react.Parent = tab;
        react.Font = tblFont;
        react.TabStop = false;
        react.FlatStyle = FlatStyle.Flat;
        react.FlatAppearance.BorderSize = 0;
        react.Click += reactClick;

        // Create Reaction Box
        rBox = new ReactBox(mForm, tab, sTabs, wTabs, shape, wave, stripIndx, tt);
    }

    // Event Handler For Trackbar Value Change
    // Calculations Differ Between Settings
    public void tick(object sender, EventArgs e)
    {

        // Settings: X, Y, R, G, B, A, R2, G2, B2, A2, BorderR, Borders R G and B
        if (tBarTxt.Contains("X"))
        {
            // Get New X Position Value
            float newVal = ((float)tBar.Value / (float)100.0);
            // Apply New Value To Shape/Wave
            if (swType == 0)
                shape.changeVal(0, newVal);
            else
                wave.changeVal(0, newVal);
            // Change Value Label Text
            tBarValL.Text = newVal.ToString();
            // Write To Preset File
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Y"))
        {
            // Get New Y Position Value
            float newVal = ((float)tBar.Value / (float)100.0);
            // Apply New Value To Shape/Wave
            if (swType == 0)
                shape.changeVal(1, newVal);
            else
                wave.changeVal(1, newVal);
            // Change Value Label Text
            tBarValL.Text = newVal.ToString();
            // Write To Preset File
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Sides"))
        {
            // Change Side Count And Write To .milk File
            shape.changeVal(2, (int)tBar.Value);
            tBarValL.Text = tBar.Value.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Size"))
        {
            // Change Size And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(3, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Angle"))
        {
            // Change Angle And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(4, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Inner Red"))
        {
            // Change Inner Redness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(5, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }



        else if (tBarTxt.Contains("Outer Red"))
        {
            // Change Outer Redness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(6, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Red"))
        {
            // Change Wave's Red Value
            float newVal = ((float)tBar.Value / (float)100.0);
            wave.changeVal(2, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Inner Green"))
        {
            // Change Inner Greenness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(7, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Outer Green"))
        {
            // Change Outer Greenness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(8, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Green"))
        {
            // Change Wave's Green Value
            float newVal = ((float)tBar.Value / (float)100.0);
            wave.changeVal(3, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Inner Blue"))
        {
            // Change Inner Blueness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(9, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Outer Blue"))
        {
            // Change Outer Blueness and Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(10, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Blue"))
        {
            // Change Wave's Blue Value
            float newVal = ((float)tBar.Value / (float)100.0);
            wave.changeVal(4, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Border Red"))
        {
            // Change Border Redness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(11, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Border Green"))
        {
            // Change Border Greenness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(12, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Border Blue"))
        {
            // Change Border Blueness And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(13, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Border Opacity"))
        {
            // Change Border Opacity And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(14, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Inner Opacity"))
        {
            // Change Inner Opacity And Write To .milk File
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(15, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Opacity"))
        {
            // Change Wave's Opacity Value
            float newVal = ((float)tBar.Value / (float)100.0);
            wave.changeVal(5, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else if (tBarTxt.Contains("Samples"))
        {
            // Change Wave's Samples Value
            float newVal = ((float)tBar.Value / (float)100.0);
            wave.changeVal(6, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        else
        {
            // Change Outer Opacity And Write To .milk file
            float newVal = ((float)tBar.Value / (float)100.0);
            shape.changeVal(16, newVal);
            tBarValL.Text = newVal.ToString();
            mForm.reWrite();
        }

        if (swType == 0)
            tBarValL.Text = shape.getVal(tBarTxt).ToString();
        else
            tBarValL.Text = wave.getVal(tBarTxt).ToString();
    }


    //////////////////////////////////////
    // Reaction EventHandler
    public void reactClick(object sender, EventArgs e)
    {
        {
            rBox.setVisible();
        }
    }

}
