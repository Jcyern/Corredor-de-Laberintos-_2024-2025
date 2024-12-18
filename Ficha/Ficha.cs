using System;
using System.Buffers;
using Direcciones;
using Faccion;


namespace FICHA
{

    public class Ficha
    {
        public int id;
        public string Name;
        public Faction Faction;
        public int Velocidad;
        public int Enfriamiento;
        public string Hability;

        public int Owner;


        public (int,int)position{get;set;}

        public Moves move = new Moves();



        //builder 
        public Ficha(int id, string Name, int Velocidad, int Enfriamiennto, int Faction)
        {

            this.id = id;
            this.Name = Name;
            this.Velocidad = Velocidad;
            this.Enfriamiento = Enfriamiennto;
            this.Faction = new Faction(Faction);
            this.Hability = "";
            position = (0,1);

        }
    }
}
