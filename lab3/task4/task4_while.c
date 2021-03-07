#include <math.h>
#include "../task1.h"

int findFirstElement(double eps) {
    static double result = 0;
    static int i = 0;
    while (fabs(a(i)) > eps) {
        result += a(i);
	++i;
    }
    return i;
}
