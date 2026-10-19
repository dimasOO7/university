package Transport;

public class PricesRunnable implements Runnable {
    private final TransportSynchronizer transport;

    public PricesRunnable(TransportSynchronizer transport) {
        this.transport = transport;
    }

    @Override
    public void run() {
        try {
            while (transport.canPrintPrice()) {
                transport.printPrice();
            }
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }
}
