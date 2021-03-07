#include <math.h>
#include "../task1.h"

double sum2(double eps) {
    static double result = 0;
    static int i = 0;
    do {
        result += a(i);
        ++i;
    } while (fabs(a(i)) > eps);
    return result;
}
