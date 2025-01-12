using System.Collections;
using System.Collections.Generic;
using FICHA;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Menu_Seleccion : MonoBehaviour
{   
    public static GameObject menu ;
    Transform Fichas;
    private static List<GameObject>files = new ();
    public static Dictionary<int,bool[]> arrays ;

    
    void Awake()
    {   

        //asociando componentes 
        menu = GameObject.Find("Seleccion_de_ficha");
        Fichas = menu.transform.GetChild(0);  // gameobject q contiene las fichas 

        if(Fichas.name != "Fichas")
        {
            throw new System.Exception ("No es el hijo correcto po favor  revisar la asignacion de Fichas ");

        }
        
        foreach ( Transform item in Fichas.transform )
        {    
            files.Add(item.gameObject); //asociar los gameobject fichas 
            Debug.Log(item.name);
        }
        Debug.Log("cantidad de fichas "+files.Count );


            Debug.Log("llamando al menu seleccion");
            LoadMenuSeleccion(TurnoInterface.turno.actual_player.fichas);


    }

//metodos de cargar el menu y  desaxtivarlo 


#region  Activate- Desactivate Menu
    public static void LoadMenuSeleccion(List<Ficha> fichas)
    {
        menu.SetActive(true);

        if(arrays == null)
        {
                arrays= new ();

            for (int i =1  ; i<= Datos.jugadores.Count ; i ++)
            {
                arrays[i]= new bool[Datos.jugadores[i].fichas.Count];
            }
        }
        //asociar las imagenes de las fichas de cada jugador 
        Debug.Log("cap de fichas "+fichas.Count);
        
        for ( int i = 0 ; i <files.Count ; i ++)
        {
            if(i < fichas.Count && arrays[TurnoInterface.turno.player][fichas[i].Colocacion] == false)
            {   Debug.Log($"encendiendo {files[i].name}");
                files[i].SetActive(true);
                files[i].GetComponent<Ficha_Select>().Load(fichas[i]);
                
            }
            else{
                Debug.Log("No encendio");
            }

            
        }
        //activar el menu de seleccion para q esger la ficha a mover 
        
    }

    public  static  void DesactivarMenuseleccionn()
    {  
        
        foreach(  var item in files )
        {
            item.SetActive(false);
        }
        menu.SetActive(false);
    }
}


#endregion
