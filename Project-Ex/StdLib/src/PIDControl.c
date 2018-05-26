#include "include.h"
double pulsetodegree = 0.555;
float AngleControl=0, set= -2, t= 0.002, invt= 500, tspeed=0.05;
double Pi= 3.141592653589793238462;
float Duongkinh = 0.09; // 9 cm
double Khoangcach =0;
// PID Angle//
float PpartAngle=0, IpartAngle=0,DpartAngle=0; // he so lay Kp nhan sai so
 
extern float KpAngle, KiAngle, KdAngle; // lay tu USART truyen ve 155 0 13
float OutputAngle=0;
float ErrAngle=0, pre_ErrAngle=0;
extern float GyroXRate, GyroYRate;
extern float Angle;
extern float AngleC;
// PID Vantoc
//extern float KpSpeed,  KiSpeed , KdSpeed ;
extern double KpSpeed,  KiSpeed , KdSpeed ;
double KpVantoc =0, KdVantoc =0, KiVantoc=0; // he so lai Kspeed nhan sai so
int i=0;
double Angle_vantoc =0;
float Speed=0, ErrSpeed=0, PreErrSpeed=0;
extern float CSpeed;
extern float PulseR,PulseL;
float DeltaPulse=0, PrePulse=0, Pulse=0;

// PID xoay chieu//
extern double KpRotate, KiRotate , KdRotate ;
double KpAngleRotate=0,KdAngleRotate=0,KiAngleRotate=0;
double AngleRotate=0, AngleRotateDegree =0;
extern float CAngle;
float ErrAngleRotate=0,PreErrAngleRotate=0;
double OutputAngleRotate=0;

//PID tong quat
double AngleControlSpeed=0;
double OutputPID1=0, OutputPID2=0, OutputPID0=0;
uint16_t PWM_period = 500;
//
extern int Run, Start, Receive;
/****************/
double PIDSpeed(float AngleSpeed )
{
 Pulse= (PulseR+PulseL)/2;
 DeltaPulse = Pulse - PrePulse ;
 PrePulse= Pulse; 
//	 DeltaPulse = Pulse;
//	 Pulse = 0;
	 i++;
	 if (i==25)
	 {
	 Speed= DeltaPulse*20; //(pulse/s) deltapulse/ thoi gian la 50ms
	 ErrSpeed= AngleSpeed - Speed;
	 KpVantoc = KpSpeed*ErrSpeed;
	 KdVantoc = KdSpeed*(ErrSpeed-PreErrSpeed)*20;// toc do thay doi cua van toc.
	 KiVantoc += KiSpeed*tspeed ; // thoi gian lay mau la 50ms 0.05
	 Angle_vantoc = KpVantoc + KdVantoc +KiVantoc;
	// AngleSpeed = Angle_vantoc + 1.28;
	 PreErrSpeed=ErrSpeed;
	 i=0;
	 }
	return Angle_vantoc;
}	
	 
double PIDAngle (float OutputS )
{	
AngleControl = OutputS + set;
ErrAngle = Angle - AngleControl;
PpartAngle = KpAngle*ErrAngle;
//DpartAngle = KdAngle*(ErrAngle-pre_ErrAngle)*100;// do h o day  = 0.01s, toc do thay doi goc trong 10ms, hay toc do goc trong 10ms
//Truc X
//DpartAngle = KdAngle*GyroXRate;// van toc goc chinh la toc do sai so cua goc, khac nhau la cong thuc tren tinh 10ms ra van toc con cong thuc nay tuc thoi 1ms se tot hon
//Truc Y
	DpartAngle = KdAngle* GyroYRate; // chu y 2 cai nay phai cung double hoac float
	IpartAngle += KiAngle*t*ErrAngle;// 0.002 o day la kieu double, muon chuyen sang kieu float thi phai ep cho bien t= thoi gian lay mau
  OutputAngle = PpartAngle + DpartAngle + IpartAngle;
  pre_ErrAngle = ErrAngle;
	
return OutputAngle;
}

double PIDRotate (float AngleRotateControl)
{
   AngleRotate = PulseR - PulseL;
	 AngleRotateDegree = AngleRotate * pulsetodegree ;
	 ErrAngleRotate = AngleRotateControl - AngleRotate;
	 KpAngleRotate  = KpRotate*ErrAngleRotate;
	 KdAngleRotate  = KdRotate* (ErrAngleRotate - PreErrAngleRotate)*invt;
	 KiAngleRotate += KiRotate*t;
	 OutputAngleRotate = KpAngleRotate + KdAngleRotate + KiAngleRotate;
	 PreErrAngleRotate = ErrAngleRotate;
	 Khoangcach = ((double)(Pi*Duongkinh)*Pulse/100.0);// Tinh quang duong xuat C#
	return OutputAngleRotate;
}

void   PIDControl (void)
	{
		AngleControlSpeed = PIDSpeed(CSpeed);
		OutputPID1 = PIDAngle(AngleControlSpeed);
		OutputPID2 = PIDRotate(CAngle);
		OutputPID0 = OutputPID1 + OutputPID2;
		if (OutputPID1 >= PWM_period) OutputPID1 = PWM_period-5 ;
	if (OutputPID1 <= -PWM_period) OutputPID1 = -PWM_period+ 5;
		if (OutputPID0 >= PWM_period) OutputPID0 = PWM_period-5 ;
	if (OutputPID0 <= -PWM_period) OutputPID0 = -PWM_period+ 5;
		if (Angle <= 40 && Angle >=-40)
	 {
		 if (OutputPID1 <0 && OutputPID0 <0 )
		 {
			 TIM4->CCR1 = -OutputPID1;
			 TIM12->CCR1 = -OutputPID0;
			 GPIO_SetBits(GPIOD,GPIO_Pin_11);
			 GPIO_ResetBits(GPIOB,GPIO_Pin_15);
		 }
		 else if (OutputPID1 <0 && OutputPID0>0)
		 {
		 TIM4->CCR1 = -OutputPID1;
			 TIM12->CCR1 = OutputPID0;
			 GPIO_SetBits(GPIOD,GPIO_Pin_11);
			 GPIO_SetBits(GPIOB,GPIO_Pin_15);
		 }
		else if (OutputPID1 >0 && OutputPID0 < 0)
		 {
		 TIM4->CCR1 = OutputPID1;
			 TIM12->CCR1 = -OutputPID0;
			 GPIO_ResetBits(GPIOD,GPIO_Pin_11);
			 GPIO_ResetBits(GPIOB,GPIO_Pin_15);
		 }
		 else 
		 {
			 TIM4->CCR1 = OutputPID1;
			 TIM12->CCR1 = OutputPID0;
			 GPIO_ResetBits(GPIOD,GPIO_Pin_11);
			 GPIO_SetBits(GPIOB,GPIO_Pin_15);
		 }
		}
		else
		{
			TIM4->CCR1 = 0;
			TIM12->CCR1 = 0;
		}   
		
//		if ( Run==1 )
//		{
//			AngleRotate=0;;
//			Vantoc_Dat = Cspeed;
//			AngleRotate_Ctrl =Pulse-PulseL;
//			Run =8;
//		}
//		
//	 else if (Run ==0)		
//	 {
//		 AngleRotate=0;
//		 Vantoc_Dat = 0;
//		 AngleRotate_Ctrl = 0;
//	 }
//	 else if (Run ==2)		
//	 {
//		 AngleRotate=0;
//		 Vantoc_Dat = 0;
//		 AngleRotate_Ctrl = Pulse - PulseL;
//		 Run = 8;
//	 }
//	 else if (Run ==3)// backward
//	 {
//	 AngleRotate=0;
//	 Vantoc_Dat = -Cspeed*1.1;
//	 AngleRotate_Ctrl = Pulse-PulseL;
//	 Run=8;
//	}
//	 else if (Run ==4)// turn left
//	 {
//	 Vantoc_Dat = Cspeedrotate;
//	 AngleRotate_Ctrl =Pulse - PulseL+ CAngle;
//	 Run = 8;
//	}
//	 else if (Run ==5)// turn right
//	 {
//		
//	 Vantoc_Dat = Cspeedrotate;
//	 AngleRotate_Ctrl =Pulse - PulseL -CAngle;
//		 Run=9;
//	}

}



