package Transport;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Random;

public class Motorbike implements Transport {
    private class Model implements Serializable {
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

        @Override
        public String toString() {
            return name + " : " + cost;
        }
    }

    private int size = 0;
    private Model head;
    private transient long lastModified;
    private String mark;

    {
        lastModified = System.currentTimeMillis();
        head = new Model();
        head.prev = head;
        head.next = head;
    }

    public Motorbike(String mark, int modelsSize) {
        this.mark = mark;
        Random random = new Random();
        String duplicateModelFix = "";
        while (size < modelsSize) {
            try {
                addModel(mark + duplicateModelFix + (size + 1), random.nextDouble(1000, 100000));
            } catch (DuplicateModelNameException e) {
                System.out.println("Ошибка: " + e.getMessage());
                duplicateModelFix += "0";
            } catch (ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
            }
        }
        lastModified = System.currentTimeMillis();
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void setMark(String new_mark) {
        mark = new_mark;
        lastModified = System.currentTimeMillis();
    }

    @Override
    public void setModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException {
        Model target = null;
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(oldName)) {
                target = p;
            } else if (p.name.equals(newName)) {
                throw new DuplicateModelNameException(newName);
            }
            p = p.next;
        }
        if (target == null) {
            throw new NoSuchModelNameException(oldName);
        }
        target.name = newName;
        lastModified = System.currentTimeMillis();
    }

    @Override
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

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                return p.cost;
            }
            p = p.next;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                p.cost = newCost;
                lastModified = System.currentTimeMillis();
                return;
            }
            p = p.next;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
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

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        if (cost < 0) {
            throw new ModelPriceOutOfBoundsException(cost);
        }
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
            p = p.next;
        }
        Model newModel = new Model(name, cost, head.prev, head);
        head.prev.next = newModel;
        head.prev = newModel;
        size++;
        lastModified = System.currentTimeMillis();
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
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
        throw new NoSuchModelNameException(name);
    }

    @Override
    public int getModelsLength() {
        return size;
    }

    @Override
    public String toString() {
        StringBuffer buff = new StringBuffer("мотоцикл марка: ");
        buff.append(mark);
        buff.append("\nчисло моделей:");
        buff.append(size);
        buff.append("\nсписок моделей:");
        int i = 1;
        Model p = head.next;
        while (p != head) {
            buff.append("\n");
            buff.append(i);
            buff.append(". ");
            buff.append(p);
            i++;
            p = p.next;
        }
        return buff.toString();
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj instanceof Transport) {
            Transport transport = (Transport) obj;
            if (transport.getMark().equals(mark)) {
                if (transport.getModelsLength() == size) {
                    return Arrays.equals(transport.getModelsNames(), getModelsNames())
                            && Arrays.equals(transport.getAllModelsCost(), getAllModelsCost());
                }
            }
        }
        return false;
    }
}
