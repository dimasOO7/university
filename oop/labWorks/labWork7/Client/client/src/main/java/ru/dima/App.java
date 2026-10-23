package ru.dima;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;

import java.util.Random;

public class App extends Application {

    private final GridPane matrixGrid = new GridPane();

    @Override
    public void start(Stage stage) {
        // 1. Поля ввода для задания произвольного размера матрицы
        Spinner<Integer> rowsSpinner = new Spinner<>(1, 100, 5);
        Spinner<Integer> colsSpinner = new Spinner<>(1, 100, 5);
        rowsSpinner.setPrefWidth(70);
        colsSpinner.setPrefWidth(70);

        Button generateBtn = new Button("Показать матрицу");

        // Панель управления (верхняя плашка)
        HBox controlPanel = new HBox(10,
                new Label("Строк:"), rowsSpinner,
                new Label("Столбцов:"), colsSpinner,
                generateBtn);
        controlPanel.setAlignment(Pos.CENTER_LEFT);
        controlPanel.setPadding(new Insets(10));

        // 2. Настройка сетки для ячеек матрицы
        matrixGrid.setHgap(4); // расстояние между столбцами
        matrixGrid.setVgap(4); // расстояние между строками
        matrixGrid.setPadding(new Insets(100));
        matrixGrid.setAlignment(Pos.CENTER);

        // 3. Оборачиваем сетку в ScrollPane для поддержки произвольных размеров
        ScrollPane scrollPane = new ScrollPane(matrixGrid);
        scrollPane.setFitToWidth(true);
        scrollPane.setFitToHeight(true);

        // Обработка кнопки: генерация и вывод
        generateBtn.setOnAction(e -> {
            int rows = rowsSpinner.getValue();
            int cols = colsSpinner.getValue();
            double[][] randomMatrix = generateRandomMatrix(rows, cols);
            displayMatrix(randomMatrix);
        });

        // Корневой контейнер
        BorderPane root = new BorderPane();
        root.setTop(controlPanel);
        root.setCenter(scrollPane);

        Scene scene = new Scene(root, 650, 450);
        stage.setTitle("Вывод матрицы произвольного размера");
        stage.setScene(scene);
        stage.show();

        // Отображение начальной матрицы при запуске
        generateBtn.fire();
    }

    /**
     * Динамическое наполнение GridPane элементами матрицы
     */
    private void displayMatrix(double[][] matrix) {
        matrixGrid.getChildren().clear();

        if (matrix == null || matrix.length == 0) {
            return;
        }

        int rows = matrix.length;
        for (int r = 0; r < rows; r++) {
            int cols = matrix[r].length;
            for (int c = 0; c < cols; c++) {
                String valueStr = String.format("%.1f", matrix[r][c]);

                Label cell = new Label(valueStr);

                // Фиксируем размеры (минимальный и предпочтительный), чтобы текст не обрезался
                cell.setPrefSize(55, 30);
                cell.setMinSize(Region.USE_PREF_SIZE, Region.USE_PREF_SIZE);
                cell.setAlignment(Pos.CENTER);

                cell.setStyle("-fx-border-color: #b0b0b0; " +
                        "-fx-border-radius: 2; " +
                        "-fx-background-color: #fafafa;");

                matrixGrid.add(cell, c, r);
            }
        }
    }

    /**
     * Вспомогательный метод создания матрицы случайных чисел
     */
    private double[][] generateRandomMatrix(int rows, int cols) {
        Random rnd = new Random();
        double[][] mat = new double[rows][cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                mat[i][j] = rnd.nextDouble() * 100;
            }
        }
        return mat;
    }

    public static void main(String[] args) {
        launch(args);
    }
}