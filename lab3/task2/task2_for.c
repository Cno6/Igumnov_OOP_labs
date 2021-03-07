#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    static double result = 0;
    for (int i = 0; ; ++i) {
	if (fabs(a(i)) <= eps) {
	    break;
	}
	else {
	result += a(i);
	}
    }
    return result;
}
