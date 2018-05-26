	#include "include.h"
//#include <stdio.h>
//#include "stm32f4xx.h"
//#include "cambiengoc.h"
//#include "Timer.h"
float GyroOffset;
//UART
uint8_t buffer[30]={0};
uint8_t buffer2[30]={0};
uint8_t buffer1[30]={0};
uint8_t buffer3[30]={0};
uint8_t buffer4[30]={0};
uint8_t buffer5[30]={0};
uint8_t buffer6[2]={0};
uint8_t strsent0[100] = {0};
uint8_t strsent1[100] = {0};
uint8_t strsent2[100] = {0};
uint8_t strsent3[100] = {0};
uint8_t strsent[100] = {0};
extern float AngleControlSpeed;
extern float Angle,AngleC;
extern int Receive;
extern double AngleRotate,AngleRotateDegree,Khoangcach;
float AccYSetAngle, AccXSetAngle;
extern double invPi;
 s16 b[6]={0};
 //float l;
//
int main (void)
{
	I2C_Configuration();
	MPU6050_Initialize();
	//GyroOffset = CalibGyro();
	/********code thiet lap  tu dau goc x_Angle de su dung Kalman*******/
	/*doan theo truc Y*/
	MPU6050_GetRawAccelTempGyro(b);
	AccYSetAngle = atan2( b[2], -b[0]) *180*invPi;
	//l = atan2 (sqrt (3),1)*180*invPi;
	SetAngle(AccYSetAngle);
	delay_01ms(500);
//	//	/*doan theo truc X*/
//	MPU6050_GetRawAccelTempGyro(b);
//	AccXSetAngle = (atan2(b[1], b[2]) )*180*invPi;
//	SetAngle(AccXSetAngle);
	/***************************************************************************************/
	Timer_2_1ms_Angle();
	Init_DIR();
	TIM_PWM0_Configuration(); //tim12 Pb14/pw0
	TIM_PWM1_Configuration();// timer 4 PD12 /pw1 banh con hoat dong chan dao chieu PD1
	Timer_3_10ms_PID();
	Config_EnB1 ();
  Config_EnB0 ();
  EXTILine4_Config() ;
  EXTILine9_Config();
	Usart_Configuration(115200);
	while(1)
		{
	if (Receive==1)
		{
	/*		******** Usart dieu khien vi tri************/
	Double2Str(Angle,3,buffer1);
	sprintf((char*)buffer2,"%2.3f",AngleControlSpeed);
	sprintf((char*)buffer3,"%2.3f",AngleRotate);
	sprintf((char*)buffer4,"%2.3f",Khoangcach);
	sprintf((char*)buffer5,"%2.3f",AngleRotateDegree);
	String_Merger(buffer1,buffer2,',',strsent0);
	String_Merger(strsent0,buffer3,',',strsent1);
	String_Merger(strsent1,buffer4,',',strsent2);
	String_Merger(strsent2,buffer5,',',strsent);
	//String_Merger(strsent3,buffer6,',',strsent);
	CTRL_USART_WriteLine(strsent);
			
//		/******Usart goc *********/
//			
//	sprintf((char*)buffer1,"%2.3f",Angle); // goc cua bo loc kalman
//  //sprintf((char*)buffer2,"%2.3f",AngleControlSpeed); // Goc control dung dong nay thay dong 75 khi ko so sanh 2 bo loc
//  sprintf((char*)buffer2,"%2.3f",AngleC); // Goc cua bo loc bu
//	String_Merger (buffer1,buffer2,',',strsent);
//	CTRL_USART_WriteLine(strsent);
		
	delay_01ms(500);
		}			
   }
return 0;
}
