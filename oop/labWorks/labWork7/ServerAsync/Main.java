import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        ExecutorService pool = Executors.newFixedThreadPool(14);
        try (ServerSocket serverSocket = new ServerSocket(8081)) {
            while (!serverSocket.isClosed()) {
                try {
                    Socket client = serverSocket.accept();
                    pool.execute(new ClientHandler(client));
                } catch (IOException e) {
                    System.err.println(e.getMessage());
                    e.printStackTrace();
                }
            }
        } catch (IOException e) {
            System.err.println(e.getMessage());
            e.printStackTrace();
        } finally {
            pool.shutdown();
        }
    }
}
