using System.Collections;
using System.Collections.Generic;
using Gammepay;
using Labenterface;
using Unity.Mathematics;
using UnityEngine;

public class Terminar : MonoBehaviour
{   
    public GameObject Fondo_de_Carga;
    public GameObject FlechaIzq;
    public GameObject FlechaDer;
    // Start is called before the first frame update
    public void Finish()
    {
        //primero q nada activar la flecha derecha y desctivar la izquierda
        FlechaIzq.SetActive(false);
        FlechaDer.SetActive(true);

        //revisa si todo el mundo escogio sus fichas y se puede comenzar el juego 



        var GO =GameObject.Find("Canvas").GetComponent<Datos>();
        
        //si la condicion es verdader pasar a la siguiente fase 
        if(GO.jugadores.Count == GO.max_players  )
        {
            
            gameObject.SetActive(false);
            
            //activa el fondo de carga
            Fondo_de_Carga.SetActive(true );

            Debug.Log("Todo  el mundo tiene sus fichas es hora de jugar");

            
            var canvas =  GameObject.Find("Canvas");
            
            //cargar turno 
            canvas.GetComponent<TurnoInterface>().LoadTurno(canvas.GetComponent<Datos>().jugadores);

            //cargar tablero 

            var Laberinto = canvas.GetComponent<Escena>().Laberinto;
            
            var tablero = Laberinto.transform.GetChild(0);// e el primer hijo de laberint0
            
            if(tablero == null)
            {
                throw new System.Exception( "EL tablero no se cargo esta en null ");
            }
            Debug.Log( " Nombre del child de laberinto es " +tablero.name);
            
            
            tablero.GetComponent<TableroInterface>().LoadLaberintoInterface();

            //una vez cargado tablero 
            //toca crear los gamobject de las fichas seleccionadas por casa juagador del diccionario q se encuentra en datos 

            //como esta encendida  el laberinto se puede buscar el Gameobject jugadores que estaba apagado 

            var diccionaro_players = GameObject.Find("Canvas").GetComponent<Datos>().jugadores;
            var jugadores = GameObject.Find("Jugadores").GetComponent<CreatePlayers>();
            for (  int i = 1 ; i <=diccionaro_players.Count; i++)
            {
                //crear las respectivas fichas en la interface 
                foreach (var ficha in diccionaro_players[i].fichas)
                {
                    jugadores.CreatePlayer(ficha);
                    Debug.Log($"se creo el gamobject ficha  {ficha.Name}");
                }
            }

            


            




            //desactivar el fondo de carga 
            Fondo_de_Carga.SetActive(false);

            
            

        }
        else
        {
            //apagar el boton terminar 
            gameObject.SetActive(false);
            
            //Cargar la escena del elegir

            var userinterface =GameObject.Find("Personalizando").GetComponent<UserInterface>();

            GameObject.Find("Canvas").GetComponent<Escena>().Load_NamesAgain();

            



        
        }
    }
}
