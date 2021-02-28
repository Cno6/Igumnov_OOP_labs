#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

double pow(double x, double y);

double f(double x) {
	return x > 3 ? (1 / (pow(x, 3) + 6)) : (x*x - 3*x + 9);
}

void main(){
	static double x;
	static double result;
	scanf("%lf", &x);
	result = f(x);
	printf("%lf", result);
}