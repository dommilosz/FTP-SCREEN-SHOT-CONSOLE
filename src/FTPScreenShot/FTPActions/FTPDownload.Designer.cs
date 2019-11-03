namespace FTPScreenShot
{
    partial class FTPDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ftpImage1 = new FTPScreenShot.Controls.FTPImage();
            this.SuspendLayout();
            // 
            // ftpImage1
            // 
            this.ftpImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftpImage1.Location = new System.Drawing.Point(0, 0);
            this.ftpImage1.Name = "ftpImage1";
            this.ftpImage1.Size = new System.Drawing.Size(436, 259);
            this.ftpImage1.TabIndex = 0;
            // 
            // FTPDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 259);
            this.Controls.Add(this.ftpImage1);
            this.Name = "FTPDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloads";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.FTPImage ftpImage1;
    }
}