using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cruz : MonoBehaviour
{
    public GameObject scene ;



    public void Cerrar ()
    {
        scene.SetActive(false);
    }

    public void Abrir ()
    {   

        //cargar el info de las fichas seleccionadas
        GetComponent<BarrasInterface>().CargarInfo();
        scene.SetActive(true);
    }
}
