#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

double sin(double a);

void main(void) {
	const double x1 = 5.0;
	double result1, result2;
	double x2;
	
	result1 = (1 - 2 * sin(x1) * sin(x1))/(1 + sin(2*x1));
	printf("f(5) = %.04lf\n", result1);
	
	printf("Enter X = ");
	scanf("%lf", &x2);
	result2 = (1 - 2 * sin(x2) * sin(x2))/(1 + sin(2*x2));
	printf("f(%.0lf) = %.04lf\n", x2, result2);
}