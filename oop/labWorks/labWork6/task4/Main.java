import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[4];
        transports[0] = new Car("1", 6);
        transports[1] = new Motorbike("2", 5);
        transports[2] = new Scooter("3", 7);
        transports[3] = new QuadBike("4", 6);

        Runnable[] markPrinters = new Runnable[4];
        for (int i = 0; i < transports.length; i++) {
            markPrinters[i] = new MarkPrinter(transports[i]);
        }

        ExecutorService executors = Executors.newFixedThreadPool(2);
        for (Runnable runnable : markPrinters) {
            executors.execute(runnable);
        }
        executors.shutdown();
    }
}
