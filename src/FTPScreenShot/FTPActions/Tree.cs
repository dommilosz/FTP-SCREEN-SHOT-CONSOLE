using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot
{
    public partial class Tree : Form
    {
        List<TreeNode> par = new List<TreeNode>();
        List<TreeNode> parall = new List<TreeNode>();
        FTPDownload ftpDownload = new FTPDownload();
        public Tree()
        {
            InitializeComponent();
            treeView1.Nodes.Clear();
            RefreshTree();
        }

        public void RefreshTree()
        {
            try
            {
                ftpDownload.ftpImage1.Visible = true;
                List<FtpListItem> itemsinmain = FTPHandle.GetItemsList("/ScreenShot");
                par = new List<TreeNode>();
                parall = new List<TreeNode>();
                for (int i = 0; i < itemsinmain.Count; i++)
                {
                    try
                    {
                        List<TreeNode> nodes = new List<TreeNode>();
                        List<FtpListItem> itemsinunder = FTPHandle.GetItemsList(itemsinmain[i].FullName);
                        for (int i2 = 0; i2 < itemsinunder.Count; i2++)
                        {
                            nodes.Add(new TreeNode(itemsinunder[i2].Name));
                        }
                        for (int i2 = 0; i2 < nodes.Count; i2++)
                        {
                            nodes[i2].ImageIndex = 1;
                            nodes[i2].SelectedImageIndex = 2;
                        }
                        TreeNode node = new TreeNode(itemsinmain[i].Name, nodes.ToArray());
                        if (node.Nodes.Count > 0)
                            par.Add(node);
                        parall.Add(node);
                    }
                    catch { }
                }
                if (Hide_ShowEmptyToolStripMenuItem1.Text.Contains("Hide"))
                {
                    treeView1.Nodes.Clear();
                    TreeNode mainnode = new TreeNode("Main Folder", parall.ToArray());
                    treeView1.Nodes.Add(mainnode);
                }
                else
                {
                    treeView1.Nodes.Clear();
                    TreeNode mainnode = new TreeNode("Main Folder", par.ToArray());
                    treeView1.Nodes.Add(mainnode);
                }
            }
            catch (Exception ex) { ResultsList.FromException(ex); }
        }

        public int GetSelectedIndex()
        {
            string folder = "{[null]}";
            if (treeView1.SelectedNode.Level == 1)
            {
                folder = treeView1.SelectedNode.Text;
            }
            if (treeView1.SelectedNode.Level == 2)
            {
                folder = treeView1.SelectedNode.Parent.Text;
            }
            if (folder != "{[null]}")
            {
                ftpDownload.ftpImage1.GetItems(true);
                for (int i = 0; i < ftpDownload.ftpImage1.comboBox1.Items.Count; i++)
                {
                    string cbv = ftpDownload.ftpImage1.comboBox1.Items[i].ToString();
                    if (cbv.Contains(folder))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 2)
            {
                LoadSelected();
            }
            else if(treeView1.SelectedNode.Level != 0)
            {
                int i = GetSelectedIndex();
                ftpDownload.ftpImage1.comboBox1.SelectedItem = ftpDownload.ftpImage1.comboBox1.Items[i];
                ftpDownload.ShowDialog();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level != 0)
            {
                string name = "";
                if (treeView1.SelectedNode.Level == 1)
                    name = treeView1.SelectedNode.Text;
                if (treeView1.SelectedNode.Level == 2)
                    name = treeView1.SelectedNode.Parent.Text + "/" + treeView1.SelectedNode.Text;
                if (MessageBox.Show("Do You Want To DELETE Selected File/Directory?" + Environment.NewLine + "Main Folder/" + name, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FTPHandle.FTPDelete("ScreenShot/" + name.TrimEnd(' '));
                    RefreshTree();
                }
            }

        }

        private void UploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FTPUpload u = new FTPUpload();
            if (u.ShowDialog() == DialogResult.OK)
            {
                RefreshTree();
            }
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadSelected();
        }
        void LoadSelected()
        {
            if (treeView1.SelectedNode.ImageIndex == 1)
            {
                Image img = FTPHandle.DownloadImage("ScreenShot/" + treeView1.SelectedNode.Parent.Text + "/" + treeView1.SelectedNode.Text);
                ZoomImageWindow ziw = new ZoomImageWindow(img);
                ziw.ShowDialog();
            }
        }
        private void TreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (!treeView1.SelectedNode.IsExpanded)
                    {
                        treeView1.SelectedNode.Expand();
                    }
                    else { treeView1.SelectedNode.Collapse(); }
                }
                if (e.KeyCode == Keys.Right)
                {
                    treeView1.SelectedNode.Expand();
                }
                if (e.KeyCode == Keys.Left)
                {
                    treeView1.SelectedNode.Collapse();
                }
            }
            catch { }
        }

        private void Hide_ShowEmptyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Hide_ShowEmptyToolStripMenuItem1.Text.Contains("Show"))
            {
                Hide_ShowEmptyToolStripMenuItem1.Text = "Hide Empty";
                treeView1.Nodes.Clear();
                TreeNode mainnode = new TreeNode("Main Folder", parall.ToArray());
                treeView1.Nodes.Add(mainnode);
            }
            else
            {
                Hide_ShowEmptyToolStripMenuItem1.Text = "Show Empty";
                treeView1.Nodes.Clear();
                TreeNode mainnode = new TreeNode("Main Folder", par.ToArray());
                treeView1.Nodes.Add(mainnode);
            }
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

    }
}
