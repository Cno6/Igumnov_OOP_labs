#include "../task1.h"

double sum(int n) {
    static double result = 0;
    int i = 0;
    while (i < n) {
	result += a(i);
	++i;
    }
    return result;
}
