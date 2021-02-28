#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

_Bool isInArea(double x, double y) {
	if (x * x + y * y == 1)
	{
		return 1;
	}
	else if (x >= -1 && x < 0 && y >= -1 && y <= 1)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

void main(){
	double coordX, coordY;
	scanf("%lf", &coordX);
	scanf("%lf", &coordY);
	isInArea(coordX, coordY);
}