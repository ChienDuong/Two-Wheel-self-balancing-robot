#include "include.h"

USART_t PID_Usart = {0,0,0,{0},{0}};
uint8_t PID_Data[50] = {0};
//He so PID
float KpAngle=0, KiAngle =0, KdAngle =0;//40 0 -2.5
double KpSpeed=0,   KiSpeed =0, KdSpeed =0;// 0.016 0.03 0    // thong so cai dat PID luc ban dau khi start
double KpRotate=0, KiRotate =0, KdRotate =0;
double CSpeed=0, CAngle =0, CSpeedRotate =0;
	/***********************/
int Run =0, Start=0,Receive=0;

void Usart_Configuration( unsigned int BaudRate)
	{
	USART_InitTypeDef 		USART_InitStruct;
	NVIC_InitTypeDef			NVIC_InitStruct;
	GPIO_InitTypeDef     	GPIO_InitStruct;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART6, ENABLE); 
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC, ENABLE);

	GPIO_InitStruct.GPIO_Pin = GPIO_Pin_6 | GPIO_Pin_7;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStruct.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStruct.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOC, &GPIO_InitStruct);


	USART_InitStruct.USART_BaudRate = BaudRate;
	USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStruct.USART_Mode = USART_Mode_Tx | USART_Mode_Rx;
	USART_InitStruct.USART_Parity = USART_Parity_No;
	USART_InitStruct.USART_StopBits = USART_StopBits_1;
	USART_InitStruct.USART_WordLength = USART_WordLength_8b; // nghi là 7 boi vi khung truyen chi co 7 bit 3 acel 3 gyro 1 nhietdo
	USART_Init(USART6, &USART_InitStruct);
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource6, GPIO_AF_USART6);
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource7, GPIO_AF_USART6);
	USART_Cmd(USART6, ENABLE);

USART_ITConfig(USART6, USART_IT_RXNE, ENABLE); // RXNE: Receive Data register not empty interrupt
 
	NVIC_InitStruct.NVIC_IRQChannel = USART6_IRQn;
	NVIC_InitStruct.NVIC_IRQChannelCmd = ENABLE;
	NVIC_InitStruct.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStruct.NVIC_IRQChannelSubPriority = 0;
	NVIC_Init(&NVIC_InitStruct);	
	USART_Cmd(USART6, ENABLE);
}
	void USART6_IRQHandler(void)
	{
		PID_Process();
		//GPIO_ToggleBits(GPIOD, GPIO_Pin_13);

   }

	 void PID_Process(void)
 {
	 PID_USART_Get();// nhan gia tri chuoi tu C#
	 String_RemoveCRLF(PID_Usart.string,PID_Data);		 // tu string xoa /r /n se ra PID data
	 PID_Parameter();
	 
 }
 
 /* Hàm nhân giá tri tu C# sau khi co tin hieu LF la biet ket thuc, roi chuyen chuoi nhan duoc sang string*/
 void PID_USART_Get(void) 
 {
	 PID_Usart.isdone = false;// bao la chua nhan xong uart
	 if(USART_GetITStatus(USART6,USART_IT_RXNE))
	 {
	 USART_ClearITPendingBit(USART6, USART_IT_RXNE); 
	 PID_Usart.receive[PID_Usart.count] = USART_ReceiveData(USART6);// gan gia tri nhan dc cua Uart vao hàm này
	 PID_Usart.count++;
	 }
	 if(PID_Usart.receive[PID_Usart.count-1] == LF) // "\n"
	 {
		 PID_Usart.isdone = true;
		 //remove old data and update new data
		 String_Copy(PID_Usart.receive,PID_Usart.string); // chuyen gia tri tu .receive sang .string
		 PID_Usart.LNG = PID_Usart.count;
		 //remove temp data
		 String_Clear(PID_Usart.receive); // xoa cai chuoi receive bang 0 de nhan cai khac
		 PID_Usart.count = 0;
	 }
 }
 
void PID_Parameter(void)
 {
	 uint8_t  strkp[10] = {0}, strki[10] = {0}, strkd[10] = {0}, strspeed[10]={0},strangle[10]={0},strspeedrotate[10]= {0},strkp2[10] = {0}, strki2[10] = {0}, strkd2[10] = {0},strkp3[10] = {0}, strki3[10] = {0}, strkd3[10] = {0};
	 
	 if(PID_Usart.isdone == true)
	 {
		 if(PID_Data[0] == 'P' && PID_Data[1] == 'I' && PID_Data[2] == 'D'&& PID_Data[3] == '1')
		 {
			 String_Split(PID_Data,',',1,strkp);// stringin, character,starpos, stringout. sau khi gap dau phay thu nhat thi string in gan vao kp
			 String_Split(PID_Data,',',2,strki);
			 String_Split(PID_Data,',',3,strkd);
			 
			 KpAngle = Str2Double(strkp);
			 KiAngle = Str2Double(strki);
			 KdAngle = Str2Double(strkd);			 
			 CTRL_USART_WriteLine(PID_Data);
			 
		 }
		 if(PID_Data[0] == 'P' && PID_Data[1] == 'I' && PID_Data[2] == 'D' && PID_Data[3] == '2' )
		 {
			 String_Split(PID_Data,',',1,strkp2);// stringin, character,starpos, stringout. sau khi gap dau phay thu nhat thi string in gan vao kp
			 String_Split(PID_Data,',',2,strki2);
			 String_Split(PID_Data,',',3,strkd2);
			 
			 KpSpeed = Str2Double(strkp2);
			 KiSpeed = Str2Double(strki2);
			 KdSpeed = Str2Double(strkd2);			 
			 CTRL_USART_WriteLine(PID_Data);
			 
		 }
		  if(PID_Data[0] == 'P' && PID_Data[1] == 'I' && PID_Data[2] == 'D' && PID_Data[3] == '3')
		 {
			 String_Split(PID_Data,',',1,strkp3);// stringin, character,starpos, stringout. sau khi gap dau phay thu nhat thi string in gan vao kp
			 String_Split(PID_Data,',',2,strki3);
			 String_Split(PID_Data,',',3,strkd3);
			 
			 KpRotate = Str2Double(strkp3);
			 KiRotate = Str2Double(strki3);
			 KdRotate = Str2Double(strkd3);			 
			 CTRL_USART_WriteLine(PID_Data);
			 
		 }
		 if(PID_Data[0] == 'S' )
		 {
			 String_Split(PID_Data,',',1,strspeed);// stringin, character,starpos, stringout. sau khi gap dau phay thu nhat thi string in gan vao kp
			 String_Split(PID_Data,',',2,strangle);
			 String_Split(PID_Data,',',3,strspeedrotate);
			 CSpeed = Str2Double(strspeed);
			 CAngle = Str2Double(strangle);
			 CSpeedRotate=Str2Double(strspeedrotate);
			 CTRL_USART_WriteLine(PID_Data);
			
		 }
		 if(PID_Data[0] == '7' )
		 {
			 Start =0;
		 }
		 if(PID_Data[0] == '8' )
		 {
			 Start =1;
		 }
		 if(PID_Data[0] == '9' )
		 {
			 Receive =1;
		 }
		 if(PID_Data[0] == '1' )
		 {
			 Run =1;
		 }
		  if(PID_Data[0] == '2' )
		 {
			 Run =2;
		 }
		  if(PID_Data[0] == '3' )
		 {
			 Run =3;
		 }
		  if(PID_Data[0] == '4' )
		 {
			 Run =4;
		 }
		  if(PID_Data[0] == '5' )
		 {
			 Run =5;
		 }
	 }
 }
	
 void delay_01ms(uint16_t period)
{
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM6, ENABLE);
	TIM6 ->PSC = 8399; //CLK= SystemClock /4/(PSC+1)*2
	TIM6->ARR = period-1 ;
	TIM6->CNT =0;
	TIM6->EGR =1;    // update registers
	TIM6 ->SR =0;
	TIM6 -> CR1 =1;// enable Timer 6
	while  (!TIM6->SR);
	TIM6 ->CR1=0;// stop timer 6
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM6, DISABLE);
	
}
 void CTRL_USART_WriteLine(uint8_t* data)
 {
	 
	uint8_t *cr_lf = (uint8_t*)"\r\n";
	while(*data != '\0')// chho cho den khi truyen het chuoi do
		{
		USART_SendData(USART6,*data);
		while(USART_GetFlagStatus(USART6, USART_FLAG_TXE) == RESET);
		data++;
		}
	while(*cr_lf != '\0')// chen them ki tu \r\n
		{
		USART_SendData(USART6,*cr_lf);
		while(USART_GetFlagStatus(USART6, USART_FLAG_TXE) == RESET);
		cr_lf++;
		}
	}
