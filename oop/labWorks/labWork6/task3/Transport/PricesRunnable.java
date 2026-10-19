package Transport;

import java.util.concurrent.locks.ReentrantLock;

public class PricesRunnable implements Runnable {
    private final Transport transport;
    private final ReentrantLock lock;

    public PricesRunnable(Transport transport, ReentrantLock lock) {
        this.transport = transport;
        this.lock = lock;
    }

    @Override
    public void run() {
        lock.lock();
        try {
            double[] costs = transport.getAllModelsCost();
            for (double cost : costs) {
                System.out.println("цена:" + cost);
            }
        } finally {
            lock.unlock();
        }
    }
}
