namespace MPU6050
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
            this.PbStart = new System.Windows.Forms.Button();
            this.PbConect = new System.Windows.Forms.Button();
            this.Cbcom = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbss = new System.Windows.Forms.Label();
            this.COM = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.zed = new ZedGraph.ZedGraphControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.PbMode = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbStart
            // 
            this.PbStart.BackColor = System.Drawing.Color.Lime;
            this.PbStart.Location = new System.Drawing.Point(13, 26);
            this.PbStart.Name = "PbStart";
            this.PbStart.Size = new System.Drawing.Size(84, 28);
            this.PbStart.TabIndex = 0;
            this.PbStart.Text = "START";
            this.PbStart.UseVisualStyleBackColor = false;
            this.PbStart.Click += new System.EventHandler(this.PbStart_Click);
            // 
            // PbConect
            // 
            this.PbConect.BackColor = System.Drawing.Color.Red;
            this.PbConect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PbConect.Location = new System.Drawing.Point(26, 63);
            this.PbConect.Name = "PbConect";
            this.PbConect.Size = new System.Drawing.Size(98, 31);
            this.PbConect.TabIndex = 1;
            this.PbConect.Text = "CONECT";
            this.PbConect.UseVisualStyleBackColor = false;
            this.PbConect.Click += new System.EventHandler(this.PbConect_Click);
            // 
            // Cbcom
            // 
            this.Cbcom.FormattingEnabled = true;
            this.Cbcom.Location = new System.Drawing.Point(16, 20);
            this.Cbcom.Name = "Cbcom";
            this.Cbcom.Size = new System.Drawing.Size(121, 28);
            this.Cbcom.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Exit);
            this.groupBox1.Controls.Add(this.PbStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(176, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 140);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONTROL";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Lime;
            this.Exit.Location = new System.Drawing.Point(13, 68);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(84, 28);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "EXIT";
            this.Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lbss);
            this.groupBox2.Controls.Add(this.Cbcom);
            this.groupBox2.Controls.Add(this.PbConect);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 143);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM PORT";
            // 
            // Lbss
            // 
            this.Lbss.AutoSize = true;
            this.Lbss.Location = new System.Drawing.Point(28, 97);
            this.Lbss.Name = "Lbss";
            this.Lbss.Size = new System.Drawing.Size(99, 22);
            this.Lbss.TabIndex = 14;
            this.Lbss.Text = "Disconnect";
            // 
            // COM
            // 
            this.COM.BaudRate = 115200;
            this.COM.DtrEnable = true;
            this.COM.ReadTimeout = 3000;
            this.COM.RtsEnable = true;
            this.COM.WriteTimeout = 500;
            this.COM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ONCOM);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // zed
            // 
            this.zed.Location = new System.Drawing.Point(364, 29);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(560, 294);
            this.zed.TabIndex = 16;
            // 
            // PbMode
            // 
            this.PbMode.BackColor = System.Drawing.Color.Yellow;
            this.PbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbMode.ForeColor = System.Drawing.Color.Red;
            this.PbMode.Location = new System.Drawing.Point(118, 176);
            this.PbMode.Name = "PbMode";
            this.PbMode.Size = new System.Drawing.Size(103, 30);
            this.PbMode.TabIndex = 18;
            this.PbMode.Text = "COMPACT";
            this.PbMode.UseVisualStyleBackColor = false;
            this.PbMode.Click += new System.EventHandler(this.PbMode_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(542, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "sampling time=25ms";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(56, 232);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(216, 20);
            this.txtReceive.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 346);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PbMode);
            this.Controls.Add(this.zed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PbStart;
        private System.Windows.Forms.Button PbConect;
        private System.Windows.Forms.ComboBox Cbcom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.IO.Ports.SerialPort COM;
        private System.Windows.Forms.Label Lbss;
        private System.Windows.Forms.Timer timer1;
        private ZedGraph.ZedGraphControl zed;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button PbMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox txtReceive;
    }
}

