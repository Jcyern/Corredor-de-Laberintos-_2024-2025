

using FICHA;
using Gammepay;

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
        public void Movimiento(Direction direccion, Ficha ficha)
        {
            (int, int)[] moves = new (int, int)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
            var pos = ficha.position;
            switch (direccion)
            {
                case Direction.Up:
                    if (ficha.position.Item1 + moves[0].Item1 >= 0 && ficha.position.Item1 + moves[0].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[0].Item2 >= 0 && ficha.position.Item2 + moves[0].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[0].Item1, ficha.position.Item2 + moves[0].Item2].IsPared == false)
                    {
                        ficha.position = (pos.Item1 + moves[0].Item1, pos.Item2 + moves[0].Item2);
                    }
                    break;
                case Direction.Down:
                    if (ficha.position.Item1 + moves[2].Item1 >= 0 && ficha.position.Item1 + moves[2].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[2].Item2 >= 0 && ficha.position.Item2 + moves[2].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[2].Item1, ficha.position.Item2 + moves[2].Item2].IsPared == false)
                    {
                        ficha.position = (pos.Item1 + moves[2].Item1, pos.Item2 + moves[2].Item2);
                    }
                    break;
                case Direction.Right:
                    if (ficha.position.Item1 + moves[1].Item1 >= 0 && ficha.position.Item1 + moves[1].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[1].Item2 >= 0 && ficha.position.Item2 + moves[1].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[1].Item1, ficha.position.Item2 + moves[1].Item2].IsPared == false)
                    {
                        ficha.position = (pos.Item1 + moves[1].Item1, pos.Item2 + moves[1].Item2);
                    }
                    break;
                case Direction.Left:
                    if (ficha.position.Item1 + moves[3].Item1 >= 0 && ficha.position.Item1 + moves[3].Item1 < Game.maze.GetLength(0) && ficha.position.Item2 + moves[3].Item2 >= 0 && ficha.position.Item2 + moves[3].Item2 < Game.maze.GetLength(1) && Game.maze[ficha.position.Item1 + moves[3].Item1, ficha.position.Item2 + moves[3].Item2].IsPared == false)
                    {
                        ficha.position = (pos.Item1 + moves[3].Item1, pos.Item2 + moves[3].Item2);
                    }
                    break;


            }
        }
    }
}