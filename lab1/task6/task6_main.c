#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void f(void);
extern double x, result;

void main() {
	x = 5.0;
	f();
	printf("f(5) = %.04lf\n", result);	
	printf("Enter X = ");
	scanf("%lf", &x);
	f();
	printf("f(%.0lf) = %.04lf\n", x, result);
}
