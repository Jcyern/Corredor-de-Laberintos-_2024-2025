using System.Collections;
using System.Collections.Generic;
using F1;
using Unity.VisualScripting;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public Player ganador;


    private  bool IsWinner(List<GameObject> fichas )
    {
        
        foreach ( var  item  in fichas)
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


    public  void Wins(List<GameObject> fichas, int player )
    {
        if(IsWinner(fichas))
        {
            ganador = TurnoInterface.turno.actual_player;

            Debug.Log("Hay un ganador ");
            //apagaar la escena del laberinto y encender la de la victoria 

            //poner un cambio de escena 

            
        }
    }
}
