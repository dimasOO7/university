import Transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[5];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motorbike("Двухколёсное", 5);
        transports[2] = new Scooter("скутер", 7);
        transports[3] = new QuadBike("Четырёхколёсное", 6);
        transports[4] = new Moped("Мопед", 6);

        for (Transport transport : transports) {
            try {
                transport.addModel("Точно уникальное название", 9999999);
                // transport.addModel("Точно уникальное название", -9999999);
                transport.setModelName("Точно уникальное название", "пупупу");
                // transport.setModelName("Точно не существующая модель", "тутутут");
                // transport.addModel("пупупу", 50000);
                transport.setModelCost(transport.getModelsNames()[0], 100);
                transport.removeModel(transport.getModelsNames()[1]);
                System.out.println(transport);
                System.out.println("Средняя цена: " + TransportStatic.getAvgCost(transport));
            } catch (DuplicateModelNameException | NoSuchModelNameException | ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
                e.printStackTrace();
            }
        }
        System.out.println("средняя цена по всем моделям:" + TransportStatic.getAvgCost(transports));
    }
}
