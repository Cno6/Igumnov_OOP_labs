#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

_Bool isInArea(double x, double y);
double f(double x);

void main(){
	printf("Type \"1\" for Exercise 1\n\rType \"2\" for Exercise 2\n\r");
	switch(getchar())
	{
		case '1':
			printf("Exercise 1\n\r");
			static double coordX, coordY, result1;
			scanf("%lf", &coordX);
			scanf("%lf", &coordY);
			result1 = isInArea(coordX, coordY);
			if (result1 == 1)
			{
				printf("Point is in area!");
			}
			else 
			{
				printf("Point is out of area!");
			}
			break;
		case '2':
			printf("Exercise 2\n\r");
			static double x, result2;
			scanf("%lf", &x);
			result2 = f(x);
			printf("%lf", result2);			
			break;
		default:
			printf("Invalid input format");
	}
}

