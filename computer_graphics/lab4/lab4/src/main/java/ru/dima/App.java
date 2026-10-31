package ru.dima;

import java.io.File;

import javafx.application.Application;
import javafx.beans.binding.Bindings;
import javafx.geometry.Insets;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.ScrollPane;
import javafx.scene.control.Slider;
import javafx.scene.control.Spinner;
import javafx.scene.control.SpinnerValueFactory;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Priority;
import javafx.scene.layout.Region;
import javafx.scene.layout.RowConstraints;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import ru.dima.ImageProcessing.KernelShape;

public class App extends Application {

    // большие картинки уменьшаются при загрузке, иначе эвристический алгоритм
    // заметно тормозит
    private static final double MAX_IMAGE_SIZE = 800;
    private static final int COLUMNS = 4;
    private static final double KERNEL_PREVIEW_SIZE = 120;

    private final ImageView sourceView = new ImageView();
    private final ImageView grayView = new ImageView();
    private final ImageView binaryView = new ImageView();
    private final ImageView task2View = new ImageView();
    private final ImageView task3View = new ImageView();
    private final ImageView erosionView = new ImageView();
    private final ImageView evristicView = new ImageView();

    private final Slider binaryThreshold = new Slider(0, 1, 0.5);
    private final Slider task2Threshold = new Slider(0, 1, 0.7);
    private final Spinner<Integer> kernelSize = new Spinner<>(1, 15, 3);
    private final ComboBox<KernelShape> kernelShape = new ComboBox<>();
    private final Spinner<Integer> anchorX = new Spinner<>(0, 2, 1);
    private final Spinner<Integer> anchorY = new Spinner<>(0, 2, 1);
    private final Canvas kernelPreview = new Canvas(KERNEL_PREVIEW_SIZE, KERNEL_PREVIEW_SIZE);
    private final Spinner<Double> f1 = new Spinner<>(-8.0, 8.0, 0.0, 0.01);
    private final Spinner<Double> f2 = new Spinner<>(-100.0, 100.0, 0.0, 0.01);

    private final Button refresh = new Button("Обновить");

    private Image gray;

    @Override
    public void start(Stage stage) {
        kernelShape.getItems().addAll(KernelShape.values());
        kernelShape.setValue(KernelShape.SQUARE);

        // превью ядра перерисовывается сразу, а изображения — только по кнопке
        // «Обновить»
        kernelSize.valueProperty().addListener((obs, oldValue, newValue) -> {
            resetAnchor(anchorX, newValue);
            resetAnchor(anchorY, newValue);
            drawKernelPreview();
        });
        kernelShape.valueProperty().addListener((obs, oldValue, newValue) -> drawKernelPreview());
        anchorX.valueProperty().addListener((obs, oldValue, newValue) -> drawKernelPreview());
        anchorY.valueProperty().addListener((obs, oldValue, newValue) -> drawKernelPreview());

        Node[] tiles = {
                tile("Исходное изображение", sourceView),
                tile("Оттенки серого", grayView),
                tile("бинаризация", binaryView),
                tile("Неполная пороговая обработка", task2View),
                tile("Сглаживающий фильтр (B = 1/10)", task3View),
                tile("Эрозия", erosionView),
                tile("Эвристическое утончение линий", evristicView),
                controls(stage),
        };

        GridPane grid = new GridPane();
        grid.setHgap(10);
        grid.setVgap(10);
        grid.setPadding(new Insets(10));
        for (int i = 0; i < tiles.length; i++) {
            grid.add(tiles[i], i % COLUMNS, i / COLUMNS);
        }
        for (int i = 0; i < COLUMNS; i++) {
            ColumnConstraints column = new ColumnConstraints();
            column.setPercentWidth(100.0 / COLUMNS);
            grid.getColumnConstraints().add(column);
        }
        int rows = (tiles.length + COLUMNS - 1) / COLUMNS;
        for (int i = 0; i < rows; i++) {
            RowConstraints row = new RowConstraints();
            row.setPercentHeight(100.0 / rows);
            grid.getRowConstraints().add(row);
        }

        drawKernelPreview();
        stage.setTitle("ЛР 4. Алгоритмы обработки изображений");
        stage.setScene(new Scene(grid, 1280, 760));
        stage.show();
    }

    private Node controls(Stage stage) {
        Button open = new Button("Открыть изображение…");
        open.setMaxWidth(Double.MAX_VALUE);
        open.setOnAction(e -> chooseImage(stage));

        refresh.setMaxWidth(Double.MAX_VALUE);
        refresh.setDisable(true);
        refresh.setOnAction(e -> process());

        GridPane form = new GridPane();
        form.setHgap(8);
        form.setVgap(6);
        ColumnConstraints labels = new ColumnConstraints();
        labels.setMinWidth(Region.USE_PREF_SIZE);
        ColumnConstraints fields = new ColumnConstraints();
        fields.setHgrow(Priority.ALWAYS);
        fields.setFillWidth(true);
        form.getColumnConstraints().addAll(labels, fields);

        int row = 0;
        form.add(bold("Параметры"), 0, row++, 2, 1);
        form.add(open, 0, row++, 2, 1);
        form.add(sliderLabel("Порог бинаризации", binaryThreshold), 0, row);
        form.add(binaryThreshold, 1, row++);
        form.add(sliderLabel("неполной обработки", task2Threshold), 0, row);
        form.add(task2Threshold, 1, row++);

        form.add(bold("Эрозия"), 0, row++, 2, 1);
        row = addField(form, row, "Размер ядра", kernelSize);
        row = addField(form, row, "Форма ядра", kernelShape);
        row = addField(form, row, "Якорь, столбец", anchorX);
        row = addField(form, row, "Якорь, строка", anchorY);
        form.add(kernelPreview, 0, row++, 2, 1);

        form.add(bold("Эвристический алгоритм"), 0, row++, 2, 1);
        row = addField(form, row, "F1", f1);
        row = addField(form, row, "F2", f2);
        form.add(refresh, 0, row, 2, 1);

        ScrollPane scroll = new ScrollPane(form);
        scroll.setFitToWidth(true);
        scroll.setStyle("-fx-background-color: transparent;");
        return scroll;
    }

    private static int addField(GridPane form, int row, String title, Region field) {
        if (field instanceof Spinner) {
            ((Spinner<?>) field).setEditable(true);
        }
        field.setMaxWidth(Double.MAX_VALUE);
        form.add(new Label(title), 0, row);
        form.add(field, 1, row);
        return row + 1;
    }

    private void chooseImage(Stage stage) {
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Выберите изображение");
        chooser.getExtensionFilters().add(
                new FileChooser.ExtensionFilter("Изображения", "*.png", "*.jpg", "*.jpeg", "*.bmp", "*.gif"));
        File file = chooser.showOpenDialog(stage);
        if (file != null) {
            loadImage(file);
        }
    }

    void loadImage(File file) {
        String url = file.toURI().toString();
        Image source = new Image(url);
        if (source.isError()) {
            new Alert(Alert.AlertType.ERROR, "Не удалось открыть " + file.getName()).showAndWait();
            return;
        }
        if (source.getWidth() > MAX_IMAGE_SIZE || source.getHeight() > MAX_IMAGE_SIZE) {
            source = new Image(url, MAX_IMAGE_SIZE, MAX_IMAGE_SIZE, true, true);
        }

        sourceView.setImage(source);
        gray = ImageProcessing.toGrayscale(source);
        grayView.setImage(gray);
        task3View.setImage(ImageProcessing.task3(gray));
        refresh.setDisable(false);
        process();
    }

    private void process() {
        if (gray == null) {
            return;
        }
        commit(kernelSize);
        commit(anchorX);
        commit(anchorY);
        commit(f1);
        commit(f2);

        task2View.setImage(ImageProcessing.task2(gray, task2Threshold.getValue()));
        Image binary = ImageProcessing.graytoBinary(gray, binaryThreshold.getValue());
        binaryView.setImage(binary);
        erosionView.setImage(ImageProcessing.erosion(binary, currentKernel(), anchorX.getValue(), anchorY.getValue()));
        evristicView.setImage(ImageProcessing.evristicAlgoritm(gray, f1.getValue(), f2.getValue()));
    }

    private static <T> void commit(Spinner<T> spinner) {
        SpinnerValueFactory<T> factory = spinner.getValueFactory();
        try {
            factory.setValue(factory.getConverter().fromString(spinner.getEditor().getText()));
        } catch (RuntimeException e) {
            spinner.getEditor().setText(factory.getConverter().toString(factory.getValue()));
        }
    }

    private boolean[][] currentKernel() {
        return ImageProcessing.kernel(kernelSize.getValue(), kernelShape.getValue());
    }

    private void drawKernelPreview() {
        boolean[][] kernel = currentKernel();
        GraphicsContext g = kernelPreview.getGraphicsContext2D();
        double cell = KERNEL_PREVIEW_SIZE / kernel.length;
        g.clearRect(0, 0, KERNEL_PREVIEW_SIZE, KERNEL_PREVIEW_SIZE);
        g.setStroke(Color.GRAY);
        g.setLineWidth(1);
        for (int y = 0; y < kernel.length; y++) {
            for (int x = 0; x < kernel[y].length; x++) {
                g.setFill(kernel[y][x] ? Color.rgb(60, 60, 60) : Color.WHITE);
                g.fillRect(x * cell, y * cell, cell, cell);
                g.strokeRect(x * cell, y * cell, cell, cell);
            }
        }
        g.setStroke(Color.RED);
        g.setLineWidth(3);
        g.strokeRect(anchorX.getValue() * cell + 1.5, anchorY.getValue() * cell + 1.5, cell - 3, cell - 3);
    }

    private static void resetAnchor(Spinner<Integer> anchor, int size) {
        SpinnerValueFactory.IntegerSpinnerValueFactory factory = (SpinnerValueFactory.IntegerSpinnerValueFactory) anchor
                .getValueFactory();
        factory.setMax(size - 1);
        factory.setValue((size - 1) / 2);
    }

    private static Node tile(String title, ImageView view) {
        view.setPreserveRatio(true);
        StackPane holder = new StackPane(view);
        holder.setMinSize(0, 0);
        holder.setPrefSize(1, 1);
        holder.setStyle("-fx-background-color: #3a3a3a;");
        view.fitWidthProperty().bind(holder.widthProperty());
        view.fitHeightProperty().bind(holder.heightProperty());

        VBox box = new VBox(4, bold(title), holder);
        VBox.setVgrow(holder, Priority.ALWAYS);
        return box;
    }

    private static Label sliderLabel(String title, Slider slider) {
        Label label = new Label();
        label.textProperty().bind(Bindings.format("%s: %.2f", title, slider.valueProperty()));
        return label;
    }

    private static Label bold(String text) {
        Label label = new Label(text);
        label.setStyle("-fx-font-weight: bold;");
        return label;
    }

    public static void main(String[] args) {
        launch();
    }
}
