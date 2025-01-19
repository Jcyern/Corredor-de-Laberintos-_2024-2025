using System.Collections;
using System.Collections.Generic;
using FICHA;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class barra : MonoBehaviour
{
    public Image Character;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Velocidad;
    public TextMeshProUGUI Habilidad;
    public TextMeshProUGUI Enfriamineto;

    public Ficha ficha ;

    
    public void LoadBarra(Ficha ficha )
    {
        var dic =GameObject.Find("Canvas").GetComponent<ImagenesCharacters>().imagenes;
        if(dic == null)throw new System.Exception ("NOse cargo el diccionario");
        Character.sprite = dic[ficha.Faction.id][ficha.Name];
        Name.text = "Nombre : "+ficha.Name;
        Velocidad.text = "Velocidad : "+ficha.Velocidad;
        Habilidad.text = "Habilidad : "+ficha.Hability;
        Enfriamineto.text ="Enfrimiento : "+ficha.Enfriamiento;

        this.ficha = ficha ;
    }


    public void DeleteFicha()
    {
        Mouse.Audio_Click();
        var dic =Datos.jugadores;
        
        dic[dic.Count].fichas.Remove(ficha);

        if(dic[dic.Count].fichas.Count <3  )GameObject.Find("Flechas").GetComponent<PaginasInterface>().terminar.SetActive(false);
        //desactivar el boton comenzar
        
        gameObject.SetActive(false);
    }



}
