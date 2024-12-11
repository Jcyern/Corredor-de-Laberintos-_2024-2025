

using System.Diagnostics;
using FICHA;
using Gammepay;
using Spectre.Console;

namespace Direcciones
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }



    public class Moves
    {
        private ((int,int),bool) Movement(Direction direccion, Ficha ficha)
        {
            (int, int)[] moves = new (int, int)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };
            var pos = ficha.position;
            switch (direccion)
            {
                case Direction.Up:
                    if (ficha.position.Item1 + moves[0].Item1 >= 0 && ficha.position.Item1 + moves[0].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[0].Item2 >= 0 && ficha.position.Item2 + moves[0].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[0].Item1, ficha.position.Item2 + moves[0].Item2].IsPared == false)
                    {
                        return (ficha.position = (pos.Item1 + moves[0].Item1, pos.Item2 + moves[0].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Down:
                    if (ficha.position.Item1 + moves[2].Item1 >= 0 && ficha.position.Item1 + moves[2].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[2].Item2 >= 0 && ficha.position.Item2 + moves[2].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[2].Item1, ficha.position.Item2 + moves[2].Item2].IsPared == false)
                    {
                        return (ficha.position = (pos.Item1 + moves[2].Item1, pos.Item2 + moves[2].Item2),true );
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Right:
                    if (ficha.position.Item1 + moves[1].Item1 >= 0 && ficha.position.Item1 + moves[1].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[1].Item2 >= 0 && ficha.position.Item2 + moves[1].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[1].Item1, ficha.position.Item2 + moves[1].Item2].IsPared == false)
                    {
                        return (ficha.position = (pos.Item1 + moves[1].Item1, pos.Item2 + moves[1].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Left:
                    if (ficha.position.Item1 + moves[3].Item1 >= 0 && ficha.position.Item1 + moves[3].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[3].Item2 >= 0 && ficha.position.Item2 + moves[3].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[3].Item1, ficha.position.Item2 + moves[3].Item2].IsPared == false)
                    {
                        return (ficha.position = (pos.Item1 + moves[3].Item1, pos.Item2 + moves[3].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                default:
                throw new Exception (" Direccionn no valida ");


            }
        }



        public void Movimiento(Ficha ficha , Direction direccion )
        {
            //Acceder al Maze para cambiar la pos en el tablero 

            var maze = Game.maze;

            var temp =(ficha.position.Item1,ficha.position.Item2);
            Debug.Print($"Ficha elminada en {ficha.position.Item1},{ficha.position.Item2} --- {ficha.Name}");

            var result =Movement(direccion,ficha);

            if ( result.Item2== true )
            {   
                //agregala en la nueva posicion
                maze[result.Item1.Item1,result.Item1.Item2].j1.Add(ficha);

                //y eliminala en la q ya paso 
                maze[temp.Item1,temp.Item2].j1.Remove(ficha);
            }
            
        }
    }
}