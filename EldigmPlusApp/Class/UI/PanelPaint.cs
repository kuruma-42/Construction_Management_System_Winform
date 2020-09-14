using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldigmPlusApp.Class.UI
{
    class PanelPaint
    {
        public void paint_PanelPurple1(object sender, PaintEventArgs e)
        {
            Panel pan = (Panel)sender;

            Color startColor = Color.FromArgb(129, 156, 203);
            Color middleColor = Color.WhiteSmoke;
            Color endColor = Color.FromArgb(129, 156, 203);

            LinearGradientBrush br = new LinearGradientBrush(pan.ClientRectangle, Color.FromArgb(129, 156, 203), Color.FromArgb(204, 218, 243), 0, false);

            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 1 / 2f, 1 };
            cb.Colors = new[] { startColor, middleColor, endColor };
            br.InterpolationColors = cb;

            br.RotateTransform(45);
            e.Graphics.FillRectangle(br, pan.ClientRectangle);
        }

        public void paint_MenuStripSteelBlue1(object sender, PaintEventArgs e)
        {
            MenuStrip pan = (MenuStrip)sender;

            Color startColor = Color.SteelBlue;
            Color middleColor = Color.LightSteelBlue;
            Color endColor = Color.SteelBlue;

            LinearGradientBrush br = new LinearGradientBrush(pan.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, 0, false);

            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 1 / 2f, 1 };
            cb.Colors = new[] { startColor, middleColor, endColor };
            br.InterpolationColors = cb;

            br.RotateTransform(45);
            e.Graphics.FillRectangle(br, pan.ClientRectangle);
        }
    }
}
