namespace Tetris
{
    public class Coordenadas
    {
        public int x;
        public int y;

        public Coordenadas(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public static bool operator ==(Coordenadas a, Coordenadas b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Coordenadas a, Coordenadas b)
        {
            return a.x != b.x || a.y != b.y;
        }
        
        public static Coordenadas operator +(Coordenadas a, Coordenadas b)
        {
            return new Coordenadas(a.x + b.x, a.y + b.y);
        }
        public static Coordenadas operator -(Coordenadas a, Coordenadas b)
        {
            return new Coordenadas(a.x - b.x, a.y - b.y);
        }
    }
}