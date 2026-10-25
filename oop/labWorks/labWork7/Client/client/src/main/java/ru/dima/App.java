package ru.dima;

import javafx.application.Application;
import javafx.application.Platform;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;
import ru.dima.matrix.Matrix;

import java.io.DataInputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class App extends Application {

    private final GridPane matrixGrid = new GridPane();

    Matrix matrix;

    @Override
    public void start(Stage stage) {

        Spinner<Integer> rowsSpinner = new IntSpinner(1, 100, 5);
        Spinner<Integer> colsSpinner = new IntSpinner(1, 100, 5);
        rowsSpinner.setPrefWidth(70);
        colsSpinner.setPrefWidth(70);

        Button generateBtn = new Button("Показать матрицу");
        Button calculateBtn = new Button("Рассчитать сумму нечётных элементов");
        Label sumLabel = new Label("Сумма нечётных элементов: ");

        HBox topPanel = new HBox(10,
                new Label("Строк:"), rowsSpinner,
                new Label("Столбцов:"), colsSpinner,
                generateBtn);
        topPanel.setAlignment(Pos.CENTER_LEFT);
        topPanel.setPadding(new Insets(5));
        HBox calculatePanel = new HBox(10, calculateBtn, sumLabel);
        calculatePanel.setAlignment(Pos.CENTER_LEFT);
        calculatePanel.setPadding(new Insets(5));

        VBox topBox = new VBox(topPanel, calculatePanel);
        topBox.setAlignment(Pos.CENTER_LEFT);
        topBox.setPadding(new Insets(5));

        matrixGrid.setHgap(4);
        matrixGrid.setVgap(4);
        matrixGrid.setPadding(new Insets(10));
        matrixGrid.setAlignment(Pos.CENTER);

        ScrollPane scrollPane = new ScrollPane(matrixGrid);
        scrollPane.setFitToWidth(true);
        scrollPane.setFitToHeight(true);

        generateBtn.setOnAction(e -> {
            int rows = rowsSpinner.getValue();
            int cols = colsSpinner.getValue();
            matrix = new Matrix(rows, cols);
            displayMatrix(matrix);
            sumLabel.setText("Сумма нечётных элементов:");
        });

        Runnable getOddSum = () -> {
            try (Socket socket = new Socket("localhost", 8081);
                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
                    DataInputStream in = new DataInputStream(socket.getInputStream())) {
                out.writeObject(matrix);
                out.flush();
                double sum = in.readDouble();
                Platform.runLater(() -> {
                    sumLabel.setText(String.format("Сумма нечётных элементов: %f", sum));
                    calculateBtn.setDisable(false);
                });
            } catch (IOException ex) {
                Platform.runLater(() -> {
                    sumLabel.setText("Сумма нечётных элементов: ошибка связи с сервером");
                    calculateBtn.setDisable(false);
                });
            }

        };

        calculateBtn.setOnAction(e -> {
            new Thread(getOddSum).start();
            calculateBtn.setDisable(true);
        });

        BorderPane root = new BorderPane();
        root.setTop(topBox);
        root.setCenter(scrollPane);

        Scene scene = new Scene(root, 750, 500);
        stage.setMinWidth(750);
        stage.setTitle("Вывод матрицы произвольного размера");
        stage.setScene(scene);
        stage.show();

        generateBtn.fire();
    }

    private void displayMatrix(Matrix matrix) {
        matrixGrid.getChildren().clear();

        if (matrix == null) {
            return;
        }
        for (int r = 0; r < matrix.getRows(); r++) {
            for (int c = 0; c < matrix.getColumns(); c++) {
                String valueStr = String.format("%.2f", matrix.getElement(r, c));

                Label cell = new Label(valueStr);

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

    public static void main(String[] args) {
        launch(args);
    }
}