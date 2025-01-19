using System;
using System.Collections;
using System.Collections.Generic;
using FICHA;
using Labenterface;
using Turnos;
using UnityEngine;
using UnityEngine.UI;

public class Ficha_Select : MonoBehaviour
{   
    public GameObject Prefact;
    
    static Ficha Ficha ;
    public  static GameObject imagen ;
    public int numero;

    void Start()
    {
    
    }


    public void Click()
    {
        Mouse.Audio_Click();
        string i =TurnoInterface.turno.player.ToString();

        var Go = GameObject.Find("Jugador_"+i);
        var ficha =Go.transform.GetChild(numero);
        if(ficha.GetComponent<PlayerMovement>().Win)
        Debug.Log($"Seleccionaste a {ficha.GetComponent<PlayerMovement>().components.Name}");
        
        if(ficha.GetComponent<PlayerMovement>().Casilla_Origen )
        {
            ficha.transform.position = Prefact.transform.position;
            ficha.GetComponent<PlayerMovement>().position = (0,1);
            ficha.GetComponent<PlayerMovement>().Casilla_Origen= false ;
        }




        ficha.GetComponent<PlayerMovement>().Activar();
        Debug.Log("velocidad de la ficha "+ficha.GetComponent<PlayerMovement>().Velocidad);


        
        //desactivar el menu seleccion 
        Menu_Seleccion.DesactivarMenuseleccionn();
        GameObject.Find("Canvas").GetComponent<Reloj>().IniciarTimer( ficha .gameObject);
        Debug.Log("se acabo el timer");
        


        
    }

    public  void Load (Ficha ficha  )
    {
        Ficha = ficha ;
        
        if(GetComponent<Image>() == null)throw new System.Exception("No Hay component imagen ");
        
        GetComponent<Image>().sprite =  GameObject.Find("Canvas").GetComponent<ImagenesCharacters>().imagenes[ficha.Faction.id][ficha.Name];
    }
}
