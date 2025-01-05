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

    public GameObject cuadricula_players;

    public GameObject Flechas ;



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
        jugador= new Player(nombre.text);

        Cancel();


        var IsAlreadySelected = GameObject.Find("Canvas").GetComponent<Datos>().jugadores.Count>0;

        if(IsAlreadySelected == false )
        Escena.Change(cuadricula_nombre,cuadricula_players);

        else
        {
            Escena.Change(cuadricula_nombre,cuadricula_faccion);
        }
    }


    public void Cancel()
    {
        nombre.text = "";
    }

    #endregion

    #region  Cantidad de Jugadores
    public void  CantPLayers (int n)
    {
        
        GameObject.Find("Canvas").GetComponent<Datos>().max_players =  n;

        Debug.Log(GameObject.Find("Canvas").GetComponent<Datos>().max_players);


        Escena.Change(cuadricula_players,cuadricula_faccion);
    }

    #endregion





    #region  Selleccionar Faccion
    public void Select_Faccion(int n)
    {
        jugador.Select_Faccion(n);

        Debug.Log($"La faccion escogida es {jugador.faction.name}");

        //Limpiando la lista de cartas 
        if( Flechas.GetComponent<PaginasInterface>().paginas!= null)
        {
            Flechas.GetComponent<PaginasInterface>().paginas.actual.Clear();
        }
        Flechas.GetComponent<PaginasInterface>().paginas = new Paginas(jugador.total_fichas);



        var dic = GameObject.Find("Canvas").GetComponent<Datos>().jugadores;
        dic[dic.Count+1]= jugador;


        Debug.Log("cantidad de jugadores guardados "+dic.Count);
        for (int i = 1 ; i<=dic.Count ; i ++)
        {
            Debug.Log($"player # {i}  {dic[i].Usuario}");
        }
        
        
        Select_Characters();
    }




    #endregion



    private  void Select_Characters()
    {    
        Debug.Log(jugador.faction.id);
        var num = jugador.faction.id -1;
        
        
        
        //agregar a un  nuevo jugador al diccionario 
        
        
        

        Escena.Change(cuadricula_faccion, cuadricula_personajes);
        imagen.sprite = fondo[num];

        
        
    }


}
