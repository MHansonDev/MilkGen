using System;
using System.Drawing;
using System.Windows.Forms;

public class Separator
{
    public Label separator;

    public Separator(Point loc, String parentType, object parent)
    {
        // Separator Bevel Line
        separator = new Label();
        separator.Location = loc;
        separator.AutoSize = false;
        separator.Height = 2;
        separator.Width = 310;
        separator.BorderStyle = BorderStyle.Fixed3D;
        separator.BackColor = Color.Green;
        if (parentType.Contains("tab"))
            separator.Parent = (TabPage)parent;
        else
            separator.Parent = (Panel)parent;

    }
}