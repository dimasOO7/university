namespace lab6
{
    /// <summary>
    /// Класс целочисленного 2D вектора
    /// </summary>
    class Vector2i
    {
        /// <summary>
        /// координата x
        /// </summary>
        public int x;
        /// <summary>
        /// координата y
        /// </summary>
        public int y;
        /// <summary>
        /// целочисленный 2D вектор
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// возвращает вектор в виде кортежа
        /// </summary>
        /// <returns>(int x, int y)</returns>
        public (int x, int y) GetTuple()
        {
            return (x, y);
        }

        public static Vector2i operator +(Vector2i a, Vector2i b)
        {
            return new Vector2i(a.x + b.x, a.y + b.y);
        }

        public static Vector2i operator +(Vector2i a, int b)
        {
            return new Vector2i(a.x + b, a.y + b);
        }

        public static Vector2i operator %(Vector2i a, int b)
        {
            return new Vector2i(a.x % b, a.y % b);
        }

        public static bool operator ==(Vector2i a, Vector2i b)
        {
            return (a.x == b.x && a.y == b.y);
        }
        public static bool operator !=(Vector2i a, Vector2i b)
        {
            return !(a==b);
        }
    }
}