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
        public Player actual_player;
        public int player ;
    

        public Dictionary<int,Player> jugadores = new ();

        public Turno(Dictionary<int,Player> jugadores)
        { 
            
            this.jugadores = jugadores;
            player = 1;
            actual_player = jugadores[player];
        }

        public void Camibio_de_Turno()
        {
            if(player+1>jugadores.Count)
            {

                //si es mayor q la cantidad de jugadores , ponlo en uno otra vez
                player=1;
            }
            else
            player+=1;


            actual_player = jugadores[player];
            
        }


    }

    
};