package dima;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.control.Button;
import javafx.scene.control.ColorPicker;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Slider;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.Priority;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

public class App extends Application {

    private static final String[] AXES = { "X", "Y", "Z" };

    private final Canvas canvas = new Canvas();
    private final Renderer renderer = new Renderer();
    private final ComboBox<Renderer.Mode> mode = new ComboBox<>();
    private final ColorPicker color = new ColorPicker(Color.rgb(255, 255, 255));
    private final Slider[] move = new Slider[3];
    private final Slider[] scale = new Slider[3];
    private final Slider[] rotate = new Slider[3];
    private double[][] transform = Matrix.identity();

    @Override
    public void start(Stage stage) {
        Pane canvasPane = new Pane(canvas);
        canvas.widthProperty().bind(canvasPane.widthProperty());
        canvas.heightProperty().bind(canvasPane.heightProperty());
        canvas.widthProperty().addListener((obs, oldValue, newValue) -> draw());
        canvas.heightProperty().addListener((obs, oldValue, newValue) -> draw());

        mode.getItems().addAll(Renderer.Mode.values());
        mode.setValue(Renderer.Mode.WIREFRAME);
        mode.setMaxWidth(Double.MAX_VALUE);
        mode.valueProperty().addListener((obs, oldValue, newValue) -> draw());
        color.setMaxWidth(Double.MAX_VALUE);
        color.valueProperty().addListener((obs, oldValue, newValue) -> draw());

        Button reset = new Button("Сброс");
        reset.setMaxWidth(Double.MAX_VALUE);
        reset.setOnAction(e -> reset());

        VBox controls = new VBox(10,
                new Label("Режим отображения"), mode,
                new Label("Цвет фигуры"), color,
                group("Перемещение", move, -3, 3, 0, this::applyMove),
                group("Масштабирование", scale, 0.1, 3, 1, this::applyScale),
                group("Поворот, °", rotate, -180, 180, 0, this::applyRotate),
                reset);
        controls.setPadding(new Insets(10));
        controls.setPrefWidth(300);

        BorderPane root = new BorderPane();
        root.setCenter(canvasPane);
        root.setRight(controls);

        stage.setScene(new Scene(root, 1100, 700));
        stage.setTitle("6201-090301D, Кузнецов Дмитрий Анатольевич");
        stage.show();
        draw();
    }

    private GridPane group(String title, Slider[] sliders, double min, double max, double value, Runnable onApply) {
        GridPane grid = new GridPane();
        grid.setHgap(8);
        grid.setVgap(4);
        grid.add(new Label(title), 0, 0, 3, 1);
        for (int i = 0; i < 3; i++) {
            Slider slider = new Slider(min, max, value);
            Label valueLabel = new Label();
            valueLabel.setMinWidth(45);
            valueLabel.textProperty().bind(slider.valueProperty().asString("%.2f"));
            GridPane.setHgrow(slider, Priority.ALWAYS);
            grid.addRow(i + 1, new Label(AXES[i]), slider, valueLabel);
            sliders[i] = slider;
        }
        Button apply = new Button("Применить");
        apply.setMaxWidth(Double.MAX_VALUE);
        apply.setOnAction(e -> onApply.run());
        grid.add(apply, 0, 4, 3, 1);
        return grid;
    }

    private void apply(double[][] m) {
        transform = Matrix.multiply(m, transform);
        draw();
    }

    private void applyMove() {
        apply(Matrix.translate(move[0].getValue(), move[1].getValue(), move[2].getValue()));
    }

    private void applyScale() {
        apply(Matrix.scale(scale[0].getValue(), scale[1].getValue(), scale[2].getValue()));
    }

    private void applyRotate() {
        double[][] m = Matrix.rotateX(Math.toRadians(rotate[0].getValue()));
        m = Matrix.multiply(Matrix.rotateY(Math.toRadians(rotate[1].getValue())), m);
        m = Matrix.multiply(Matrix.rotateZ(Math.toRadians(rotate[2].getValue())), m);
        apply(m);
    }

    private void reset() {
        for (int i = 0; i < 3; i++) {
            move[i].setValue(0);
            scale[i].setValue(1);
            rotate[i].setValue(0);
        }
        transform = Matrix.identity();
        draw();
    }

    private void draw() {
        renderer.render(canvas.getGraphicsContext2D(), (int) canvas.getWidth(), (int) canvas.getHeight(),
                transform, mode.getValue(), color.getValue());
    }

    public static void main(String[] args) {
        launch();
    }
}
