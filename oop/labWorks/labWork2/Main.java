import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[2];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);

        for (Transport transport : transports) {
            try {
                System.out.println("марка: " + transport.getMark());
                System.out.println("Класс: " + transport.getClass().getName());
                transport.addModel("Точно уникальное название", 9999999);
                //transport.addModel("Точно уникальное название", -9999999);
                transport.setModelName("Точно уникальное название", "пупупу");
                //transport.setModelName("Точно не существующая модель", "тутутут");
                //transport.addModel("пупупу", 50000);
                transport.setModelCost(transport.getModelsNames()[0], 100);
                transport.removeModel(transport.getModelsNames()[1]);
                TransportStatic.show(transport);
                System.out.println("Средняя цена: " + TransportStatic.getAvgCost(transport));
            } catch (DuplicateModelNameException | NoSuchModelNameException | ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
            }
        }
    }
}
