module ru.dima {
    requires javafx.controls;
    requires javafx.fxml;

    opens ru.dima to javafx.fxml;
    exports ru.dima;
}
