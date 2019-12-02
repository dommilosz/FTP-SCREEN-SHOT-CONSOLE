namespace BlueScreen_Simulator
{
    partial class Settings
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmax = new System.Windows.Forms.NumericUpDown();
            this.tmin = new System.Windows.Forms.NumericUpDown();
            this.cmax = new System.Windows.Forms.NumericUpDown();
            this.cmin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.EFont = new System.Windows.Forms.NumericUpDown();
            this.QRFont = new System.Windows.Forms.NumericUpDown();
            this.MFont = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.unsmode = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFont)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(391, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 15;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.EFont);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.QRFont);
            this.groupBox2.Controls.Add(this.tmax);
            this.groupBox2.Controls.Add(this.MFont);
            this.groupBox2.Controls.Add(this.tmin);
            this.groupBox2.Controls.Add(this.cmax);
            this.groupBox2.Controls.Add(this.cmin);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 132);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(85, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(85, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "max";
            // 
            // tmax
            // 
            this.tmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmax.Location = new System.Drawing.Point(138, 105);
            this.tmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmax.Name = "tmax";
            this.tmax.Size = new System.Drawing.Size(75, 16);
            this.tmax.TabIndex = 37;
            // 
            // tmin
            // 
            this.tmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmin.Location = new System.Drawing.Point(138, 83);
            this.tmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmin.Name = "tmin";
            this.tmin.Size = new System.Drawing.Size(75, 16);
            this.tmin.TabIndex = 36;
            // 
            // cmax
            // 
            this.cmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmax.Location = new System.Drawing.Point(138, 44);
            this.cmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmax.Name = "cmax";
            this.cmax.Size = new System.Drawing.Size(75, 16);
            this.cmax.TabIndex = 35;
            // 
            // cmin
            // 
            this.cmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmin.Location = new System.Drawing.Point(138, 22);
            this.cmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmin.Name = "cmin";
            this.cmin.Size = new System.Drawing.Size(75, 16);
            this.cmin.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(85, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(85, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Percent";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(413, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 196);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.unsmode);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(286, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 177);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EXECUTION";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(3, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 30);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Close BSOD\r\nafter execution";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button6.Location = new System.Drawing.Point(3, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(118, 22);
            this.button6.TabIndex = 30;
            this.button6.Text = "< TEST CMD";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // EFont
            // 
            this.EFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EFont.Location = new System.Drawing.Point(347, 84);
            this.EFont.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.EFont.Name = "EFont";
            this.EFont.Size = new System.Drawing.Size(54, 16);
            this.EFont.TabIndex = 21;
            // 
            // QRFont
            // 
            this.QRFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QRFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QRFont.Location = new System.Drawing.Point(347, 61);
            this.QRFont.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.QRFont.Name = "QRFont";
            this.QRFont.Size = new System.Drawing.Size(54, 16);
            this.QRFont.TabIndex = 20;
            // 
            // MFont
            // 
            this.MFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MFont.Location = new System.Drawing.Point(347, 38);
            this.MFont.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.MFont.Name = "MFont";
            this.MFont.Size = new System.Drawing.Size(54, 16);
            this.MFont.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(219, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 60);
            this.label7.TabIndex = 22;
            this.label7.Text = "Main Font\r\nQR Text Font\r\nEmoticon Font";
            // 
            // unsmode
            // 
            this.unsmode.AutoSize = true;
            this.unsmode.Checked = true;
            this.unsmode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unsmode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.unsmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unsmode.Location = new System.Drawing.Point(3, 127);
            this.unsmode.Name = "unsmode";
            this.unsmode.Size = new System.Drawing.Size(118, 17);
            this.unsmode.TabIndex = 33;
            this.unsmode.Text = "unsafe mode";
            this.unsmode.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(283, 177);
            this.textBox1.TabIndex = 32;
            this.textBox1.WordWrap = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(413, 360);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown tmax;
        public System.Windows.Forms.NumericUpDown tmin;
        public System.Windows.Forms.NumericUpDown cmax;
        public System.Windows.Forms.NumericUpDown cmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.NumericUpDown EFont;
        public System.Windows.Forms.NumericUpDown QRFont;
        public System.Windows.Forms.NumericUpDown MFont;
        public System.Windows.Forms.CheckBox unsmode;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBox1;
    }
}