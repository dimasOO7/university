package Transport;

import java.io.Serializable;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Objects;
import java.util.Random;

public class Scooter implements Transport {
    private class Model implements Serializable, Cloneable {
        public String name;
        public double cost;

        public Model(String name, double cost) {
            this.name = name;
            this.cost = cost;
        }

        @Override
        public String toString() {
            return name + " : " + cost;
        }

        @Override
        public Object clone() throws CloneNotSupportedException {
            return super.clone();
        }
    }

    private String mark;

    private HashMap<String, Model> map;

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
        Model model = map.remove(oldName);
        if (model == null) {
            throw new NoSuchModelNameException(oldName);
        }
        model.name = newName;
        map.put(newName, model);
    }

    @Override
    public String[] getModelsNames() {
        return map.keySet().toArray(new String[map.size()]);
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        Model model = map.get(name);
        if (model == null) {
            throw new NoSuchModelNameException(name);
        }
        return model.cost;
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        Model model = map.get(name);
        if (model == null) {
            throw new NoSuchModelNameException(name);
        }
        model.cost = newCost;
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[map.size()];
        int i = 0;
        for (Model model : map.values()) {
            costs[i] = model.cost;
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
        map.put(name, new Model(name, cost));
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        Model model = map.remove(name);
        if (model == null) {
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
        if (obj instanceof Transport) {
            Transport transport = (Transport) obj;
            if (Objects.equals(mark, transport.getMark())) {
                if (transport.getModelsLength() == map.size()) {
                    return Arrays.equals(transport.getModelsNames(), getModelsNames())
                            && Arrays.equals(transport.getAllModelsCost(), getAllModelsCost());
                }
            }
        }
        return false;
    }

    @Override
    public Object clone() {
        Scooter result = null;
        try {
            result = (Scooter) super.clone();
            result.map = new HashMap<>(map.size());
            for (Map.Entry<String, Model> entry : map.entrySet()) {
                result.map.put(entry.getKey(), (Model) entry.getValue().clone());
            }

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return result;
    }

    @Override
    public String toString() {
        StringBuffer buff = new StringBuffer("скутер марка: ");
        buff.append(mark);
        buff.append("\nчисло моделей:");
        buff.append(map.size());
        buff.append("\nсписок моделей:");
        int i = 1;
        for (Map.Entry<String, Model> entry : map.entrySet()) {
            buff.append("\n");
            buff.append(i);
            buff.append(". ");
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
