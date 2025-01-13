
using FICHA;
using Base_Datos;
using System.Data;
using System.Diagnostics;
using Faccion;
using Gammepay;
using System;
using System.Collections.Generic;


namespace F1
{
    public class Player
    {

        public string Usuario;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public Faction? faction;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public List<Ficha> fichas = new List<Ficha>();

        //fichas de la base de datos // hay q cargarlas 
        public  List<Ficha> total_fichas = new List<Ficha>();

        public  int Numero;





        public Player(string name, Faction faction = null)
        {
            Usuario = name;
            this.faction = faction;

            //agrega el jugador a la lista de jugadores 
           // Game.jugadores.Add(this);

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
                {   
                    total_fichas.Clear();
                    total_fichas = SQlite.instancia.GetFichas(faction.id);
                }
            else
                throw new Exception(" aun no se ha escogido faccion");
        }


        public void Print_Fichas()
        {

            System.Console.WriteLine();
            int count = 0;
            foreach (var item in total_fichas)
            {
                count++;
        
                System.Console.WriteLine();
            }
        }

        public void Add(int n)
        {
            fichas.Add(total_fichas[n - 1]);
        }

    }
}