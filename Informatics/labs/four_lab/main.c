#include <stdio.h>
#include <ctype.h>
#include <math.h>

int Recursive(int n)
{
    if (n<2) return 1;
    if (n % 2 ==0) return Recursive(n/2) +1;
    return Recursive(3*n+1) + 1;
    
}

double DoubleFactorial(int n)
{
    int result = 1;
    if (n % 2 == 0)
    {
        for (int i = 2; i <= n; i+=2)
        {
            result *= i;
        }
    }
    else
    {
        for (int i = 1; i <= n; i+=2)
        {
            result *= i;
        }
    }
    return (double) result;
}

int FirstTask(int n)
{
    int result = 0;
    for (int i = 1; i <= n;i++)
    {
        if (Recursive(i) > 100)
        {
            result++;
        }
    }
    return result;
   
}

double StraightCalculate(double x, int n)
{
    double result = 0;
    for (int i =1; i <= n; i++)
    {
        result += (DoubleFactorial(2 * i - 1) * pow(x,2*i+2))/(DoubleFactorial(2*i) * (2* i + 1));
    }
    return result;
}

double RecurentCalculate(double x, int n)
{
    double lastElement = StraightCalculate(x,1);
    double result = lastElement;
    for (int i = 1; i < n;i++)
    {
        lastElement = lastElement * ((4 * i * i + 4 * i + 1) * x * x) / (4 * i * i + 10 * i + 6);
        result += lastElement;
    }
    return result;
}

int main()
{
    printf("ответ на первое задание: %d \n", FirstTask(100));
    double x;
    int n;

    printf("введите x (вещественное число): ");
    scanf("%lg", &x);
    printf("введите n (целое число): ");
    scanf("%d",&n);

    printf("результат прямого подсчёта: %lg\n", StraightCalculate(x,n));
    printf("результат рекурентного подсчёта: %lg\n", RecurentCalculate(x,n));
}

