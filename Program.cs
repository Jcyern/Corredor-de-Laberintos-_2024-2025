// See https://aka.ms/new-console-template for more information
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

public class Program
{

    static void Main(string[] args)
    {
        Juego game = new();
        game.Bienvenido();

    }


    public void Create_base()
    {
        SQlite.instancia.CreateTable();
        SQlite.instancia.Insert_Elements();
    }

    public static void Maze(int n)
    {
        Laberinto maze = new Laberinto(n);

        while (maze.IsValid_Maze() == false)
        {
            maze = new Laberinto(10);
        }
        maze.Print();
    }



}



public class Juego
{
    public Player jugador;

    public Juego(string name = "")
    {
        jugador = new Player("");
    }

    public void Bienvenido()
    {
        System.Console.WriteLine("Bienvenido al Juego de Laberinto ");
        System.Console.WriteLine();
        System.Console.WriteLine("Por Favor ingresa tu nombre ");
        jugador = new Player(Console.ReadLine() ?? "");


        System.Console.WriteLine($"{jugador.Usuario} necesitamos que escojas una casa con la cual jugar ");
        System.Console.WriteLine();




        //Seleccionando Faccion
        Faccion();


        //Seleciona las fichas 
        Fichas();



    }

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


}
