using System.Collections;
using System.Collections.Generic;
using FICHA;
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


    public void Load(Ficha ficha)
    {
        nombre.text = "Nombre : "+ficha.Name;
        velocidad.text= "Velocidad : "+ficha.Velocidad;
        habilidad.text= "Habilidad : "+ficha.Hability;
        enfriamiento.text ="Enfriamiento : "+ficha.Enfriamiento;

        fondo.sprite = sprites[ficha.Faction.id-1];
    }
}
