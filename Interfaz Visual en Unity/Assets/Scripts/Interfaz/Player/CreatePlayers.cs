using System.Collections;
using System.Collections.Generic;
using FICHA;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{
    public GameObject prefab;
    public  Transform parent ;

    


    public void CreatePlayer(Ficha ficha )
    {   
    Debug.Log($"{prefab.transform.position.x}, {prefab.transform.position.y}, {prefab.transform.position.z}");
       // Debug.Log($"{position.x}, {position.y}, {position.z}");

        //Quaternion.identify es la rotacion por defecto , se mantiene sin rotar

        GameObject nuevoPlayer = Instantiate(prefab,prefab.transform.position,Quaternion.identity,parent);

        
        nuevoPlayer.GetComponent<PlayerMovement>().LoadFicha(ficha);
        nuevoPlayer.GetComponent<Collider2D>().isTrigger = true ;
        nuevoPlayer.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Canvas").GetComponent<ImagenesCharacters>().imagenes[ficha.Faction.id][ficha.Name];

        //encender el objeto 

        nuevoPlayer.SetActive(true);

        
        

    }
}
