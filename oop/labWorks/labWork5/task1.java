
import Transport.*;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

public class task1 {
    public static void main(String[] args) {
        Transport transport;
        try {
            Class c = Class.forName(args[0]);
            Constructor[] constr = c.getConstructors();
            transport = (Transport) constr[0].newInstance(args[1], Integer.parseInt(args[2]));
            Method method = c.getMethod(args[3], String.class, double.class);
            method.invoke(transport, args[4], Double.parseDouble(args[5]));
            TransportStatic.show(transport);
        } catch (ClassNotFoundException e) {
            System.err.print("Задан неверный класс:" + e.getMessage());
        } catch (InstantiationException | IllegalAccessException e) {
            System.err.print("Ошибка создания объекта:" + e.getMessage());
        } catch (NoSuchMethodException e) {
            System.err.print("Не найден метод:" + e.getMessage());
        } catch (InvocationTargetException e) {
            System.err.print("Не удалось вызвать метод:" + e.getMessage());
        }
    }
}

// java task1 Transport.Motorbike "мотоцикл" 3 setModelCost мотоцикл2 67