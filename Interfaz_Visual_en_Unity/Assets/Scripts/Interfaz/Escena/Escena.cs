using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena : MonoBehaviour
{

    public  GameObject cuadricula_nombre ;

    public   GameObject cuadricula_faccion;

    public   GameObject cuadricula_personajes;

    public   GameObject cuadricula_players;


    public GameObject Personalizando;


    public  GameObject Laberinto ;


    public void  Change ( GameObject apagar, GameObject encender)
    {
        apagar.SetActive(false);
        encender.SetActive(true);
    }


    public  void  Cantidad_Juagadores()
    {
        Change(cuadricula_nombre,cuadricula_players);

    }

    public  void LoadFaccion(bool cant_players = false )
    {
        if(cant_players)
        {
            Change(cuadricula_players, cuadricula_faccion);
        }
        else

        {
            Change(cuadricula_nombre,cuadricula_faccion);
        }
    }

    public  void Load_Select_Personajes()
    {
        Change( cuadricula_faccion,cuadricula_personajes);
    }
    public  void Load_NamesAgain()
    {
        Change(cuadricula_personajes,cuadricula_nombre);
    }


    public void LoadLaberinto ()
    {
        Change (Personalizando,Laberinto);
    }
}
