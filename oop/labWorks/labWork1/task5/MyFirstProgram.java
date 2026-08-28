import java.util.Scanner;
import MyFirstPackage.MySecondClass;

class MyFirstClass
{
    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);

        System.out.print("введите размер массива: ");
        int i = scanner.nextInt();
        MySecondClass secondClass = new MySecondClass(i);
        System.out.print("введите новое первое число: ");
        int n = scanner.nextInt();
        secondClass.setNumber(0, n);
        double avg = secondClass.getAvg();
        System.out.println("среднее арифметическое: " + avg);
        secondClass.displayArray();

        scanner.close();
    }
}

