
using FICHA;
using Spectre;
using Spectre.Console;
using Base_Datos;
using System.Data;
using System.Diagnostics;
using Faccion;


namespace F1
{
    public class Player
    {

        public string Usuario;
        public Faction? faction;

        public List<Ficha> fichas = new List<Ficha>();
        private List<Ficha> total_fichas = new List<Ficha>();



        public Player(string name, Faction faction)
        {
            Usuario = name;
            this.faction = faction;

        }

        //Seleccionar la Faction 
        public void Select_Faccion(int result)
        {
            faction = new Faction(result);
            Debug.Print(faction.name.ToString());

            System.Console.WriteLine($"La Faction escogida es {faction.id} ");

            //Cargando las fichas disponibles de esa faccion , q se encuentran en la base de datos 
            LoadFichas();
        }


        public void Select_Fichas(int n)
        {
            if (n < total_fichas.Count && n >= 0)
            {
                fichas.Add(total_fichas[n]);
                Debug.Print($"Add {total_fichas[n].Name} ");
            }
        }
        private void LoadFichas()
        {
            if (faction != null)
                total_fichas = SQlite.instancia.GetFichas(faction.id);
            else
                throw new Exception(" aun no se ha escogido faccion");
        }


        public void Print_Fichas()
        {
            AnsiConsole.Markup($"[{Color.Cyan2}]Fichas Disponibles : [/]");
            System.Console.WriteLine();
            int count = 0;
            foreach (var item in total_fichas)
            {
                count++;
                AnsiConsole.Markup($"[{Color.BlueViolet}]  #{count} Nombre: {item.Name} Velocidad: {item.Velocidad} Enfriamineto: {item.Enfriamiento}    [/]");
                System.Console.WriteLine();
            }
        }

        public void Add(int n)
        {
            fichas.Add(total_fichas[n - 1]);
        }

    }
}