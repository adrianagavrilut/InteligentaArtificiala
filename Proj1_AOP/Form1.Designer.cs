namespace AOP_project
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExplorer = new System.Windows.Forms.Button();
            this.buttonSpawn = new System.Windows.Forms.Button();
            this.buttonTransporter = new System.Windows.Forms.Button();
            this.buttonExploiter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.pictureBox1.Location = new System.Drawing.Point(58, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1602, 747);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.buttonStart.Location = new System.Drawing.Point(1566, 12);
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
            this.label1.Location = new System.Drawing.Point(7, 29);
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
            this.buttonExplorer.Location = new System.Drawing.Point(479, 10);
            this.buttonExplorer.Name = "buttonExplorer";
            this.buttonExplorer.Size = new System.Drawing.Size(211, 64);
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
            this.buttonSpawn.Location = new System.Drawing.Point(58, 9);
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
            this.buttonTransporter.Location = new System.Drawing.Point(991, 9);
            this.buttonTransporter.Name = "buttonTransporter";
            this.buttonTransporter.Size = new System.Drawing.Size(211, 64);
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
            this.buttonExploiter.Location = new System.Drawing.Point(728, 9);
            this.buttonExploiter.Name = "buttonExploiter";
            this.buttonExploiter.Size = new System.Drawing.Size(211, 64);
            this.buttonExploiter.TabIndex = 10;
            this.buttonExploiter.Text = "Exploite";
            this.buttonExploiter.UseVisualStyleBackColor = false;
            this.buttonExploiter.Click += new System.EventHandler(this.buttonExploiter_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(232, 841);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 31);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU-ExtB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(7, 846);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Explorer\'s target:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU-ExtB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(696, 846);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Transporter\'s target:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(585, 840);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 31);
            this.textBox2.TabIndex = 15;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MingLiU-ExtB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(346, 846);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Exploiter\'s target:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(959, 840);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 31);
            this.textBox3.TabIndex = 17;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.textBox4.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(1509, 837);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(151, 35);
            this.textBox4.TabIndex = 20;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MingLiU-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(1361, 842);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "Winnings:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(1699, 899);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSpawn);
            this.Controls.Add(this.buttonTransporter);
            this.Controls.Add(this.buttonExploiter);
            this.Controls.Add(this.buttonExplorer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
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
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExplorer;
        private System.Windows.Forms.Button buttonSpawn;
        private System.Windows.Forms.Button buttonTransporter;
        private System.Windows.Forms.Button buttonExploiter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
    }
}

