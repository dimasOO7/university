package ru.dima.matrix;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Random;

public class Matrix implements Serializable {
    private double[][] matrix;

    private static final long serialVersionUID = 1L;

    public Matrix(int collums, int rows) {
        if (collums < 1 || rows < 1) {
            throw new IllegalArgumentException();
        }
        matrix = new double[collums][rows];
        Random random = new Random();
        for (int i = 0; i < collums; i++) {
            for (int j = 0; j < rows; j++) {
                matrix[i][j] = random.nextInt(100);
            }
        }
    }

    public int[] getSize() {
        int[] result = new int[2];
        result[0] = matrix.length;
        result[1] = matrix[0].length;
        return result;
    }

    public double getElement(int x, int y) {
        return matrix[x][y];
    }

    public void setElement(int x, int y, double value) {
        matrix[x][y] = value;
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
