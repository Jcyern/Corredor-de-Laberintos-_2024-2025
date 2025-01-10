using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turnos;
using F1;
using UnityEngine.UI;
using FICHA;
using UnityEngine.InputSystem;

public class TurnoInterface : MonoBehaviour
{   
    public List<GameObject> fichas_menu_seleccion;
    private Color color ;
    private  Turno turno ;

    public Player actual;
    public int  number ;

    public GameObject menu_seleccion ;

    
    public void LoadTurno ( Dictionary<int,Player> jugadores)
    {
        turno = new Turno(jugadores);
        actual = turno.actual_player;
        number=1;

    }

    public void Camibio_de_Turno()
    {
        turno.Camibio_de_Turno();
        actual = turno.actual_player;
        number =turno.player;

        LoadMenuSeleccion(actual.fichas);
    }

    public void LoadMenuSeleccion(List<Ficha> fichas)
    {

        //asociar las imagenes de las fichas de cada jugador 
        for ( int i = 0 ; i <fichas_menu_seleccion.Count ; i ++)
        {
            if(i == fichas.Count)
            {
                break;
            }
            fichas_menu_seleccion[i].GetComponent<Ficha_Select>().Load(fichas[i]);

            fichas_menu_seleccion[i].SetActive(true);
        }
        //activar el menu de seleccion para q esger la ficha a mover 
        menu_seleccion.SetActive(true);
    }

    public   void DesactivarMenuseleccionn()
    {  
        
        foreach(  var item in fichas_menu_seleccion )
        {
            item.SetActive(false);
        }
    }




    #region  Activation-Desactivations


        public  static void   ActivarPlayer(GameObject player )
        {   
            player.SetActive(true); //activar el objet
            
             //Activar la action //para recibir las entradas 
            //player.GetComponent<PlayerMovement>().IsSelected = true ;
            player.GetComponent<PlayerMovement>().velocity = 5;
            
            player.GetComponent<Collider2D>().isTrigger = false; //para q pueda chocar con los obstaculos 
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; //congelar solo la rotacion
            //lo demas descongelado para q  pueda dezplazarce 

            Debug.Log($"se activo {player.GetComponent<PlayerMovement>().components.Name}");
        }


        public static void DesactivatePlayer(GameObject player )
        {
            //player.GetComponent<PlayerMovement>().IsSelected= false ;
            player.GetComponent<PlayerMovement>().velocity =  0;
            

            //desactivrarlo , congelar las pos y adems poner el trigger true para q puedan pasar por encima de el 
            
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }

    #endregion
}
