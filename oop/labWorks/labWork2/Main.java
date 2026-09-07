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
