package Transport;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.concurrent.BlockingQueue;

public class TransportCreator implements Runnable {
    BlockingQueue<Transport> queue;
    String fileName;

    public TransportCreator(String fileName, BlockingQueue<Transport> blockingQueue) {
        queue = blockingQueue;
        this.fileName = fileName;
    }

    @Override
    public void run() {
        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String mark = reader.readLine();
            queue.put(new Car(mark, 5));

        } catch (IOException e) {
            e.printStackTrace();
            System.err.println("Не найден файл");
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
    }
}
