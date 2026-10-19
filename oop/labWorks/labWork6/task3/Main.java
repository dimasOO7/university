import java.util.concurrent.locks.ReentrantLock;

import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport transport = new Motorbike("марка", 10);

        ReentrantLock lock = new ReentrantLock();

        Thread threadModels = new Thread(new NamesRunnable(transport, lock));
        Thread threadPrices = new Thread(new PricesRunnable(transport, lock));

        threadModels.start();
        threadPrices.start();
    }
}
