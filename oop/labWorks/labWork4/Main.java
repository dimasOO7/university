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
        Transport[] transports = new Transport[4];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);
        transports[2] = (Transport) ((Car) transports[0]).clone();
        transports[3] = (Transport) ((Motorbike) transports[1]).clone();

        System.out
                .println("ссылки на автомобиль и клон: " + (transports[0] == transports[2] ? "одинаковые" : "разные"));
        System.out
                .println("ссылки на мотоцикл и клон: " + (transports[1] == transports[3] ? "одинаковые" : "разные"));
        System.out.println(
                "содержание автомобиля и клона: " + (transports[0].equals(transports[2]) ? "одинаковые" : "разные"));
        System.out.println("хэш оригинального автомобиля:" + transports[0].hashCode());
        System.out.println("хэш клона автомобиля:" + transports[2].hashCode());
        System.out.println(
                "содержание мотоцикла и клона: " + (transports[1].equals(transports[3]) ? "одинаковые" : "разные"));
        System.out.println("хэш оригинального мотоцикла:" + transports[1].hashCode());
        System.out.println("хэш клона мотоцикла:" + transports[3].hashCode());
        try {
            transports[2].setMark("клонированный автомобиль");
            transports[2].setModelName("Четырёхколёсное1", "клонированная марка");
            transports[3].setMark("клонированный мотоцикл");
            transports[3].setModelName("Двухколёсное1", "клонированная марка");
        } catch (DuplicateModelNameException | NoSuchModelNameException e) {
            e.printStackTrace();
        }

        for (Transport transport : transports) {
            System.out.println(transport);
            System.out.println("хэш: " + transport.hashCode());
        }

    }
}
