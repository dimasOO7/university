public class DuplicateModelNameException extends Exception {
    private final String name;

    public DuplicateModelNameException(String name) {
        super("Название модели" + name + "повторяется");
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
