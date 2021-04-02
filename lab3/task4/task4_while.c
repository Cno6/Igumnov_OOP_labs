#include <math.h>
#include "../task1.h"

int findFirstElement(double eps) {
    double result = 0;
    int i = 0;
    while (1) {
		if (fabs(a(i)) <= eps) { break; }
		++i;
    }
    return i;
}
