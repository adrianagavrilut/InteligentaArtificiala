namespace Roboti
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExplorer = new System.Windows.Forms.Button();
            this.buttonSpawn = new System.Windows.Forms.Button();
            this.buttonTransporter = new System.Windows.Forms.Button();
            this.buttonExploiter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.pictureBox1.Location = new System.Drawing.Point(88, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1393, 793);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(1501, 86);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(111, 796);
            this.listBox1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 70;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("MingLiU-ExtB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStart.Location = new System.Drawing.Point(1387, 11);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(94, 62);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start Stop";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            // 
            // buttonExplorer
            // 
            this.buttonExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExplorer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExplorer.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExplorer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonExplorer.Location = new System.Drawing.Point(589, 9);
            this.buttonExplorer.Name = "buttonExplorer";
            this.buttonExplorer.Size = new System.Drawing.Size(146, 64);
            this.buttonExplorer.TabIndex = 9;
            this.buttonExplorer.Text = "Explore";
            this.buttonExplorer.UseVisualStyleBackColor = false;
            this.buttonExplorer.Click += new System.EventHandler(this.buttonExplorer_Click);
            // 
            // buttonSpawn
            // 
            this.buttonSpawn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSpawn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSpawn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSpawn.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSpawn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSpawn.Location = new System.Drawing.Point(88, 9);
            this.buttonSpawn.Name = "buttonSpawn";
            this.buttonSpawn.Size = new System.Drawing.Size(145, 64);
            this.buttonSpawn.TabIndex = 12;
            this.buttonSpawn.Text = "Spawn resources";
            this.buttonSpawn.UseVisualStyleBackColor = false;
            this.buttonSpawn.Click += new System.EventHandler(this.buttonSpawn_Click);
            // 
            // buttonTransporter
            // 
            this.buttonTransporter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTransporter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTransporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransporter.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTransporter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTransporter.Location = new System.Drawing.Point(914, 9);
            this.buttonTransporter.Name = "buttonTransporter";
            this.buttonTransporter.Size = new System.Drawing.Size(145, 64);
            this.buttonTransporter.TabIndex = 11;
            this.buttonTransporter.Text = "Transport";
            this.buttonTransporter.UseVisualStyleBackColor = false;
            this.buttonTransporter.Click += new System.EventHandler(this.buttonTransporter_Click);
            // 
            // buttonExploiter
            // 
            this.buttonExploiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExploiter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExploiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExploiter.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExploiter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonExploiter.Location = new System.Drawing.Point(752, 9);
            this.buttonExploiter.Name = "buttonExploiter";
            this.buttonExploiter.Size = new System.Drawing.Size(143, 64);
            this.buttonExploiter.TabIndex = 10;
            this.buttonExploiter.Text = "Exploite";
            this.buttonExploiter.UseVisualStyleBackColor = false;
            this.buttonExploiter.Click += new System.EventHandler(this.buttonExploiter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(1706, 989);
            this.Controls.Add(this.buttonSpawn);
            this.Controls.Add(this.buttonTransporter);
            this.Controls.Add(this.buttonExploiter);
            this.Controls.Add(this.buttonExplorer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExplorer;
        private System.Windows.Forms.Button buttonSpawn;
        private System.Windows.Forms.Button buttonTransporter;
        private System.Windows.Forms.Button buttonExploiter;
    }
}

