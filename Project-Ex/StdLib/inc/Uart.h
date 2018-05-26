#ifndef _Uart_H_
#define _Uart_H_

#ifdef __cplusplus
 
 extern "C" {
#endif 
#include "include.h"
void Usart_Configuration( unsigned int BaudRate);
void PID_Process(void);
void PID_Parameter(void);
void PID_USART_Get(void);
void CTRL_USART_WriteLine(uint8_t* data);
void delay_01ms(uint16_t period);
	 
/******************************************************************************
 * @fn     String_Split     
 * @brief  split string with special character
 * @param  stringin: string input
					 character: character to split
					 startpos: position of character follow number of "character";
					 stringout: output string
 * @retval None
 ******************************************************************************/	 
void String_Split(uint8_t* stringin, uint8_t character, uint8_t startpos, uint8_t* stringout);
#endif
