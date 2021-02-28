#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void f(void);
double x, result;

void main() {
	const double x1 = 5.0;
	x = x1;
	f();
	printf("f(5) = %.04lf\n", result);	
	printf("Enter X = ");
	scanf("%lf", &x);
	f();
	printf("f(%.0lf) = %.04lf\n", x, result);
}
