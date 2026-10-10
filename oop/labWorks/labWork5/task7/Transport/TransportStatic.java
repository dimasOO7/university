package Transport;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;

public class TransportStatic {
    public static void show(Transport transport) {
        String[] names = transport.getModelsNames();
        double[] prices = transport.getAllModelsCost();

        for (int i = 0; i < names.length; i++) {
            System.out.println(names[i] + " : " + prices[i]);
        }
    }

    public static double getAvgCost(Transport transport) {
        int length = transport.getModelsLength();
        if (length <= 0) {
            throw new ArithmeticException("отсутствуют модели, вычисление средней цены невозможно");
        }
        double[] prices = transport.getAllModelsCost();
        double sum = 0;
        for (double a : prices) {
            sum += a;
        }
        return sum / length;
    }

    public static Transport createByLink(String mark, int size, Transport link) {
        if (link == null) {
            return null;
        }
        Class c = link.getClass();
        try {
            Constructor constructor = c.getConstructor(String.class, int.class);
            return (Transport) constructor.newInstance(mark, size);
        } catch (NoSuchMethodException e) {
            return null;
        } catch (IllegalAccessException | IllegalArgumentException | InvocationTargetException
                | InstantiationException e) {
            System.out.println("ошибка при создании объекта" + e.getMessage());
            return null;
        }
    }

    public static double getAvgCost(Transport... transports) {
        if (transports == null || transports.length == 0) {
            throw new IllegalArgumentException("отсутствуют транспортные средства");
        }
        double sum = 0;
        double count = 0;
        for (Transport transport : transports) {
            if (transport == null) {
                continue;
            }

            double[] costs = transport.getAllModelsCost();
            count += costs.length;
            for (double cost : costs) {
                sum += cost;
            }
        }
        if (count <= 0) {
            throw new ArithmeticException("отсутствуют модели, вычисление средней цены невозможно");
        }
        return sum / count;
    }
}
