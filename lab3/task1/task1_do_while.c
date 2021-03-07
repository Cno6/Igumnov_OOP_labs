#include "../task1.h"

double sum(int n) {
    static double result = 0;
    int i = 0;
    do {
        result += a(i);
	++i;
    } while (i < n);
    return result;
}
