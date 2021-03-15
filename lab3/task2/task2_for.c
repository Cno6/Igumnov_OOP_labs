#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    double result = 0;
    for (int i = 0; fabs(a(i)) > eps; ++i) {
		result += a(i);
    }
    return result;
}
