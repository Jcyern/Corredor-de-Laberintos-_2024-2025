using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turnos;
using F1;
using UnityEngine.UI;

public class TurnoInterface : MonoBehaviour
{
    private Color color ;
    private  Turno turno ;

    public Player actual;

    
    public void LoadTurno ( Dictionary<int,Player> jugadores)
    {
        turno = new Turno(jugadores);
        actual = turno.actual_player;

    }

    public void Camibio_de_Turno()
    {
        turno.Camibio_de_Turno();
        actual = turno.actual_player;
    }




    #region  Activation-Desactivations

    
        public void  ActivarPlayer()
        {   
            

            for( int i =0 ;i <actual.fichas.Count ; i ++)
            {
                var playerObject= GameObject.Find(actual.fichas[i].Name);
                
                if(playerObject != null)
                {
                    color =playerObject.GetComponent<SpriteRenderer>().color;

                    playerObject.GetComponent<SpriteRenderer>().color = Color.red;

                    //hacer q el button pueda recibir los cliks 

                    playerObject.GetComponent<Button>().interactable = true;
                    playerObject.GetComponent<Button>().onClick.AddListener(DesactivatePlayer);
                }
                
            }
        }


        public void DesactivatePlayer()
        {
            gameObject.GetComponent<PlayerMovement>().IsSelected= true ;

            for (int i = 0; i < actual.fichas.Count; i++)
            {
                var playerObject= GameObject.Find(actual.fichas[i].Name);

                if(playerObject != null)
                {
                    
                    playerObject.GetComponent<SpriteRenderer>().color = color ;

                    //Desactivar el Button
                    playerObject.GetComponent<Button>().interactable = false;

                    if(playerObject.GetComponent<PlayerMovement>().IsSelected== true )
                    {
                        //descongerlar para q pueda  moverse el cuerpo 
                        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    }

                    else
                    {
                        //sino es congelar las posiciones 
                        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    }
                }
            

            }

        }

    #endregion
}
