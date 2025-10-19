#include <stdio.h>
#include <ctype.h>

int is_glasn(char c) 
{
    return (c == 'a' || c == 'e' || c == 'i' ||
            c == 'o' || c == 'u' || c == 'y');
}


int main(){
    printf("Лабораторная работа №3\nВариант 1 61010-090301D Кузнецов Дмитрий\n");
    FILE *out = fopen("out.txt", "w");
    if (!out) { 
        perror("Ошибка открытия файла для записи\n"); 
        return 1;
    }
    FILE *in = fopen("in.txt", "r");
     if (!in) { 
        perror("Ошибка открытия файла для чтения\n"); 
        return 1;
    }
    int n = 0; // переменная для подсчёта того, каких букв больше, если < 0 то больше согласных, если >= 0 больше гласных
    char glasn[26];
    char sogl[26];
    int ch;
    int str = 1;  
    while ((ch = fgetc(in)) != EOF)
    {   
        if (ch == '\n') {
            if (n >= 0)
            {
                for (int i =0; i<26;i++)
                {
                    if (glasn[i])
                    {
                        fputc(glasn[i],out);
                    }
                }
            }
            else
            {
                for (int i =0; i<26;i++)
                {
                    if (sogl[i])
                    {
                        fputc(sogl[i],out);
                    }
                }
            }
            fputc('\n',out);
            n =0;
            for (int i = 0; i < 26; i++) {
                glasn[i] = 0;
                sogl[i] = 0; 
            }
            str++;
            continue;

        }
        ch = tolower(ch);
        if (isalpha(ch)){
            if (is_glasn(ch))
            {
                n++;
                glasn[ch - 'a'] = ch; // записываем букву в массив для глассных, на её позицию в алфавите
            }
            else
            {
                n--;
                sogl[ch -'a'] = ch; // записываем букву в массив для согласных, на её позицию в алфавите
            }
        } 

    }

    if (n >= 0)
    {
        for (int i =0; i<26;i++)
        {
            if (glasn[i])
            {
                fputc(glasn[i],out);
            }
        }
    }
    else
    {
        for (int i =0; i<26;i++)
        {
            if (sogl[i])
            {
                fputc(sogl[i],out);
            }
        }
    }
    fclose(out);
    fclose(in);
    return 0;
}