import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;

import matrix.Matrix;

public class ClientHandler implements Runnable {
    private final Socket socket;

    public ClientHandler(Socket socket) {
        this.socket = socket;
    }

    @Override
    public void run() {
        try {
            ObjectInputStream inStream = new ObjectInputStream(socket.getInputStream());
            Object obj = inStream.readObject();
            if (obj instanceof Matrix) {
                Matrix matrix = (Matrix) obj;
                DataOutputStream outStream = new DataOutputStream(socket.getOutputStream());
                outStream.writeDouble(Matrix.getOddSum(matrix));
                outStream.close();
            } else {
                System.err.println("Ошибка, получен неверный класс");
            }
            inStream.close();
        } catch (IOException | ClassNotFoundException e) {
            System.err.println(e.getMessage());
            e.getStackTrace();
        }
    }
}