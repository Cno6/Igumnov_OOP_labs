#include <math.h>
#include "../task1.h"

int findFirstElement(double eps) {
    int i = 0;
    for (;; ++i) {
	if (fabs(a(i)) <= eps) { break; }
    }
    return i;
}
