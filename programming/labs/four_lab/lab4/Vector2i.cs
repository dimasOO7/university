namespace lab
{
    class Vector2i
    {
        public int x;
        public int y;
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

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