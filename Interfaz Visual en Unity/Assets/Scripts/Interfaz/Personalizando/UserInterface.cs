using System.Collections;
using System.Collections.Generic;
using Base_Datos;
using F1;
using Gammepay;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Page;

public class UserInterface : MonoBehaviour
{
    public TMP_InputField nombre ;


    public GameObject cuadricula_nombre ;

    public GameObject cuadricula_faccion;

    public GameObject cuadricula_personajes;


    //imagenes para la el fondo de la seleccion de personajes 
    public   UnityEngine.UI.Image imagen;
    public  Sprite[]  fondo = new Sprite[4];




    private Player jugador  = new ("");

//crear la base de datos 


void Start()
{   Debug.Log("Creando base de datos");
    SQlite.instancia.CreateTable();
    Debug.Log("///////// Is ready //////");
}








#region Ingresar Nombre

    public void Guardar()
    {
        jugador.Usuario = nombre.text;

        Escena.Change(cuadricula_nombre,cuadricula_faccion);
    }


    public void Cancel()
    {
        nombre.text = "";
    }

    #endregion


    #region  Selleccionar Faccion
    public void Select_Faccion(int n)
    {
        jugador.Select_Faccion(n);

        Debug.Log($"La faccion escogida es {jugador.faction.name}");

        Select_Characters();
    }


    #endregion



    private  void Select_Characters()
    {    
        Debug.Log(jugador.faction.id);
        var num = jugador.faction.id -1;
        
        

        PaginasInterface.paginas = new Paginas(jugador.total_fichas);

        Escena.Change(cuadricula_faccion, cuadricula_personajes);
        imagen.sprite = fondo[num];
        
    }


}
