package Transport;

public class NamesRunnable implements Runnable {
    private final TransportSynchronizer transport;

    public NamesRunnable(TransportSynchronizer transport) {
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
