public class ModelPriceOutOfBoundsException extends RuntimeException {
    private final double cost;

    public ModelPriceOutOfBoundsException(double cost) {
        super("Цена" + cost + "выходит за пределы");
        this.cost = cost;
    }

    public double getCost() {
        return cost;
    }
}
