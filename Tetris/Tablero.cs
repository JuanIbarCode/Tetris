using System;

namespace Tetris
{
    public class Tablero
    {
        private bool[,] _tablero;
        public bool[,] tablero => _tablero;
        private int _ancho;
        private int _alto;

        public Tablero(int ancho, int alto)
        {
            _ancho = ancho;
            _alto = alto;
            
            LimpiarTablero();
            DibujarMarcoTablero();
        }

        public void AgregarPieza(Pieza pieza)
        {
            for (var y = 0; y < pieza.Forma.GetLength(0); y++)
            {
                for (var x = 0; x < pieza.Forma.GetLength(1); x++)
                {
                    if (pieza.Forma[y, x])
                    {
                        tablero[x + pieza.Posicion.x, y + pieza.Posicion.y] = true;
                    }
                }
            }
        }
        
        public void DibujarMarcoSiguientePieza(Pieza pieza)
        {
            LimpiarMarcoSiguientePieza();
            
            Console.ForegroundColor = ConsoleColor.White;

            var offsetX = (_ancho + 5) * 2;
            var offsetY = 3;
            
            for (var y = -2; y <= pieza.Forma.GetLength(0) + 1; y++)
            {
                for (var x = -2; x <= pieza.Forma.GetLength(1) + 1; x++)
                {
                    if (x == -2)
                    {
                        if (y == -2)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaSuperiorIzquierda.ToString(), x, y, offsetX,
                                offsetY);
                        }
                        else if (y == pieza.Forma.GetLength(0) + 1)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaInferiorIzquierda.ToString(), x, y, offsetX,
                                offsetY);
                        }
                        else
                        {
                            Utilidades.DibujarCaracteres(Utilidades.LadoIzquierdo.ToString(), x, y, offsetX, offsetY);
                        }

                    }
                    else if (x == pieza.Forma.GetLength(1) + 1)
                    {
                        if (y == -2)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaSuperiorDerecha.ToString(), x, y, offsetX,
                                offsetY);
                        }
                        else if (y == pieza.Forma.GetLength(0) + 1)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaInferiorDerecha.ToString(), x, y, offsetX,
                                offsetY);
                        }
                        else
                        {
                            Utilidades.DibujarCaracteres(Utilidades.LadoDerecho.ToString(), x, y, offsetX, offsetY);
                        }
                    }
                    else if (x > -2 && x <= pieza.Forma.GetLength(0) + 3)
                    {
                        if (y == -2 || y == pieza.Forma.GetLength(0) + 1)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y, -1 + offsetX,
                                offsetY);
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y, offsetX, offsetY);
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y, 1 + offsetX,
                                offsetY);
                        }
                    }
                    else Console.Write(' ');

                }
            }

            for (var y = 0; y < pieza.Forma.GetLength(0); y++)
            {
                for (var x = 0; x < pieza.Forma.GetLength(1); x++)
                {
                    if (pieza.Forma[y, x])
                    {
                        Utilidades.DibujarCaracteres(Utilidades.Bloque.ToString(), x, y, pieza.Color, offsetX, offsetY);
                    }
                }
            }
        }
        private void LimpiarTablero() 
        {
            _tablero = new bool[_ancho, _alto];
            
            for (var x = 0; x < _ancho; x++)
            {
                for (var y = 0; y < _alto; y++)
                {
                    tablero[x, y] = false;
                }   
            }
        }
        private void LimpiarMarcoSiguientePieza()
        {
            var offsetX = (_ancho + 3) * 2;
            var offsetY = 1;

            for (var y = 0; y < 12; y++)
            {
                for (var x = 0; x < 12; x++)
                {
                    Utilidades.DibujarCaracteres(Utilidades.Vacio.ToString(), x, y, -1 + offsetX, offsetY);
                    Utilidades.DibujarCaracteres(Utilidades.Vacio.ToString(), x, y, offsetX, offsetY);
                    Utilidades.DibujarCaracteres(Utilidades.Vacio.ToString(), x, y, 1 + offsetX, offsetY);
                }
            }
        }
        
        public void DibujarMarcoTablero()
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            for (var y = 1; y < _alto + 1; y++)
            {
                for (var x = 0; x < _ancho + 1; x++)
                {
                    if (x == 0)
                    {
                        if (y == 1)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaSuperiorIzquierda.ToString(), x, y);
                        }
                        else if (y == _alto)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaInferiorIzquierda.ToString(), x, y);
                        }
                        else
                        {
                            Utilidades.DibujarCaracteres(Utilidades.LadoIzquierdo.ToString(), x, y);
                        }
                    }
                    else if (x > 0 && x < _ancho)
                    {
                        if (y == 1 || y == _alto)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y, -1, 0);
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y);
                            Utilidades.DibujarCaracteres(Utilidades.Horizontal.ToString(), x, y, 1, 0);
                        }
                    }
                    else if (x == _ancho)
                    {
                        if (y == 1)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaSuperiorDerecha.ToString(), x, y);
                        }
                        else if (y == _alto)
                        {
                            Utilidades.DibujarCaracteres(Utilidades.EsquinaInferiorDerecha.ToString(), x, y);
                        }
                        else
                        {
                            Utilidades.DibujarCaracteres(Utilidades.LadoDerecho.ToString(), x, y);
                        }
                    }
                }
            }
        }

        private void ComprobarLineasCompletas()
        {
            
        }

        private void LimpiarLinea(int y)
        {
            
        }

        public bool Colision(Coordenadas posicion, Coordenadas direccion, bool[,] forma)
        {
            if (direccion == new Coordenadas(0, -1)) direccion = new Coordenadas(0, 0);
            if (posicion.y + forma.GetLength(0) + direccion.y > _alto) return true;

            for (var x = 0; x < forma.GetLength(1); x++)
            {
                for (var y = 0; y < forma.GetLength(0); y++)
                {
                    if (!forma[y, x]) continue;

                    var posX = posicion.x + x + direccion.x;
                    var posY = posicion.y + y + direccion.y;

                    if (posX is < 0 or > Utilidades.Ancho - 1) return true;
                    if (posY > 18) return true;
                    if (tablero[posX, posY]) return true;
                }
            }

            return false;
        }
    }
}