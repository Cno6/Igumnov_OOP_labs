#include <math.h>
#include "../task1.h"

int findFirstElement(double eps) {
    static int i = 0;
    do {
        ++i;
    } while (fabs(a(i)) > eps);
    return i;
}
