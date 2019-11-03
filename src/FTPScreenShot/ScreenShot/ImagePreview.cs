using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot.ScreenShot
{
    public partial class ImagePreview : Form
    {
        Rectangle rec;
        Pen pen = new Pen(Color.Aqua);
        public ImagePreview()
        {
            InitializeComponent();
            pen.Width = 10;

        }
        public ImagePreview(Image back, Image sel, Rectangle r)
        { 
            r.Width--;
            r.Height--;
            rec = r;
            rec.X = 0;
            rec.Y = 0;
            InitializeComponent();
            Background.Image = back;
            Selection.Image = sel;
            Selection.Size = sel.Size;
            Selection.Location = r.Location;
            this.Invalidate();
        }

        private void ImagePreview_Paint(object sender, PaintEventArgs e)
        {
            //try
            {

            }
            //catch { }
        }

        private void Selection_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, rec);
        }

        private void ImagePreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
