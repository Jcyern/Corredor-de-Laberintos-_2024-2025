using System.Collections;
using System.Collections.Generic;
using F1;
using Unity.VisualScripting;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public Player ganador;


    private static  bool IsWinner( int player )
    {
        
        foreach ( Transform  item  in GameObject.Find("Jugador_"+player).transform)
        {   
            if(item.GetComponent<PlayerMovement>().Win == false)
            {
                //tiene una ficha q aun no ha llegado a la meta
                Debug.Log("Quedan fichas sin llegar a la meta ");
                return false ;
            }
        }
        return true ;
    }


    public  static void Wins( int player )
    {
        
        if(IsWinner(player))
        {
            Player ganador = TurnoInterface.turno.actual_player;

            Debug.Log("Hay un ganador ");
            //apagaar la escena del laberinto y encender la de la victoria 

            //poner un cambio de escena 
            GameObject.Find("Canvas").GetComponent<Escena>().WinnerScene();
            Final.The_Winner_Is(ganador);
            
        }
    }
}
