#include "../task1.h"

double sum(int n) {
    static double result = 0;
    for (int i = 0; i < n; ++i) {
	result += a(i);
    }
    return result;
}
