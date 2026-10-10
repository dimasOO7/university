package Transport;

import java.io.Serializable;
import java.util.Collection;
import java.util.HashMap;
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

    String mark;

    HashMap<String, Model> map;

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
        if (map.containsKey(newName)) {
            throw new DuplicateModelNameException(newName);
        }
        Model model = map.remove(oldName);
        if (model != null) {
            model.name = newName;
            map.put(newName, model);
        }
        throw new NoSuchModelNameException(oldName);
    }

    @Override
    public String[] getModelsNames() {
        return (String[]) map.keySet().toArray();
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        Model model = map.get(name);
        if (model != null) {
            return model.cost;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        Model model = map.get(name);
        if (model != null) {
            model.cost = newCost;
        }
        throw new NoSuchModelNameException(name);
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
}
