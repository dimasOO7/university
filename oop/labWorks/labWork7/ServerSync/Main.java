import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.ServerSocket;
import java.net.Socket;

import matrix.Matrix;

public class Main {
    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(8081)) {
            while (!serverSocket.isClosed()) {
                try (Socket client = serverSocket.accept()) {
                    ObjectInputStream inStream = new ObjectInputStream(client.getInputStream());
                    Object obj = inStream.readObject();
                    if (obj instanceof Matrix) {
                        Matrix matrix = (Matrix) obj;
                        DataOutputStream outStream = new DataOutputStream(client.getOutputStream());
                        outStream.writeDouble(Matrix.getOddSum(matrix));
                        outStream.close();
                    } else {
                        System.err.println("Ошибка, получен неверный класс");
                    }
                    inStream.close();
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
