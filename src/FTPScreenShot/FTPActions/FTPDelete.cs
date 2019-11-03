using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot
{
    public partial class FTPDelete : Form
    {
        List<FtpListItem> items;
        public FTPDelete()
        {

            InitializeComponent();
            FTPExplorer ex = new FTPExplorer();
            items = ex.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                comboBox1.Items.Add(items[i].Name + "    ||    Count : " + FTPHandle.GetItemsList(items[i].FullName).Count);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete? " + Environment.NewLine + items[comboBox1.SelectedIndex].Name, "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FTPHandle.FTPDelete(items[comboBox1.SelectedIndex].FullName);
                }
            }
            catch (Exception ex)
            {
                ResultsList.FromException(ex);
            }
        }
    }
}
