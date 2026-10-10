package Transport;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Objects;
import java.util.Random;

public class QuadBike implements Transport {
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
    private ArrayList<Model> models;

    public QuadBike(String mark, int modelsSize) {
        this.mark = mark;
        models = new ArrayList<Model>(modelsSize);
        Random random = new Random();
        for (int i = 0; i < modelsSize; i++) {
            models.add(new Model(mark + (i + 1), random.nextDouble(1000, 100000)));
        }
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void setMark(String new_mark) {
        mark = new_mark;
    }

    @Override
    public void setModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException {
        Model targetModel = null;
        for (Model model : models) {
            if (model.name.equals(oldName)) {
                targetModel = model;
            } else if (model.name.equals(newName)) {
                throw new DuplicateModelNameException(newName);
            }
        }
        if (targetModel == null) {
            throw new NoSuchModelNameException(oldName);
        }
        targetModel.name = newName;
    }

    @Override
    public String[] getModelsNames() {
        String[] names = new String[models.size()];
        for (int i = 0; i < names.length; i++) {
            names[i] = models.get(i).name;
        }
        return names;
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        for (Model model : models) {
            if (model.name.equals(name)) {
                return model.cost;
            }
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        for (Model model : models) {
            if (model.name.equals(name)) {
                model.cost = newCost;
                return;
            }
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[models.size()];
        for (int i = 0; i < costs.length; i++) {
            costs[i] = models.get(i).cost;
        }
        return costs;
    }

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        if (cost < 0) {
            throw new ModelPriceOutOfBoundsException(cost);
        }
        for (Model model : models) {
            if (model.name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
        }
        models.add(new Model(name, cost));
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        int targetIndex = -1;
        for (int i = 0; i < models.size(); i++) {
            if (models.get(i).name.equals(name)) {
                targetIndex = i;
                break;
            }
        }
        if (targetIndex < 0) {
            throw new NoSuchModelNameException(name);
        }
        models.remove(targetIndex);
    }

    @Override
    public int getModelsLength() {
        return models.size();
    }

    @Override
    public String toString() {
        StringBuffer buff = new StringBuffer("квадроцикл марка: ");
        buff.append(mark);
        buff.append("\nчисло моделей:");
        buff.append(models.size());
        buff.append("\nсписок моделей:");
        for (int i = 0; i < models.size(); i++) {
            buff.append("\n");
            buff.append(i + 1);
            buff.append(". ");
            buff.append(models.get(i));
        }
        return buff.toString();
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
                if (transport.getModelsLength() == models.size()) {
                    return Arrays.equals(transport.getModelsNames(), getModelsNames())
                            && Arrays.equals(transport.getAllModelsCost(), getAllModelsCost());
                }
            }
        }
        return false;
    }

    @Override
    public int hashCode() {
        int result = Objects.hashCode(mark);
        result = 31 * result + Arrays.hashCode(getModelsNames());
        result = 31 * result + Arrays.hashCode(getAllModelsCost());
        return result;
    }

    @Override
    public Object clone() {
        QuadBike result = null;
        try {
            result = (QuadBike) super.clone();
            result.models = new ArrayList<>(models.size());
            for (int i = 0; i < models.size(); i++) {
                result.models.add((Model) models.get(i).clone());
            }

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return result;
    }
}
