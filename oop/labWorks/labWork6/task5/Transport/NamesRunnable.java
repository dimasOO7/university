package Transport;

import java.util.concurrent.locks.ReentrantLock;

public class NamesRunnable implements Runnable {
    private final Transport transport;
    private final ReentrantLock lock;

    public NamesRunnable(Transport transport, ReentrantLock lock) {
        this.transport = transport;
        this.lock = lock;
    }

    @Override
    public void run() {
        lock.lock();
        try {
            String[] names = transport.getModelsNames();
            for (String name : names) {
                System.out.println("Модель: " + name);
            }
        } finally {
            lock.unlock();
        }
    }
}
