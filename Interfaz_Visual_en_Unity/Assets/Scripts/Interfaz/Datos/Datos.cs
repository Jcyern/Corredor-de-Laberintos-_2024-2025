using System.Collections;
using System.Collections.Generic;
using F1;
using UnityEngine;
using System;

public class Datos : MonoBehaviour
{ 
    public static  int max_players= 0;
    public static  Dictionary<int ,Player> jugadores = new Dictionary<int, Player>(); 

    
    //me da un el gameobject del player 
    public static Dictionary<int,List<(GameObject objeto ,int pos)>> Player = new  Dictionary<int,List<(GameObject objeto ,int pos)>>();

    void Awake()
    {
        jugadores.Clear();
        Player.Clear();
    }
}
