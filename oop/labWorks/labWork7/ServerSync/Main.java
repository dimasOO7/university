import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.ServerSocket;
import java.net.Socket;

import ru.dima.matrix.Matrix;

public class Main {
    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(8081)) {
            while (!serverSocket.isClosed()) {
                try (Socket client = serverSocket.accept();
                        ObjectInputStream inStream = new ObjectInputStream(client.getInputStream());
                        DataOutputStream outStream = new DataOutputStream(client.getOutputStream())) {
                    Object obj = inStream.readObject();
                    if (obj instanceof Matrix) {
                        Matrix matrix = (Matrix) obj;
                        outStream.writeDouble(Matrix.getOddSum(matrix));
                        outStream.flush();
                    } else {
                        System.err.println("Ошибка, получен неверный класс");
                    }
                } catch (IOException | ClassNotFoundException e) {
                    System.err.println(e.getMessage());
                    e.printStackTrace();
                }
            }
        } catch (IOException e) {
            System.err.println(e.getMessage());
            e.printStackTrace();
        }
    }
}
