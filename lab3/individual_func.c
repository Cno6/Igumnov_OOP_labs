#include <math.h>

double a(int i) {
    return pow(-1, i) * (pow(2, i+1) / (pow(2, 2*i) + 1));
}
