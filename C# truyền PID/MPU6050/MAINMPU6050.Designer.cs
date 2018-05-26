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
            this.PbSet = new System.Windows.Forms.Button();
            this.PbConect = new System.Windows.Forms.Button();
            this.Cbcom = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSpeedRotate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.COM = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.zed = new ZedGraph.ZedGraphControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.PbMode = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grbPID = new System.Windows.Forms.GroupBox();
            this.btPID3 = new System.Windows.Forms.Button();
            this.btPID1 = new System.Windows.Forms.Button();
            this.btPID2 = new System.Windows.Forms.Button();
            this.txtKd = new System.Windows.Forms.TextBox();
            this.txtKi = new System.Windows.Forms.TextBox();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.lbKd = new System.Windows.Forms.Label();
            this.lbKi = new System.Windows.Forms.Label();
            this.lbKp = new System.Windows.Forms.Label();
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.gboxControl = new System.Windows.Forms.GroupBox();
            this.btready = new System.Windows.Forms.Button();
            this.btHold = new System.Windows.Forms.Button();
            this.txtDeltaPulse = new System.Windows.Forms.TextBox();
            this.lbDeltaPulse = new System.Windows.Forms.Label();
            this.btReceive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtSA = new System.Windows.Forms.Label();
            this.txtSpeedAngle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPID2 = new System.Windows.Forms.TextBox();
            this.txtPID3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zed1 = new ZedGraph.ZedGraphControl();
            this.zed2 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbPID.SuspendLayout();
            this.gboxControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbSet
            // 
            this.PbSet.BackColor = System.Drawing.Color.Lime;
            this.PbSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbSet.Location = new System.Drawing.Point(39, 83);
            this.PbSet.Name = "PbSet";
            this.PbSet.Size = new System.Drawing.Size(94, 36);
            this.PbSet.TabIndex = 0;
            this.PbSet.Text = "SET";
            this.PbSet.UseVisualStyleBackColor = false;
            this.PbSet.Click += new System.EventHandler(this.PbSet_Click);
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
            this.groupBox1.Controls.Add(this.txtSpeedRotate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAngle);
            this.groupBox1.Controls.Add(this.PbSet);
            this.groupBox1.Controls.Add(this.txtSpeed);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(176, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 160);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONTROL";
            // 
            // txtSpeedRotate
            // 
            this.txtSpeedRotate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeedRotate.Location = new System.Drawing.Point(119, 23);
            this.txtSpeedRotate.Name = "txtSpeedRotate";
            this.txtSpeedRotate.Size = new System.Drawing.Size(33, 26);
            this.txtSpeedRotate.TabIndex = 75;
            this.txtSpeedRotate.Text = "0.0";
            this.txtSpeedRotate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 73;
            this.label5.Text = "A_Rotate";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Lime;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Start.Location = new System.Drawing.Point(39, 125);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(87, 28);
            this.Start.TabIndex = 74;
            this.Start.Text = "START";
            this.Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(16, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 72;
            this.label4.Text = "SPEED";
            // 
            // txtAngle
            // 
            this.txtAngle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngle.Location = new System.Drawing.Point(80, 56);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(53, 26);
            this.txtAngle.TabIndex = 47;
            this.txtAngle.Text = "0.0";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed.Location = new System.Drawing.Point(80, 22);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(33, 26);
            this.txtSpeed.TabIndex = 46;
            this.txtSpeed.Text = "0.0";
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSpeed.TextChanged += new System.EventHandler(this.txtSpeed_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbStatus);
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
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(28, 97);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(99, 22);
            this.lbStatus.TabIndex = 14;
            this.lbStatus.Text = "Disconnect";
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
            this.zed.Location = new System.Drawing.Point(529, 297);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(479, 226);
            this.zed.TabIndex = 16;
           
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // PbMode
            // 
            this.PbMode.BackColor = System.Drawing.Color.Yellow;
            this.PbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbMode.ForeColor = System.Drawing.Color.Red;
            this.PbMode.Location = new System.Drawing.Point(726, 262);
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
            this.label7.Location = new System.Drawing.Point(564, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "sampling time=100ms";
            // 
            // grbPID
            // 
            this.grbPID.Controls.Add(this.btPID3);
            this.grbPID.Controls.Add(this.btPID1);
            this.grbPID.Controls.Add(this.btPID2);
            this.grbPID.Controls.Add(this.txtKd);
            this.grbPID.Controls.Add(this.txtKi);
            this.grbPID.Controls.Add(this.txtKp);
            this.grbPID.Controls.Add(this.lbKd);
            this.grbPID.Controls.Add(this.lbKi);
            this.grbPID.Controls.Add(this.lbKp);
            this.grbPID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPID.ForeColor = System.Drawing.Color.Navy;
            this.grbPID.Location = new System.Drawing.Point(12, 168);
            this.grbPID.Name = "grbPID";
            this.grbPID.Size = new System.Drawing.Size(158, 160);
            this.grbPID.TabIndex = 52;
            this.grbPID.TabStop = false;
            this.grbPID.Text = "PID Parameter";
            // 
            // btPID3
            // 
            this.btPID3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPID3.ForeColor = System.Drawing.Color.Navy;
            this.btPID3.Location = new System.Drawing.Point(105, 125);
            this.btPID3.Name = "btPID3";
            this.btPID3.Size = new System.Drawing.Size(53, 34);
            this.btPID3.TabIndex = 68;
            this.btPID3.Text = "PID3";
            this.btPID3.UseVisualStyleBackColor = true;
            this.btPID3.Click += new System.EventHandler(this.btPID3_Click);
            // 
            // btPID1
            // 
            this.btPID1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPID1.ForeColor = System.Drawing.Color.Navy;
            this.btPID1.Location = new System.Drawing.Point(0, 126);
            this.btPID1.Name = "btPID1";
            this.btPID1.Size = new System.Drawing.Size(52, 34);
            this.btPID1.TabIndex = 47;
            this.btPID1.Text = "PID1";
            this.btPID1.UseVisualStyleBackColor = true;
            this.btPID1.Click += new System.EventHandler(this.btPID1_Click);
            // 
            // btPID2
            // 
            this.btPID2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPID2.ForeColor = System.Drawing.Color.Navy;
            this.btPID2.Location = new System.Drawing.Point(52, 125);
            this.btPID2.Name = "btPID2";
            this.btPID2.Size = new System.Drawing.Size(55, 34);
            this.btPID2.TabIndex = 67;
            this.btPID2.Text = "PID2";
            this.btPID2.UseVisualStyleBackColor = true;
            this.btPID2.Click += new System.EventHandler(this.btPID2_Click);
            // 
            // txtKd
            // 
            this.txtKd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKd.Location = new System.Drawing.Point(43, 96);
            this.txtKd.Name = "txtKd";
            this.txtKd.Size = new System.Drawing.Size(74, 26);
            this.txtKd.TabIndex = 46;
            this.txtKd.Text = "0.0";
            this.txtKd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKi
            // 
            this.txtKi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKi.Location = new System.Drawing.Point(43, 61);
            this.txtKi.Name = "txtKi";
            this.txtKi.Size = new System.Drawing.Size(74, 26);
            this.txtKi.TabIndex = 45;
            this.txtKi.Text = "0.0";
            this.txtKi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKp
            // 
            this.txtKp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKp.Location = new System.Drawing.Point(43, 26);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(74, 26);
            this.txtKp.TabIndex = 44;
            this.txtKp.Text = "4.0";
            this.txtKp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbKd
            // 
            this.lbKd.AutoSize = true;
            this.lbKd.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKd.ForeColor = System.Drawing.Color.Navy;
            this.lbKd.Location = new System.Drawing.Point(0, 99);
            this.lbKd.Name = "lbKd";
            this.lbKd.Size = new System.Drawing.Size(28, 19);
            this.lbKd.TabIndex = 43;
            this.lbKd.Text = "Kd";
            // 
            // lbKi
            // 
            this.lbKi.AutoSize = true;
            this.lbKi.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi.ForeColor = System.Drawing.Color.Navy;
            this.lbKi.Location = new System.Drawing.Point(0, 64);
            this.lbKi.Name = "lbKi";
            this.lbKi.Size = new System.Drawing.Size(25, 19);
            this.lbKi.TabIndex = 42;
            this.lbKi.Text = "Ki";
            // 
            // lbKp
            // 
            this.lbKp.AutoSize = true;
            this.lbKp.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKp.ForeColor = System.Drawing.Color.Navy;
            this.lbKp.Location = new System.Drawing.Point(0, 29);
            this.lbKp.Name = "lbKp";
            this.lbKp.Size = new System.Drawing.Size(28, 19);
            this.lbKp.TabIndex = 41;
            this.lbKp.Text = "Kp";
            // 
            // btRight
            // 
            this.btRight.BackColor = System.Drawing.Color.Lime;
            this.btRight.Location = new System.Drawing.Point(105, 54);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(57, 28);
            this.btRight.TabIndex = 54;
            this.btRight.Text = "R";
            this.btRight.UseVisualStyleBackColor = false;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.BackColor = System.Drawing.Color.Lime;
            this.btLeft.Location = new System.Drawing.Point(3, 54);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(59, 28);
            this.btLeft.TabIndex = 55;
            this.btLeft.Text = "L";
            this.btLeft.UseVisualStyleBackColor = false;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btDown
            // 
            this.btDown.BackColor = System.Drawing.Color.Lime;
            this.btDown.Location = new System.Drawing.Point(49, 84);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(59, 28);
            this.btDown.TabIndex = 57;
            this.btDown.Text = "D";
            this.btDown.UseVisualStyleBackColor = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btUp
            // 
            this.btUp.BackColor = System.Drawing.Color.Lime;
            this.btUp.Location = new System.Drawing.Point(54, 19);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(59, 28);
            this.btUp.TabIndex = 58;
            this.btUp.Text = "U";
            this.btUp.UseVisualStyleBackColor = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // gboxControl
            // 
            this.gboxControl.Controls.Add(this.btready);
            this.gboxControl.Controls.Add(this.btHold);
            this.gboxControl.Controls.Add(this.btUp);
            this.gboxControl.Controls.Add(this.btRight);
            this.gboxControl.Controls.Add(this.btDown);
            this.gboxControl.Controls.Add(this.btLeft);
            this.gboxControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gboxControl.Location = new System.Drawing.Point(176, 178);
            this.gboxControl.Name = "gboxControl";
            this.gboxControl.Size = new System.Drawing.Size(164, 149);
            this.gboxControl.TabIndex = 59;
            this.gboxControl.TabStop = false;
            this.gboxControl.Text = "Control";
            // 
            // btready
            // 
            this.btready.BackColor = System.Drawing.Color.Lime;
            this.btready.Location = new System.Drawing.Point(99, 115);
            this.btready.Name = "btready";
            this.btready.Size = new System.Drawing.Size(59, 28);
            this.btready.TabIndex = 60;
            this.btready.Text = "ready";
            this.btready.UseVisualStyleBackColor = false;
            this.btready.Click += new System.EventHandler(this.btready_Click);
            // 
            // btHold
            // 
            this.btHold.BackColor = System.Drawing.Color.Lime;
            this.btHold.Location = new System.Drawing.Point(10, 118);
            this.btHold.Name = "btHold";
            this.btHold.Size = new System.Drawing.Size(59, 28);
            this.btHold.TabIndex = 59;
            this.btHold.Text = "H";
            this.btHold.UseVisualStyleBackColor = false;
            this.btHold.Click += new System.EventHandler(this.btHold_Click);
            // 
            // txtDeltaPulse
            // 
            this.txtDeltaPulse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaPulse.Location = new System.Drawing.Point(96, 28);
            this.txtDeltaPulse.Name = "txtDeltaPulse";
            this.txtDeltaPulse.Size = new System.Drawing.Size(90, 26);
            this.txtDeltaPulse.TabIndex = 61;
            this.txtDeltaPulse.Text = "4.0";
            this.txtDeltaPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbDeltaPulse
            // 
            this.lbDeltaPulse.AutoSize = true;
            this.lbDeltaPulse.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeltaPulse.ForeColor = System.Drawing.Color.Navy;
            this.lbDeltaPulse.Location = new System.Drawing.Point(2, 35);
            this.lbDeltaPulse.Name = "lbDeltaPulse";
            this.lbDeltaPulse.Size = new System.Drawing.Size(83, 19);
            this.lbDeltaPulse.TabIndex = 48;
            this.lbDeltaPulse.Text = "DeltaPulse";
            // 
            // btReceive
            // 
            this.btReceive.BackColor = System.Drawing.Color.Lime;
            this.btReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btReceive.Location = new System.Drawing.Point(383, 302);
            this.btReceive.Name = "btReceive";
            this.btReceive.Size = new System.Drawing.Size(103, 28);
            this.btReceive.TabIndex = 62;
            this.btReceive.Text = "RECEIVE";
            this.btReceive.UseVisualStyleBackColor = false;
            this.btReceive.Click += new System.EventHandler(this.btReceive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 63;
            this.label1.Text = "PID";
            // 
            // txtPID
            // 
            this.txtPID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID.Location = new System.Drawing.Point(59, 69);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(127, 26);
            this.txtPID.TabIndex = 64;
            this.txtPID.Text = "4.0";
            this.txtPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSA
            // 
            this.txtSA.AutoSize = true;
            this.txtSA.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSA.ForeColor = System.Drawing.Color.Navy;
            this.txtSA.Location = new System.Drawing.Point(215, 35);
            this.txtSA.Name = "txtSA";
            this.txtSA.Size = new System.Drawing.Size(117, 19);
            this.txtSA.TabIndex = 65;
            this.txtSA.Text = "Speed,Angle Ctl";
            // 
            // txtSpeedAngle
            // 
            this.txtSpeedAngle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeedAngle.Location = new System.Drawing.Point(338, 28);
            this.txtSpeedAngle.Name = "txtSpeedAngle";
            this.txtSpeedAngle.Size = new System.Drawing.Size(127, 26);
            this.txtSpeedAngle.TabIndex = 66;
            this.txtSpeedAngle.Text = "4.0";
            this.txtSpeedAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(238, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 67;
            this.label2.Text = "PID2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 68;
            this.label3.Text = "PID3";
            // 
            // txtPID2
            // 
            this.txtPID2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID2.Location = new System.Drawing.Point(338, 73);
            this.txtPID2.Name = "txtPID2";
            this.txtPID2.Size = new System.Drawing.Size(127, 26);
            this.txtPID2.TabIndex = 69;
            this.txtPID2.Text = "4.0";
            this.txtPID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPID3
            // 
            this.txtPID3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID3.Location = new System.Drawing.Point(59, 105);
            this.txtPID3.Name = "txtPID3";
            this.txtPID3.Size = new System.Drawing.Size(127, 26);
            this.txtPID3.TabIndex = 70;
            this.txtPID3.Text = "4.0";
            this.txtPID3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPID3);
            this.groupBox3.Controls.Add(this.txtPID2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSpeedAngle);
            this.groupBox3.Controls.Add(this.txtSA);
            this.groupBox3.Controls.Add(this.txtPID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbDeltaPulse);
            this.groupBox3.Controls.Add(this.txtDeltaPulse);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(6, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 137);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report";
            // 
            // zed1
            // 
            this.zed1.Location = new System.Drawing.Point(367, 25);
            this.zed1.Name = "zed1";
            this.zed1.ScrollGrace = 0D;
            this.zed1.ScrollMaxX = 0D;
            this.zed1.ScrollMaxY = 0D;
            this.zed1.ScrollMaxY2 = 0D;
            this.zed1.ScrollMinX = 0D;
            this.zed1.ScrollMinY = 0D;
            this.zed1.ScrollMinY2 = 0D;
            this.zed1.Size = new System.Drawing.Size(309, 226);
            this.zed1.TabIndex = 72;
            // 
            // zed2
            // 
            this.zed2.Location = new System.Drawing.Point(682, 25);
            this.zed2.Name = "zed2";
            this.zed2.ScrollGrace = 0D;
            this.zed2.ScrollMaxX = 0D;
            this.zed2.ScrollMaxY = 0D;
            this.zed2.ScrollMaxY2 = 0D;
            this.zed2.ScrollMinX = 0D;
            this.zed2.ScrollMinY = 0D;
            this.zed2.ScrollMinY2 = 0D;
            this.zed2.Size = new System.Drawing.Size(326, 226);
            this.zed2.TabIndex = 75;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 535);
            this.Controls.Add(this.zed2);
            this.Controls.Add(this.zed1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btReceive);
            this.Controls.Add(this.gboxControl);
            this.Controls.Add(this.grbPID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PbMode);
            this.Controls.Add(this.zed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbPID.ResumeLayout(false);
            this.grbPID.PerformLayout();
            this.gboxControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PbSet;
        private System.Windows.Forms.Button PbConect;
        private System.Windows.Forms.ComboBox Cbcom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.IO.Ports.SerialPort COM;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer timer1;
        private ZedGraph.ZedGraphControl zed;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button PbMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grbPID;
        private System.Windows.Forms.Button btPID1;
        private System.Windows.Forms.TextBox txtKd;
        private System.Windows.Forms.TextBox txtKi;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.Label lbKd;
        private System.Windows.Forms.Label lbKi;
        private System.Windows.Forms.Label lbKp;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.GroupBox gboxControl;
        private System.Windows.Forms.TextBox txtDeltaPulse;
        private System.Windows.Forms.Button btHold;
        private System.Windows.Forms.Label lbDeltaPulse;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Button btReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label txtSA;
        private System.Windows.Forms.TextBox txtSpeedAngle;
        private System.Windows.Forms.Button btPID3;
        private System.Windows.Forms.Button btPID2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPID2;
        private System.Windows.Forms.TextBox txtPID3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSpeedRotate;
        private ZedGraph.ZedGraphControl zed1;
        private ZedGraph.ZedGraphControl zed2;
        private System.Windows.Forms.Button btready;
    }
}

