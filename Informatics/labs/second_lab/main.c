#include <stdlib.h>
#include <stdio.h>
#include <math.h>

int task1(int a[], int n, int x)
{
    int r=0;
    
    for (int i =0; i < n; i++)
    {
        if (a[i]%x !=0)
        {
            if (r == 0 || r > a[i])
            {
                r = a[i];
            }
        }
    }
    if (r==0)
    {
        printf("нет ответа на первое задание\n");
        return x;
    }
    else{
        return r;
    }
}

int task2(int a[], int n)
{
    int i =0;
    while (i <n)
    {
        if (a[i]%2 !=0 && a[i] !=0)
        {
            return i;
        }
        i++;
    }
    printf("нет ответа на второе задание\n");
    return -1;

}

void main(){
    printf("Лабораторная работа №2\nВариант 3 61010-090301D Кузнецов Дмитрий\n");
    printf("введите размер массива: ");
    int size;
    scanf("%d",&size);
    int arr[size];
    if (size <4)
    {
        for (int i =0; i < size; i++)
        {
            printf("введите число №%d: ", i+1);
            scanf("%d",&arr[i]);
        }
    }
    else
    {
        for (int i =0; i < size; i++)
        {
            arr[i]= rand();
        }
    }
    int inp;
    printf("введите число для Задания 1: ");
    scanf("%d",&inp);
    printf("результат первого задания: %d\n", task1(arr,size, inp));
    printf("результат второго задания: %d\n", task2(arr,size));
}

