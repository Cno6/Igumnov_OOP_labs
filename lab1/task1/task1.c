#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

void main(void) {
	const double x1 = 5.0;
	double x2;
	
	printf("f(5) = %.04lf\n", (1 - 2 * sin(x1) * sin(x1))/(1 + sin(2*x1)));
	
	printf("Enter X = ");
	scanf("%lf", &x2);
	printf("f(%.0lf) = %.04lf\n", x2, (1 - 2 * sin(x2) * sin(x2))/(1 + sin(2*x2)));
}