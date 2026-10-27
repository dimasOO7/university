import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport transport = new Motorbike("марка", 10);
        TransportSynchronizer synchronizer = new TransportSynchronizer(transport);
        Thread threadModels = new Thread(new NamesRunnable(synchronizer));
        Thread threadPrices = new Thread(new PricesRunnable(synchronizer));

        threadPrices.setPriority(Thread.MAX_PRIORITY);
        threadModels.setPriority(Thread.MIN_PRIORITY);
        threadModels.start();
        threadPrices.start();
    }
}
