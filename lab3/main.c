#include <stdio.h>
#include "task1.h"
#include <string.h>
#include <stdlib.h>
#include <conio.h>

int main() {
    int n, k;
    double eps;
	char option;
    while (1) {
		system("cls");
        printf("1.Exercise 1\n2.Exercise 2\n3.Exercise 3\n4.Exercise 4\n5.Exercise 5\n6. Quit\n");
		option = getchar();
		system("cls");
        switch(option) {
	    case '1':
	        printf("Exercise 1.\nType int 'n'\n");
	        scanf("%d", &n);
	        printf("Ans: %lf\n", sum(n));
			break;
	    case '2':
	        printf("Exercise 2.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %lf\n", sum2(eps));
			break;
	    case '3':
	        printf("Exercise 3.\nType int 'n' and 'k'\n");
	        scanf("%d %d", &n, &k);
	        printf("Ans: \n");
			print(n, k);
			break;
	    case '4':
	        printf("Exercise 4.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %d\n", findFirstElement(eps));
			break;
	    case '5':
	        printf("Exercise 5.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %d\n", findFirstNegativeElement(eps));
			break;
	    case '6':
			return 0;
		}
		system("pause");
    }
}

