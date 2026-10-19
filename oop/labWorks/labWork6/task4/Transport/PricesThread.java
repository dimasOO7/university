package Transport;

public class PricesThread extends Thread {
    private final Transport transport;

    public PricesThread(Transport transport) {
        this.transport = transport;
    }

    @Override
    public void run() {
        double[] costs = transport.getAllModelsCost();
        for (double cost : costs) {
            System.out.println(cost);
        }
    }
}
