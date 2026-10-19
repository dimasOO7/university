package Transport;

public class PricesSynchronizer implements Runnable {
    private final TransportSynchronizer transport;

    public PricesSynchronizer(TransportSynchronizer transport) {
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
