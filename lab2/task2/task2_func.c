#include <math.h>

double pow(double x, double y);

double f(double x) {
	return x > 3 ? (1 / (pow(x, 3) + 6)) : (x*x - 3*x + 9);
}

