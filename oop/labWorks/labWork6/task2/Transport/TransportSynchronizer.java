package Transport;

public class TransportSynchronizer {
    private Transport v;
    private volatile int current = 0;
    private Object lock = new Object();
    private boolean set = false;

    public TransportSynchronizer(Transport v) {
        this.v = v;
    }

    public void printPrice() throws InterruptedException {
        String val;
        synchronized (lock) {
            String[] p = v.getModelsNames();
            if (!canPrintPrice())
                throw new InterruptedException();
            while (!set)
                lock.wait();
            val = p[current++];
            System.out.println("Print model: " + val);
            set = false;
            lock.notifyAll();
        }
    }

    public void printModel() throws InterruptedException {
        synchronized (lock) {
            double[] s = v.getAllModelsCost();
            if (!canPrintModel())
                throw new InterruptedException();
            while (set)
                lock.wait();
            System.out.println("Print price: " + s[current]);

            set = true;
            lock.notifyAll();
        }
    }

    public boolean canPrintPrice() {
        return current < v.getModelsLength();
    }

    public boolean canPrintModel() {
        return (!set && current < v.getModelsLength()) || (set && current < v.getModelsLength() - 1);
    }
}