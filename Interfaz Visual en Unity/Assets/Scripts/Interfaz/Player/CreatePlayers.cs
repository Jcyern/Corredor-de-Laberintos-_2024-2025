using System.Collections;
using System.Collections.Generic;
using FICHA;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{
    public GameObject prefab;
    public  Transform parent ;

    

    void Start()
    {
        CreatePlayer(new Ficha(2,"Draco_Malfoy",4,2,2));
    }


    public void CreatePlayer(Ficha ficha )
    {   
    Debug.Log($"{prefab.transform.position.x}, {prefab.transform.position.y}, {prefab.transform.position.z}");
       // Debug.Log($"{position.x}, {position.y}, {position.z}");

        //Quaternion.identify es la rotacion por defecto , se mantiene sin rotar

        GameObject nuevoObjeto = Instantiate(prefab,prefab.transform.position,Quaternion.identity,parent);
        
        nuevoObjeto.GetComponent<PlayerMovement>().LoadFicha(ficha);
        nuevoObjeto.SetActive(true);

        
        

    }
}
