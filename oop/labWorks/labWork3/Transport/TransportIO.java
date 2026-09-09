package Transport;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.Reader;
import java.io.Writer;
import java.nio.charset.StandardCharsets;

public class TransportIO {
    public static void outputTransport(Transport v, OutputStream out) throws IOException {
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

        for (int i = 0; i < modelsCount; i++) {
            byte[] nameBytes = names[i].getBytes();
            dOutStream.writeInt(nameBytes.length);
            dOutStream.write(nameBytes);
            dOutStream.writeDouble(costs[i]);
        }
    }

    public static Transport inputTransport(InputStream in) throws IOException, IllegalArgumentException {
        DataInputStream dInStream = new DataInputStream(in);
        int stringlen = dInStream.readInt();
        byte[] buffer = new byte[stringlen];
        dInStream.readFully(buffer);
        String type = new String(buffer, StandardCharsets.UTF_8);
        stringlen = dInStream.readInt();
        buffer = new byte[stringlen];
        dInStream.readFully(buffer);
        String mark = new String(buffer, StandardCharsets.UTF_8);
        int modelsCount = dInStream.readInt();
        Transport transport;
        switch (type) {
            case "Car":
                transport = new Car(mark, 0);
                break;
            case "Motorbike":
                transport = new Motorbike(mark, 0);
                break;
            default:
                throw new IllegalArgumentException("Неизвестный тип");
        }

        for (int i = 0; i < modelsCount; i++) {
            int nameLen = dInStream.readInt();
            byte[] nameBytes = new byte[nameLen];
            dInStream.readFully(nameBytes);
            String name = new String(nameBytes, StandardCharsets.UTF_8);
            double cost = dInStream.readDouble();
            try {
                transport.addModel(name, cost);
            } catch (DuplicateModelNameException e) {
                System.err.println(e.getMessage());
            }
        }
        return transport;
    }

    public static void writeTransport(Transport v, Writer out) {
        PrintWriter writer = new PrintWriter(out);
        writer.println(v.getClass().getSimpleName());
        writer.println(v.getMark());

        double[] costs = v.getAllModelsCost();
        String[] names = v.getModelsNames();
        for (int i = 0; i < names.length; i++) {
            writer.println(names[i]);
            writer.println(costs[i]);
        }
    }

    public static Transport readTransport(Reader in) throws IOException {
        BufferedReader reader = new BufferedReader(in);
        String type = reader.readLine();
        String mark = reader.readLine();

        Transport transport;

        switch (type) {
            case "Car":
                transport = new Car(mark, 0);
                break;
            case "Motorbike":
                transport = new Motorbike(mark, 0);
                break;
            default:
                throw new IllegalArgumentException("Неизвестный тип");
        }

        String name = reader.readLine();

        while (name != null) {
            double cost = Double.parseDouble(reader.readLine());
            try {
                transport.addModel(name, cost);
            } catch (DuplicateModelNameException e) {
                System.err.println(e.getMessage() + " пропуск этой модели");
            }
            name = reader.readLine();
        }

        return transport;
    }
}
