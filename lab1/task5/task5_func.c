#include <math.h>

double f(double x) {
	return (1 - 2 * sin(x) * sin(x))/(1 + sin(2*x));
}