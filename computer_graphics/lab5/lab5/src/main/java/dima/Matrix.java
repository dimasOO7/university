package dima;

public class Matrix {

    public static double[][] identity() {
        return new double[][]{
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] translate(double dx, double dy, double dz) {
        return new double[][]{
                {1, 0, 0, dx},
                {0, 1, 0, dy},
                {0, 0, 1, dz},
                {0, 0, 0, 1}
        };
    }

    public static double[][] scale(double kx, double ky, double kz) {
        return new double[][]{
                {kx, 0, 0, 0},
                {0, ky, 0, 0},
                {0, 0, kz, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] rotateX(double a) {
        double c = Math.cos(a), s = Math.sin(a);
        return new double[][]{
                {1, 0, 0, 0},
                {0, c, -s, 0},
                {0, s, c, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] rotateY(double a) {
        double c = Math.cos(a), s = Math.sin(a);
        return new double[][]{
                {c, 0, s, 0},
                {0, 1, 0, 0},
                {-s, 0, c, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] rotateZ(double a) {
        double c = Math.cos(a), s = Math.sin(a);
        return new double[][]{
                {c, -s, 0, 0},
                {s, c, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] axonometric(double a, double b) {
        double ca = Math.cos(a), sa = Math.sin(a), cb = Math.cos(b), sb = Math.sin(b);
        return new double[][]{
                {ca, sa, 0, 0},
                {-sa * cb, ca * cb, sb, 0},
                {sa * sb, -ca * sb, cb, 0},
                {0, 0, 0, 1}
        };
    }

    public static double[][] multiply(double[][] a, double[][] b) {
        double[][] r = new double[4][4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                for (int k = 0; k < 4; k++) {
                    r[i][j] += a[i][k] * b[k][j];
                }
            }
        }
        return r;
    }

    public static double[] apply(double[][] m, double[] p) {
        double[] r = new double[3];
        for (int i = 0; i < 3; i++) {
            r[i] = m[i][0] * p[0] + m[i][1] * p[1] + m[i][2] * p[2] + m[i][3];
        }
        return r;
    }
}
