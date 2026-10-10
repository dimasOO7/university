package Transport;

import java.io.Serializable;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Random;

public class Moped implements Transport {
    private class Model implements Serializable, Cloneable {
        String name = null;
        double cost = Double.NaN;

        public Model() {
        }

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

    private LinkedList<Model> list;
    private String mark;

    public Moped(String mark, int modelsSize) {
        this.mark = mark;
        Random random = new Random();
        list = new LinkedList<>();
        for (int i = 0; i < modelsSize; i++) {
            list.add(new Model(mark + (i + 1), random.nextDouble(1000, 100000)));
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
        Model target = null;
        for (Model model : list) {
            if (model.name.equals(oldName)) {
                target = model;
            } else if (model.name.equals(newName)) {
                throw new DuplicateModelNameException(newName);
            }
        }
        if (target == null) {
            throw new NoSuchModelNameException(oldName);
        }
        target.name = newName;
    }

    @Override
    public String[] getModelsNames() {
        String[] names = new String[list.size()];
        int i = 0;
        for (Model model : list) {
            names[i] = model.name;
            i++;
        }
        return names;
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        for (Model model : list) {
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
        for (Model model : list) {
            if (model.name.equals(name)) {
                model.cost = newCost;
                return;
            }
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[list.size()];
        int i = 0;
        for (Model model : list) {
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
        for (Model model : list) {
            if (model.name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
        }
        list.add(new Model(name, cost));
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        for (Model model : list) {
            if (model.name.equals(name)) {
                list.remove(model);
                return;
            }
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public int getModelsLength() {
        return list.size();
    }

    @Override
    public String toString() {
        StringBuffer buff = new StringBuffer("мопед марка: ");
        buff.append(mark);
        buff.append("\nчисло моделей:");
        buff.append(list.size());
        buff.append("\nсписок моделей:");
        int i = 1;
        for (Model model : list) {
            buff.append("\n");
            buff.append(i);
            buff.append(". ");
            buff.append(model);
            i++;
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
                if (transport.getModelsLength() == list.size()) {
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
        Moped result = null;
        try {
            result = (Moped) super.clone();
            result.list = new LinkedList<>();
            for (Model model : list) {
                result.list.add((Model) model.clone());
            }
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return result;
    }
}
