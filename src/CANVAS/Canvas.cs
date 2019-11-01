using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CANVAS
{
    public class Canvas : Form
    {
        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;
        public Bitmap image;
        Rectangle rmem;
        //Image back;
        public Image screen;
        public static Pen pen = new Pen(Color.Aqua);
        bool fullscreen = false;
        public bool preview = false;

        public Canvas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.Cursor = Cursors.Cross;
            this.MouseDown += Canvas_MouseDown;
            this.MouseMove += Canvas_MouseMove;
            this.MouseUp += Canvas_MouseUp;
            this.Paint += Canvas_Paint;
            this.KeyDown += Canvas_KeyDown;
            this.DoubleBuffered = true;
            pen.DashStyle = DashStyle.Dot;
            pen.Width = 2;
            screen = ScreenS();
            this.BackgroundImage = screen;
        }
        public static Canvas Open()
        {
            return new Canvas();
        }
        
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !drawing&&!preview)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            if (e.KeyCode == Keys.Escape && drawing)
            {
                drawing = false;
                this.Invalidate();
                return;
            }
            if (preview&&e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            if (preview && e.KeyCode == Keys.Escape)
            {
                preview = false;
                fullscreen = false;
                this.Invalidate();
                return;
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            fullscreen = true;
            currentPos = startPos = e.Location;
            drawing = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            fullscreen = false;
            currentPos = e.Location;
            if (drawing) this.Invalidate();
        }
        //public Image BackScreen()
        //{
        //    Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
        //    }
        //    return bmp;
        //}
        public Image ScreenS()
        {
            this.Opacity = 0;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            }
            this.Opacity = 100;
            return bmp;
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                ScreenShot();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (fullscreen)
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                bounds.Height -= 1;
                Pen pen2 = new Pen(Color.Aqua);
                e.Graphics.DrawRectangle(pen2, bounds);
                pen2.Width = 1;

                return;
            }
            if (drawing)
            {
                e.Graphics.DrawRectangle(pen, GetRectangle());
                rmem = GetRectangle();
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                Pen alphapen = new Pen(Color.FromArgb(128, Color.Black), 100);
                e.Graphics.FillRectangle(alphapen.Brush, 0, 0, rmem.X, bounds.Height);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X, 0, bounds.Width, rmem.Y);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X + rmem.Width, rmem.Y, bounds.Width, bounds.Height);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X, rmem.Y + rmem.Height, rmem.Width, bounds.Height);
                return;
            }
            if (preview)
            {
                Pen pen2 = new Pen(Color.Aqua);
                Rectangle r = rmem;
                e.Graphics.DrawRectangle(pen2, rmem);
                pen2.Width = 1;
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                Pen alphapen = new Pen(Color.FromArgb(128, Color.Black), 100);
                e.Graphics.FillRectangle(alphapen.Brush, 0, 0, rmem.X, bounds.Height);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X, 0, bounds.Width, rmem.Y);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X+1 + rmem.Width, rmem.Y, bounds.Width, bounds.Height);
                e.Graphics.FillRectangle(alphapen.Brush, rmem.X, rmem.Y+1 + rmem.Height, rmem.Width+1, bounds.Height);
                return;
            }
            if (!drawing)
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                Pen alphapen = new Pen(Color.FromArgb(128, Color.Black), 100);
                e.Graphics.FillRectangle(alphapen.Brush, 0, 0, bounds.Width, bounds.Height);
            }
        }


        public void ScreenShot()
        {
            Rectangle r = rmem;
            r.Width++;
            r.Height++;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            //ImagePreview ip = null;
            if (rmem.Width >= 1 && rmem.Height >= 1)
            {
                image = Crop((Bitmap)screen, r);
                //ip = new ImagePreview(back, image , r);
            }
            else
            {
                image = Crop((Bitmap)screen, bounds);
                //ip = new ImagePreview(back, image, bounds);
            }
            //this.TopMost = false;
            drawing = false;
            preview = true;
            this.Invalidate();
        }
        public Bitmap Crop(Bitmap image, Rectangle selection)
        {
            Bitmap bmp = image;

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            return cropBmp;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Canvas";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
    }
}