using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;

namespace LABLibary.Form
{
    public class MenuStrip
    {
        public class ColorTableWhite : ProfessionalColorTable
        {
            public override Color MenuItemBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
        }
        public class ColorTableBlack : ProfessionalColorTable
        {
            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(34,34,34); }
            }
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(40,40,40); }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.FromArgb(21,21,21); }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.FromArgb(21, 21, 21); }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.FromArgb(21, 21, 21); }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.FromArgb(21, 21, 21); }
            }
        }

#pragma warning disable CA1416 

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            private Color primaryColor;
            private Color textColor;
            private int arrowThickness;
            public Color secondColor = Color.FromArgb(21, 21, 21);

            public MyRenderer(bool isMainMenu,Color primaryColor) : base(new ColorTableBlack())
            {
                this.primaryColor = primaryColor;
                if (isMainMenu)
                {
                    arrowThickness = 3;
                    if (textColor == Color.Empty) //Set Default Color
                        this.textColor = Color.Gainsboro;
                    else//Set custom text color 
                        this.textColor = textColor;
                }
                else
                {
                    arrowThickness = 2;
                    if (textColor == Color.Empty) //Set Default Color
                        this.textColor = Color.DimGray;
                    else//Set custom text color
                        this.textColor = textColor;
                }
            }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                //Fields
                var graph = e.Graphics;
                var arrowSize = new System.Drawing.Size(5, 12);
                var arrowColor = e.Item.Selected ? Color.White : primaryColor;
                var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                    arrowSize.Width, arrowSize.Height);
                using (GraphicsPath path = new GraphicsPath())
                using (Pen pen = new Pen(arrowColor, arrowThickness))
                {
                    //Drawing
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
                    path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
                    graph.DrawPath(pen, path);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                base.OnRenderItemText(e);
                e.Item.ForeColor = e.Item.Selected ? Color.Black : Color.DarkGray;
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                var g = e.Graphics;

                e.Item.ForeColor = e.Item.Enabled ? Color.White : Color.DarkGray;

                if (e.Item.Enabled)
                {

                    var bgColor = e.Item.Selected ? Color.Black : secondColor;

                    // Normal item
                    var rect = new Rectangle(2, 0, e.Item.Width - 3, e.Item.Height);

                    using (var b = new SolidBrush(bgColor))
                    {
                        g.FillRectangle(b, rect);
                    }

                    // Header item on open menu
                    if (e.Item.GetType() == typeof(ToolStripMenuItem))
                    {
                        if (((ToolStripMenuItem)e.Item).DropDown.Visible && e.Item.IsOnDropDown == false)
                        {
                            using (var b = new SolidBrush(Color.Black))
                            {
                                g.FillRectangle(b, rect);
                            }
                        }
                    }
                }
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                var g = e.Graphics;

                var rect = new Rectangle(e.ImageRectangle.Left - 2, e.ImageRectangle.Top - 2,
                                             e.ImageRectangle.Width + 4, e.ImageRectangle.Height + 4);

                using (var b = new SolidBrush(Colors.LightBorder))
                {
                    g.FillRectangle(b, rect);
                }

                using (var p = new Pen(Colors.BlueHighlight))
                {
                    var modRect = new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
                    g.DrawRectangle(p, modRect);
                }

                if (e.Item.ImageIndex == -1 && String.IsNullOrEmpty(e.Item.ImageKey) && e.Item.Image == null)
                {
                    g.DrawImage(Image.FromFile(".\\donesmall.png"), new Point(e.ImageRectangle.Left, e.ImageRectangle.Top));
                }
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                var g = e.Graphics;

                var rect = new Rectangle(1, 3, e.Item.Width, 1);

                using (var b = new SolidBrush(Colors.LightBorder))
                {
                    g.FillRectangle(b, rect);
                }
            }

            
        }
    }

    public sealed class Colors
    {
        public static Color GreyBackground
        {
            get { return Color.FromArgb(60, 63, 65); }
        }

        public static Color HeaderBackground
        {
            get { return Color.FromArgb(57, 60, 62); }
        }

        public static Color BlueBackground
        {
            get { return Color.FromArgb(66, 77, 95); }
        }

        public static Color DarkBlueBackground
        {
            get { return Color.FromArgb(52, 57, 66); }
        }

        public static Color DarkBackground
        {
            get { return Color.FromArgb(43, 43, 43); }
        }

        public static Color MediumBackground
        {
            get { return Color.FromArgb(49, 51, 53); }
        }

        public static Color LightBackground
        {
            get { return Color.FromArgb(69, 73, 74); }
        }

        public static Color LighterBackground
        {
            get { return Color.FromArgb(95, 101, 102); }
        }

        public static Color LightestBackground
        {
            get { return Color.FromArgb(178, 178, 178); }
        }

        public static Color LightBorder
        {
            get { return Color.FromArgb(81, 81, 81); }
        }

        public static Color DarkBorder
        {
            get { return Color.FromArgb(51, 51, 51); }
        }

        public static Color LightText
        {
            get { return Color.FromArgb(220, 220, 220); }
        }

        public static Color DisabledText
        {
            get { return Color.FromArgb(153, 153, 153); }
        }

        public static Color BlueHighlight
        {
            get { return Color.FromArgb(104, 151, 187); }
        }

        public static Color BlueSelection
        {
            get { return Color.FromArgb(75, 110, 175); }
        }

        public static Color GreyHighlight
        {
            get { return Color.FromArgb(122, 128, 132); }
        }

        public static Color GreySelection
        {
            get { return Color.FromArgb(92, 92, 92); }
        }

        public static Color DarkGreySelection
        {
            get { return Color.FromArgb(82, 82, 82); }
        }

        public static Color DarkBlueBorder
        {
            get { return Color.FromArgb(51, 61, 78); }
        }

        public static Color LightBlueBorder
        {
            get { return Color.FromArgb(86, 97, 114); }
        }

        public static Color ActiveControl
        {
            get { return Color.FromArgb(159, 178, 196); }
        }
    }
}
