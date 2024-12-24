

using System.Diagnostics;
using FICHA;
using Gammepay;
using System;

using Turnos;

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
            (int, int)[] moves = new (int, int)[] { (-ficha.Velocidad, 0), (0, ficha.Velocidad), (ficha.Velocidad, 0), (0, -ficha.Velocidad) };
            (int,int)[]Basic_moves = new (int,int)[]{ (-1,0),(0,1),(1,0),(0,-1)};
            var pos = ficha.position;
            switch (direccion)
            {
                case Direction.Up:
                    if(CheckMove(ficha.position,moves[0]))
                    {
                        return (ficha.position = (pos.Item1 + moves[0].Item1, pos.Item2 + moves[0].Item2),true);
                    }
                    //verifica si con los basic moves se puede mover , si con el dezplazmiento normal de la ficha no puede 
                    else if(CheckMove(ficha.position, Basic_moves[0]))
                    {
                        return (ficha.position = (pos.Item1 + Basic_moves[0].Item1, pos.Item2 + Basic_moves[0].Item2),true);
                    }
                    else
                    {   
                        System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Down:
                
                    if(CheckMove(ficha.position,moves[2]))
                    {
                        return (ficha.position = (pos.Item1 + moves[2].Item1, pos.Item2 + moves[2].Item2),true );
                    }

                    //verifica si con los basic moves se puede mover , si con el dezplazmiento normal de la ficha no puede 
                    else if(CheckMove(ficha.position,Basic_moves[2]))
                    {
                        return (ficha.position = (pos.Item1 + Basic_moves[2].Item1, pos.Item2 + Basic_moves[2].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Right:

                    if(CheckMove(ficha.position,moves[1]))
                    {
                        return (ficha.position = (pos.Item1 + moves[1].Item1, pos.Item2 + moves[1].Item2),true);
                    }

                    //verifica si con los basic moves se puede mover , si con el dezplazmiento normal de la ficha no puede 
                    else if(CheckMove(ficha.position,Basic_moves[1]))
                    {
                        return (ficha.position = (pos.Item1 + Basic_moves[1].Item1, pos.Item2 + Basic_moves[1].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                case Direction.Left:

                    if(CheckMove(ficha.position,moves[3]))
                    {
                        return (ficha.position = (pos.Item1 + moves[3].Item1, pos.Item2 + moves[3].Item2),true);
                    }

                    //verifica si con los basic moves se puede mover , si con el dezplazmiento normal de la ficha no puede 
                    else if(CheckMove(ficha.position,Basic_moves[3]))
                    {
                        return (ficha.position = (pos.Item1 + Basic_moves[3].Item1, pos.Item2 + Basic_moves[3].Item2),true);
                    }
                    else
                    {   System.Console.WriteLine("No se Puede mover hay obstaculo");
                        return  (ficha.position,false);
                    }
                default:
                throw new Exception (" Direccionn no valida ");


            }
        }



        public bool Movimiento(Ficha ficha , Direction direccion )
        {
            //Acceder al Maze para cambiar la pos en el tablero 

            var maze = Game.Maze;

            var temp =(ficha.position.Item1,ficha.position.Item2);
            Debug.Print($"Ficha elminada en {ficha.position.Item1},{ficha.position.Item2} --- {ficha.Name}");

            var result =Movement(direccion,ficha);

            if ( result.Item2== true )
            {  
                 //si la pos es la salida del laberinto 
                if(   result.Item1.Item1 ==maze.GetLength(0) - 1 && result.Item1.Item2 == maze.GetLength(0) - 2)
                {
                    System.Console.WriteLine("va a verificar si es victoria ");
                    Game.VerifyVictory(Turno.jugador);
                }
                
                else
                {
                    //agregala en la nueva posicion
                    maze[result.Item1.Item1,result.Item1.Item2].j1.Add(ficha);
                }

                //y eliminala en la q ya paso 
                maze[temp.Item1,temp.Item2].j1.Remove(ficha);
                return true ;
            }

            return false ;
            
        }






        private bool CheckMove((int,int)pos , (int,int)move)
        {
            
            if ( move.Item1 == 0 )
            {
                //va hacia la derecha 
                if(pos.Item2>=0)
                {
                    for(int i = 1; i <= move.Item2; i++)
                    {
                        if(pos.Item2+ i>=0 && pos.Item2+i<Game.Maze.GetLength(1))
                        { //si queda dentro de los limites 
                            if (Game.Maze[pos.Item1,pos.Item2+i].IsPared)
                            {
                                return false ;
                            }
                        }
                        else
                        {
                            return false ;
                        }
                    }
                    return true ;
                }
                
                //va hacia la  izquierda
                else if(pos.Item2<0)
                {
                    for (int i = -1; i >= move.Item2 ; i--)
                    {
                        if( pos.Item2+ i >= 0 && pos.Item2+i < Game.Maze.GetLength(1))
                        {
                            if(Game.Maze[pos.Item1 , pos.Item2+i].IsPared)
                            {
                                //si hay  pared 
                                return false ;
                            }
                        }
                        else
                        {   
                            //fuera de los limites
                            return false;
                        }
                    }
                    return true ;
                }
            }

            else if ( move.Item2== 0)
            {
                //va hacia Abajo
                if(move.Item1>=0)
                {
                    for (int i = 1; i <= move.Item1; i++)
                    {
                        if(pos.Item1+1>=0 && pos.Item1<Game.Maze.GetLength(0))
                        {
                            if ( Game.Maze[pos.Item1+i,pos.Item2].IsPared)
                            {
                                System.Console.WriteLine("Hay Pared ");
                                System.Console.WriteLine("Not Valid ");
                                return false ;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Fuera de Limite");
                            System.Console.WriteLine("Not Valid");
                            return false ;
                        }
                    }
                    return true ;
                }
                //arriba 
                if( move.Item1<0)
                {
                    for (int i = -1 ; i >= move.Item1 ; i--)
                    {
                        if(pos.Item1+i>=0 && pos.Item1< Game.Maze.GetLength(0))
                        {
                            if( Game.Maze[pos.Item1+i, pos.Item2].IsPared)
                            {
                                System.Console.WriteLine("Hay Pared ");
                                System.Console.WriteLine("Not Valid ");
                                return false ;
                            }
                        }
                        else
                        {  
                            System.Console.WriteLine("Not Valid");
                            return false;
                        }
                    }
                    return true ;
                }
    
            }

            return false ;

            
        
        }
    }
    
}
