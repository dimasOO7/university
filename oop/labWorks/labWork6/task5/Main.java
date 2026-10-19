import java.util.concurrent.ArrayBlockingQueue;
import Transport.*;

public class Main {
    public static void main(String[] args) {
        String[] files = { "lada.txt", "bmw.txt", "mazda.txt", "porshe.txt", "tesla.txt" };

        ArrayBlockingQueue<Transport> queue = new ArrayBlockingQueue<>(2);
        for (String file : files) {
            Thread thread = new Thread(new TransportCreator(file, queue));
            thread.start();
        }
        for (int i = 0; i < files.length; i++) {
            try {
                System.out.println(queue.take().getMark());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
