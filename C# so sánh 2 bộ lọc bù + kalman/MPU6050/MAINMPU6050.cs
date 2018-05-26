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

        int TickStart, intMode=1;


        private void Form1_Load(object sender, EventArgs e)
        {
            // Khoa het cac Texbox va Button khi chua Connect cong COM
            PbStart.Enabled = false;

            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "ANGLE";
            myPane.XAxis.Title.Text = "Time,Seconds";
            myPane.YAxis.Title.Text = "Angle";

            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(60000);
            RollingPointPairList list2 = new RollingPointPairList(60000);

            LineItem curve = myPane.AddCurve("Diem zero", list, Color.Yellow, SymbolType.None);
            LineItem curve1 = myPane.AddCurve(" AngleKalman", list1, Color.Blue, SymbolType.None);
            LineItem curve2 = myPane.AddCurve("AngleCtrl or AngleComplem", list2, Color.Red, SymbolType.None);
          //  timer1.Interval = 10;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            zed.AxisChange();

            TickStart = Environment.TickCount;
        }

        private void PbConect_Click(object sender, EventArgs e)
        {
            
            if (Lbss.Text == "Disconnect")
            {
                COM.PortName = Cbcom.Text; //Chon cong COM ket voi voi VXL
                COM.Open();
                Lbss.Text = "Connect";
                PbConect.Text = "Disconnect";
                // Sau khi nhan Connect cho phep nhap du lieu de gui len VXL
                PbStart.Enabled = true;
            }
            else
            {
                // Khi tat cong Ket noi ta set lai gia tri ban dau nhu khi Form Load
                COM.Close();
                Lbss.Text = "Disconnect";
                PbConect.Text = "Connect";
                PbStart.Enabled = false;
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
            Draw("0",data,data1);
        }
        
        
        string s;
        
        private void PbStart_Click(object sender, EventArgs e)
        {
            if (PbStart.Text == "START")
            {
                //PbStart.Text = "STOP";
                s = "9";
                COM.WriteLine(s);
            }
            //else
            //{
            //    PbStart.Text = "START";
            //    s = "7";
            //    COM.WriteLine(s);
            //}
        }

        int x = 0;
        string data="0", data1="0";
          string strReceive = "0";
        private void ONCOM(object sender, SerialDataReceivedEventArgs e)
        {

            string[] strArray = {"0"};
            strReceive = COM.ReadLine();
            if (strReceive != null)
            {
                strArray = strReceive.Split(',');
               
                    data = strArray[0]; // Angle
                    data1 = strArray[1];// Angle_kalman
             
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
            if(zed.GraphPane.CurveList.Count <=0)
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

            IPointListEdit list =curve.Points as IPointListEdit;
            IPointListEdit list1=curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            if (list == null)
                return;
            if (list1 == null)
                return;
            if (list2 == null)
                return;
            double time = (Environment.TickCount -TickStart ) / 250.0 ;// thoi gian tinh theo ms

            list.Add(time,intsetpoint);
            list1.Add(time,intcurrent);
            list2.Add(time, intsetpoint1);

            Scale xScale = zed.GraphPane.XAxis.Scale;
            if( time > xScale.Max-xScale.MajorStep)
            {
                if (intMode ==1)
                {
                    xScale.Max = time +xScale.MajorStep;
                    xScale.Min= xScale.Max-30.0;
                }
                else
                {
                    xScale.Max=time+xScale.MajorStep;
                    xScale.Min=0;
                }
            }
            zed.AxisChange();
            zed.Invalidate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        }
}
