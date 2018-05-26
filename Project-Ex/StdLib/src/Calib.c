#include "include.h"

s16 Calib[6];
float TestGyroOffset=0;
float f[1000]={0};
int d=0;
float CalibGyro (void)
{
for ( d=0; d<1000;d++)
	{
	MPU6050_GetRawAccelTempGyro(Calib);
	TestGyroOffset +=Calib[5];
	f[d]=Calib[5];
	}
	TestGyroOffset = TestGyroOffset/1000;
	return TestGyroOffset;
}
