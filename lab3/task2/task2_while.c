#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    static double result = 0;
    static int i = 0;
    while (fabs(a(i)) > eps) {
        result += a(i);
	++i;
    }
    return result;
}
