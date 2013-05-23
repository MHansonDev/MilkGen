using System;
using System.Drawing;
using System.Windows.Forms;


public class ShapeTabs
{
    // Shape TabControl
    public TabControl shapeTabs;

    // Shape TapPages
    public TabPage shape1Tab, shape2Tab, shape3Tab, shape4Tab;

    // Shapes
    public Shape shape1, shape2, shape3, shape4;

    public ShapeTabs(MilkForm milkForm)
    {
        // Configure Shape TabControl
        shapeTabs = new TabControl();
        shapeTabs.Parent = milkForm;
        shapeTabs.Size = new Size(340, 450);
        shapeTabs.Location = new Point(0, 110);
        

        // Create Shape Tabs
        shape1Tab = new TabPage();
        shape1Tab.Parent = shapeTabs;
        shape1Tab.Text = "Shape 1";
        shape1Tab.BackColor = Color.Black;
        shape1Tab.ForeColor = Color.White;
        shape1Tab.BorderStyle = BorderStyle.Fixed3D;
        shape1Tab.AutoScroll = true;
        shape1Tab.HorizontalScroll.Visible = false;
        shape1Tab.HorizontalScroll.LargeChange = shape1Tab.HorizontalScroll.Maximum / 2;

        shape2Tab = new TabPage();
        shape2Tab.Parent = shapeTabs;
        shape2Tab.Text = "Shape 2";
        shape2Tab.BackColor = Color.Black;
        shape2Tab.ForeColor = Color.White;
        shape2Tab.BorderStyle = BorderStyle.Fixed3D;
        shape2Tab.AutoScroll = true;
        shape2Tab.HorizontalScroll.Visible = false;
        shape2Tab.HorizontalScroll.LargeChange = shape2Tab.HorizontalScroll.Maximum / 2;

        shape3Tab = new TabPage();
        shape3Tab.Parent = shapeTabs;
        shape3Tab.Text = "Shape 3";
        shape3Tab.BackColor = Color.Black;
        shape3Tab.ForeColor = Color.White;
        shape3Tab.BorderStyle = BorderStyle.Fixed3D;
        shape3Tab.AutoScroll = true;
        shape3Tab.HorizontalScroll.Visible = false;
        shape3Tab.HorizontalScroll.LargeChange = shape3Tab.HorizontalScroll.Maximum / 2;

        shape4Tab = new TabPage();
        shape4Tab.Parent = shapeTabs;
        shape4Tab.Text = "Shape 4";
        shape4Tab.BackColor = Color.Black;
        shape4Tab.ForeColor = Color.White;
        shape4Tab.BorderStyle = BorderStyle.Fixed3D;
        shape4Tab.AutoScroll = true;
        shape4Tab.HorizontalScroll.Visible = false;
        shape4Tab.HorizontalScroll.LargeChange = shape4Tab.HorizontalScroll.Maximum / 2;


        // Create Shapes Inside Tab Pages
        shape1 = new Shape(milkForm, shape1Tab, this, "0", (float)0.2, (float)0.5);
        shape2 = new Shape(milkForm, shape2Tab, this, "1", (float)0.4, (float)0.5);
        shape3 = new Shape(milkForm, shape3Tab, this, "2", (float)0.6, (float)0.5);
        shape4 = new Shape(milkForm, shape4Tab, this, "3", (float)0.8, (float)0.5);
    }


    //////////////////////////////////////////////////////////
    // Rewrite Shape Parameters
    public void reWrite()
    {
        // Write Enabled Shape Parameters
        if (shape1.isEnabled())
            shape1.write();
        if (shape2.isEnabled())
            shape2.write();
        if (shape3.isEnabled())
            shape3.write();
        if (shape4.isEnabled())
            shape4.write();
    }

}
