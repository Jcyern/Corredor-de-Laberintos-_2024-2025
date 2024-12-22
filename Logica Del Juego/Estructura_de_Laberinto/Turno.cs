using F1;
using Gammepay;
using Spectre.Console;
using Faccion;
using System.Diagnostics;
namespace Turnos
{
    public class Turno 
    {
        public  static Player jugador = new Player(" null",new Faction(0));

        public static  int index = -1;



        public static  void Cambio_Turno()
        {
            if( index +1 <Game.jugadores.Count)
            {
                Debug.Print(" entra en las capacidades");
                jugador = Game.jugadores[index+1];
                index = index+ 1;
            }
            else 
            {
                index = 0;
                jugador = Game.jugadores[0];
            }

            System.Console.WriteLine("///////////");
            System.Console.WriteLine();
            AnsiConsole.Markup($"[{Color.Blue1}] Es el turno de {jugador.Usuario} [/]");
        }

    }
}