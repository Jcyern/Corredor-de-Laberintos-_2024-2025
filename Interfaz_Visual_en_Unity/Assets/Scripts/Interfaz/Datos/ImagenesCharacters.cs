using System;
using System.Collections;
using System.Collections.Generic;
using FICHA;
using UnityEngine;

public class ImagenesCharacters : MonoBehaviour
{
    public List<Sprite>  Gryffindor = new List<Sprite>();
    public List<Sprite>  Slytherin = new List<Sprite>();
    public List<Sprite>  Hufflepuff = new List<Sprite>();
    public List<Sprite>  Ravenclaw = new List<Sprite>();


    public Dictionary<int,Dictionary<string,Sprite>> imagenes = new Dictionary<int, Dictionary<string, Sprite>>();

    void Start()
    {
        imagenes = DicionarioImagenes();

        Debug.Log( "se cargo as imagenes del diccionario");
    }
    //diccionario de gryffindor 
    public Dictionary<int,Dictionary<string,Sprite>> DicionarioImagenes()
    {
        Dictionary<int,Dictionary<string,Sprite>> diccionario = new();

        Dictionary<string,Sprite> G = new Dictionary<string, Sprite>
        {
            ["Albus_Dumbledore"]= Gryffindor[0],
            ["Harry_Potter"]= Gryffindor[1],
            ["Hermione"]= Gryffindor[2],
            ["Ron_Weasley"]= Gryffindor[3],
            ["Sirius_Black"]= Gryffindor[4]
        };

        diccionario[1]=G;


        Dictionary<string,Sprite> S = new Dictionary<string, Sprite>
        {
            ["Draco_Malfoy"]= Slytherin[0],
            ["Bellatrix_Lestrange"]= Slytherin[1],
            ["Estudiante_Astuto"]= Slytherin[2],
            ["Bruja"]= Slytherin[3],
            ["Baron_Sanguinario"] =Slytherin[4]
        };


        diccionario[2]= S;


        Dictionary<string,Sprite> H = new Dictionary<string, Sprite>
        {
            ["Borracho_de_Matalobos"]= Ravenclaw[0],
            ["Glacius"]= Ravenclaw[1],
            ["Kelpie"]= Ravenclaw[2],
            ["Leo"]= Ravenclaw[3],
            ["Gigante"]= Ravenclaw[4]
        };

            diccionario[3]= H;

        Dictionary<string,Sprite> R = new Dictionary<string, Sprite>
        {
            ["Boggart"]= Hufflepuff[0],
            ["Caballero"]= Hufflepuff[1],
            ["Elfo"] = Hufflepuff[2],
            ["Fluffy"]= Hufflepuff[3],
            ["Gytrash"]= Hufflepuff[4]
        };

        diccionario[4]= R;

        return diccionario;
    }



    public Sprite GetImage ( Ficha ficha )
    {
        Debug.Log(ficha.Faction.id);
        return imagenes[ficha.Faction.id][ficha.Name];
    }
}