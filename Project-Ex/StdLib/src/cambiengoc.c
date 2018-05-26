#include "cambiengoc.h"
//#include "stm32f4xx_i2c.h"
//#include "math.h"
//#include "Kalman.h"
#include "include.h"

/**Khai bao cho o loc bu***/
static s16  az[10],gx[10],ay[10];
s16 a[6] = {0};
s16 c[6] = {0};
unsigned int ind =0;
double AccY_Out, AccZ_Out,GyroX_Out;
float AccXAngle, GyroXRate,AccYAngle,GyroYRate , Angle, AngleC; 
double AccY_Final , AccZ_Final, GyroX_Final, GyroX_Final_Converted, Acc_Angle_Final, Acc_Angle_Now,GyroY_Now;
double invPi= 0.3183098862;
double GyroX_Offset1000 = -0.206374049*131;
double GyroY_Offset1000 = 238;
extern GPIO_InitTypeDef  GPIO_InitStructure;
I2C_InitTypeDef   I2C_InitStructure;
void I2C_Configuration(void)
{
#ifdef FAST_I2C_MODE
 #define I2C_SPEED 400000
 #define I2C_DUTYCYCLE I2C_DutyCycle_16_9  
#else /* STANDARD_I2C_MODE*/
 #define I2C_SPEED 100000
 #define I2C_DUTYCYCLE I2C_DutyCycle_2
#endif /* FAST_I2C_MODE*/
	
  

  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_I2C1, ENABLE);
	
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_7;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_OD;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;  
  GPIO_Init(GPIOB, &GPIO_InitStructure);
	
  GPIO_PinAFConfig(GPIOB,GPIO_PinSource8,GPIO_AF_I2C1);
  GPIO_PinAFConfig(GPIOB,GPIO_PinSource7,GPIO_AF_I2C1);	

  /* I2C De-initialize */
  I2C_DeInit(I2C1);
  I2C_InitStructure.I2C_Mode = I2C_Mode_I2C;
  I2C_InitStructure.I2C_DutyCycle = I2C_DUTYCYCLE;
  I2C_InitStructure.I2C_OwnAddress1 = 0;
  I2C_InitStructure.I2C_Ack = I2C_Ack_Enable;
  I2C_InitStructure.I2C_ClockSpeed = I2C_SPEED;
  I2C_InitStructure.I2C_AcknowledgedAddress = I2C_AcknowledgedAddress_7bit;
  I2C_Init(I2C1, &I2C_InitStructure);
 /* I2C ENABLE */
  I2C_Cmd(I2C1, ENABLE); 
  /* Enable Interrupt */	
}
void MPU6050_Initialize() 
{
    MPU6050_SetClockSource(MPU6050_CLOCK_PLL_XGYRO);
    MPU6050_SetFullScaleGyroRange(MPU6050_GYRO_FS_250);
    MPU6050_SetFullScaleAccelRange(MPU6050_ACCEL_FS_2);
		MPU6050_SetRateDivider(0x7); // sample rate 100Hz->13
	  MPU6050_WriteBits(MPU6050_DEFAULT_ADDRESS, MPU6050_RA_CONFIG, 0, 5, 0x00);
    MPU6050_SetSleepModeStatus(DISABLE); 
}
void MPU6050_SetClockSource(uint8_t source) 
{
    MPU6050_WriteBits(MPU6050_DEFAULT_ADDRESS, MPU6050_RA_PWR_MGMT_1, MPU6050_PWR1_CLKSEL_BIT, MPU6050_PWR1_CLKSEL_LENGTH, source);

}

void MPU6050_SetFullScaleGyroRange(uint8_t range) 
{
    MPU6050_WriteBits(MPU6050_DEFAULT_ADDRESS, MPU6050_RA_GYRO_CONFIG, MPU6050_GCONFIG_FS_SEL_BIT, MPU6050_GCONFIG_FS_SEL_LENGTH, range);
}


void MPU6050_SetFullScaleAccelRange(uint8_t range) 
{
    MPU6050_WriteBits(MPU6050_DEFAULT_ADDRESS, MPU6050_RA_ACCEL_CONFIG, MPU6050_ACONFIG_AFS_SEL_BIT, MPU6050_ACONFIG_AFS_SEL_LENGTH, range);
}

void MPU6050_SetRateDivider(uint8_t source_1)
{
    MPU6050_WriteBits(MPU6050_DEFAULT_ADDRESS, 0x19, 7, 8, source_1);
}
void MPU6050_WriteBits(uint8_t slaveAddr, uint8_t regAddr, uint8_t bitStart, uint8_t length, uint8_t data) 
{
   
    uint8_t tmp, mask;
    MPU6050_I2C_BufferRead(slaveAddr, &tmp, regAddr, 1);  
    mask = ((1 << length) - 1) << (bitStart - length + 1);
    data <<= (bitStart - length + 1); // shift data into correct position
    data &= mask; // zero all non-important bits in data
    tmp &= ~(mask); // zero all important bits in existing byte
    tmp |= data; // combine data with existing byte
    MPU6050_I2C_ByteWrite(slaveAddr,&tmp,regAddr);   
}

void MPU6050_I2C_BufferRead(u8 slaveAddr, u8* pBuffer, u8 readAddr, u16 NumByteToRead)
{
 // ENTR_CRT_SECTION();

  /* While the bus is busy */
  while(I2C_GetFlagStatus(MPU6050_I2C, I2C_FLAG_BUSY));

  /* Send START condition */
  I2C_GenerateSTART(MPU6050_I2C, ENABLE);

  /* Test on EV5 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_MODE_SELECT));

  /* Send MPU6050 address for write */
  I2C_Send7bitAddress(MPU6050_I2C, slaveAddr, I2C_Direction_Transmitter); 

  /* Test on EV6 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_TRANSMITTER_MODE_SELECTED));

  /* Clear EV6 by setting again the PE bit */
  I2C_Cmd(MPU6050_I2C, ENABLE);

  /* Send the MPU6050's internal address to write to */
  I2C_SendData(MPU6050_I2C, readAddr);

  /* Test on EV8 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_BYTE_TRANSMITTED));

  /* Send STRAT condition a second time */
  I2C_GenerateSTART(MPU6050_I2C, ENABLE);

  /* Test on EV5 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_MODE_SELECT));

  /* Send MPU6050 address for read */
  I2C_Send7bitAddress(MPU6050_I2C, slaveAddr, I2C_Direction_Receiver);

  /* Test on EV6 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_RECEIVER_MODE_SELECTED));

  /* While there is data to be read */
  while(NumByteToRead)
  {
    if(NumByteToRead == 1)
    {
      /* Disable Acknowledgement */
      I2C_AcknowledgeConfig(MPU6050_I2C, DISABLE);

      /* Send STOP Condition */
      I2C_GenerateSTOP(MPU6050_I2C, ENABLE);
    }

    /* Test on EV7 and clear it */
    if(I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_BYTE_RECEIVED))
    {
      /* Read a byte from the MPU6050 */
      *pBuffer = I2C_ReceiveData(MPU6050_I2C);

      /* Point to the next location where the byte read will be saved */
      pBuffer++;

      /* Decrement the read bytes counter */
      NumByteToRead--;
    }
  }

  /* Enable Acknowledgement to be ready for another reception */
  I2C_AcknowledgeConfig(MPU6050_I2C, ENABLE);
//  EXT_CRT_SECTION();
}

void MPU6050_I2C_ByteWrite(u8 slaveAddr, u8* pBuffer, u8 writeAddr)
{
//  ENTR_CRT_SECTION();

  /* Send START condition */
  I2C_GenerateSTART(MPU6050_I2C, ENABLE);

  /* Test on EV5 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_MODE_SELECT));

  /* Send MPU6050 address for write */
  I2C_Send7bitAddress(MPU6050_I2C, slaveAddr, I2C_Direction_Transmitter);

  /* Test on EV6 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_TRANSMITTER_MODE_SELECTED));

  /* Send the MPU6050's internal address to write to */
  I2C_SendData(MPU6050_I2C, writeAddr);

  /* Test on EV8 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_BYTE_TRANSMITTED));

  /* Send the byte to be written */
  I2C_SendData(MPU6050_I2C, *pBuffer);

  /* Test on EV8 and clear it */
  while(!I2C_CheckEvent(MPU6050_I2C, I2C_EVENT_MASTER_BYTE_TRANSMITTED));

  /* Send STOP condition */
  I2C_GenerateSTOP(MPU6050_I2C, ENABLE);

 // EXT_CRT_SECTION();

}

void MPU6050_SetSleepModeStatus(FunctionalState NewState) 
{
    MPU6050_WriteBit(MPU6050_DEFAULT_ADDRESS, MPU6050_RA_PWR_MGMT_1, MPU6050_PWR1_SLEEP_BIT, NewState);
}
void MPU6050_WriteBit(uint8_t slaveAddr, uint8_t regAddr, uint8_t bitNum, uint8_t data) 
{
    uint8_t tmp;
    MPU6050_I2C_BufferRead(slaveAddr, &tmp, regAddr, 1);  
    tmp = (data != 0) ? (tmp | (1 << bitNum)) : (tmp & ~(1 << bitNum));
    MPU6050_I2C_ByteWrite(slaveAddr,&tmp,regAddr); 
}

void MPU6050_GetRawAccelTempGyro(s16* AccelGyro) 
{
    u8 dataR[14],i; 
    MPU6050_I2C_BufferRead(MPU6050_DEFAULT_ADDRESS, dataR, MPU6050_RA_ACCEL_XOUT_H, 14);

    for(i=0;i<7;i++) 
    AccelGyro[i]=(dataR[i*2]<<8)|dataR[i*2+1];   

}
/* Ðoc gia tri cam bien_dung bo loc bu`*/
void Read_Sensor_Kalman (void)
{
/*Bo loc Kalman*/
  MPU6050_GetRawAccelTempGyro(a);
//	/****** xoay theo truc X*****/
//	AccXAngle = (atan2(a[1], a[2]) )*180*invPi;
//	GyroXRate = (a[4]-GyroX_Offset1000)/131;
//	Angle = KalmanCalculate (AccXAngle,GyroXRate,0.005);
	
	/******* Xoay theo truc y*******/
	AccYAngle = atan2(a[2],-a[0])*180*invPi ;  // goc
	GyroYRate = (a[5]-GyroY_Offset1000) /131;   // giatoc
	Angle = KalmanCalculate (AccYAngle,GyroYRate,0.001);
}

void Read_Sensor_Complementary (void)
{
/* Complementary filter sida :v*, bien truc x nhung thay sang truc y r */
int i =0;
	float AccY_Out_Sum =0;
	float AccZ_Out_Sum=0;
	float GyroX_Out_Sum=0;
	MPU6050_GetRawAccelTempGyro(c);
	ay[ind]= c[2];  // bo cua x la 1 2 4 , cua y la 2 0 5
	az[ind]=c[0];
	gx[ind]=c[5];
	ind = (ind+1)%10;
	for ( i =0;i <10;i++) 
	{
		AccY_Out_Sum= AccY_Out_Sum + ay[i];
		AccZ_Out_Sum= AccZ_Out_Sum + az[i];
		GyroX_Out_Sum=GyroX_Out_Sum + gx[i];
	}
	AccY_Out= AccY_Out_Sum/10;
	AccZ_Out= AccZ_Out_Sum/10;
	GyroX_Out=GyroX_Out_Sum/10;
		AccY_Final= AccY_Out;
	  AccZ_Final= AccZ_Out;
	 Acc_Angle_Now = (atan2(AccY_Out, -AccZ_Out) )*180*invPi;// ra don vi do.
	 GyroX_Final_Converted = (GyroX_Out - GyroY_Offset1000 )/131;// chuyen ra do.
	AngleC = 0.98 * (AngleC + GyroX_Final_Converted *0.001) +0.02 * Acc_Angle_Now;	
}
