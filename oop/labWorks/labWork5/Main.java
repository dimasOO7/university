import Transport.*;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;

public class Main {
    public static void main(String[] args) {
        Transport original = new Motorbike("orig", 5);
        Transport transport = TransportStatic.CreateByLink("created", 67, original);
        TransportStatic.show(original);
        TransportStatic.show(transport);
        System.out.println("Оригинальный класс:" + original.getClass().getName());
        System.out.println("класс созданного объекта:" + transport.getClass().getName());
    }
}
