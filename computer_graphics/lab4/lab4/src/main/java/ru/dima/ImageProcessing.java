package ru.dima;

import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import javafx.scene.image.PixelWriter;
import javafx.scene.image.WritableImage;
import javafx.scene.paint.Color;

public class ImageProcessing {

    public static WritableImage toGrayscale(Image source) {
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();
        WritableImage grayImage = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = grayImage.getPixelWriter();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Color color = reader.getColor(x, y);
                double gray = 0.299 * color.getRed() + 0.587 * color.getGreen() + 0.114 * color.getBlue();
                writer.setColor(x, y, new Color(gray, gray, gray, color.getOpacity()));
            }
        }
        return grayImage;
    }

    public static WritableImage graytoBinary(Image source, double threshold) {
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();
        WritableImage result = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = result.getPixelWriter();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Color color = reader.getColor(x, y).getRed() >= threshold ? new Color(1, 1, 1, 1)
                        : new Color(0, 0, 0, 1);
                writer.setColor(x, y, color);
            }
        }
        return result;
    }

    public static WritableImage task2(Image source, double threshold) {
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();
        WritableImage result = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = result.getPixelWriter();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Color old = reader.getColor(x, y);
                Color newColor = old.getRed() >= threshold ? new Color(1, 1, 1, 1) : old;
                writer.setColor(x, y, newColor);
            }
        }
        return result;
    }

    private static int clamp(int value, int min, int max) {
        return Math.max(min, Math.min(max, value));
    }

    public static WritableImage task3(Image source) {
        double[][] mask = new double[][] { { 1, 1, 1 }, { 1, 2, 1 }, { 1, 1, 1 } };
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();
        WritableImage result = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = result.getPixelWriter();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                double color = 0;
                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        int sx = clamp(x + i, 0, width - 1);
                        int sy = clamp(y + j, 0, height - 1);
                        color += reader.getColor(sx, sy).getRed() * mask[i + 1][j + 1];
                    }
                }
                color /= 10;
                writer.setColor(x, y, new Color(color, color, color, 1));
            }
        }
        return result;
    }

    public enum KernelShape {
        SQUARE("Квадрат"), CROSS("Крест"), CIRCLE("Круг");

        private final String title;

        KernelShape(String title) {
            this.title = title;
        }

        @Override
        public String toString() {
            return title;
        }
    }

    public static boolean[][] kernel(int size, KernelShape shape) {
        boolean[][] kernel = new boolean[size][size];
        double center = (size - 1) / 2.0;
        double radius = size / 2.0;

        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                double dx = x - center;
                double dy = y - center;
                switch (shape) {
                    case SQUARE:
                        kernel[y][x] = true;
                        break;
                    case CROSS:
                        kernel[y][x] = Math.abs(dx) <= 0.5 || Math.abs(dy) <= 0.5;
                        break;
                    case CIRCLE:
                        kernel[y][x] = dx * dx + dy * dy <= radius * radius - 0.5;
                        break;
                }
            }
        }
        return kernel;
    }

    public static WritableImage erosion(Image source, boolean[][] kernel, int anchorX, int anchorY) {
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();
        WritableImage result = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = result.getPixelWriter();

        boolean[][] white = new boolean[height][width];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                white[y][x] = reader.getColor(x, y).getRed() > 0.5;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                boolean boolColor = true;
                for (int ky = 0; ky < kernel.length && boolColor; ky++) {
                    for (int kx = 0; kx < kernel[ky].length && boolColor; kx++) {
                        int sx = x + kx - anchorX;
                        int sy = y + ky - anchorY;
                        if (kernel[ky][kx] && sx >= 0 && sx < width && sy >= 0 && sy < height) {
                            boolColor = white[sy][sx];
                        }
                    }
                }
                Color color = boolColor ? new Color(1, 1, 1, 1) : new Color(0, 0, 0, 1);
                writer.setColor(x, y, color);
            }
        }
        return result;
    }

    public static double localDensity(PixelReader reader, int x, int y) {
        double d = 0;
        double current = reader.getColor(x, y).getRed();
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                d += reader.getColor(x + i, y + j).getRed() - current;
            }
        }
        return d;
    }

    public static WritableImage evristicAlgoritm(Image source, double F1, double F2) {
        int width = (int) source.getWidth();
        int height = (int) source.getHeight();

        WritableImage result = new WritableImage(width, height);
        PixelReader reader = source.getPixelReader();
        PixelWriter writer = result.getPixelWriter();

        Color lineColor = new Color(1, 1, 1, 1);
        Color backColor = new Color(0, 0, 0, 1);

        for (int y = 2; y < height - 2; y++) {
            for (int x = 2; x < width - 2; x++) {
                double d = localDensity(reader, x, y);
                writer.setColor(x, y, backColor);
                if (d > F1) {
                    double D = 0;
                    double curr = localDensity(reader, x, y);
                    for (int i = -1; i <= 1; i++) {
                        for (int j = -1; j <= 1; j++) {
                            if (i != 0 || j != 0) {
                                D += localDensity(reader, x + i, y + j) - curr;
                            }
                        }
                    }
                    if (D > F2) {
                        writer.setColor(x, y, lineColor);
                    }
                }

            }
        }
        return result;
    }
}
