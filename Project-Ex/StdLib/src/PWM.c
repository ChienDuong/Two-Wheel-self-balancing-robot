#include "include.h"
extern TIM_TimeBaseInitTypeDef    TIM_TimeBaseStructure;
TIM_OCInitTypeDef          TIM_OCInitStructure;	
GPIO_InitTypeDef           GPIO_InitStructure;
void TIM_PWM0_Configuration(void)
{
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM12, ENABLE);
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB , ENABLE);
  
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_14;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP ;
  GPIO_Init(GPIOB, &GPIO_InitStructure); 
	GPIO_PinAFConfig (GPIOB,GPIO_PinSource14, GPIO_AF_TIM12);
	/* Time base configuration */
  TIM_TimeBaseStructure.TIM_Prescaler = 163; //83; 163 la 1ms
  TIM_TimeBaseStructure.TIM_Period =499; ;
  TIM_TimeBaseStructure.TIM_ClockDivision = 0   ;  //TIM_CKD_DIV1 ,0 hoac div1 deu dc
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	//yeu cau:chu ki ngat 0.5ms =>f=2000
//=> prescaler = 84MHZ/84= 1MHZ
// => can f =2000 nen nen chia 1MHZ cho period= 500;
  TIM_TimeBaseInit(TIM12, &TIM_TimeBaseStructure);
//	TIM_Cmd(TIM12, ENABLE);
	
// sau khi khoi tao timer 12, thi dsu dung timer12 nay lam pwm0
//TIM_OCmode: PWM mode1: clear on compare match
//            PWM mode2 : set on ompare match
//=> no e di chung voi cai TIM_OCpolarity , pwm1-high, pwm2-low
//TIM_Pulse : day la thong so quyet dinh dutycycle, set= sau do tac dong vao cac chan CCRx
// TIM_OutputState: cho phep hoac ko chan PWM hoat dong
  TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM1; 
  TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable; 
  TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;
  //TIM_OCInitStructure.TIM_OutputNState = TIM_OutputNState_Enable; 
  //TIM_OCInitStructure.TIM_OCNPolarity = TIM_OCNPolarity_High;
  TIM_OCInitStructure.TIM_Pulse = 0;
  //TIM_OCStructInit(&TIM_OCInitStructure);
  
  TIM_OC1Init(TIM12, &TIM_OCInitStructure);  
  TIM_OC1PreloadConfig(TIM12, TIM_OCPreload_Enable);

  
	TIM_Cmd(TIM12, ENABLE);
  TIM_ARRPreloadConfig(TIM12, ENABLE);

  /* TIM12 enable counter */
  
 // TIM_CtrlPWMOutputs(TIM12, ENABLE);

}

void TIM_PWM1_Configuration(void)
{
RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD , ENABLE);
	
GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd =GPIO_PuPd_UP ;
  GPIO_Init(GPIOD, &GPIO_InitStructure); 
	GPIO_PinAFConfig (GPIOD,GPIO_PinSource12, GPIO_AF_TIM4);
// 0.5ms  = 2KHz	
	TIM_TimeBaseStructure.TIM_Prescaler =  163;//167;//163;//83;   
  TIM_TimeBaseStructure.TIM_Period =   499 ;//254;//254;//499 ;
	//2KHZ
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);
	
	TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM1; 
  TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable; 
  TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;
  TIM_OCInitStructure.TIM_Pulse = 0;
  //TIM_OCStructInit(&TIM_OCInitStructure);
  
  TIM_OC1Init(TIM4, &TIM_OCInitStructure);  
  TIM_OC1PreloadConfig(TIM4, TIM_OCPreload_Enable);

  
	TIM_Cmd(TIM4, ENABLE);
  TIM_ARRPreloadConfig(TIM4, ENABLE);
}
