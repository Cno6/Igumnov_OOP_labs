#include <math.h>
#include "../task1.h"

int findFirstNegativeElement(double eps) {
    int i = 0;
    for (;; ++i) {
	if (a(i) < 0 && fabs(a(i)) <= eps) {
	    return i;
	}
    }
}
