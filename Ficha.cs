using System;
using Direcciones;

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


    //Definiendo un Enum para los tipos de fichas 

    public enum EnumFaction
    {
        Gryffindor,

        Slytherin,

        Ravenclaw,

        Hufflepuff,
        None,
    }

    public class Faction
    {
        public EnumFaction name;
        public int id;


        public Faction(int n)
        {
            switch (n)
            {
                case 0:
                    name = EnumFaction.None;
                    id = 0;
                    break;

                case 1:
                    name = EnumFaction.Gryffindor;
                    id = 1;
                    break;
                case 2:
                    name = EnumFaction.Slytherin;
                    id = 2;
                    break;
                case 3:
                    name = EnumFaction.Hufflepuff;
                    id = 3;
                    break;
                case 4:
                    name = EnumFaction.Ravenclaw;
                    id = 4;
                    break;
                default:
                    throw new Exception(" El  numero pasado no es valido  con ninguna de las facciones disponibles");

            }
        }




    }
}
