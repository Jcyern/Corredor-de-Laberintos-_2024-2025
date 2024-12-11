
using FICHA;
using Base_Datos;
using System.Data.SqlTypes;
using Maze_Generator;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using F1;
using Spectre.Console;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Xml.XPath;
using Gammepay;
using System.Net;

public class Program
{

    static void Main(string[] args)
    {
        Create_base();
        Juego game = new();
        //game.Bienvenido();


        //Prueba de moviemiento 
        
        game.jugador.faction = new Faction(1);
        game.jugador.fichas.Add(  new Ficha(1,"Albus_Dumbledore",3,2,1));
        game.jugador.fichas.Add(    new Ficha(1,"Animago",2,1,1));
        game.jugador.fichas.Add(  new Ficha(1,"Auror",1,0,1));

        Generar_Maze(10);
        var tablero = Game.maze;

        //inicializando  fichas en la pos 0,1
        foreach ( var item in game.jugador.fichas)
        {
            tablero[0,1].j1.Add(item);
        }


        tablero.Print();

        }


    public static void Create_base()
    {
        SQlite.instancia.CreateTable();
        SQlite.instancia.Insert_Elements();
    }


    private static  void Generar_Maze(int n)
    {
        //Generando laberintos validos aleatorios
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine("/////////////////////Generando laberinto //////////////////");
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine();

        Laberinto maze = new Laberinto(n);

        while (maze.IsValid_Maze() == false)
        {
            maze = new Laberinto(10);
        }


        Game.maze = maze;

        System.Console.WriteLine("/////////////////Laberinto is Ready ////////////////////////");
        System.Console.WriteLine();

        //Game.maze.Print();
    }





}



public class Juego
{
    public Player jugador;

    public Juego(string name = "")
    {
        jugador = new Player("", new Faction(0));
    }
#region  Welcome
    public void Bienvenido()
    {
        System.Console.WriteLine("Bienvenido al Juego de Laberinto ");
        System.Console.WriteLine();
        System.Console.WriteLine("Por Favor ingresa tu nombre ");
        jugador = new Player(Console.ReadLine() ?? "", new Faction(0));


        System.Console.WriteLine($"{jugador.Usuario} necesitamos que escojas una casa con la cual jugar ");
        System.Console.WriteLine();




        //Seleccionando Faccion
        Faccion();


        //Seleciona las fichas 
        Fichas();

        Generar_Maze(10);


        Empezar_Dezplazaminetos(this);

    }

    #endregion Welcome 

    #region  Select Faccion

    private void Faccion()
    {
        AnsiConsole.Markup($"[yellow]Gryffindor -- 1[/]");
        System.Console.WriteLine();
        AnsiConsole.Markup("[green]Slytherin --- 2[/]");
        System.Console.WriteLine();
        AnsiConsole.Markup($"[{Color.Gold1}]Hufflepuff -- 3[/]");
        System.Console.WriteLine();
        AnsiConsole.Markup("[blue]Ravenclaw --- 4[/]");
        System.Console.WriteLine();
        System.Console.WriteLine("Selecciona una faccion , escribiendo el numero correspondiente");

        int result = 0;
        while (int.TryParse(Console.ReadLine(), out result) == false)
        {
            System.Console.WriteLine("El valor pasado no es un numero ");
        }

        System.Console.WriteLine($"El valor pasado es {result}");

        if (jugador != null)
        {
            jugador.Select_Faccion(result);

            if (jugador.faction != null)
                AnsiConsole.Markup($"[{Color.BlueViolet}] Felicidades ha escogido la faccion {jugador.faction.id} [/]");
        }
    }

    #endregion

    #region  Select_Fichas
    private void Fichas()
    {
        System.Console.WriteLine();
        AnsiConsole.Markup($"[{Color.BlueViolet}] Llego el momento de eleigir tus fichas , con las cuales jugaras   [/]");
        AnsiConsole.Markup($"[{Color.BlueViolet}] Escoge 3 fichas minimo para salir a la siguiente fase    [/]");

        while (jugador.fichas.Count < 3)
        {
            jugador.Print_Fichas();

            System.Console.WriteLine("Escribe el numero de la ficha q quieras Agregar ");

            int result = 0;
            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                System.Console.WriteLine("No es un numero lo q pasaste ");
            }
            jugador.Add(result);
        }

        AnsiConsole.Markup($"[{Color.Gold1}] Desea escoger mas fichas   [/]");
        System.Console.WriteLine(" 1 -- Pasar a la siguiente Fase ");
        System.Console.WriteLine(" 2 -- Escoger mas Fichas ");
        switch (Console.ReadLine())
        {
            case "1":
                System.Console.WriteLine("Siguiente Fase");
                System.Console.WriteLine();
                break;
            case "2":
                jugador.Print_Fichas();

                System.Console.WriteLine("Escribe el numero de la ficha q quieras Agregar ");

                int result = 0;
                while (int.TryParse(Console.ReadLine(), out result) == false)
                {
                    System.Console.WriteLine("No es un numero lo q pasaste ");
                }
                jugador.Add(result);
                break;


            default:
                System.Console.WriteLine("No escribiste ni 1 ni 2");
                break;
        }


        System.Console.WriteLine("Tus Fichas Escogidas son");
        int count = 0;
        foreach (var item in jugador.fichas)
        {
            count++;
            AnsiConsole.Markup($"[{Color.BlueViolet}]  #{count} Nombre: {item.Name} Velocidad: {item.Velocidad} Enfriamineto: {item.Enfriamiento}    [/]");
            System.Console.WriteLine();
        }
    }

#endregion
    #region  Generador
    private void Generar_Maze(int n)
    {
        //Generando laberintos validos aleatorios
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine("/////////////////////Generando laberinto //////////////////");
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine();

        Laberinto maze = new Laberinto(n);

        while (maze.IsValid_Maze() == false)
        {
            maze = new Laberinto(10);
        }


        Game.maze = maze;

        System.Console.WriteLine("/////////////////Laberinto is Ready ////////////////////////");
        System.Console.WriteLine();

        Game.maze.Print();
    }

    #endregion

    #region  Movimientos
    public void Empezar_Dezplazaminetos(Juego game )
        {
            System.Console.WriteLine("Presiona Q para seleccionar una ficha para mover");
            System.Console.WriteLine("Escriba Esc para salir ");
            while ( true )
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
            
                if( info.Key == ConsoleKey.Q)
                {
                    int count = 0 ;
                    foreach ( var ficha in game.jugador.fichas)
                    {  
                        count ++;
                        System.Console.WriteLine($"{count}  -- {ficha.Name}");
                    }

                    int result = 0;
                    while (int.TryParse(Console.ReadLine(), out result) == false)
                        {
                            System.Console.WriteLine("El valor pasado no es un numero ");
                        } 

                    Movimiendo(game.jugador.fichas[result-1]);
                }

            else if ( info.Key == ConsoleKey.Escape)
            {
                System.Console.WriteLine("you press Escape ");
                break;
            }
        } 
    }




        public static void Movimiendo(Ficha ficha)
    {
        System.Console.WriteLine("Presiona : Esc para salir");
        System.Console.WriteLine(" W arriba ");
        System.Console.WriteLine(" S abajo ");
        System.Console.WriteLine(" A izquierda ");
        System.Console.WriteLine(" D  derecha ");
    
            ConsoleKeyInfo info  = Console.ReadKey(true);
        if ( info.Key == ConsoleKey.Escape)
        {
            System.Console.WriteLine("se tecleo escape");
            System.Console.WriteLine("Teclea otra vez si quierer cerrar ");
        
        }

        else if ( info.Key == ConsoleKey.W)
        {
            ficha.move.Movimiento(ficha,Direcciones.Direction.Up);
            System.Console.WriteLine("Arriba");
            Game.maze.Print();
        }

        else if( info.Key == ConsoleKey.S)
        {
            ficha.move.Movimiento(ficha,Direcciones.Direction.Down);
            System.Console.WriteLine("Abajo");
            Game.maze.Print();
        }
        else if( info.Key == ConsoleKey.A)
        {
            ficha.move.Movimiento(ficha,Direcciones.Direction.Left);
            System.Console.WriteLine("Izquierda");
            Game.maze.Print();
        }
        else if ( info.Key == ConsoleKey.D)
        {
            ficha.move.Movimiento(ficha,Direcciones.Direction.Right);
            System.Console.WriteLine("Derecha");
            Game.maze.Print();
        }
        
    }
    

#endregion

}
