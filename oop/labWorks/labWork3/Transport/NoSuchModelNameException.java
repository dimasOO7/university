package Transport;

public class NoSuchModelNameException extends Exception {
    private final String name;

    public NoSuchModelNameException(String name) {
        super("Модель с именем " + name + " не найдена");
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
