#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

double sin(double a);
double x, result;

void f(void) {
	result = (1 - 2 * sin(x) * sin(x))/(1 + sin(2*x));
}
