package Transport;

public class MarkPrinter implements Runnable {
    private final Transport transport;

    public MarkPrinter(Transport transport) {
        this.transport = transport;
    }

    @Override
    public void run() {
        System.out.println(transport.getMark());
    }
}
