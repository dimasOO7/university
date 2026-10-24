package ru.dima.matrix;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Random;

public class Matrix implements Serializable {
    private double[][] matrix;

    private static final long serialVersionUID = 2L;

    public Matrix(int rows, int columns) {
        if (columns < 1 || rows < 1) {
            throw new IllegalArgumentException();
        }
        matrix = new double[rows][columns];
        Random random = new Random();
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                matrix[i][j] = random.nextDouble(-100, 100);
            }
        }
    }

    public int[] getSize() {
        int[] result = new int[2];
        result[0] = matrix.length;
        result[1] = matrix[0].length;
        return result;
    }

    public int getRows() {
        return matrix.length;
    }

    public int getColumns() {
        return matrix[0].length;
    }

    public double getElement(int row, int colum) {
        return matrix[row][colum];
    }

    public void setElement(int row, int colum, double value) {
        matrix[row][colum] = value;
    }

    public static double getOddSum(Matrix matrix) {
        if (matrix == null) {
            throw new IllegalArgumentException("Матрица не может быть null!");
        }
        return Arrays.stream(matrix.matrix)
                .flatMapToDouble(Arrays::stream)
                .filter(val -> Double.isFinite(val) && (long) val % 2 != 0)
                .sum();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (double[] row : matrix) {
            sb.append("( ");
            for (double val : row) {
                sb.append(String.format("%.2f ", val));
            }
            sb.append(")\n");
        }
        return sb.toString();
    }
}
