package Transport;

import java.util.Arrays;
import java.util.Random;

public class Car implements Transport {
    private class Model {
        public String name;
        public double cost;

        public Model(String name, double cost) {
            this.name = name;
            this.cost = cost;
        }
    }

    private String mark;
    private Model[] models;

    public Car(String mark, int modelsSize) {
        this.mark = mark;
        models = new Model[modelsSize];
        Random random = new Random();
        for (int i = 0; i < modelsSize; i++) {
            models[i] = new Model(mark + (i + 1), random.nextDouble(1000, 100000));
        }
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void changeMark(String new_mark) {
        mark = new_mark;
    }

    @Override
    public void changeModelName(String oldName, String newName)
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
        String[] names = new String[models.length];
        for (int i = 0; i < names.length; i++) {
            names[i] = models[i].name;
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
    public void changeModelCost(String name, double newCost) throws NoSuchModelNameException {
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
        double[] costs = new double[models.length];
        for (int i = 0; i < costs.length; i++) {
            costs[i] = models[i].cost;
        }
        return costs;
    }

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        for (Model model : models) {
            if (model.name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
        }
        models = Arrays.copyOf(models, models.length + 1);
        models[models.length - 1] = new Model(name, cost);
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        int targetIndex = -1;
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(name)) {
                targetIndex = i;
                break;
            }
        }
        if (targetIndex < 0) {
            throw new NoSuchModelNameException(name);
        }
        System.arraycopy(models, targetIndex + 1, models, targetIndex, models.length - targetIndex - 1);
        models = Arrays.copyOf(models, models.length - 1);
    }

    @Override
    public int getModelsLength() {
        return models.length;
    }
}
