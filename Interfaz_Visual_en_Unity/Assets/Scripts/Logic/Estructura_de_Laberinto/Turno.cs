using F1;
using Gammepay;
using Faccion;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using FICHA;
namespace Turnos
{
    public   class Turno 
    {   
        public static bool turno = true ;
        public static Dictionary<int,List<Ficha>> players_list =  new  Dictionary<int, List<Ficha>>();


        public static void Cambio_De_Turno()
        {
            if (turno  )
            {
                turno = false ;
                System.Console.WriteLine("Turno del Jugador 2");
            }
            else
            {
                turno = true ;
                System.Console.WriteLine("Turno del Jugador 1");
            }
        }


        public static  List<Ficha> GetFichas()
        {
            if( turno )
            {
                if(players_list[1]== null)
                {
                    throw new Exception( "La lista del jugador 1 no han sido asociadas ");
                }

                else{
                    return players_list[1];
                }
            }

            else
            {
                if(players_list[2]== null)
                {
                    throw new Exception("La lista del jugador 2 no han sido asociadas ");
                }

                else 
                {
                    return players_list[2];
                }
            }
        }
    }

    
};