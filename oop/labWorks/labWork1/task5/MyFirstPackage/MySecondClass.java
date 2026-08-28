package MyFirstPackage;
import java.util.Random;

public class MySecondClass
{
    private int[] numbers;

    public int getNumber(int i)
    {
        if (i < numbers.length &&  i >= 0)
        {
            return numbers[i];
        }
        return -1;
    }

    public void setNumber(int i, int number)
    {
        if (i < numbers.length &&  i >= 0)
        {
            numbers[i] = number;
        }
    }

    public MySecondClass(int length)
    {
        Random random = new Random();
        numbers = new int[length];
        for(int i = 0; i < length; i++)
        {
            numbers[i] = random.nextInt(1000);
        }
    }

    public double getAvg()
    {
        if (numbers.length == 0){
            return 0;
        }

        double sum = 0;
        for (int n : numbers) {
            sum += n;
        }
        return sum/numbers.length;
    }

    public void displayArray()
    {
        for (int n : numbers)
        {
         System.out.println(n);   
        }
    }
}
