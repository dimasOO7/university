package dima;

import java.util.Arrays;

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.image.PixelFormat;
import javafx.scene.image.WritableImage;
import javafx.scene.paint.Color;

public class Renderer {

    public enum Mode {
        WIREFRAME("Каркасная модель"),
        HIDDEN("Удаление невидимых граней"),
        FLAT("Закраска с учётом освещённости"),
        GOURAUD("Градиентная закраска (Гуро)");

        private final String title;

        Mode(String title) {
            this.title = title;
        }

        @Override
        public String toString() {
            return title;
        }
    }

    private static final double R = 1;
    private static final int N_ALPHA = 40;
    private static final int N_BETA = 40;
    private static final double SCENE = 3;
    private static final double[][] PROJECTION = Matrix.axonometric(Math.toRadians(30), Math.toRadians(60));
    private static final double[] LIGHT = { -6, 6, 10 };
    private static final double KA = 0.15;
    private static final double KD = 0.7;
    private static final double KS = 0.5;
    private static final double P = 20;

    private final double[][] vertices = new double[2 + (N_ALPHA - 1) * N_BETA][];
    private final int[][] faces = new int[N_ALPHA * N_BETA][];
    private Color color;

    public Renderer() {
        vertices[0] = point(0, 0);
        vertices[vertices.length - 1] = point(Math.PI, 0);
        for (int i = 1; i < N_ALPHA; i++) {
            for (int j = 0; j < N_BETA; j++) {
                vertices[index(i, j)] = point(Math.PI * i / N_ALPHA, 2 * Math.PI * j / N_BETA);
            }
        }
        int f = 0;
        for (int i = 0; i < N_ALPHA; i++) {
            for (int j = 0; j < N_BETA; j++) {
                if (i == 0) {
                    faces[f++] = new int[] { index(0, j), index(1, j), index(1, j + 1) };
                } else if (i == N_ALPHA - 1) {
                    faces[f++] = new int[] { index(i, j), index(N_ALPHA, j), index(i, j + 1) };
                } else {
                    faces[f++] = new int[] { index(i, j), index(i + 1, j), index(i + 1, j + 1), index(i, j + 1) };
                }
            }
        }
    }

    private static double[] point(double alpha, double beta) {
        double x = R * Math.sin(alpha) * Math.cos(beta);
        double y = R * Math.sin(alpha) * Math.sin(beta);
        double z = R * Math.cos(alpha) > 0 ? R * Math.cos(alpha) + R : R * Math.cos(alpha);
        return new double[] { x, y, z };
    }

    private int index(int i, int j) {
        if (i == 0) {
            return 0;
        }
        if (i == N_ALPHA) {
            return vertices.length - 1;
        }
        return 1 + (i - 1) * N_BETA + j % N_BETA;
    }

    public void render(GraphicsContext gc, int w, int h, double[][] transform, Mode mode, Color color) {
        this.color = color;
        gc.setFill(Color.WHITE);
        gc.fillRect(0, 0, w, h);
        if (w <= 0 || h <= 0) {
            return;
        }

        double[][] m = Matrix.multiply(PROJECTION, transform);
        double[][] p = new double[vertices.length][];
        for (int i = 0; i < vertices.length; i++) {
            p[i] = Matrix.apply(m, vertices[i]);
        }

        double k = Math.min(w, h) / (2 * SCENE);
        double[] sx = new double[p.length];
        double[] sy = new double[p.length];
        double[] sz = new double[p.length];
        for (int i = 0; i < p.length; i++) {
            sx[i] = k * p[i][0] + w / 2.0;
            sy[i] = -k * p[i][1] + h / 2.0;
            sz[i] = k * p[i][2];
        }

        double[][] normals = new double[faces.length][];
        for (int f = 0; f < faces.length; f++) {
            normals[f] = normal(p[faces[f][0]], p[faces[f][1]], p[faces[f][2]]);
        }

        if (mode == Mode.WIREFRAME || mode == Mode.HIDDEN) {
            gc.setStroke(Color.BLACK);
            gc.setLineWidth(1);
            for (int f = 0; f < faces.length; f++) {
                if (mode == Mode.HIDDEN && normals[f][2] <= 0) {
                    continue;
                }
                int[] face = faces[f];
                double[] xs = new double[face.length];
                double[] ys = new double[face.length];
                for (int v = 0; v < face.length; v++) {
                    xs[v] = sx[face[v]];
                    ys[v] = sy[face[v]];
                }
                gc.strokePolygon(xs, ys, face.length);
            }
            return;
        }

        double[] vertexIntensity = new double[p.length];
        if (mode == Mode.GOURAUD) {
            double[][] vn = new double[p.length][3];
            for (int f = 0; f < faces.length; f++) {
                double len = Math.sqrt(dot(normals[f], normals[f]));
                for (int v : faces[f]) {
                    for (int c = 0; c < 3; c++) {
                        vn[v][c] += normals[f][c] / len;
                    }
                }
            }
            for (int i = 0; i < p.length; i++) {
                vertexIntensity[i] = intensity(p[i], vn[i]);
            }
        }

        int[] pixels = new int[w * h];
        Arrays.fill(pixels, 0xFFFFFFFF);
        double[] zBuffer = new double[w * h];
        Arrays.fill(zBuffer, Double.NEGATIVE_INFINITY);

        for (int f = 0; f < faces.length; f++) {
            if (normals[f][2] <= 0) {
                continue;
            }
            int[] face = faces[f];
            double faceIntensity = intensity(p[face[0]], normals[f]);
            for (int t = 1; t < face.length - 1; t++) {
                int[] tri = { face[0], face[t], face[t + 1] };
                double[] x = new double[3], y = new double[3], z = new double[3], in = new double[3];
                for (int v = 0; v < 3; v++) {
                    x[v] = sx[tri[v]];
                    y[v] = sy[tri[v]];
                    z[v] = sz[tri[v]];
                    in[v] = mode == Mode.GOURAUD ? vertexIntensity[tri[v]] : faceIntensity;
                }
                fillTriangle(pixels, zBuffer, w, h, x, y, z, in);
            }
        }

        WritableImage image = new WritableImage(w, h);
        image.getPixelWriter().setPixels(0, 0, w, h, PixelFormat.getIntArgbInstance(), pixels, 0, w);
        gc.drawImage(image, 0, 0);
    }

    private static double[] normal(double[] a, double[] b, double[] c) {
        return new double[] {
                (b[1] - a[1]) * (c[2] - a[2]) - (b[2] - a[2]) * (c[1] - a[1]),
                (b[2] - a[2]) * (c[0] - a[0]) - (b[0] - a[0]) * (c[2] - a[2]),
                (b[0] - a[0]) * (c[1] - a[1]) - (b[1] - a[1]) * (c[0] - a[0])
        };
    }

    private static double dot(double[] a, double[] b) {
        return a[0] * b[0] + a[1] * b[1] + a[2] * b[2];
    }

    private static double intensity(double[] point, double[] n) {
        double[] s = { LIGHT[0] - point[0], LIGHT[1] - point[1], LIGHT[2] - point[2] };
        double nLen = Math.sqrt(dot(n, n));
        double sLen = Math.sqrt(dot(s, s));
        double cosTheta = dot(n, s) / (nLen * sLen);
        double i = KA;
        if (cosTheta > 0) {
            i += KD * cosTheta;
            double cosAlpha = 2 * cosTheta * n[2] / nLen - s[2] / sLen;
            if (cosAlpha > 0) {
                i += KS * Math.pow(cosAlpha, P);
            }
        }
        return i;
    }

    private void fillTriangle(int[] pixels, double[] zBuffer, int w, int h,
            double[] x, double[] y, double[] z, double[] in) {
        int[] o = { 0, 1, 2 };
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2 - i; j++) {
                if (y[o[j]] > y[o[j + 1]]) {
                    int t = o[j];
                    o[j] = o[j + 1];
                    o[j + 1] = t;
                }
            }
        }
        int a = o[0], b = o[1], c = o[2];
        if (y[c] == y[a]) {
            return;
        }

        int yStart = Math.max(0, (int) Math.ceil(y[a]));
        int yEnd = Math.min(h - 1, (int) Math.floor(y[c]));
        for (int py = yStart; py <= yEnd; py++) {
            double t1 = (py - y[a]) / (y[c] - y[a]);
            double x1 = x[a] + (x[c] - x[a]) * t1;
            double z1 = z[a] + (z[c] - z[a]) * t1;
            double i1 = in[a] + (in[c] - in[a]) * t1;

            int from = py < y[b] ? a : b;
            int to = py < y[b] ? b : c;
            double t2 = y[to] == y[from] ? 0 : (py - y[from]) / (y[to] - y[from]);
            double x2 = x[from] + (x[to] - x[from]) * t2;
            double z2 = z[from] + (z[to] - z[from]) * t2;
            double i2 = in[from] + (in[to] - in[from]) * t2;

            if (x1 > x2) {
                double t = x1;
                x1 = x2;
                x2 = t;
                t = z1;
                z1 = z2;
                z2 = t;
                t = i1;
                i1 = i2;
                i2 = t;
            }

            int xStart = Math.max(0, (int) Math.ceil(x1));
            int xEnd = Math.min(w - 1, (int) Math.floor(x2));
            for (int px = xStart; px <= xEnd; px++) {
                double t = x2 == x1 ? 0 : (px - x1) / (x2 - x1);
                double zz = z1 + (z2 - z1) * t;
                int idx = py * w + px;
                if (zBuffer[idx] < zz) {
                    zBuffer[idx] = zz;
                    pixels[idx] = color(i1 + (i2 - i1) * t);
                }
            }
        }
    }

    private int color(double intensity) {
        int r = (int) Math.min(255, 255 * color.getRed() * intensity);
        int g = (int) Math.min(255, 255 * color.getGreen() * intensity);
        int b = (int) Math.min(255, 255 * color.getBlue() * intensity);
        return 0xFF000000 | r << 16 | g << 8 | b;
    }
}
