using System;
using System.Buffers;
using Direcciones;
using EnumHab;
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
        public Hability Hability;
        public int Colocacion;

        public int Seconds;

        public bool Win = false ;



        public (int,int)position{get;set;}

        public Moves move = new Moves();


        public Hability CreateHab(Ficha ficha , EnumHability habilidad)
        {
            switch(habilidad)
            {
                case EnumHability.Aumentar_Velocity:
                return new Aumentar_velocity(ficha);

                case EnumHability.AntiTramps:
                return new  AntiTramp(ficha);

                case EnumHability.MoreTime:
                return new MoreTime(ficha);
                
                default:
                throw new Exception( "HABILIDAD NO RECONOCIDA ");
            }
        }
        //builder 
        public Ficha(int id, string Name, int Velocidad, int Enfriamiennto, int Faction , int Seconds, EnumHability Hability)
        {

            this.id = id;
            this.Name = Name;
            this.Velocidad = Velocidad;
            this.Enfriamiento = Enfriamiennto;
            this.Faction = new Faction(Faction);
            position = (0,1);
            this.Seconds = Seconds;
            this.Hability =  CreateHab(this, Hability);

        }

        public Ficha (Ficha ficha )
        {
            id = ficha.id;
            Name = ficha.Name;
            Velocidad = ficha.Velocidad;
            Enfriamiento = ficha.Enfriamiento;
            Faction =ficha.Faction;
            position = ficha.position;
            Seconds = ficha.Seconds;
            Hability = ficha.Hability;
        }
    }
}
