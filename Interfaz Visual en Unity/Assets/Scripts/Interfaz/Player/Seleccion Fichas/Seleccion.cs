


using System.Collections.Generic;
using FICHA;
using Turnos;
using UnityEngine;
using UnityEngine.UI;

namespace  SELECCION
{
    public class Seleccion  : MonoBehaviour
    {
        Color color ;

        List <Ficha> players = new List<Ficha>();


        public void  ActivarPlayer()
        {   
            
            players = Turno.GetFichas();

            for( int i =0 ;i < players.Count ; i ++)
            {
                var playerObject= GameObject.Find(players[i].Name);
                
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

            for (int i = 0; i < players.Count; i++)
            {
                var playerObject= GameObject.Find(players[i].Name);

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
    }

}