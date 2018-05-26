using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using ZedGraph;
using System.Globalization;



namespace MPU6050
{
    public partial class Form1 : Form
    {
        public double Acc_Angle_Final, Angle;
        public Form1()
        {
            InitializeComponent();
        }

        int TickStart, intMode = 1;


        private void Form1_Load(object sender, EventArgs e)
        {
            // Khoa het cac Texbox va Button khi chua Connect cong COM
            PbSet.Enabled = false;
            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "ANGLE";
            myPane.XAxis.Title.Text = "Time(s)";
            myPane.YAxis.Title.Text = "Angle(degree)";

            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(60000);
            RollingPointPairList list2 = new RollingPointPairList(60000);

            LineItem curve = myPane.AddCurve("Angle_Ctrl_0", list, Color.Yellow, SymbolType.None);
            LineItem curve1 = myPane.AddCurve(" Angle", list1, Color.Blue, SymbolType.None);
            LineItem curve2 = myPane.AddCurve("Angle_Ctl", list2, Color.Red, SymbolType.None);
            //  timer1.Interval = 10;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            zed.AxisChange();
            TickStart = Environment.TickCount;
            //so222222222222222222222222222222222222222222//
            GraphPane myPane1 = zed1.GraphPane;
            myPane1.Title.Text = "VITRI";
            myPane1.XAxis.Title.Text = "time(s)";
            myPane1.YAxis.Title.Text = "khoang cach (m)";

            RollingPointPairList list3 = new RollingPointPairList(60000);
            RollingPointPairList list4 = new RollingPointPairList(60000);
            RollingPointPairList list5 = new RollingPointPairList(60000);

            LineItem curve3 = myPane1.AddCurve("zero", list3, Color.Yellow, SymbolType.None);
            LineItem curve4 = myPane1.AddCurve(" zero", list4, Color.Blue, SymbolType.None);
            LineItem curve5 = myPane1.AddCurve("khoangcach", list5, Color.Red, SymbolType.None);
            //  timer1.Interval = 10;
            myPane1.XAxis.Scale.Min = 0;
            myPane1.XAxis.Scale.Max = 30;
            myPane1.XAxis.Scale.MinorStep = 3;
            myPane1.XAxis.Scale.MajorStep = 5;
            //myPane1.YAxis.Scale.Min = -6;
            //myPane1.YAxis.Scale.Max = 6;
            //myPane1.YAxis.Scale.MinorStep = 0.5;
            //myPane1.YAxis.Scale.MajorStep = 1;
            zed1.AxisChange();
            //so 3333333333333333333 goc
            GraphPane myPane2 = zed2.GraphPane;
            myPane2.Title.Text = "GOCXOAY";
            myPane2.XAxis.Title.Text = "time(s)";
            myPane2.YAxis.Title.Text = "Goc (DEGREE)";

            RollingPointPairList list6 = new RollingPointPairList(60000);
            RollingPointPairList list7 = new RollingPointPairList(60000);
            RollingPointPairList list8 = new RollingPointPairList(60000);

            LineItem curve6 = myPane2.AddCurve("zero", list6, Color.Yellow, SymbolType.None);
            LineItem curve7 = myPane2.AddCurve(" zero", list7, Color.Blue, SymbolType.None);
            LineItem curve8 = myPane2.AddCurve("khoangcach", list8, Color.Red, SymbolType.None);
            //  timer1.Interval = 10;
            myPane2.XAxis.Scale.Min = 0;
            myPane2.XAxis.Scale.Max = 30;
            myPane2.XAxis.Scale.MinorStep = 3;
            myPane2.XAxis.Scale.MajorStep = 5;

            zed2.AxisChange();

        }

        private void PbConect_Click(object sender, EventArgs e)
        {

            if (lbStatus.Text == "Disconnect")
            {
                COM.PortName = Cbcom.Text; //Chon cong COM ket voi voi VXL
                COM.Open();
                lbStatus.Text = "Connect";
                PbConect.Text = "Disconnect";
                // Sau khi nhan Connect cho phep nhap du lieu de gui len VXL
                PbSet.Enabled = true;
            }
            else
            {
                // Khi tat cong Ket noi ta set lai gia tri ban dau nhu khi Form Load
                COM.Close();
                lbStatus.Text = "Disconnect";
                PbConect.Text = "Connect";
                PbSet.Enabled = false;
            }

        }
        // Su dung Timer 1 de cap nhat ten cac cong COM khi dang ket noi
        int intlen = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (intlen != ports.Length)
            {
                intlen = ports.Length;
                Cbcom.Items.Clear();
                for (int j = 0; j < intlen; j++)
                {
                    Cbcom.Items.Add(ports[j]);
                }
                Cbcom.Text = ports[0];
            }
            Draw("0", data, data1);
            Draw1("0", "0", quangduong);
            Draw2("0", "0", goc);
            txtDeltaPulse.Text = pulse;
            txtPID.Text = pid1;
            txtSpeedAngle.Text = speedangle;
            txtPID2.Text = pid2;
            txtPID3.Text = pid3;
        }


        string s;


        // int x = 0;
        string data = "0", data1 = "0", pulse = "0", quangduong = "0", goc = "0";
        string strReceive = "0", pid1 = "0", speedangle = "0", pid2 = "0", pid3 = "0";
        private void ONCOM(object sender, SerialDataReceivedEventArgs e)
        {

            string[] strArray = { "0" };
            strReceive = COM.ReadLine();
            if (strReceive != null)
            {
                strArray = strReceive.Split(',');
                if (strArray[0] == "PID1")
                {
                    pid1 = strReceive;
                }
                else if
                    (strArray[0] == "PID2")
                {
                    pid2 = strReceive;
                }
                else if
                (strArray[0] == "PID3")
                {
                    pid3 = strReceive;
                }
                else if (strArray[0] == "S")
                {
                    speedangle = strReceive;
                }
                else if (Start.Text == "STOP")
                {
                    data = strArray[0]; // Angle
                    data1 = strArray[1];// Angle_Ctl
                    pulse = strArray[2];//deltapulse
                    quangduong = strArray[3];
                    goc = strArray[4];
                }
            }
        }






        private void PbMode_Click(object sender, EventArgs e)
        {
            if (PbMode.Text == "SCROLL")
            {
                intMode = 1;
                PbMode.Text = "COMPACT";
            }
            else
            {
                intMode = 0;
                PbMode.Text = "SCROLL";
            }

        }

        private void PbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Draw(string setpoint, string current, string setpoint1)
        {
            double intsetpoint;
            double intcurrent;
            double intsetpoint1;
            double.TryParse(setpoint, out intsetpoint);
            double.TryParse(current, NumberStyles.Number, CultureInfo.InvariantCulture, out intcurrent);
            double.TryParse(setpoint1, NumberStyles.Number, CultureInfo.InvariantCulture, out intsetpoint1);
            if (zed.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zed.GraphPane.CurveList[0] as LineItem;
            LineItem curve1 = zed.GraphPane.CurveList[1] as LineItem;
            LineItem curve2 = zed.GraphPane.CurveList[2] as LineItem;
            if (curve == null)
                return;
            if (curve1 == null)
                return;
            if (curve2 == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            if (list == null)
                return;
            if (list1 == null)
                return;
            if (list2 == null)
                return;
            double time = (Environment.TickCount - TickStart) / 250.0;// thoi gian tinh theo ms

            list.Add(time, intsetpoint);
            list1.Add(time, intcurrent);
            list2.Add(time, intsetpoint1);

            Scale xScale = zed.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (intMode == 1)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }
                else
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }
            zed.AxisChange();
            zed.Invalidate();
        }
        private void Draw1(string setpoint, string current, string setpoint1)
        {
            double intsetpoint;
            double intcurrent;
            double intsetpoint1;
            double.TryParse(setpoint, out intsetpoint);
            double.TryParse(current, NumberStyles.Number, CultureInfo.InvariantCulture, out intcurrent);
            double.TryParse(setpoint1, NumberStyles.Number, CultureInfo.InvariantCulture, out intsetpoint1);
            if (zed1.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve3 = zed1.GraphPane.CurveList[0] as LineItem;
            LineItem curve4 = zed1.GraphPane.CurveList[1] as LineItem;
            LineItem curve5 = zed1.GraphPane.CurveList[2] as LineItem;
            if (curve3 == null)
                return;
            if (curve4 == null)
                return;
            if (curve5 == null)
                return;

            IPointListEdit list3 = curve3.Points as IPointListEdit;
            IPointListEdit list4 = curve4.Points as IPointListEdit;
            IPointListEdit list5 = curve5.Points as IPointListEdit;
            if (list3 == null)
                return;
            if (list4 == null)
                return;
            if (list5 == null)
                return;
            double time = (Environment.TickCount - TickStart) / 250.0;// thoi gian tinh theo ms

            list3.Add(time, intsetpoint);
            list4.Add(time, intcurrent);
            list5.Add(time, intsetpoint1);

            Scale xScale = zed1.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (intMode == 1)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }
                else
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }
            zed1.AxisChange();
            zed1.Invalidate();
        }
        private void Draw2(string setpoint, string current, string setpoint1)
        {
            double intsetpoint;
            double intcurrent;
            double intsetpoint1;
            double.TryParse(setpoint, out intsetpoint);
            double.TryParse(current, NumberStyles.Number, CultureInfo.InvariantCulture, out intcurrent);
            double.TryParse(setpoint1, NumberStyles.Number, CultureInfo.InvariantCulture, out intsetpoint1);
            if (zed2.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve6 = zed2.GraphPane.CurveList[0] as LineItem;
            LineItem curve7 = zed2.GraphPane.CurveList[1] as LineItem;
            LineItem curve8 = zed2.GraphPane.CurveList[2] as LineItem;
            if (curve6 == null)
                return;
            if (curve7 == null)
                return;
            if (curve8 == null)
                return;

            IPointListEdit list6 = curve6.Points as IPointListEdit;
            IPointListEdit list7 = curve7.Points as IPointListEdit;
            IPointListEdit list8 = curve8.Points as IPointListEdit;
            if (list6 == null)
                return;
            if (list7 == null)
                return;
            if (list8 == null)
                return;
            double time = (Environment.TickCount - TickStart) / 250.0;// thoi gian tinh theo ms

            list6.Add(time, intsetpoint);
            list7.Add(time, intcurrent);
            list8.Add(time, intsetpoint1);

            Scale xScale = zed2.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (intMode == 1)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }
                else
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }
            zed2.AxisChange();
            zed2.Invalidate();
        }


        private void btUp_Click(object sender, EventArgs e)
        {
            string strsent1 = "1";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent1);
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            string strsent4 = "4";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent4);
            }
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            string strsent5 = "5";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent5);
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            string strsent3 = "3";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent3);
            }
        }

        private void btHold_Click(object sender, EventArgs e)
        {
            string strsent2 = "2";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent2);
            }
        }



        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void btReceive_Click(object sender, EventArgs e)
        {
            string strsent9 = "9";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent9);
            }

        }







        private void btready_Click(object sender, EventArgs e)
        {
            string strsent0 = "0";
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(strsent0);
            }
        }

        private void PbSet_Click(object sender, EventArgs e)
        {
            string s = "0", speed = "0", angle = "0", speedrotate = "0";
            speed = txtSpeed.Text;
            angle = txtAngle.Text;
            speedrotate = txtSpeedRotate.Text;
            s = "S" + "," + speed + "," + angle + "," + speedrotate;
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(s);
            }
        }



        private void Start_Click(object sender, EventArgs e)
        {
            string start = "8";
            //if (lbStatus.Text == "Connect")
            //{
            //    COM.WriteLine(start);
            //}
            if (Start.Text == "START")
            {
                Start.Text = "STOP";
                start = "8";
                COM.WriteLine(start);
            }
            else
            {
                Start.Text = "START";
                s = "7";
                COM.WriteLine(s);
            }
        }

        private void btPID1_Click(object sender, EventArgs e)
        {
            string pid1 = "0", kp = "0", ki = "0", kd = "0";
            kp = txtKp.Text;
            ki = txtKi.Text;
            kd = txtKd.Text;
            pid1 = "PID1" + "," + kp + "," + ki + "," + kd;
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(pid1);
            }
        }

        private void btPID2_Click(object sender, EventArgs e)
        {
            string pid2 = "0", kp = "0", ki = "0", kd = "0";
            kp = txtKp.Text;
            ki = txtKi.Text;
            kd = txtKd.Text;
            pid2 = "PID2" + "," + kp + "," + ki + "," + kd;
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(pid2);
            }
        }

        private void btPID3_Click(object sender, EventArgs e)
        {
            string pid3 = "0", kp = "0", ki = "0", kd = "0";
            kp = txtKp.Text;
            ki = txtKi.Text;
            kd = txtKd.Text;
            pid3 = "PID3" + "," + kp + "," + ki + "," + kd;
            if (lbStatus.Text == "Connect")
            {
                COM.WriteLine(pid3);
            }
        }
    }
}
