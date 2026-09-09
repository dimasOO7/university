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
        Transport[] transports = new Transport[8];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);

        try (OutputStream out = new FileOutputStream("car.transport")) {
            TransportIO.outputTransport(transports[0], out);
            System.out.println("автомобиль успешно записан.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (OutputStream out = new FileOutputStream("bike.transport")) {
            TransportIO.outputTransport(transports[1], out);
            System.out.println("мотоцикл успешно записан.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (InputStream in = new FileInputStream("car.transport")) {
            transports[2] = TransportIO.inputTransport(in);
            transports[2].changeMark("Прочитанная машина");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (InputStream in = new FileInputStream("bike.transport")) {
            transports[3] = TransportIO.inputTransport(in);
            transports[3].changeMark("Двухколёсный файл");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileWriter out = new FileWriter("car.txt")) {
            TransportIO.writeTransport(transports[0], out);
            System.out.println("автомобиль успешно записан через символьный поток.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileWriter out = new FileWriter("bike.txt")) {
            TransportIO.writeTransport(transports[1], out);
            System.out.println("мотоцикл успешно записан через символьный поток.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileReader in = new FileReader("car.txt")) {
            transports[4] = TransportIO.readTransport(in);
            transports[4].changeMark("машина из символов");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileReader in = new FileReader("bike.txt")) {
            transports[5] = TransportIO.readTransport(in);
            transports[5].changeMark("Мотоцикл из символов");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (OutputStream fileOut = new FileOutputStream("car.serialized");
                ObjectOutputStream out = new ObjectOutputStream(fileOut)) {
            out.writeObject(transports[0]);
            System.out.println("автомобиль успешно сериализован.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (OutputStream fileOut = new FileOutputStream("bike.serialized");
                ObjectOutputStream out = new ObjectOutputStream(fileOut)) {
            out.writeObject(transports[1]);
            System.out.println("мотоцикл успешно сериализован.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (InputStream fileIn = new FileInputStream("car.serialized");
                ObjectInputStream in = new ObjectInputStream(fileIn)) {
            transports[6] = (Transport) in.readObject();
            transports[6].changeMark("сериализованная машина");
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        try (InputStream fileIn = new FileInputStream("bike.serialized");
                ObjectInputStream in = new ObjectInputStream(fileIn)) {
            transports[7] = (Transport) in.readObject();
            transports[7].changeMark("сериализованный мотоцикл");
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        for (Transport transport : transports) {
            System.out.println("марка: " + transport.getMark());
            System.out.println("Класс: " + transport.getClass().getName());
            transport.show();
            System.out.println("Средняя цена: " + transport.getAvgCost());
        }

        System.out.println("Ручной ввод транспорта:");
        System.out.println("1.тип Car или Motorbike");
        System.out.println("2.марка");
        System.out.println("3.название модели 1");
        System.out.println("4.цена модели 1");
        System.out.println("5.название модели 2");
        System.out.println("6.цена модели 2");
        System.out.println("...");
        System.out.println("7. Ctr+D для Linux/Mac, Ctrl+Z для Windows");
        try {
            Transport transportFromReader = TransportIO.readTransport(new java.io.InputStreamReader(System.in));
            java.io.PrintWriter pw = new java.io.PrintWriter(System.out);
            TransportIO.writeTransport(transportFromReader, pw);
            pw.flush();
            transportFromReader.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
