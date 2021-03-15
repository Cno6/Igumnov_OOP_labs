#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    double result = 0;
    int i = 0;
    while (fabs(a(i)) > eps) {
        result += a(i);
		++i;
    }
    return result;
}
