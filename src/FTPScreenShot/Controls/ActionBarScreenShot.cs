using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot.Controls
{
    public partial class ActionBarScreenShot : UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string selection_size
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image1
        {
            get { return Btn_rect.BackgroundImage; }
            set { Btn_rect.BackgroundImage = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image2
        {
            get { return Btn_circle.BackgroundImage; }
            set { Btn_circle.BackgroundImage = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image3
        {
            get { return Btn_pen.BackgroundImage; }
            set { Btn_pen.BackgroundImage = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image4
        {
            get { return Btn_txt.BackgroundImage; }
            set { Btn_txt.BackgroundImage = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image5
        {
            get { return Btn_copy.BackgroundImage; }
            set { Btn_copy.BackgroundImage = value; }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image6
        {
            get { return Btn_send.BackgroundImage; }
            set { Btn_send.BackgroundImage = value; }
        }
        public Canvas canvas = null;
        public ActionBarScreenShot()
        {
            InitializeComponent();
        }
    }
}
