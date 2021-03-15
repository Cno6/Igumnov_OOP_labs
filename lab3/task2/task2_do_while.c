#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    double result = 0;
    int i = 0;
	if (fabs(a(i)) > eps) {
		do {
			result += a(i);
			++i;
		} while (fabs(a(i)) > eps);
	}
    return result;
}
