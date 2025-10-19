#include <stdio.h>
#include <math.h>

int main() {
    double x;
    printf("Calculation of function ln(x)\n");
    printf("(x > 0) x = ");
    scanf("%lg", &x);
    printf("f(x) = %f\n", log(x));

    return 0;
}