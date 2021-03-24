#include <stdio.h>
#include "../task1.h"

void print(int n, int k) {
    for (int i = 0; i <= n; ++i) {
        if (!((i+1) % k)) { continue; }
		printf("%lf ", a(i));
    }
}


