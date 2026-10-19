import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport transport = new Motorbike("марка", 1000);
        ModelNamesThread namesThread = new ModelNamesThread(transport);
        PricesThread pricesThread = new PricesThread(transport);
        pricesThread.setPriority(Thread.MAX_PRIORITY);
        namesThread.setPriority(Thread.MIN_PRIORITY);
        namesThread.start();
        pricesThread.start();
    }
}
