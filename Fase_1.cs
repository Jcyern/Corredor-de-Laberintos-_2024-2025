
using FICHA;
using Spectre;
using Spectre.Console;
using Base_Datos;
using System.Data;


namespace F1
{
    public class Fase_1
    {

        public static Fase_1 first = new Fase_1();
        public (Faction,int) faction;






        //Seleccionar la Faction 
        public  void Select_Faccion()
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

            switch (Console.ReadLine())
            {
                case "1":
                    faction = (Faction.Gryffindor,1);
                    break;
                case "2":
                    faction = (Faction.Slytherin,2);
                    break;
                case "3":
                    faction = (Faction.Hufflepuff,3);
                    break;
                case "4":
                    faction = (Faction.Ravenclaw,4);
                    break;
                default:
                    throw new Exception(" El  numero pasado no es valido ");

            }

            System.Console.WriteLine($"La Faction escogida es {faction.Item1} ");
        }
    
    
        public  void Select_Fichas()
        {
            System.Console.WriteLine("Las Fichas disponibles a escoger son :;");
            

            //busca las fichas en la base de dato q cumplan con esa Faction 
            var List = SQlite.instancia.GetFichas(faction.Item2);
            int count = 0;
            foreach( var item in List)
            {count ++;
                AnsiConsole.Markup($"[{Color.Aquamarine3}] F_{count} : Name: { item.Name} Velocidad { item.Velocidad} Enfriamiento: {item.Enfriamiento} [/] "
                );
                System.Console.WriteLine();
            }
        }

    }
}