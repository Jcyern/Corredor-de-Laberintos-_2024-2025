using System.Collections;
using System.Collections.Generic;
using F1;
using FICHA;
using Unity.VisualScripting;
using UnityEngine;

public class Activate_Hability : MonoBehaviour
{
    public GameObject Player ;
    PlayerMovement pm ;
    Ficha ficha;
    public void LoadHability(Ficha ficha ,int pos, int player )
    {
        this.ficha = ficha;
        //no se puede buscar el objeto pq esta apagado
        //buscar el padre y luego coger la ficha segun su pos 
        var objeto  = GameObject.Find("Jugador_"+player);
        Debug.Log($"es el turno de {objeto.name}");

        //cargando la propiedades de player movement 

        pm = objeto.transform.GetChild(pos).GetComponent<PlayerMovement>();
        Debug.Log("se cargo la fucha "+pm.components.Name);

        
    }   


    public  void Activate()
    {
        
        ficha.Hability.Activate();
        
        //actualizar las propiedades modificadas por la habilidad
        pm.Actualizar(ficha);


        Debug.Log($"Se activo la habilidad_ {ficha.Hability.Nombre}");

        //volver apagar el boton
        gameObject.SetActive(false);
    }
}
