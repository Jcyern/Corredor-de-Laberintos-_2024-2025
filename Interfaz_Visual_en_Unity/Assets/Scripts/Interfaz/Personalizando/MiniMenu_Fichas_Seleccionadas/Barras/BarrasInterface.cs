using System.Collections;
using System.Collections.Generic;
using Gammepay;
using UnityEditor;
using UnityEngine;

public class BarrasInterface : MonoBehaviour
{
    public GameObject[] barras = new GameObject[5];


    public  void CargarInfo()
    {
        var  players = Datos.jugadores;

        var list =players[players.Count].fichas;

        for (int i = 0; i < barras.Length; i++)
        {   
            if(i<list.Count)
            {
                barras[i].GetComponent<barra>().LoadBarra(list[i]);
                barras[i].SetActive(true);
            }

            else
            {
                barras[i].SetActive(false);
            }

        }
    }
}
