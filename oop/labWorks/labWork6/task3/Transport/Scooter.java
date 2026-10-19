package Transport;

import java.io.Serializable;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Objects;
import java.util.Random;

public class Scooter implements Transport {
    private String mark;

    private HashMap<String, Double> map;

    public Scooter(String mark, int modelsSize) {
        map = new HashMap<>(modelsSize);
        this.mark = mark;
        Random random = new Random();
        String duplicateModelFix = "";
        while (map.size() < modelsSize) {
            try {
                addModel(mark + duplicateModelFix + (map.size() + 1), random.nextDouble(1000, 100000));
            } catch (DuplicateModelNameException e) {
                System.out.println("Ошибка: " + e.getMessage());
                duplicateModelFix += "0";
            } catch (ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
            }
        }
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void setMark(String newMark) {
        mark = newMark;
    }

    @Override
    public void setModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException {
        if (!oldName.equals(newName) && map.containsKey(newName)) {
            throw new DuplicateModelNameException(newName);
        }
        if (!map.containsKey(oldName)) {
            throw new NoSuchModelNameException(oldName);
        }
        map.put(newName, map.remove(oldName));
    }

    @Override
    public String[] getModelsNames() {
        return map.keySet().toArray(new String[map.size()]);
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        Double cost = map.get(name);
        if (cost == null) {
            throw new NoSuchModelNameException(name);
        }
        return cost;
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        if (map.replace(name, newCost) == null) {
            throw new NoSuchModelNameException(name);
        }
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[map.size()];
        int i = 0;
        for (Double cost : map.values()) {
            costs[i] = cost;
            i++;
        }
        return costs;
    }

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        if (cost < 0) {
            throw new ModelPriceOutOfBoundsException(cost);
        }
        if (map.containsKey(name)) {
            throw new DuplicateModelNameException(name);
        }
        map.put(name, cost);
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        if (map.remove(name) == null) {
            throw new NoSuchModelNameException(name);
        }
    }

    @Override
    public int getModelsLength() {
        return map.size();
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj == this) {
            return true;
        }
        if (!(obj instanceof Transport)) {
            return false;
        }
        Transport transport = (Transport) obj;
        if (!Objects.equals(mark, transport.getMark())) {
            return false;
        }
        if (transport.getModelsLength() != map.size()) {
            return false;
        }

        for (String name : getModelsNames()) {
            try {
                if (Double.compare(getModelCost(name), transport.getModelCost(name)) != 0) {
                    return false;
                }
            } catch (NoSuchModelNameException e) {
                return false;
            }
        }
        return true;
    }

    @Override
    public Scooter clone() {
        try {
            Scooter result = (Scooter) super.clone();
            if (this.map != null) {
                result.map = new HashMap<>(this.map);
            }
            return result;
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public String toString() {
        StringBuffer buff = new StringBuffer("скутер марка: ");
        buff.append(mark);
        buff.append("\nчисло моделей:");
        buff.append(map.size());
        buff.append("\nсписок моделей:");
        int i = 1;
        for (Map.Entry<String, Double> entry : map.entrySet()) {
            buff.append("\n");
            buff.append(i);
            buff.append(". ");
            buff.append(entry.getKey());
            buff.append(" : ");
            buff.append(entry.getValue());
            i++;
        }
        return buff.toString();
    }

    @Override
    public int hashCode() {
        int result = Objects.hashCode(mark);
        result = 31 * result + Arrays.hashCode(getModelsNames());
        result = 31 * result + Arrays.hashCode(getAllModelsCost());
        return result;
    }
}
