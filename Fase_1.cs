
using FICHA;
using Spectre;
using Spectre.Console;
using Base_Datos;
using System.Data;
using System.Diagnostics;


namespace F1
{
    public class Selecciones
    {


        public Faction? faction;



        private List<Ficha> total_fichas = new List<Ficha>();

        public List<Ficha> fichas = new List<Ficha>();

        //Seleccionar la Faction 
        public void Select_Faccion(int result)
        {
            faction = new Faction(result);

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



    }
}