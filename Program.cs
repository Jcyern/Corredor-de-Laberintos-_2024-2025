// See https://aka.ms/new-console-template for more information
using FICHA;
using Base_Datos;
using System.Data.SqlTypes;
using Maze_Generator;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using F1;

public class Program
{

    static void Main(string[] args)
    {
        //Maze(10);

        var first = Fase_1.first;
        first.Select_Faccion();
        first.Select_Fichas();
        
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
