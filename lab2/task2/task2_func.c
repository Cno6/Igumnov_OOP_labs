#include <math.h>

double f(double x) {
	return x > 3 ? (1 / (pow(x, 3) + 6)) : (x*x - 3*x + 9);
}

