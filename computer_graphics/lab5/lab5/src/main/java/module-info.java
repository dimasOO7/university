module dima {
    requires javafx.controls;
    requires javafx.fxml;

    opens dima to javafx.fxml;
    exports dima;
}
