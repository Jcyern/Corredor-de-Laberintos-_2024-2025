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
        Debug.Log("cantidad de jugadores"+turno.jugadores.Count );
        turno.Camibio_de_Turno();

        Menu_Seleccion.LoadMenuSeleccion(turno.actual_player.fichas);

        Debug.Log($"tunro de {turno.actual_player.Usuario}");
    }


    




}
