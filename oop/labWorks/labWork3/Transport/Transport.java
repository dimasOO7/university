package Transport;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.charset.StandardCharsets;

public interface Transport {

    public abstract String getMark();

    public abstract void changeMark(String new_mark);

    public abstract void changeModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException;

    public abstract String[] getModelsNames();

    public abstract double getModelCost(String name) throws NoSuchModelNameException;

    public abstract void changeModelCost(String name, double newCost) throws NoSuchModelNameException;

    public abstract double[] getAllModelsCost();

    public abstract void addModel(String name, double cost) throws DuplicateModelNameException;

    public abstract void removeModel(String name) throws NoSuchModelNameException;

    public abstract int getModelsLength();

    public default void show() {
        String[] names = getModelsNames();
        double[] prices = getAllModelsCost();

        for (int i = 0; i < names.length; i++) {
            System.out.println(names[i] + " : " + prices[i]);
        }
    }

    public default double getAvgCost() {
        int length = getModelsLength();
        if (length <= 0) {
            throw new ArithmeticException("отсутствуют модели, вычисление средней цены невозможно");
        }
        double[] prices = getAllModelsCost();
        double sum = 0;
        for (double a : prices) {
            sum += a;
        }
        return sum / length;
    }
}