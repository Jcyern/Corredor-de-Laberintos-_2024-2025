using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cruz : MonoBehaviour
{
    public GameObject scene ;



    public void Cerrar ()
    {
        Mouse.Audio_Click();
        scene.SetActive(false);
    }

    public void Abrir ()
    {   
        Mouse.Audio_Click();
        //cargar el info de las fichas seleccionadas
        GetComponent<BarrasInterface>().CargarInfo();
        scene.SetActive(true);
    }
}
