package Transport;

import java.io.Serializable;

public interface Transport extends Serializable {

    public abstract String getMark();

    public abstract void setMark(String new_mark);

    public abstract void setModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException;

    public abstract String[] getModelsNames();

    public abstract double getModelCost(String name) throws NoSuchModelNameException;

    public abstract void setModelCost(String name, double newCost) throws NoSuchModelNameException;

    public abstract double[] getAllModelsCost();

    public abstract void addModel(String name, double cost) throws DuplicateModelNameException;

    public abstract void removeModel(String name) throws NoSuchModelNameException;

    public abstract int getModelsLength();
}