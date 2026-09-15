package Transport;

public class TransportStatic {
    public static void show(Transport transport) {
        String[] names = transport.getModelsNames();
        double[] prices = transport.getAllModelsCost();

        for (int i = 0; i < names.length; i++) {
            System.out.println(names[i] + " : " + prices[i]);
        }
    }

    public static  double getAvgCost(Transport transport) {
        int length = transport.getModelsLength();
        if (length <= 0) {
            throw new ArithmeticException("отсутствуют модели, вычисление средней цены невозможно");
        }
        double[] prices = transport.getAllModelsCost();
        double sum = 0;
        for (double a : prices) {
            sum += a;
        }
        return sum / length;
    }
}
