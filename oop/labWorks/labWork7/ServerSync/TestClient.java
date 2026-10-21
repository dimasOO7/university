import java.io.DataInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

import matrix.Matrix;

public class TestClient {
    public static void main(String[] args) {
        try {
            Socket socket = new Socket("localhost", 8081);
            Matrix matrix = new Matrix(3, 3);
            ObjectOutputStream jOutputStream = new ObjectOutputStream(socket.getOutputStream());
            jOutputStream.writeObject(matrix);
            DataInputStream dataInputStream = new DataInputStream(socket.getInputStream());
            System.out.println(matrix);
            System.out.println(dataInputStream.readDouble());
            System.out.println();
        } catch (Exception e) {
            System.err.println(e.getMessage());
        }
    }
}
