#include <stdio.h>
#include "../task1.h"

void print(int n, int k) {
    int i = 0;
    while (i <= n) {
        if (!((i+1) % k)) {
			i++;
			continue;
		}
		printf("%lf ", a(i));
		i++;
    }
}

