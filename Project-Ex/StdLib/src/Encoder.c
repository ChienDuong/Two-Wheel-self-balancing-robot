#include "include.h"
extern GPIO_InitTypeDef           GPIO_InitStructure;
EXTI_InitTypeDef                  EXTI_InitStructure;
extern NVIC_InitTypeDef           NVIC_InitStructure;
float PulseR = 0, PulseL=0;

void Init_DIR (void)
	{
		GPIO_InitTypeDef  DIR1;
	  GPIO_InitTypeDef  DIR0;
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
		DIR1.GPIO_Pin = GPIO_Pin_11;
		DIR1.GPIO_Mode = GPIO_Mode_OUT;
		DIR1.GPIO_Speed = GPIO_Speed_100MHz;
		DIR1.GPIO_OType = GPIO_OType_PP;
		DIR1.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_Init(GPIOD, &DIR1);
		
		
		DIR0.GPIO_Pin = GPIO_Pin_15;
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
		DIR0.GPIO_Mode = GPIO_Mode_OUT;
		DIR0.GPIO_Speed = GPIO_Speed_100MHz;
		DIR0.GPIO_OType = GPIO_OType_PP;
		DIR0.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_Init(GPIOB, &DIR0);
	}
	
void Config_EnB1 (void)
{
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL ;
  GPIO_Init(GPIOB, &GPIO_InitStructure); 
}
void Config_EnB0 (void)
{
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_11;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL ;
  GPIO_Init(GPIOE, &GPIO_InitStructure); 
}

void EXTILine4_Config(void)  // PB4 là encoder A1
{
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
  /* Configure PB0 pin as input floating */
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4;
  GPIO_Init(GPIOB, &GPIO_InitStructure);
  /* Connect EXTI Line0 to PB0 pin */
  SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOB, EXTI_PinSource4);
  /* Configure EXTI Line0 */
  EXTI_InitStructure.EXTI_Line = EXTI_Line4;
  EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
  EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;  
  EXTI_InitStructure.EXTI_LineCmd = ENABLE;
  EXTI_Init(&EXTI_InitStructure);

  /* Enable and set EXTI Line0 Interrupt to the lowest priority */
  NVIC_InitStructure.NVIC_IRQChannel = EXTI4_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}
void EXTI4_IRQHandler(void)
{
  if(EXTI_GetITStatus(EXTI_Line4) != RESET)
  {
		if(GPIO_ReadInputDataBit(GPIOB, GPIO_Pin_5)==1)
			// PB5 encoder B1 xac dinh chieu quay
			PulseR+=1;
		else
			PulseR-=1;
	  EXTI->PR = EXTI_Line4;
  }
}

void EXTILine9_Config(void)  // PE9 là encoder A0
{
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOE, ENABLE);
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
  /* Configure PB0 pin as input floating */
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;
  GPIO_Init(GPIOE, &GPIO_InitStructure);
  /* Connect EXTI Line9 to PB9 pin */
  SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOE, EXTI_PinSource9);
  /* Configure EXTI Line9 */
  EXTI_InitStructure.EXTI_Line = EXTI_Line9;
  EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
  EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;  
  EXTI_InitStructure.EXTI_LineCmd = ENABLE;
  EXTI_Init(&EXTI_InitStructure);

  /* Enable and set EXTI Line0 Interrupt to the lowest priority */
  NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}
void EXTI9_5_IRQHandler(void)
{
  if(EXTI_GetITStatus(EXTI_Line9) != RESET)
  {
		if(GPIO_ReadInputDataBit(GPIOE, GPIO_Pin_11)==1)
			// PE11 encoder B0 xac dinh chieu quay
			PulseL-=1;
		else
			PulseL+=1;
	  EXTI->PR = EXTI_Line9;
  }
}
