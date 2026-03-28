using System;

namespace LabWork1
{
    internal static class RecursionFunction
    {
        public static int[] F(int[] A)
        {
            int[] result = new int[0];
            if (A.Length <= 2)
            {
                result = A;
            }
            else if (A.Length % 2 == 0)
            {
                int semiLenght = A.Length / 2;
                int[] B = new int[semiLenght];
                int[] C = new int[semiLenght];
                for (int i = 0; i < semiLenght; i++)
                {
                    B[i] = A[i];
                    C[i] = A[i + semiLenght];
                }

                B = F(B);
                C = F(C);

                result = new int[B.Length + C.Length];
                for (int i = 0; i < B.Length; i++)
                {
                    result[i] = B[i];
                }
                for (int i = 0; i < C.Length; i++)
                {
                    result[i + B.Length] = C[i];
                }
            }
            else
            {
                int semiLenght = A.Length / 2;
                int[] B = new int[semiLenght + 1];
                int[] C = new int[semiLenght + 1];
                B[semiLenght] = A[semiLenght];
                C[0] = A[semiLenght];
                for (int i = 0; i < semiLenght; i++)
                {
                    B[i] = A[i];
                    C[i + 1] = A[i + semiLenght + 1];
                }

                B = F(B);
                C = F(C);
                result = new int[B.Length + C.Length];
                for (int i = 0; i < B.Length; i++)
                {
                    result[i] = B[i];
                }
                for (int i = 0; i < C.Length; i++)
                {
                    result[i + B.Length] = C[i];
                }
            }
            return result;
        }
    }
}
