using F1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Final:MonoBehaviour
{
    public GameObject texto_ganador;
    public static TextMeshProUGUI Text;

    void Awake()
    { 
        if(texto_ganador == null) throw new System.Exception("EL gameobject the winner no esta asociado");
        Text = texto_ganador.GetComponent<TextMeshProUGUI>();
    }
    
    public static void  The_Winner_Is ( Player Ganador)
    {
            Text .text = "El Ganador es "+Ganador.Usuario;
    }
}