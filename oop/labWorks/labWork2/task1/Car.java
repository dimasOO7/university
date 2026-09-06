import java.util.Arrays;
import java.util.Scanner;

public class Car {
    private String mark;
    private Model[] models;

    public String getMark() {
        return mark;
    }

    public void changeMark(String new_mark) {
        mark = new_mark;
    }

    private class Model {
        public String name;
        public double cost;

        public Model(String name, double cost) {
            this.name = name;
            this.cost = cost;
        }
    }

    public void changeModelName(String oldName, String newName) {
        Model targetModel = null;
        for (Model model : models) {
            if (model.name.equals(oldName)) {
                targetModel = model;
            } else if (model.name.equals(newName)) {
                throw new RuntimeException();
            }
        }
        if (targetModel == null) {
            throw new RuntimeException("Не найдена старая модель");
        }
        targetModel.name = newName;
    }

    public String[] getModelsNames() {
        String[] names = new String[models.length];
        for (int i = 0; i < names.length; i++) {
            names[i] = models[i].name;
        }
        return names;
    }

    public double getModelCost(String name) {
        for (Model model : models) {
            if (model.name.equals(name)) {
                return model.cost;
            }
        }
        throw new RuntimeException();
    }

    public void changeModelCost(String name, double newCost) {
        for (Model model : models) {
            if (model.name.equals(name)) {
                model.cost = newCost;
                return;
            }
        }
        throw new RuntimeException();
    }

    public double[] getAllModelsCost() {
        double[] costs = new double[models.length];
        for (int i = 0; i < costs.length; i++) {
            costs[i] = models[i].cost;
        }
        return costs;
    }

    public void addModel(String name, double cost) {
        for (Model model : models) {
            if (model.name.equals(name)) {
                throw new RuntimeException();
            }
        }
        models = Arrays.copyOf(models, models.length + 1);
        models[models.length - 1] = new Model(name, cost);
    }

    public void removeModel(String name) {
        int targetIndex = -1;
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(name)) {
                targetIndex = i;
                break;
            }
        }
        if (targetIndex < 0) {
            throw new RuntimeException();
        }
        System.arraycopy(models, targetIndex + 1, models, targetIndex, models.length - targetIndex - 1);
        models = Arrays.copyOf(models, models.length - 1);
    }

    public int getModelsLength() {
        return models.length;
    }

    public Car(String mark, int modelsSize) {
        this.mark = mark;
        models = new Model[modelsSize];
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < modelsSize; i++) {
            boolean checkedName = false;
            String name = "";
            while (!checkedName) {
                System.out.println("Введите название для модели №" + (i + 1) + ":");
                name = scanner.nextLine();
                if (name != null && !name.equals("")) {
                    checkedName = true;
                    for (int j = 0; j < i; j++) {
                        if (models[j].name.equals(name)) {
                            checkedName = false;
                            break;
                        }
                    }
                }
            }

            System.out.println("Введите цену модели " + name + ":");
            double cost = Double.parseDouble(scanner.nextLine());
            models[i] = new Model(name, cost);
        }
    }
}
