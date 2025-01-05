using System.Collections;
using System.Collections.Generic;
using FICHA;
using Gammepay;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{  
    public Image Character ;
    public TextMeshProUGUI nombre ;
    public TextMeshProUGUI velocidad;

    public TextMeshProUGUI habilidad;

    public TextMeshProUGUI enfriamiento;

    public  Sprite[]sprites = new Sprite[4];
    public Image fondo ;

    public Ficha ficha ;


    public void Load(Ficha ficha)
    {
        this.ficha = ficha ;
        nombre.text = "Nombre : "+ficha.Name;
        velocidad.text= "Velocidad : "+ficha.Velocidad;
        habilidad.text= "Habilidad : "+ficha.Hability;
        enfriamiento.text ="Enfriamiento : "+ficha.Enfriamiento;



        fondo.sprite = sprites[ficha.Faction.id-1];

        Character.sprite = GameObject.Find("Canvas").GetComponent<ImagenesCharacters>().GetImage(ficha);
    }


    public void Choose ()  //se selecciona la ficha 
    {
        var dic =GameObject.Find("Canvas").GetComponent<Datos>().jugadores;
        
        if(dic[dic.Count].fichas.Count <5)
        {  
            
            
            dic[dic.Count].fichas.Add(ficha);
            Debug.Log($"Se agrego la ficha {ficha.Name}");

            //si tiene al menos 3 cartas actica el terminar
            if(dic[dic.Count].fichas.Count>=3)GameObject.Find("Flechas").GetComponent<PaginasInterface>().terminar.SetActive(true);
        }
        else
        {
            Debug.Log("NO se puede agregar mas fichas , la lista tiene el max ");
        }
    }
}
