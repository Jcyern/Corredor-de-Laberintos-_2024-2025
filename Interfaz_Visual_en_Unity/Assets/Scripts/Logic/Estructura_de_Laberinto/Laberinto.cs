using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;
using FICHA;
using Case;

using Game_Logic.Trampas;


namespace Maze_Generator
{

public class Laberinto
{
    public HashSet<(int, int)> obstacles { get; set; }

    public Casilla[,] maze;

    public bool Valido;


    private TypeTramps[] types = new TypeTramps[]
        {
            TypeTramps.Freeze,
            TypeTramps.RandomMove,
            TypeTramps.LowVelocity
        };


    public int GetLength(int n)
    {
        if (n < maze.Rank)
        {
            return maze.GetLength(n);
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }


    public Casilla this[int fila, int columna]
    {
        get
        {
            if (fila < maze.GetLength(0) && fila >= 0 && columna >= 0 && columna < maze.GetLength(1))
            {
                return maze[fila, columna];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        set
        {
            if (fila < maze.GetLength(0) && fila >= 0 && columna >= 0 && columna < maze.GetLength(1))
            {
                
                maze[fila, columna] =value ;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }





    //builder 
    public Laberinto(int x, int y)
    {
        maze = new Casilla[x, y];
        this.obstacles = new HashSet<(int, int)>();

        //inicializando la casillas 
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = new Casilla(i, j);
            }
        }


        //Para q genere los obstaculos 
        CreateObstacles();

    }

#region  Print 
    public void Print()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if(maze[i,j].trampa != null)
                {
                    string trampa = maze[i,j].trampa.Type.ToString();
                    Console.Write(trampa[0]);
                }
                else  if(maze[i,j].j1.Count>0)
                {
                    Console.WriteLine($"{maze[i,j].j1[0].Name[0] }\t");
                }
                else if (!maze[i, j].IsPared)
                {
                    Console.WriteLine($"1 \t");

                }
                else if ( maze[i,j].IsPared)
                    Console.WriteLine("0 \t");


            }
            Console.WriteLine();
        }
    }

#endregion



#region Obstaculos
    //Metodo de agregar paredes al azar
    public void CreateObstacles()
    {


        //creando los bordes del maze de obstaculos
        for (int i = 0; i < maze.GetLength(1); i++)
        {
            //poniendo en true el incio 
            maze[0,1].inicio = true ;

            if (maze[0, i].inicio != true )
            {//para q no ponga en true la entrada
                maze[0, i].IsPared = true;   // La Primera Fila 
                obstacles.Add((0, i));
            }

            //asignamos la salia del talero 
            maze[maze.GetLength(0) - 1, maze.GetLength(1) - 2].salida = true ;
            //si es desigual de la salida
            if (maze[maze.GetLength(0) - 1, i].salida == false ) 
            {
                maze[maze.GetLength(0) - 1, i].IsPared = true;  // La ultima fila 
                obstacles.Add((maze.GetLength(0) - 1, i));
            }


        }
        //para lo q tenga q ver con el conteo de las filas 
        for ( int i = 0 ; i < maze.GetLength(0);  i ++)
        {
            maze[i, 0].IsPared = true;  // La primera columna 
            obstacles.Add((i, 0));


            maze[i, maze.GetLength(1) - 1].IsPared = true;   //La ultima columna
            obstacles.Add((i, maze.GetLength(1) - 1));
            Debug.Print(" obstaculos " + obstacles.Count);

        }



        Debug.Print("after for " + obstacles.Count);

        //hora de crear random , crea obstaculos random por el tablero  
        RandomObstacles();





    }

    private void RandomObstacles()
    {
        int cant = maze.GetLength(1) * 6;
        Debug.Print(cant.ToString());

        while (cant != 0)
        {
            Random random = new Random();
            // para q no ponga obtaculos en los bordes q se supone que ya tienen obstaculos
            var row = random.Next(1, maze.GetLength(0) - 1);
            var column = random.Next(1, maze.GetLength(1) - 1);

            //random obstacle 

            maze[row, column].IsPared = true;
            obstacles.Add((row, column));

            cant--;
        }
    }


#endregion


#region  Trampas
    public void CreateTramps()
    {

        Random rnd = new Random();

        int cant  = maze.GetLength(1);


        int fila = 0;
        int columna = 0;

        while( cant >0)
        {   
            fila = rnd.Next(0,maze.GetLength(0));
            columna =  rnd.Next(0,maze.GetLength(1));Debug.Print(cant.ToString());

            if(maze[fila,columna].IsPared == false && maze[fila,columna].salida == false && maze[fila,columna].inicio == false  && maze[fila,columna].trampa == null)
            {
                
                //sino es la  entrada , ni la salida y no hay  pared en la casilla , 
                // entonces se puede colocar una trampa 
                
                maze[fila,columna].trampa = RandomTramp(maze[fila,columna]);
                Debug.Print($"tramp {maze[fila,columna].trampa.Type}");
                

                cant --;
            }
        }
    }


    private Trampa RandomTramp( Casilla casilla)
    {
        Random random = new Random();
        var i = random.Next(0,types.Length);
        
        var result = types[i];
        
        switch ( result)
        {
            case TypeTramps.Freeze:
            return new Freeze(casilla.Pos);

            case TypeTramps.RandomMove:
            return new RandomMove(casilla.Pos);

            case TypeTramps.LowVelocity:
            return new LowVelocity(casilla.Pos);

            default:
            throw new Exception("El Enum de typos de trampas no es ninguno de las creadas ");
        }
    }

#endregion





#region   Validacion
    
    public bool IsValid_Maze()
    {
        var visit = new bool[maze.GetLength(0), maze.GetLength(1)];

        foreach (var item in obstacles)
        {
            visit[item.Item1, item.Item2] = true;
        }

        // creando cola e inicializandola en la entrada (0,1)
        var cola = new Queue<(int, int)>();
        cola.Enqueue((0, 1));


        //metodo para verificar si el tablero es valido 
        return IsInvalid(visit, (0, 0), cola);

    }


    // Metodo para saber cuando un laberinto es invalido , en este caso cuando se le crean islas
    // osea queda una casilla en true sin acceso rodeada de false 

    private bool IsInvalid(bool[,] visit, (int, int) actual, Queue<(int, int)> cola)
    {
        if (cola.Count == 0)
        {
            //cola vacia , termino el recorrido


            for (int i = 0; i < visit.GetLength(0); i++)
            {

                for (int j = 0; j < visit.GetLength(1); j++)
                {
                    if (!visit[i, j])
                    {
                        Valido = false;


                        return false;

                    }
                }
            }
            Valido = true;
            return true;

        }


        else
        {
            actual = cola.Dequeue(); //extrae el elemento actual de la cola
            visit[actual.Item1, actual.Item2] = true;
            Debug.Print("actual es :" + actual.Item1 + actual.Item2);

            // utilizamos un array direccional  para ver q rango de mov tiene para moverse 
            var lab = Direccion(actual);

            foreach (var item in lab)
            {
                if (!cola.Contains(item))
                {  //sino se encuentra  en la cola y el elemento no se ecuentra visitado (agregalo a la cola) 
                    if (visit[item.Item1, item.Item2] == false)
                        cola.Enqueue(item);
                }
            }
            return IsInvalid(visit, actual, cola);
        }
    }


    private List<(int, int)> Direccion((int, int) Pos)
    {
        List<(int, int)> direct = new List<(int, int)>();
        // abajo
        if (Pos.Item1 + 1 < maze.GetLength(0) && !maze[Pos.Item1 + 1, Pos.Item2].IsPared)
        {
            direct.Add((Pos.Item1 + 1, Pos.Item2));
        }
        //arriba 
        if (Pos.Item1 - 1 >= 0 && !maze[Pos.Item1 - 1, Pos.Item2].IsPared)
        {
            direct.Add((Pos.Item1 - 1, Pos.Item2));
        }
        //dereha 
        if (Pos.Item2 + 1 < maze.GetLength(1) && !maze[Pos.Item1, Pos.Item2 + 1].IsPared)
        {
            direct.Add((Pos.Item1, Pos.Item2 + 1));
        }
        //izquierda
        if (Pos.Item2 - 1 >= 0 && !maze[Pos.Item1, Pos.Item2 - 1].IsPared)
        {
            direct.Add((Pos.Item1, Pos.Item2 - 1));
        }


        return direct;
    }



#endregion



}





}