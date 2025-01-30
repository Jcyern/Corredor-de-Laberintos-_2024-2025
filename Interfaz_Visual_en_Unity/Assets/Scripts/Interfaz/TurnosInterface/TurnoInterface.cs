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
    public   static Turno turno ;

    public   Player actual;
    public   int  number ;

    public GameObject menu_seleccion ;

    
    public  static void LoadTurno ( Dictionary<int,Player> jugadores)
    {
        turno = new Turno(jugadores);
        


    }

    public static void Camibio_de_Turno()
    {   
        //aumentar el enfriamiento de las habilidades
        var dic = Datos.jugadores;
    
            if(turno.actual_player.Numero ==dic.Count)// eso pasaria si paso una ronda completa
            {
                Debug.Log("Aumentando el tiempo de las variaciones ");
                for(int j  = 1 ; j<=dic.Count; j ++)
                { 
                    //recorre todas la fichas de cada jugador y aumnetar una la variacion 
                    foreach( var item in dic[j].fichas)
                    {   
                        //aumentar el tiempo de espera de la habilidad 
                        if(item.Hability.variacion != item.Enfriamiento) //por eliminar casos y aumentar la velocidad 
                        item.Hability.Variacion();

                        Debug.Log($"item {item.Name}-- Variacion : {item.Hability.variacion}");
                    }
                }
            }
        


        Debug.Log("cantidad de jugadores"+turno.jugadores.Count );
        turno.Camibio_de_Turno();

        Menu_Seleccion.LoadMenuSeleccion(turno.actual_player.fichas);

        Debug.Log($"tunro de {turno.actual_player.Usuario}");
    }


    




}
