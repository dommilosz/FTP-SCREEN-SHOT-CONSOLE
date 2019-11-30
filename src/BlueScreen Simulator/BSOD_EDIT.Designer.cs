namespace BlueScreen_Simulator
{
    partial class BSOD_EDIT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BSOD_EDIT));
            this.txt_2 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHANGEBACKCOLORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHANGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHANGEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rESETToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sETTINGSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_3 = new System.Windows.Forms.RichTextBox();
            this.txt_4 = new System.Windows.Forms.RichTextBox();
            this.txt_5 = new System.Windows.Forms.RichTextBox();
            this.txt_1 = new System.Windows.Forms.RichTextBox();
            this.Perc_Timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.BSOD_Timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password_in = new System.Windows.Forms.TextBox();
            this.txt_6 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rESETToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_2
            // 
            this.txt_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_2.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_2.DetectUrls = false;
            this.txt_2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_2.Location = new System.Drawing.Point(124, 250);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(1000, 124);
            this.txt_2.TabIndex = 1;
            this.txt_2.Text = "Your PC ran into a problem and needs to restart. We\'re\njust collecting some error" +
    " info, and then we\'ll restart for\nyou";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.cHANGEBACKCOLORToolStripMenuItem,
            this.qRToolStripMenuItem,
            this.sETTINGSToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sAVEToolStripMenuItem,
            this.lOADToolStripMenuItem,
            this.rESETToolStripMenuItem2});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // sAVEToolStripMenuItem
            // 
            this.sAVEToolStripMenuItem.Name = "sAVEToolStripMenuItem";
            this.sAVEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sAVEToolStripMenuItem.Text = "SAVE";
            this.sAVEToolStripMenuItem.Click += new System.EventHandler(this.sAVEToolStripMenuItem_Click);
            // 
            // lOADToolStripMenuItem
            // 
            this.lOADToolStripMenuItem.Name = "lOADToolStripMenuItem";
            this.lOADToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lOADToolStripMenuItem.Text = "LOAD";
            this.lOADToolStripMenuItem.Click += new System.EventHandler(this.lOADToolStripMenuItem_Click);
            // 
            // cHANGEBACKCOLORToolStripMenuItem
            // 
            this.cHANGEBACKCOLORToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHANGEToolStripMenuItem,
            this.rESETToolStripMenuItem});
            this.cHANGEBACKCOLORToolStripMenuItem.Name = "cHANGEBACKCOLORToolStripMenuItem";
            this.cHANGEBACKCOLORToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cHANGEBACKCOLORToolStripMenuItem.Text = "COLOR (BACK)";
            // 
            // cHANGEToolStripMenuItem
            // 
            this.cHANGEToolStripMenuItem.Name = "cHANGEToolStripMenuItem";
            this.cHANGEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cHANGEToolStripMenuItem.Text = "CHANGE";
            this.cHANGEToolStripMenuItem.Click += new System.EventHandler(this.cHANGEToolStripMenuItem_Click);
            // 
            // rESETToolStripMenuItem
            // 
            this.rESETToolStripMenuItem.Name = "rESETToolStripMenuItem";
            this.rESETToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rESETToolStripMenuItem.Text = "RESET";
            this.rESETToolStripMenuItem.Click += new System.EventHandler(this.rESETToolStripMenuItem_Click);
            // 
            // qRToolStripMenuItem
            // 
            this.qRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHANGEToolStripMenuItem1,
            this.rESETToolStripMenuItem1});
            this.qRToolStripMenuItem.Name = "qRToolStripMenuItem";
            this.qRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.qRToolStripMenuItem.Text = "QR";
            // 
            // cHANGEToolStripMenuItem1
            // 
            this.cHANGEToolStripMenuItem1.Name = "cHANGEToolStripMenuItem1";
            this.cHANGEToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.cHANGEToolStripMenuItem1.Text = "CHANGE";
            this.cHANGEToolStripMenuItem1.Click += new System.EventHandler(this.cHANGEToolStripMenuItem1_Click);
            // 
            // rESETToolStripMenuItem1
            // 
            this.rESETToolStripMenuItem1.Name = "rESETToolStripMenuItem1";
            this.rESETToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.rESETToolStripMenuItem1.Text = "RESET";
            this.rESETToolStripMenuItem1.Click += new System.EventHandler(this.rESETToolStripMenuItem1_Click);
            // 
            // sETTINGSToolStripMenuItem
            // 
            this.sETTINGSToolStripMenuItem.Name = "sETTINGSToolStripMenuItem";
            this.sETTINGSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sETTINGSToolStripMenuItem.Text = "SETTINGS";
            this.sETTINGSToolStripMenuItem.Click += new System.EventHandler(this.sETTINGSToolStripMenuItem_Click);
            // 
            // txt_3
            // 
            this.txt_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_3.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_3.DetectUrls = false;
            this.txt_3.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 18F);
            this.txt_3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_3.Location = new System.Drawing.Point(124, 380);
            this.txt_3.Multiline = false;
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(441, 33);
            this.txt_3.TabIndex = 2;
            this.txt_3.Text = "{p}% complete";
            // 
            // txt_4
            // 
            this.txt_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_4.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_4.DetectUrls = false;
            this.txt_4.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_4.Location = new System.Drawing.Point(201, 436);
            this.txt_4.Name = "txt_4";
            this.txt_4.Size = new System.Drawing.Size(1000, 33);
            this.txt_4.TabIndex = 3;
            this.txt_4.Text = "For more information about this issue and possible fixes, visit https://windows.c" +
    "om/stopcode";
            // 
            // txt_5
            // 
            this.txt_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_5.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_5.DetectUrls = false;
            this.txt_5.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_5.Location = new System.Drawing.Point(201, 475);
            this.txt_5.Multiline = false;
            this.txt_5.Name = "txt_5";
            this.txt_5.Size = new System.Drawing.Size(1000, 16);
            this.txt_5.TabIndex = 4;
            this.txt_5.Text = "If you call a support person, give them this info:";
            // 
            // txt_1
            // 
            this.txt_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_1.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_1.DetectUrls = false;
            this.txt_1.Font = new System.Drawing.Font("Microsoft YaHei UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_1.Location = new System.Drawing.Point(124, 69);
            this.txt_1.Multiline = false;
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(1000, 170);
            this.txt_1.TabIndex = 7;
            this.txt_1.Text = ":(";
            // 
            // Perc_Timer
            // 
            this.Perc_Timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1113, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BSOD_Start);
            // 
            // BSOD_Timer
            // 
            this.BSOD_Timer.Interval = 10;
            this.BSOD_Timer.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.Filter = "Save Files (.txt)|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Save Files (.txt)|*.txt";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox7.Location = new System.Drawing.Point(1102, 574);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(86, 23);
            this.textBox7.TabIndex = 17;
            this.textBox7.Text = "33215";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1041, 578);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "password:";
            // 
            // password_in
            // 
            this.password_in.Location = new System.Drawing.Point(5000, 549);
            this.password_in.Name = "password_in";
            this.password_in.Size = new System.Drawing.Size(100, 20);
            this.password_in.TabIndex = 19;
            // 
            // txt_6
            // 
            this.txt_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txt_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_6.ContextMenuStrip = this.contextMenuStrip1;
            this.txt_6.DetectUrls = false;
            this.txt_6.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_6.Location = new System.Drawing.Point(201, 497);
            this.txt_6.Name = "txt_6";
            this.txt_6.Size = new System.Drawing.Size(1000, 137);
            this.txt_6.TabIndex = 5;
            this.txt_6.Text = "Stop code: CRITICAL PROCESS DIED";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1032, 640);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "PREVIEW";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rESETToolStripMenuItem2
            // 
            this.rESETToolStripMenuItem2.Name = "rESETToolStripMenuItem2";
            this.rESETToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.rESETToolStripMenuItem2.Text = "RESET";
            this.rESETToolStripMenuItem2.Click += new System.EventHandler(this.rESETToolStripMenuItem2_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-200, 588);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(88, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(117, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // BSOD_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.password_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_6);
            this.Controls.Add(this.txt_5);
            this.Controls.Add(this.txt_4);
            this.Controls.Add(this.txt_3);
            this.Controls.Add(this.txt_2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BSOD_EDIT";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BSOD_EDIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BSOD_EDIT_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_2;
        private System.Windows.Forms.RichTextBox txt_4;
        private System.Windows.Forms.RichTextBox txt_5;
        private System.Windows.Forms.RichTextBox txt_1;
        private System.Windows.Forms.Timer Perc_Timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer BSOD_Timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password_in;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHANGEBACKCOLORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHANGEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHANGEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rESETToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sETTINGSToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txt_3;
        private System.Windows.Forms.RichTextBox txt_6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem rESETToolStripMenuItem2;
    }
}

