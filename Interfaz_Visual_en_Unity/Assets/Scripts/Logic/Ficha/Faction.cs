

using System;

namespace Faccion
{

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
