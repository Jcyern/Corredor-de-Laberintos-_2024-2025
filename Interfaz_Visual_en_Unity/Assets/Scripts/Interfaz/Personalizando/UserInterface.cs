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

    public  GameObject Canvas;

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
    
        Canvas =   GameObject.Find("Canvas");



        //Limpiando diccionario de jugadores
        Datos.jugadores.Clear();
        
    
}








#region Ingresar Nombre

    public void Guardar()
    {
        Mouse.Audio_Click();
        jugador= new Player(nombre.text);

        Cancel();


        var IsAlreadySelected = Datos.jugadores.Count>0;

        if(IsAlreadySelected == false )
        Canvas.GetComponent<Escena>().Cantidad_Juagadores();

        else
        {
            Canvas.GetComponent<Escena>().LoadFaccion();
        }

        
    }


    public void Cancel()
    {
        Mouse.Audio_Click();
        nombre.text = "";
    }

    #endregion

    #region  Cantidad de Jugadores
    public void  CantPLayers (int n)
    {
        Mouse.Audio_Click();
        Datos.max_players =  n;

        Debug.Log(Datos.max_players);


        Canvas.GetComponent<Escena>().LoadFaccion(true);
    }

    #endregion





    #region  Seleccionar Faccion
    public void Select_Faccion(int n)
    {
        Mouse.Audio_Click();
        jugador.Select_Faccion(n);


        Debug.Log($"La faccion escogida es {jugador.faction.name}");

        //Limpiando la lista de cartas 
        if( Flechas.GetComponent<PaginasInterface>().paginas!= null)
        {
            Flechas.GetComponent<PaginasInterface>().paginas.actual.Clear();
        }
        Flechas.GetComponent<PaginasInterface>().paginas = new Paginas(jugador.total_fichas);

        //activar el cmabio de paginas , Y SE ASOCIAN LAS FICHAS 
        Flechas.GetComponent<PaginasInterface>().Next();

        //ahora hace falta asociarlo 




        var dic = Datos.jugadores;
        jugador.Numero = dic.Count+1;
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
        
        
        

        Canvas.GetComponent<Escena>().Load_Select_Personajes();
        imagen.sprite = fondo[num];

        
        
    }


}
