module ru.dima {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.graphics;

    opens ru.dima to javafx.fxml;

    exports ru.dima;
}
