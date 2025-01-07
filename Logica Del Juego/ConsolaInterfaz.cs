
using F1;
using Faccion;
using FICHA;
using Gammepay;
using Maze_Generator;
using Spectre.Console;
using Turnos;

namespace Interface
{

#region  Game
public class Juego
{
    public Player jugador;

    public Juego(string name = "")
    {
        jugador = new Player("", new Faction(0));
    }


    public int IsNumber( string? consola)
    {  
            int result = 0;
            while (int.TryParse(consola, out result) == false)
            {
                System.Console.WriteLine("El valor pasado no es un numero ");
            }
            return result;
        
    }






#region  Welcome
    public void Bienvenido()
    {   
        Console.Clear();
        System.Console.WriteLine("Bienvenido al Juego de Laberinto ");
        System.Console.WriteLine();
        System.Console.WriteLine("Por Favor ingresa tu nombre ");
        jugador = new Player(Console.ReadLine() ?? "", new Faction(0));

        Console.Clear();
        System.Console.WriteLine($"{jugador.Usuario} necesitamos que escojas una casa con la cual jugar ");
        System.Console.WriteLine();

        //Seleccionando Faccion
        Faccion();

        Console.Clear();
        //Seleciona las fichas 
        Fichas();

        Console.Clear();
        Generar_Maze(20,28);

        
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

        int result = IsNumber(Console.ReadLine());

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
    private void Generar_Maze(int fila , int columna )
    {
        Console.Clear();
        //Generando laberintos validos aleatorios
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine("/////////////////////Generando laberinto //////////////////");
        System.Console.WriteLine("///////////////////////////////////////////////////////////");
        System.Console.WriteLine();

        Laberinto maze = new Laberinto(fila , columna );

        while (maze.IsValid_Maze() == false)
        {
            maze = new Laberinto(fila,columna);
        }


        Game.Maze = maze;

        System.Console.WriteLine("/////////////////Laberinto is Ready ////////////////////////");
        System.Console.WriteLine();
        Console.Clear();

        //Game.maze.Print();
    }

    #endregion







    #region  Movimientos
    public void Empezar_Dezplazaminetos(Juego game )
        {
            Game.Maze.Print();
            System.Console.WriteLine("Presiona Q para seleccionar una ficha para mover");
            System.Console.WriteLine("Escriba Esc para salir ");
            System.Console.WriteLine();

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
                    System.Console.WriteLine();


                    int result = 0;
                    System.Console.WriteLine("Selecciona una ficha poniendo su numero en consola ");
                    while (int.TryParse(Console.ReadLine(), out result) == false)
                        {
                            System.Console.WriteLine("El valor pasado no es un numero ");
                        } 

                    //empezar la movimientos de la ficha
                    Movimiendo(game.jugador.fichas[result-1]);

                    if(Game.winner.Item1) //si se cumple la condicion de victoria , finalizar el juego y dar el ganador 
                    {
                        //Llamar al metodo de la victoria 
                        Game.Victory();
                        break;
                    }

                    //despues de hacer todos los desplazamientos se rompe para seguir

                    System.Console.WriteLine("Desea terminar o seguir el juego ");
                    System.Console.WriteLine("Presione ");
                    System.Console.WriteLine("Y --  seguir ");
                    System.Console.WriteLine("N -- terminar juego "); 
                    
                    ConsoleKeyInfo llave  = Console.ReadKey(true );
                    


                    if(llave.Key == ConsoleKey.N)
                    break;
                    
                    if(llave.Key == ConsoleKey.Y)
                    Empezar_Dezplazaminetos(game);  //vuelve a llamar all metodo 
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
        System.Console.WriteLine();
        AnsiConsole.Markup($"Tienes  [red]{ficha.Enfriamiento }[/]movimientos ");
        
        int count = ficha.Enfriamiento;
        while (count>0)
        {
            ConsoleKeyInfo info  = Console.ReadKey(true);
            if ( info.Key == ConsoleKey.Escape)
            {
                System.Console.WriteLine("se tecleo escape");
                System.Console.WriteLine("Teclea otra vez si quierer cerrar ");
                break;
        
            }
            //Arriba 
            else if ( info.Key == ConsoleKey.W)
            {
                var result = ficha.move.Movimiento(ficha,Direcciones.Direction.Up);
                System.Console.WriteLine("Arriba");
                if(result)// si es verdadera elmina un movimiento 
                count -=1;
                Console.Clear();
                AnsiConsole.Markup($"Te quedan [red]{count}[/] movimientos  ");
                System.Console.WriteLine();
                Game.Maze.Print();
                
                if( count == 0)
                {   
                    System.Console.WriteLine();
                    System.Console.WriteLine("Se acabaron los movimientos ");
                  //  Turno.Cambio_Turno();
                    break ;
                }
                if(Game.winner.Item1)
                {
                    break;
                }
            }
            //Abajo
            else if( info.Key == ConsoleKey.S)
            {
                var result =ficha.move.Movimiento(ficha,Direcciones.Direction.Down);
                System.Console.WriteLine("Abajo");
                if(result)
                count-=1;
                Console.Clear();
                AnsiConsole.Markup($"Te quedan [red]{count}[/] movimientos  ");
                System.Console.WriteLine();
                Game.Maze.Print();
                
                
                if( count == 0)
                {   
                    System.Console.WriteLine();
                    System.Console.WriteLine("Se acabaron los movimientos ");
                   // Turno.Cambio_Turno();
                    break ;
                }
                if(Game.winner.Item1)
                {
                    break;
                }
            }

            //Izquierda
            else if( info.Key == ConsoleKey.A)
            {
                var result =ficha.move.Movimiento(ficha,Direcciones.Direction.Left);
                System.Console.WriteLine("Izquierda");
                if(result)
                count-=1;
                Console.Clear();

                AnsiConsole.Markup($"Te quedan [red]{count}[/] movimientos  ");
                System.Console.WriteLine();
                Game.Maze.Print();
                
                
                if( count == 0)
                {   
                    System.Console.WriteLine();
                    System.Console.WriteLine("Se acabaron los movimientos ");
                    //Turno.Cambio_Turno();
                    break ;
                }
                if(Game.winner.Item1)
                {
                    break;
                }
                
            }
            //Derecha
            else if ( info.Key == ConsoleKey.D)
            {
                var result = ficha.move.Movimiento(ficha,Direcciones.Direction.Right);
                System.Console.WriteLine("Derecha");

                if(result)
                count -=1;
                Console.Clear();

                AnsiConsole.Markup($"Te quedan [red]{count}[/] movimientos  ");
                System.Console.WriteLine();
                Game.Maze.Print();
                

                if( count == 0)
                {   
                    System.Console.WriteLine();
                    System.Console.WriteLine("Se acabaron los movimientos ");
                    //Turno.Cambio_Turno();
                    break ;
                }
                if(Game.winner.Item1)
                {
                    break;
                }
            }
        }
    
    
    }
    

#endregion


#endregion
}
}