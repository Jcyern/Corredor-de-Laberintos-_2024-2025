using System;

namespace FICHA
{

    public class Ficha
    {
        public int id;
        public string Name;
        public Faction Faction;
        public int Velocidad;
        public int Enfriamiennto;
        public string Hability;



        //builder 
        public Ficha(int id, string Name, int Velocidad, int Enfriamiennto, int Faction)
        {

            this.id = id;
            this.Name = Name;
            this.Velocidad = Velocidad;
            this.Enfriamiennto = Enfriamiennto;
            this.Faction = GetEnum(Faction);
            this.Hability = "";

        }


        public Faction GetEnum(int faction)
        {
            switch (faction)
            {
                case 1:
                    return Faction.Gryffindor;
                case 2:
                    return Faction.Slytherin;
                case 3:
                    return Faction.Ravenclaw;
                case 4:
                    return Faction.Hufflepuff;
                default:
                    throw new Exception(" El numero pasado no corresponde a ninguna Enum Faction");
            }
        }
    }


    //Definiendo un Enum para los tipos de fichas 

    public enum Faction
    {
        Gryffindor,

        Slytherin,

        Ravenclaw,

        Hufflepuff
    }
}
