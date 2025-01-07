using Maze_Generator;
using FICHA;
using F1;
using System.Collections.Generic;
using System;
namespace Gammepay
{
    public class Game
    {
        public static  Laberinto Maze ;

        public static (bool,string) winner = (false,"") ;

        public static List<Player> jugadores = new List<Player>();

        public static  (int,int) final_pos;



        public  static bool VerifyVictory(Player jugador )
        {
            var list = jugador.fichas;

            foreach( Ficha item in list)
            { 
                // verifica q todas las fichas han sido sacadas del laberinto 
                if(item.position != (Maze.GetLength(0) - 1, Maze.GetLength(0) - 2))
                {
                    
                    return false ;
                }
            }
            winner.Item2 = jugador.Usuario;
            return  true ;
        }


        public static void Victory()
        { 
            System.Console.WriteLine("//////////////////////////////////////////////////////////////////");
            System.Console.WriteLine("//////////////////////////////////////////////////////////////////");
            System.Console.WriteLine("//////////////////////////////////////////////////////////////////");
            System.Console.WriteLine("//////////////////////////////////////////////////////////////////");
            System.Console.WriteLine($"Gano el juagador {winner.Item2}  Felicidades !!!!!!!!!!!!!!!!!!!!!" );

        }







    #region  Generate Maze
    public  static Laberinto Generar_Maze(int fila , int columna )
    {
        Console.Clear();
        //Generando laberintos validos aleatorios
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine("/////////////////////Generando laberinto //////////////////");
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine();

        Maze = new Laberinto(fila , columna );

        while (Maze.IsValid_Maze() == false)
        {
            Maze = new Laberinto(fila,columna);
        }



        System.Console.WriteLine("/////////////////Laberinto is Ready ////////////////////////");
        System.Console.WriteLine();
        Console.Clear();

        return Maze;
    }

    #endregion



    }
}