//#include "Timer.h"
//#include "stm32f4xx.h"
//#include <stdio.h>
#include "include.h"
//extern void PIDControl (void);
TIM_TimeBaseInitTypeDef    TIM_TimeBaseStructure;
NVIC_InitTypeDef NVIC_InitStructure;

void Timer_2_1ms_Angle (void)//5ms
{
RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
  
  /* Time base configuration */
  TIM_TimeBaseStructure.TIM_Prescaler = ((SystemCoreClock/2)/100000)-1;     // frequency = 100000
  TIM_TimeBaseStructure.TIM_Period = 100 - 1;//400 la 4ms   => thoi gian bai nay: 100/100000 = 0.001 =1ms
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
  TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
  TIM_ITConfig(TIM2,TIM_IT_Update,ENABLE);
  TIM_Cmd(TIM2, ENABLE);
  
  NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);  
}
void TIM2_IRQHandler(void) {
  if (TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET)
  {
	 Read_Sensor_Kalman();
		//Read_Sensor_Complementary ();
		//PIDControl();
	}
	
	TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
}

void Timer_3_10ms_PID (void)//5ms
	{
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
   /* Time base configuration */
   TIM_TimeBaseStructure.TIM_Prescaler = ((SystemCoreClock/2)/500000)-1;     // frequency = 500000
		TIM_TimeBaseStructure.TIM_Period =1000-1; // 1000 la 2ms    2500 la 5ms  tan so bai nay: 5000/500000 = .01 =10ms
	 // tan so = 100 => 10ms
   TIM_TimeBaseStructure.TIM_ClockDivision = 0;
	 TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
   TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
   TIM_ITConfig(TIM3,TIM_IT_Update,ENABLE);
   TIM_Cmd(TIM3, ENABLE);  
   NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
   NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
   NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
   NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
   NVIC_Init(&NVIC_InitStructure);   
	}
	void TIM3_IRQHandler(void)
	{
		if (TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET)
		{
			{
//			if(Start ==1)
//			{
		     PIDControl ();
				
//}
			}
			TIM_ClearITPendingBit(TIM3, TIM_IT_Update); 
		}
	}
