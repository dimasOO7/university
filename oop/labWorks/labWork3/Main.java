import Transport.*;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[4];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);

        try(OutputStream out =  new FileOutputStream("car.transport"))
        {
            Transport.outputTransport(transports[0], out);
            System.out.println("автомобиль успешно записан.");
        }
        catch( IOException e)
        {
            e.printStackTrace();
        }

        try(OutputStream out =  new FileOutputStream("bike.transport"))
        {
            Transport.outputTransport(transports[1], out);
            System.out.println("мотоцикл успешно записан.");
        }
        catch( IOException e)
        {
            e.printStackTrace();
        }

        try(InputStream in = new FileInputStream("car.transport"))
        {
            transports[2] = Transport.inputTransport(in);
            transports[2].changeMark("Прочитанная машина");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

        try(InputStream in = new FileInputStream("bike.transport"))
        {
            transports[3] = Transport.inputTransport(in);
            transports[3].changeMark("Двухколёсный файл");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }


        for (Transport transport : transports) {
            try {
                System.out.println("марка: " + transport.getMark());
                System.out.println("Класс: " + transport.getClass().getName());
                transport.addModel("Точно уникальное название", 9999999);
                transport.changeModelName("Точно уникальное название", "пупупу");
                transport.changeModelCost(transport.getModelsNames()[0], 100);
                transport.removeModel(transport.getModelsNames()[1]);
                transport.show();
                System.out.println("Средняя цена: " + transport.getAvgCost());
            } catch (DuplicateModelNameException | NoSuchModelNameException | ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
            }
        }
    }
}
