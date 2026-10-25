package ru.dima;

import javafx.animation.PauseTransition;
import javafx.geometry.Point2D;
import javafx.scene.control.Spinner;
import javafx.scene.control.SpinnerValueFactory;
import javafx.scene.control.TextFormatter;
import javafx.scene.control.Tooltip;
import javafx.util.Duration;
import javafx.util.StringConverter;

public class IntSpinner extends Spinner<Integer> {

    private final SpinnerValueFactory.IntegerSpinnerValueFactory factory;
    private final Tooltip errorTooltip = new Tooltip();
    private final PauseTransition hideTimer = new PauseTransition(Duration.seconds(2.5));

    public IntSpinner(int min, int max, int initial) {
        factory = new SpinnerValueFactory.IntegerSpinnerValueFactory(min, max, initial);
        setValueFactory(factory);
        setEditable(true);

        errorTooltip.setStyle("-fx-background-color: #c62828; -fx-text-fill: white;");
        hideTimer.setOnFinished(e -> clearError());

        factory.setConverter(new StringConverter<>() {
            @Override
            public String toString(Integer value) {
                return value == null ? "" : value.toString();
            }

            @Override
            public Integer fromString(String text) {
                if (text == null || text.isBlank()) {
                    showError("Введите число от " + factory.getMin() + " до " + factory.getMax());
                    return factory.getValue();
                }
                try {
                    int v = Integer.parseInt(text.trim());
                    if (v < factory.getMin() || v > factory.getMax()) {
                        showError("Значение должно быть от " + factory.getMin()
                                + " до " + factory.getMax());
                        return Math.max(factory.getMin(), Math.min(factory.getMax(), v));
                    }
                    return v;
                } catch (NumberFormatException e) {
                    showError("Слишком большое число");
                    return factory.getValue();
                }
            }
        });

        getEditor().setTextFormatter(new TextFormatter<>(change -> {
            if (!change.isContentChange())
                return change;
            if (change.getControlNewText().matches("\\d*"))
                return change;
            showError(describeRejection(change.getText()));
            return null;
        }));

        getEditor().setOnAction(e -> commit());
        focusedProperty().addListener((obs, was, now) -> {
            if (!now)
                commit();
        });
    }

    private static String describeRejection(String inserted) {
        if (inserted.contains("-")) {
            return "Отрицательные числа не допускаются";
        }
        if (inserted.contains(".") || inserted.contains(",")) {
            return "Допускаются только целые числа";
        }
        return "Допускаются только цифры";
    }

    private void commit() {
        commitValue();
        getEditor().setText(factory.getConverter().toString(getValue()));
    }

    private void showError(String message) {
        getEditor().setStyle("-fx-border-color: #c62828; -fx-border-radius: 3;");

        errorTooltip.setText(message);
        errorTooltip.hide();
        Point2D p = localToScreen(0, getHeight());
        if (p != null) {
            errorTooltip.show(this, p.getX(), p.getY() + 2);
        }
        hideTimer.playFromStart();
    }

    private void clearError() {
        getEditor().setStyle("");
        errorTooltip.hide();
    }
}