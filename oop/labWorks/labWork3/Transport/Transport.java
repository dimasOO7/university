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

    public static void outputTransport(Transport v,OutputStream out) throws IOException
    {
        DataOutputStream dOutStream = new DataOutputStream(out);
        byte[] classBytes = v.getClass().getSimpleName().getBytes();
        dOutStream.writeInt(classBytes.length);
        dOutStream.write(classBytes);
        byte[] markBytes = v.getMark().getBytes();
        dOutStream.writeInt(markBytes.length);
        dOutStream.write(markBytes);

        int modelsCount = v.getModelsLength();

        dOutStream.writeInt(modelsCount);

        double[] costs = v.getAllModelsCost();
        String[] names = v.getModelsNames();

        for(int i = 0; i < modelsCount; i++)
        {
            byte[] nameBytes = names[i].getBytes();
            dOutStream.writeInt(nameBytes.length);
            dOutStream.write(nameBytes);
            dOutStream.writeDouble(costs[i]);
        }
    }

    public  static Transport inputTransport(InputStream in) throws  IOException, IllegalArgumentException
    {
        DataInputStream dInStream = new DataInputStream(in);
        int stringlen = dInStream.readInt();
        byte[] buffer = new byte[stringlen];
        dInStream.readFully(buffer);
        String type = new String(buffer,StandardCharsets.UTF_8);
        stringlen = dInStream.readInt();
        buffer = new byte[stringlen];
        dInStream.readFully(buffer);
        String mark = new String(buffer,StandardCharsets.UTF_8);
        int modelsCount = dInStream.readInt();
        Transport transport;
        switch(type)
        {
            case "Car":
                transport = new Car(mark,0);
                break;
            case "Motorbike":
                transport = new Motorbike(mark, 0);
                break;
            default:
                throw new IllegalArgumentException("Неизвестный тип");
        }

        for(int i = 0; i < modelsCount;i++)
        {
            int nameLen = dInStream.readInt();
            byte[] nameBytes = new byte[nameLen];
            dInStream.readFully(nameBytes);
            String name = new String(nameBytes,StandardCharsets.UTF_8);
            double cost = dInStream.readDouble();
            try
            {
            transport.addModel(name, cost);
            }
            catch (DuplicateModelNameException e)
            {
                System.err.println(e.getMessage());
            }
        }
        return transport;
    }
}