using System;
using System.Collections.Generic;

namespace Tetris
{
    public static class Utilidades
    {
        public const int Ancho = 10;
        public const int Alto = 20;
        
        public static Random Random = new Random();

        private const int OffsetX = 0;
        private const int OffsetY = 0;

        //Caracteres del juego
        public const char Vacio = ' ';
        public const char Bloque = '■';
        public const char EsquinaSuperiorDerecha = '╗';
        public const char EsquinaSuperiorIzquierda = '╔';
        public const char EsquinaInferiorDerecha = '╝';
        public const char EsquinaInferiorIzquierda = '╚';
        public const char LadoDerecho = '║';
        public const char LadoIzquierdo = '║';
        public const char Horizontal = '═';
        
        //Piezas
        public static readonly List<List<bool[,]>> Piezas = new() {
            new List<bool[,]>
            {
                new[,]
                {
                    { true },
                    { true },
                    { true },
                    { true }
                },
                new[,]
                {
                    { true, true, true, true }
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { true, true },
                    { true, true }
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { true, true, true },
                    { false, true, false }
                },
                new[,]
                {
                    { false, true },
                    { true, true },
                    { false, true }
                },
                new[,]
                {
                    { false, true, false },
                    { true, true, true }
                },
                new[,]
                {
                    { true, false },
                    { true, true },
                    { true, false }
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { true, false },
                    { true, false },
                    { true, true }
                },
                new[,]
                {
                    { true, true, true },
                    { true, false, false }
                },
                new[,]
                {
                    { true, true },
                    { false, true },
                    { false, true }
                },
                new[,]
                {
                    { false, false, true },
                    { true, true, true }
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { false, true },
                    { false, true },
                    { true, true }
                },
                new[,]
                {
                    { true, false, false },
                    { true, true, true }
                },
                new[,]
                {
                    { true, true },
                    { true, false },
                    { true, false }
                },
                new[,]
                {
                    { true, true, true },
                    { false, false, true }
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { false, true, true },
                    { true, true, false }
                },
                new[,]
                {
                    { true, false},
                    { true, true},
                    { false, true}
                }
            },
            new List<bool[,]>
            {
                new[,]
                {
                    { true, true, false },
                    { false, true, true }
                },
                new[,]
                {
                    { false, true},
                    { true, true},
                    { true, false}
                }
            }
        };


        public static void DibujarTitulo()
        {
            
        }
        
        #region DibujarCaracteres
        public static void DibujarCaracteres(string caracteres, int x, int y, ConsoleColor color)
        {
            
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition((x * 2) + OffsetX, y + OffsetY - 1);
                mousePos = Console.GetCursorPosition();
            }
            while (mousePos.Left != (x * 2) + OffsetX || mousePos.Top != y + OffsetY - 1);
            
            Console.ForegroundColor = color;
            Console.Write(caracteres);
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DibujarCaracteres(string caracteres, int x, int y, int offsetX, int offsetY)
        {
            
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition((x * 2) + OffsetX + offsetX, y + OffsetY + offsetY - 1);
                mousePos = Console.GetCursorPosition();
            }
            while (mousePos.Left != (x * 2) + OffsetX + offsetX || mousePos.Top != y + OffsetY + offsetY - 1);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(caracteres);
        }
        public static void DibujarCaracteres(string caracteres, int x, int y)
        {
            
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition((x * 2) + OffsetX, y + OffsetY - 1);
                mousePos = Console.GetCursorPosition();
            }
            while (mousePos.Left != (x * 2) + OffsetX || mousePos.Top != y + OffsetY - 1);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(caracteres);
        }
        public static void DibujarCaracteres(string caracteres, int x, int y, ConsoleColor color, int offsetX, int offsetY)
        {
            
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition((x * 2) + OffsetX + offsetX, y + OffsetY + offsetY - 1);
                mousePos = Console.GetCursorPosition();
            } 
            while (mousePos.Left != (x * 2) + OffsetX + offsetX || mousePos.Top != y + OffsetY + offsetY - 1);
            
            Console.ForegroundColor = color;
            Console.Write(caracteres);
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DibujarCaracteres(string caracteres, int x, int y, ConsoleColor color, int offsetX, int offsetY, bool esPieza)
        {
            if (esPieza)
            {
                if (x + offsetX < 1 || y + offsetY < 2 || x + offsetX > 10 || y + offsetY > 19) return;
            }
            
            
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition((x * 2) + OffsetX + offsetX, y + OffsetY + offsetY - 1);
                mousePos = Console.GetCursorPosition();
            }
            while (mousePos.Left != (x * 2) + OffsetX + offsetX || mousePos.Top != y + OffsetY + offsetY - 1);
            
            Console.ForegroundColor = color;
            Console.Write(caracteres);
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
        
        public static void BorrarCaracter(int x, int y)
        {
            var mousePos = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x * OffsetX, y * OffsetY);
                mousePos = Console.GetCursorPosition();
            } while (mousePos.Left == x * OffsetX && mousePos.Top == y * OffsetY);

            Console.Write(' ');
        }
        
        public static bool ComprobarPiezaFueraMapa(Pieza pieza, Coordenadas direccion)
        {
            for (var x = 0; x < pieza.Forma.GetLength(1); x++)
            {
                for (var y = 0; y < pieza.Forma.GetLength(0); y++)
                {
                    if (pieza.Forma[y, x])
                    {
                        var pos = pieza.Posicion + direccion;
                        if (x + pos.x < 0 || x + pos.x > 9 || y + pos.y < 0 ||
                            y + pos.y > 18)
                            return true;
                    }
                }
            }

            return false;
        }

        public static Coordenadas CogerDireccionSegunTecla(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.LeftArrow => new Coordenadas(-1,0),
                ConsoleKey.RightArrow => new Coordenadas(1,0),
                ConsoleKey.DownArrow => new Coordenadas(0,1),
                ConsoleKey.UpArrow => new Coordenadas(0,-1),
                _ => new Coordenadas(0,0)
            };
        }
        
        public static ConsoleColor CogerColorSegunPieza(int pieza)
        {
            pieza++;
            return pieza switch
            {
                0 => ConsoleColor.White,
                1 => ConsoleColor.Cyan,
                2 => ConsoleColor.Yellow,
                3 => ConsoleColor.DarkMagenta,
                4 => ConsoleColor.Blue,
                5 => ConsoleColor.DarkYellow,
                6 => ConsoleColor.Red,
                7 => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
        }
    }
}