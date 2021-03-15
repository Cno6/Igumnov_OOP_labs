#include <math.h>
#include "../task1.h"

int findFirstElement(double eps) {
    int i = 0;
    do {
		if (fabs(a(i)) > eps) {
			++i;
		}
		else { break; }
    } while (1);
    return i;
}
