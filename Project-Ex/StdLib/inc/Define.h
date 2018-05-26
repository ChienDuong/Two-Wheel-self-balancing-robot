/******************************************************************************
 *                                                                            *
 *  @Project    Dev_Base				                                              *
 *	@File       Define.h		                                                  *
 * 	@Author	    Lam Thang Long                                                *
 *  @Version 		V1.0	                                                       	*
 *                                                                            *
 ******************************************************************************/
#ifndef __DEFINE_H
#define __DEFINE_H
/******************************************************************************
 *                                                                            *
 *  												INCLUDE		                                        *
 *  														                                              *
 ******************************************************************************/
#include "stm32f4xx.h"
#include <stdbool.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
/******************************************************************************
 *                                                                            *
 *  												TYPEDEF		                                        *
 *  														                                              *
 ******************************************************************************/
 
 /* Struct */
#define CR										'\r'
#define LF										'\n'
#define Line									(uint8_t*)"\n"
#define CR_LF   							(uint8_t*)"\r\n"
#define LNG_READ							5		// user
#define LNG_MAX								100	// max length of frame on USART

 typedef struct
 {
	 bool     isdone; //confirm when all data is received by line
	 uint16_t count; //count received data
	 uint16_t LNG;   //length of received data
	 uint8_t  receive[LNG_MAX];// store received data on USART Rx Interrupt
	 uint8_t  string[LNG_MAX]; // store full of received data
 }USART_t;
 
 typedef struct
 {
	 uint32_t timpos;
	 uint32_t timneg;
	 uint32_t interval;
	 double   time_ms;
 }CAPTURE_t;
 /* Enum */
 typedef enum
 {
    BIT0 = (uint8_t)0,
    BIT1 = (uint8_t)1
 }BIT;
 
 /* Data Type */
 #define NULL    0
 
 #define FALSE   0
 #define TRUE    1
 typedef float real32_t;
 typedef double real64_t;
 
 /* Function Pointer */
 typedef void (*VOID_PFUNC_VOID)(void);
/******************************************************************************
 *                                                                            *
 *  												DEFINE		                                        *
 *  														                                              *
 ******************************************************************************/
#define _LED_					1
#define _BUTTON_			1

#define _SYSTICK_			1
#define _TIMER_BASE_	1
#define _TIMER_CTRL_  1

#define _PWM0_				1
#define _PWM1_				1

#define _ENC0_				1
#define	_ENC1_				1

#define _GPS_USART_		1
//#define _GPS_NORMAL_  1
#define _GPS_DMA_	    1
#define _CTRL_USART_	1
#define _CTRL_NORMAL_ 1
//#define _CTRL_DMA_    1

#define _SRF05_CAP_		1

#define _IMU_I2C_			1

#define _MEMS_SPI_		1
//#define _SLAVE_SPI_		1 //<For Test><Caution: not use it along with _PWM0_>

#endif /* _DEFINE_H */
