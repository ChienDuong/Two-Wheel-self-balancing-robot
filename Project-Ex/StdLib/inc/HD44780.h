#ifndef __HD44780
#define __HD44780


#include "stdio.h"
#include "stm32f4xx.h"



/* Define for boot from Flash */
#define FLASH_BOOT


/* Basic LCD Driver settings */
#define LCD_PROCESS_IO_FREQ 10000
#define QUEUE_SIZE 200

// Used for custom character creation
#define b00000	0x00
#define b00001	0x01
#define b00010	0x02
#define b00011	0x03
#define b00100	0x04
#define b00101	0x05
#define b00110	0x06
#define b00111	0x07
#define b01000	0x08
#define b01001	0x09
#define b01010	0x0A
#define b01011	0x0B
#define b01100	0x0C
#define b01101	0x0D
#define b01110	0x0E
#define b01111	0x0F
#define b10000	0x10
#define b10001	0x11
#define b10010	0x12
#define b10011	0x13
#define b10100	0x14
#define b10101	0x15
#define b10110	0x16
#define b10111	0x17
#define b11000	0x18
#define b11001	0x19
#define b11010	0x1A
#define b11011	0x1B
#define b11100	0x1C
#define b11101	0x1D
#define b11110	0x1E
#define b11111	0x1F




///////////////////////////////////////////////////////////
// Entry mode set
#define ENTRY_INCREMENT			0x0002
#define ENTRY_DECREMENT			0x0000
#define DISPLAY_SHIFT_OFF		0x0000
#define DISPLAY_SHIFT_ON		0x0001

// Display on/off control
#define DISPLAY_OFF				0x0000
#define DISPLAY_ON				0x0004
#define CURSOR_OFF				0x0000
#define CURSOR_ON				0x0002
#define CURSOR_BLINK_OFF		0x0000
#define CURSOR_BLINK_ON			0x0001

// Cursor or display shift
#define SHIFT_DISPLAY			0x0008
#define SHIFT_CURSOR			0x0000
#define SHIFT_DIRECTION_LEFT	0x0000
#define SHIFT_DIRECTION_RIGHT	0x0004

// Function set
#define BUS_WIDTH_8				0x0010
#define BUS_WIDTH_4				0x0000
#define DISPLAY_LINES_1			0x0000
#define DISPLAY_LINES_2			0x0008
#define FONT_5x8				0x0000
#define FONT_5x10				0x0004






///////////////////////////// Structures //////////////////////////////

typedef enum
{
  False = 0,
  True = 1
}Bool;

enum COMMANDS {
NO_TASK 			= 0x0000,
ClearDisplay		= 0x0001,
ReturnHome			= 0x0002,
EntryMode			= 0x0004,
DisplayControl		= 0x0008,
CursorDisplayShift	= 0x0010,
FunctionSet			= 0x0020,
SetCGRamAddress		= 0x0040,
SetDDRamAddress		= 0x0080,
ReadBusyAndAddress	= 0x0100,
WriteData			= 0x0200,
ReadData			= 0x0300,
ToggleEN			= 0x8000,
WaitBusy			= 0xC000,
WAIT				= 0xFFFF
};

struct TASK{
enum COMMANDS Command;
uint16_t Data;
uint8_t	Iter;
};



////////////////////////// Functions //////////////////////////////

/* LCD_ConfigurePort variables
Port [GPIOA, GPIOB, GPIOC, GPIOD, GPIOE, GPIOF, GPIOG, GPIOH or GPIOI]
RS [GPIO_Pin_0 to GPIO_Pin_15]
RW [GPIO_Pin_0 to GPIO_Pin_15]
E [GPIO_Pin_0 to GPIO_Pin_15]
DB0 [GPIO_Pin_0 to GPIO_Pin_15 or NULL]
DB1 [GPIO_Pin_0 to GPIO_Pin_15 or NULL]
DB2 [GPIO_Pin_0 to GPIO_Pin_15 or NULL]
DB3 [GPIO_Pin_0 to GPIO_Pin_15 or NULL]
DB4	[GPIO_Pin_0 to GPIO_Pin_15]
DB5	[GPIO_Pin_0 to GPIO_Pin_15]
DB6	[GPIO_Pin_0 to GPIO_Pin_15]
DB7	[GPIO_Pin_0 to GPIO_Pin_15]
*/
void LCD_ConfigurePort(GPIO_TypeDef* Port,
						uint16_t RS,
						uint16_t RW,
						uint16_t E,
						uint16_t DB0,
						uint16_t DB1,
						uint16_t DB2,
						uint16_t DB3,
						uint16_t DB4,
						uint16_t DB5,
						uint16_t DB6,
						uint16_t DB7
						);

/* LCD_Initalize variables
	BusWidth[BUS_WIDTH_4, BUS_WIDTH_8]
	DisplayLines[DISPLAY_LINES_1, DISPLAY_LINES_2]
	FontSize[FONT_5x8, FONT_5x10]
*/
void LCD_Initalize(int BusWidth, int DisplayLines, int FontSize);
void LCD_Home(void);									// Move cursor to home position.
void LCD_Clear(void);									// Clear the entire display
void LCD_Print(char* str);			// Print the null terminated string.
void LCD_MoveCursor(int value);		// Move cursor number of places +/-
void LCD_MoveDisplay(int value);	// Shift the entire display number of places +/-
void LCD_DisplayOn(Bool value);		// Turn display on or off.
void LCD_DisplayScroll(Bool value);	// The display scrolls on character entry.
void LCD_EntryIncrement(Bool value);// Increment or decrement cursor/display.
void LCD_CursorOn(Bool value);		// Turn cursor on or off.
void LCD_CursorBlink(Bool value);	// Turn the cursor blinking on or off.
void LCD_MoveToPosition(int value); // Move cursor to absolute position
void LCD_CustChar(uint8_t array[], int charNum);	// An array of 8 bytes, and the position in CGRAM to put the new custom character.



////////////////////////// Private Functions //////////////////////////////

void LCD_HardInitalize(void);
void LCD_WaitNotBusy(void);
void LCD_ClockTick(void);
uint16_t LCD_ConvertDataToPortData(uint16_t Data);
uint16_t LCD_ConvertPortDataToData(uint16_t PortData);
void LCD_Port_Set_Input(void);
void LCD_Port_Set_Output(void);

struct TASK* LCD_ExaminTask(void);
void LCD_DeleteTask(void);
void LCD_PushTask(struct TASK);

void LCD_InitalizeRCC(void);
void LCD_InitalizeNVIC(void);
void LCD_TIM_Config(void);

#endif	/* __HD44780 */
