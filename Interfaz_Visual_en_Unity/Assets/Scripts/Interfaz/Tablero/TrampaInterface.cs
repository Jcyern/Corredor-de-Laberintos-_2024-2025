

using System;
using FICHA;
using Game_Logic.Trampas;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TrampaInterface 
{    
    public GameObject ficha ;
    public Trampa trampa ;
    public Rigidbody2D rb;
    public PlayerMovement pm;

    public (int,int) velocity = (0,0);
    public TrampaInterface (Trampa trampa)
    {
        this.trampa = trampa;
    }
    public  void LoadComponents(GameObject ficha )
    {   
        this.ficha = ficha;
        rb = ficha.GetComponent<Rigidbody2D>();
        pm = ficha.GetComponent<PlayerMovement>();
    }


    public void Activate (GameObject Ficha)
    {
        LoadComponents(Ficha);
        //cargando el objetivo
        trampa.Objetivo(pm.components);
        var ficha = trampa .Activate();

        switch (trampa.Type)
        {
            case TypeTramps.Freeze:
            
                //Se reduce la vlocidad de la ficha 
                Debug.Log("se redujo la velocidad a 0 Freeze Type");
                
                if(ficha != null)
                {
                    pm.velocity = ficha .Velocidad;

                }else
                {
                    Debug.Log("La trampa Freeze ya se ha activado, Cant Acctivate Again");
                }
            break;

            case TypeTramps.LowVelocity:
                if(ficha == null)
                {
                    Debug.Log("Ya se activo la trampa una vez");
                }
                else
                    {
                        pm.velocity = ficha.Velocidad;

                    }
            break;


            case TypeTramps.RandomMove:
                
                Debug.Log("MOver a la ficha a casilla random");
                

                if(ficha != null)
                {
                    Debug.Log($"casilla : {ficha.position.Item1},{ficha.position.Item2}");
                    Transform fila = GameObject.Find("Fila_"+ficha.position.Item1).transform;
                    var casilla = fila.GetChild(ficha.position.Item2);

                    this.ficha.transform.position = casilla.position;
                }
                else{
                    Debug.Log("NO se activa , ya se activo una vez");
                }

            break;

            default:
            throw new Exception("Trampano reconocida ");
        }
        

        


    }

    public void Desactivate()
    {
        //desactivar la trampa .
        var ficha =trampa.Desactivate();
        if(ficha == null)
        throw new Exception("la ficha en desactivate es nula");
        switch (trampa.Type)
        {
            case TypeTramps.Freeze  :
                Debug.Log("Desactiate freeze");
                Debug.Log("Volver a poner la velocidad normal");
                
                pm.velocity= ficha.Velocidad;
                pm.components.Velocidad= ficha.Velocidad;
            break;
            case TypeTramps.LowVelocity:
                Debug.Log(" Desativar Low velocity Tramp");
                pm.velocity = ficha.Velocidad;
                pm.components.Velocidad = ficha.Velocidad;
                break;

            case TypeTramps.RandomMove:
            Debug.Log("Desactivar Random Move ");
            break;


            default:
            throw new Exception("NO se reconoce el tipo de trampa ");
        }
        

    }
}