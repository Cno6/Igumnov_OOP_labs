#include <stdio.h>
#include "../task1.h"

void print(int n, int k) {
    static int i = 1;
    do {
        if (!(i % k)) {
	    i++;
	    continue;
	}
        printf("%lf ", a(i));
        i++;
    } while (i < n);
}

