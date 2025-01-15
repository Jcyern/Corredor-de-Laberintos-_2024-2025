

using System;
using FICHA;
using Game_Logic.Trampas;
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
    public void LoadComponents()
    {
        rb = ficha.GetComponent<Rigidbody2D>();
        pm = ficha.GetComponent<PlayerMovement>();
    }

    public void Activate ()
    {
        trampa.ficha = ficha.GetComponent<PlayerMovement>().components;
        //asocia la ficha q callo en la trampa

        if(trampa.Type ==  TypeTramps.Freeze)
        {
            //Se reduce la vlocidad de la ficha 
            Debug.Log("se redujo la velocidad a 0 Freeze Type");
            velocity = trampa.Activate();
            if(velocity!=(0,0))
            pm.velocity = velocity.Item1;
            else{
                Debug.Log("La trampa Freeze ya se ha activado, Cant Acctivate Again");
            }

        }

        else if( trampa.Type == TypeTramps.LowVelocity)
        {
            Debug.Log("reducir en 2 la velocidad");
            velocity =trampa.Activate();

            pm.velocity -=velocity.Item1;

        }

        else if (trampa.Type == TypeTramps.RandomMove)
        {
            Debug.Log("MOver a la ficha a casilla random");
            var pos = trampa.Activate();
            Debug.Log($"casilla : {pos.Item1},{pos.Item2}");
            if(pos != (0,0))
            {
                Transform fila = GameObject.Find("Fila_"+pos.Item1).transform;
                var casilla = fila.GetChild(pos.Item2);
                

                var Game_player = GameObject.Find(trampa.ficha.Name
                );
                
                Game_player.transform.position = casilla.position;
            }
            else{
                Debug.Log("no Se activa pq el random move se activo una vez");
            }
        }


    }

    public void Desactivate()
    {
        if(trampa.Type == TypeTramps.Freeze)
        {

            Debug.Log("Desactiate freeze");
            Debug.Log("Volver a poner la velocidad normal");
            trampa.Desactivate();
            pm.velocity= pm.components.Velocidad;
        }

        else if( trampa.Type == TypeTramps.LowVelocity)
        {
            Debug.Log("LOw velocity Tramp");
            Debug.Log("Se reduce la velocidad");
            trampa.Desactivate();
            Debug.Log("se volvio a la velocidad inicial");

            //volver a poner la velocidad inicial

            pm.velocity = pm.components.Velocidad;
        }
        else if ( trampa.Type == TypeTramps.RandomMove)
        {
            Debug.Log("Trampa de Randon Move");

            trampa.Desactivate();
        }

        
    }
}