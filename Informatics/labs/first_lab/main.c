//импорт библиотек
#include <stdlib.h>
#include <stdio.h>
#include <math.h>

//импорт остальных файлов
#include "task1.c"
#include "task2.c"
#include "task3.c"
#include "task4.c"

void main(){
    int selected_task;
    printf("Лабораторная работа №1\nвариант 6 61010-090301D Кузнецов Дмитрий\nВыберите задание (введите число от 1 до 4)\n");
    scanf("%d", &selected_task);
    switch (selected_task)
    {
    case 1:
        task1();
        break;
    
    case 2:
        task2();
        break;
    
    case 3:
        task3();
        break;

    case 4:
        task4();
        break;

    default:
        printf("введён неверный номер задания\n");
        break;
    }
}