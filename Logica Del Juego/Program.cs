
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
using Faccion;
using Turnos;
using Interface;

public class Program
{

    static void Main(string[] args)
    {
        Create_base();
        Juego game = new();
        //game.Bienvenido();


        //Prueba de moviemiento 
        
        // game.jugador.faction = new Faction(1);
        // game.jugador.fichas.Add(  new Ficha(1,"Albus_Dumbledore",3,2,1));
        // game.jugador.fichas.Add(    new Ficha(1,"Animago",2,1,1));
        // game.jugador.fichas.Add(  new Ficha(1,"Auror",1,2,1));

        Generar_Maze(23,34);

        Game.Maze.Print();

        // var tablero = Game.maze;

        // //inicializando  fichas en la pos 0,1
        // foreach ( var item in game.jugador.fichas)
        // {
        //     tablero[0,1].j1.Add(item);
        // }


        // tablero.Print();
        // game.Empezar_Dezplazaminetos(game);

        }


    public static void Create_base()
    {
        SQlite.instancia.CreateTable();
        
    }

private static  void Generar_Maze(int fila , int columna )
    {
        //Generando laberintos validos aleatorios
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine("/////////////////////Generando laberinto //////////////////");
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine();

        Laberinto maze =new Laberinto(fila,columna );

        while (maze.IsValid_Maze() == false)
        {
            maze = new Laberinto(fila,columna );
        }


        Game.Maze = maze;

        System.Console.WriteLine("/////////////////Laberinto is Ready ////////////////////////");
        System.Console.WriteLine();

        //Game.maze.Print();
    }
}


