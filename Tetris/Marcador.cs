using System;

namespace Tetris
{
    public class Marcador
    {
        private int _puntuacionActual;

        public Marcador()
        {
            ResetearPuntuacion();
        }

        public void AgregarPuntuacion(int cantidad)
        {
            _puntuacionActual += cantidad;
            MostrarPuntuacion();
        }

        public void ResetearPuntuacion()
        {
            _puntuacionActual = 0;
        }

        private void MostrarPuntuacion()
        {
            Console.WriteLine("La puntuacion actual es: " + _puntuacionActual);
        }
    }
}