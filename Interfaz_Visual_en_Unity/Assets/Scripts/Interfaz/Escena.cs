using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena : MonoBehaviour
{
    // Start is called before the first frame update
    public static void  Change ( GameObject apagar, GameObject encender)
    {
        apagar.SetActive(false);
        encender.SetActive(true);
    }
}
