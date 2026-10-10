import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[5];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);
        transports[2] = new Scooter("скутер", 7);
        transports[3] = new QuadBike("квадроцикл", 6);
        transports[4] = new Moped("Мопед", 6);
        for (Transport transport : transports) {
            System.out.println(transport);
            try (FileWriter out = new FileWriter(transport.getClass().getSimpleName() + ".txt")) {
                TransportIO.writeTransport(transport, out);
                System.out.println(transport.getMark() + " успешно записан через символьный поток.");
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        Transport[] fromFiles = new Transport[5];

        for (int i = 0; i < transports.length; i++) {
            try (FileReader in = new FileReader(transports[i].getClass().getSimpleName() + ".txt")) {
                fromFiles[i] = TransportIO.readTransport(in);
                fromFiles[i].setMark("прочитанный " + fromFiles[i].getClass().getSimpleName());
                System.out.println(fromFiles[i]);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
