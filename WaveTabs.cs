using System;
using System.Drawing;
using System.Windows.Forms;


public class WaveTabs
{
    // Wave TabControl
    public TabControl waveTabs;

    // Wave TabPages
    public TabPage wave1Tab, wave2Tab, wave3Tab, wave4Tab;

    // Waves
    public Wave wave1, wave2, wave3, wave4;

    public WaveTabs(MilkForm milkForm)
    {
        // Configure wave TabControl
        waveTabs = new TabControl();
        waveTabs.Parent = milkForm;
        waveTabs.Size = new Size(340, 450);
        waveTabs.Location = new Point(345, 110);

        // Create wave tabs
        wave1Tab = new TabPage();
        wave1Tab.Parent = waveTabs;
        wave1Tab.Text = "Wave 1";
        wave1Tab.BackColor = Color.Black;
        wave1Tab.BorderStyle = BorderStyle.Fixed3D;
        wave1Tab.AutoScroll = true;
        wave1Tab.HorizontalScroll.Visible = false;
        wave1Tab.HorizontalScroll.LargeChange = wave1Tab.HorizontalScroll.Maximum;

        wave2Tab = new TabPage();
        wave2Tab.Parent = waveTabs;
        wave2Tab.Text = "Wave 2";
        wave2Tab.BackColor = Color.Black;
        wave2Tab.BorderStyle = BorderStyle.Fixed3D;
        wave2Tab.AutoScroll = true;
        wave2Tab.HorizontalScroll.Visible = false;
        wave2Tab.HorizontalScroll.LargeChange = wave2Tab.HorizontalScroll.Maximum;

        wave3Tab = new TabPage();
        wave3Tab.Parent = waveTabs;
        wave3Tab.Text = "Wave 3";
        wave3Tab.BackColor = Color.Black;
        wave3Tab.BorderStyle = BorderStyle.Fixed3D;
        wave3Tab.AutoScroll = true;
        wave3Tab.HorizontalScroll.Visible = false;
        wave3Tab.HorizontalScroll.LargeChange = wave3Tab.HorizontalScroll.Maximum;

        wave4Tab = new TabPage();
        wave4Tab.Parent = waveTabs;
        wave4Tab.Text = "Wave 4";
        wave4Tab.BackColor = Color.Black;
        wave4Tab.BorderStyle = BorderStyle.Fixed3D;
        wave4Tab.AutoScroll = true;
        wave4Tab.HorizontalScroll.Visible = false;
        wave4Tab.HorizontalScroll.LargeChange = wave4Tab.HorizontalScroll.Maximum;

        wave1 = new Wave(milkForm, wave1Tab, this, "0");
        wave2 = new Wave(milkForm, wave2Tab, this, "1");
        wave3 = new Wave(milkForm, wave3Tab, this, "2");
        wave4 = new Wave(milkForm, wave4Tab, this, "3");
    }

    //////////////////////////////////////////////
    // Rewrite Wave Parameters
    public void reWrite()
    {
        // Write Enabled Wave Parameters
        if (wave1.isEnabled())
            wave1.write();
        if (wave2.isEnabled())
            wave2.write();
        if (wave3.isEnabled())
            wave3.write();
        if (wave4.isEnabled())
            wave4.write();
    }
}
