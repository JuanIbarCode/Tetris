
using System;

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
    
    public class Pieza
    {
        private bool[,] _forma;        
        public bool[,] Forma => _forma;

        private Coordenadas _posicion;
        public Coordenadas Posicion => _posicion;

        private ConsoleColor _color;
        public ConsoleColor Color => _color;

        private int _rotacionActual;
        public int RotacionActual => _rotacionActual;
        
        private int _piezaActual;
        public int PiezaActual => _piezaActual;

        public Pieza(int pieza)
        {
            _piezaActual = pieza;
            _rotacionActual = 0;
            _forma = Utilidades.Piezas[_piezaActual][_rotacionActual];
            
            _posicion = new Coordenadas(5, 0);
            _color = Utilidades.CogerColorSegunPieza(_piezaActual);
        }

        public void MoverPieza(Coordenadas direccion)
        {
            if (Utilidades.ComprobarPiezaFueraMapa(this, direccion)) return;
            _posicion += direccion;
        }

        public void DibujarPieza()
        {
            for (var x = 0; x < _forma.GetLength(1); x++)
            {
                for (var y = 0; y < _forma.GetLength(0); y++)
                {
                    if (_forma[y, x])
                    {
                        Utilidades.DibujarCaracteres(Utilidades.Bloque.ToString(), x + _posicion.x, y + _posicion.y,
                            _color, 1, 1, true);
                    }
                }
            }
        }

        public void DibujarFantasma(Tablero tablero)
        {
            var posicionFantasma = _posicion;
            do
            {
                posicionFantasma += new Coordenadas(0, 1);
            } while (!tablero.Colision(posicionFantasma, new Coordenadas(0, 1), _forma));
            
            
            for (var x = 0; x < _forma.GetLength(1); x++)
            {
                for (var y = 0; y < _forma.GetLength(0); y++)
                {
                    if (_forma[y, x])
                    {
                        Utilidades.DibujarCaracteres(Utilidades.Bloque.ToString(), x + posicionFantasma.x,
                            y + posicionFantasma.y, ConsoleColor.Gray, 1, 1, true);
                    }
                }
            }
        }

        public void LimpiarPieza()
        {
            for (var x = 0; x < _forma.GetLength(1); x++)
            {
                for (var y = 0; y < _forma.GetLength(0); y++)
                {
                    if (_forma[y, x])
                    {
                        Utilidades.DibujarCaracteres(Utilidades.Vacio.ToString(), x + _posicion.x, y + _posicion.y,
                            _color, 1, 1, true);
                    }
                }
            }
        }

        public void LimpiarFantasma(Tablero tablero, Coordenadas posicionAnterior)
        {
            var posicionFantasma = posicionAnterior;
            do
            {
                posicionFantasma += new Coordenadas(0, 1);
            } while (!tablero.Colision(posicionFantasma, new Coordenadas(0, 1), _forma));

            for (var x = 0; x < _forma.GetLength(1); x++)
            {
                for (var y = 0; y < _forma.GetLength(0); y++)
                {
                    if (_forma[y, x])
                    {
                        Utilidades.DibujarCaracteres(Utilidades.Vacio.ToString(), x + posicionFantasma.x, y + posicionFantasma.y,
                            _color, 1, 1, true);
                    }
                }
            }
        }

        public void RotarPieza()
        {
            if (_rotacionActual + 1 == Utilidades.Piezas[_piezaActual].Count)
                _rotacionActual = 0;
            else _rotacionActual++;

            _forma = Utilidades.Piezas[_piezaActual][_rotacionActual];
        }

        public bool[,] SiguienteRotacion()
        {
            if (_rotacionActual + 1 == Utilidades.Piezas[_piezaActual].Count)
                return Utilidades.Piezas[_piezaActual][0];

            return Utilidades.Piezas[_piezaActual][_rotacionActual + 1];
        }
    }
}