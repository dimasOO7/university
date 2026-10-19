package Transport;

public class ModelNamesThread extends Thread {
    private final Transport transport;

    public ModelNamesThread(Transport transport) {
        this.transport = transport;
    }

    @Override
    public void run() {
        String[] names = transport.getModelsNames();
        for (String name : names) {
            System.out.println("модель: " + name);
        }
    }
}
