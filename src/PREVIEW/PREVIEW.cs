using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREVIEW
{
    public partial class PREVIEW : Form
    {
        public PREVIEW()
        {
            InitializeComponent();
        }
        public static PREVIEW Open()
        {
            return new PREVIEW();
        }
        public void Show(Image img)
        {
            pictureBox1.Image = img;
            this.ShowDialog();
        }
    }
}
