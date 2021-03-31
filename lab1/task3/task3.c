#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

double f(double x);

void main() {
	const double x1 = 5.0;
	double x2;
	
	printf("f(5) = %.04lf\n", f(x1));	
	printf("Enter X = ");
	scanf("%lf", &x2);
	printf("f(%.0lf) = %.04lf\n", x2, f(x2));
}

double f(double x) {
	return (1 - 2 * sin(x) * sin(x))/(1 + sin(2*x));
}