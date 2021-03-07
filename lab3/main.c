#include <stdio.h>
#include "task1.h"
#include <string.h>
#include <stdlib.h>
#include <conio.h>

int main() {
    static int n, k;
    static double eps;
    while ("true") {
		system("cls");
        printf("1.Exercise 1\n2.Exercise 2\n3.Exercise 3\n4.Exercise 4\n5.Exercise 5\n6. Quit\n");
        switch(getchar()) {
	    case '1':
	        system("cls");
	        printf("Exercise 1.\nType int 'n'\n");
	        scanf("%d", &n);
	        printf("Ans: %lf\n", sum(n));
	        printf("type for exit ");
		    while (! _kbhit() ) { continue; }
			break;
	    case '2':
	        system("cls");
	        printf("Exercise 2.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %lf\n", sum2(eps));
	        printf("type for exit ");
		    while (! _kbhit() ) { continue; }
			break;
	    case '3':
	        system("cls");
	        printf("Exercise 3.\nType int 'n' and 'k'\n");
	        scanf("%d %d", &n, &k);
	        printf("Ans: \n");
			print(n, k);
	        printf("type for exit ");
		    while (! _kbhit() ) { continue; }
			break;
		continue;
	    case '4':
	        system("cls");
	        printf("Exercise 4.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %d\n", findFirstElement(eps));
	        printf("type for exit ");
		    while (! _kbhit() ) { continue; }
			break;
		continue;
	    case '5':
	        system("cls");
	        printf("Exercise 5.\nType 0 < e < 1 'eps'\n");
	        scanf("%lf", &eps);
	        printf("Ans: %d\n", findFirstNegativeElement(eps));
	        printf("type for exit ");
		    while (! _kbhit() ) { continue; }
			break;
	    case '6':
			return 0;
		}
    }
}

