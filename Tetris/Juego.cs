using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Tetris
{
    public class Game
    {
        private Tablero _tablero;
        private Marcador _marcador;
        
        private Pieza _piezaActual;
        private Pieza _piezaSiguiente;

        private bool _gameOver;
        private int _frame;

        public Game()
        {
            _tablero = new Tablero(Utilidades.Ancho, Utilidades.Alto);
            _marcador = new Marcador();
            _piezaActual = new Pieza(Utilidades.Random.Next(0,Utilidades.Piezas.Count));
            _piezaSiguiente = new Pieza(Utilidades.Random.Next(0,Utilidades.Piezas.Count));

            Start();
        }

        private void Start()
        {
            _tablero.DibujarMarcoSiguientePieza(_piezaSiguiente);
            _piezaActual.DibujarPieza();
            
            Update();
        }

        private void Update()
        {
            var sw = new Stopwatch();
            sw.Start();
            
            while (!_gameOver)
            {
                //Input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    var dir = Utilidades.CogerDireccionSegunTecla(key);
                    var forma = dir != new Coordenadas(0, -1) ? _piezaActual.Forma : _piezaActual.SiguienteRotacion();
                    
                    
                    if (!_tablero.Colision(_piezaActual.Posicion, dir,  forma))
                    {
                        _piezaActual.LimpiarPieza();

                        if (dir != new Coordenadas(0, -1))
                        {
                            _piezaActual.MoverPieza(dir);
                        }
                        else
                        {
                            _piezaActual.RotarPieza();
                        }
                        
                        _piezaActual.DibujarPieza();
                    }
                }
                
                if (sw.ElapsedMilliseconds > 1000)
                {   
                    _piezaActual.LimpiarPieza();
                    _piezaActual.MoverPieza(new Coordenadas(0, 1));
                    _piezaActual.DibujarPieza();
                    sw.Restart();
                }
            }
        }
    }
}