import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;

import ru.dima.matrix.Matrix;

public class ClientHandler implements Runnable {
    private final Socket socket;

    public ClientHandler(Socket socket) {
        this.socket = socket;
    }

    @Override
    public void run() {
        try (Socket socket = this.socket;
                ObjectInputStream inStream = new ObjectInputStream(socket.getInputStream());
                DataOutputStream outStream = new DataOutputStream(socket.getOutputStream());) {
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
}