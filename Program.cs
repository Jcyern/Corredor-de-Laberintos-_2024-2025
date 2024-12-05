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

public class Program
{

    static void Main(string[] args)
    {
        Juego game = new Juego();
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



public class Juego()
{
    public string? usuario;



    public void Bienvenido()
    {
        System.Console.WriteLine("Bienvenido al Juego de Laberinto ");
        System.Console.WriteLine();
        System.Console.WriteLine("Por Favor ingresa tu nombre ");
        usuario = Console.ReadLine() ?? "";


        System.Console.WriteLine($"{usuario} necesitamos que escojas una casa con la cual jugar ");
        System.Console.WriteLine();




        //Seleccionando Faccion
        Faccion();



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

        Selecciones j1 = new Selecciones();
        j1.Select_Faccion(result);

        if (j1.faction != null)
            AnsiConsole.Markup($"[{Color.BlueViolet}] Felicidades ha escogido la faccion {j1.faction.id}");

    }


}
