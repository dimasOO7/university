package Transport;

public class NamesSynchronizer implements Runnable {
    private final TransportSynchronizer transport;

    public NamesSynchronizer(TransportSynchronizer transport) {
        this.transport = transport;
    }

    @Override
    public void run() {
        try {
            while (transport.canPrintModel()) {
                transport.printModel();
            }
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }
}
