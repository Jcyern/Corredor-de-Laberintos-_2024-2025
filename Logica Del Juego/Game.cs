using Maze_Generator;
using FICHA;
using F1;
using System.Diagnostics;
namespace Gammepay
{
    public class Game
    {
        public  static Stopwatch  reloj = new Stopwatch();
        public static  Laberinto maze ;

        public static (bool,string) winner = (false,"") ;

        public static List<Player> jugadores = new List<Player>();



        public  static bool VerifyVictory(Player jugador )
        {
            var list = jugador.fichas;

            foreach( Ficha item in list)
            { 
                // verifica q todas las fichas han sido sacadas del laberinto 
                if(item.position != (maze.GetLength(0) - 1, maze.GetLength(0) - 2))
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

    }
}