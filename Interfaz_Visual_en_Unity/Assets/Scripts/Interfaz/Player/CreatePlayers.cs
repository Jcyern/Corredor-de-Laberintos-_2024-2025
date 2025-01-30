using System.Collections;
using System.Collections.Generic;
using F1;
using FICHA;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{
    public GameObject prefab;

    


    public void CreatePlayer((Ficha ficha,int player, int pos) dupla , Transform padre  )
    {   
        Debug.Log($"{prefab.transform.position.x}, {prefab.transform.position.y}, {prefab.transform.position.z}");
       // Debug.Log($"{position.x}, {position.y}, {position.z}");

        //Quaternion.identify es la rotacion por defecto , se mantiene sin rotar

        GameObject nuevoPlayer = Instantiate(prefab,prefab.transform.position,Quaternion.identity,padre);

        dupla.ficha.Colocacion = dupla.pos;
        nuevoPlayer.GetComponent<PlayerMovement>().LoadFicha(dupla);
        nuevoPlayer.GetComponent<Collider2D>().isTrigger = true ;
        nuevoPlayer.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Canvas").GetComponent<ImagenesCharacters>().imagenes[dupla.ficha.Faction.id][dupla.ficha.Name];
        //encender el objeto 

        nuevoPlayer.SetActive(false);
        //agregrlo al diccionario de datos de GameObject players
        //Junto con su posicion 
        // if(Datos.Player[dupla.player]== null)
        // {
        //     //activando la lista 
        //     Datos.Player[dupla.player]= new List<(GameObject playe,int pos)>();
        // }
        // Datos.Player[dupla.player].Add((nuevoPlayer,dupla.pos));

        
        

    }
}
