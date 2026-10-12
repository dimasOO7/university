
import Transport.*;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

public class Task1 {
    public static void main(String[] args) {
        if (args.length < 4) {
            System.out.println(
                    "Ошибка ввода, введите 4 аргумента: полное название класса, метод, аргумент1 метода, аргумент2 метода");
            return;
        }
        Transport transport;
        try {
            Class<?> c = Class.forName(args[0]);
            Constructor<?> constr = c.getConstructor(String.class, int.class);
            transport = (Transport) constr.newInstance("марка", 10);
            Method method = c.getMethod(args[1], String.class, double.class);
            method.invoke(transport, args[2], Double.parseDouble(args[3]));
            System.out.println("Марка: " + transport.getMark());
            TransportStatic.show(transport);
        } catch (ClassNotFoundException e) {
            System.err.println("Задан неверный класс:" + e.getMessage());
        } catch (InstantiationException | IllegalAccessException e) {
            System.err.println("Ошибка создания объекта:" + e.getMessage());
        } catch (NoSuchMethodException e) {
            System.err.println("Не найден метод:" + e.getMessage());
        } catch (InvocationTargetException e) {
            Throwable cause = (e.getCause() != null) ? e.getCause() : e;
            System.err.println("Ошибка при выполнении метода: " + cause.getMessage());
        }
    }
}

// java Task1 Transport.Motorbike setModelCost марка1 67