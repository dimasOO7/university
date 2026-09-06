import java.util.Scanner;

public class Motorbike {
    private class Model {
        String name = null;
        double cost = Double.NaN;
        Model prev = null;
        Model next = null;

        public Model() {
        }

        public Model(String name, double cost) {
            this.name = name;
            this.cost = cost;
        }

        public Model(String name, double cost, Model prev, Model next) {
            this.name = name;
            this.cost = cost;
            this.prev = prev;
            this.next = next;
        }
    }

    private int size = 0;
    private Model head;
    private long lastModified;
    private String mark;

    {
        lastModified = System.currentTimeMillis();
        head = new Model();
        head.prev = head;
        head.next = head;
    }

    public Motorbike(String mark, int modelsSize) {
        this.mark = mark;
        Scanner scanner = new Scanner(System.in);
        while (size < modelsSize) {
            System.out.println("Введите название для модели №" + (size + 1) + ":");
            String name = scanner.nextLine();
            System.out.println("Введите цену модели " + name + ":");
            double cost = Double.parseDouble(scanner.nextLine());

            addModel(name, cost);
        }
        lastModified = System.currentTimeMillis();
    }

    public String getMark() {
        return mark;
    }

    public void changeMark(String new_mark) {
        mark = new_mark;
        lastModified = System.currentTimeMillis();
    }

    public void changeModelName(String oldName, String newName) {
        Model target = null;
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(oldName)) {
                target = p;
            } else if (p.name.equals(newName)) {
                throw new RuntimeException();
            }
            p = p.next;
        }
        if (target == null) {
            throw new RuntimeException();
        }
        target.name = newName;
        lastModified = System.currentTimeMillis();
    }

    public String[] getModelsNames() {
        String[] names = new String[size];
        Model p = head.next;
        int i = 0;
        while (p != head) {
            names[i] = p.name;
            i++;
            p = p.next;
        }
        return names;
    }

    public double getModelCost(String name) {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                return p.cost;
            }
            p = p.next;
        }
        throw new RuntimeException();
    }

    public void changeModelCost(String name, double newCost) {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                p.cost = newCost;
                lastModified = System.currentTimeMillis();
                return;
            }
            p = p.next;
        }
        throw new RuntimeException();
    }

    public double[] getAllModelsCost() {
        double[] costs = new double[size];
        Model p = head.next;
        int i = 0;
        while (p != head) {
            costs[i] = p.cost;
            i++;
            p = p.next;
        }
        return costs;
    }

    public void addModel(String name, double cost) {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                throw new RuntimeException();
            }
            p = p.next;
        }
        Model newModel = new Model(name, cost, head.prev, head);
        head.prev.next = newModel;
        head.prev = newModel;
        size++;
        lastModified = System.currentTimeMillis();
    }

    public void removeModel(String name) {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                p.prev.next = p.next;
                p.next.prev = p.prev;
                size--;
                lastModified = System.currentTimeMillis();
                return;
            }
            p = p.next;
        }
    }

    public int getModelsLength() {
        return size;
    }
}
