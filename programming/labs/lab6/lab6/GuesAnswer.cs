namespace lab6;

/// <summary>
/// Класс для игры угадай ответ
/// </summary>
public class GuesAnswer
{
    public readonly double result;

    public double Result
    {
        get
        {
            return result;
        }
    }
    
    private readonly double a;

    public double A
    {
        get
        {
            return a;
        }
    }
    
    private readonly double b;

    public double B
    {
        get
        {
            return b;
        }
    }
    
    public GuesAnswer(double a, double b)
    {
        this.a = Math.Round(a, 2);
        this.b = Math.Round(b, 2);
        result = CalculateFunction(this.a, this.b);
    }
    private static double CalculateFunction(double a, double b)
    {
        double r = -4 * Math.Pow(Math.Sin(a * 3), 3) + Math.Sqrt(b) / Math.Log(b + 2);
        return Math.Round(r, 2);
    }
    /// <summary>
    /// проверка валидности ответа
    /// </summary>
    /// <param name="answer">ответ пользователя</param>
    /// <returns>true если ответ верен, false если неверен</returns>
    public bool Guess(double answer)
    {
        if (Math.Abs(answer - result) < 0.005)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}