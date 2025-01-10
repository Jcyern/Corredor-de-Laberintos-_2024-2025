using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Case;
using UnityEditor.Callbacks;
using Labenterface;
using FICHA;
using System;
using Gammepay;
using SELECCION;
using Game_Logic.Trampas;

public class CasillaDisplay : MonoBehaviour
{   
    public Sprite pared;

    public Sprite camino;

    public Sprite trampa ;
    public int x;
    public int y;
    public Casilla casilla ;

    



    void Start( )
    {
        this.GetComponent<Collider2D>().isTrigger = false ;
    }




    public  void LoadCasillaDisplay(Casilla casilla)
    {
        x =casilla.Fila;
        y=casilla.Columna;

        this.casilla = casilla;
    }

#region  Logica Trigger
    void OnTriggerEnter2D ( Collider2D  objeto )
    {
        if(this.casilla.salida == true)
        {
            Debug.Log("Hay un player en la salida ");
            Debug.Log("You win");

                var rb = objeto.GetComponent<Rigidbody2D>();
                var list = TableroInterface.casillas_de_vicotria;
                for( int i = 0 ; i< list.Count ; i ++)
                {
                    if(list[i].Item2== false )
                    {   
                        var pos = list[i].Item1;
                        rb.position = list[i].Item1;
                        list[i]= new (pos,true);
                        
                        objeto.GetComponent<Collider2D>().isTrigger = true ;
                        

                        //para congelar el rigidbody en una las pos en la que esta 
                        objeto.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                    
                        break ;
                    }
                }
            
        }


        else 
        {   if(casilla.inicio == false)
            {   
                Debug.Log("Hay un objeto en la casilla ");
                if( objeto.CompareTag("Player"))
                {   
                    if(objeto.GetComponent<PlayerMovement>().velocidad>0)
                    {   
                        Debug.Log("Hay un player en la casilla ");
                        objeto.GetComponent<PlayerMovement>().velocidad -=1;
                    }
                    else if ( objeto.GetComponent<PlayerMovement>().velocidad == 0)
                    {
                        Debug.Log ( " el objeto no se puede mover la velocidad esta en cero ");
                        objeto.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                    
                        Debug.Log(" Activar cambio de turno ");
                        GameObject.Find("Canvas").GetComponent<TurnoInterface>().ActivarPlayer();

                    }
                }
            }
            else 
            { 
                Debug.Log(" Esta en la casilla inicio");
            }
        }
            }

#endregion


#region  Collision

    void OnCollisionEnter2D(Collision2D collision )
    {
        if(collision.gameObject.CompareTag("Player"))  // verifica q si lo q esta colisionando es un player 
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            this.GetComponent<AudioSource>().Play();
            if(rb != null)
            {
                //Establecer la velocidad del jugador a 0
                rb.velocity= Vector2.zero;
                Debug.Log("La velocidad se anulo");
            }
            else
            {
                throw new System.Exception("Anade el Componente RigidBody al gameobject");
            }
        }
    }

#endregion


    public void LoadImages()
    {
        var SpriteRender_ = GetComponent<SpriteRenderer>();
        if(casilla != null)
        {
            if( casilla.IsPared)
            {
                SpriteRender_.sprite = pared;
                
            }
            else if (casilla.trampa != null)
            {
                SpriteRender_.sprite = trampa;
            }

            else 
            {
                SpriteRender_.sprite = camino;
                GetComponent<Collider2D>().isTrigger= true ;
            }

        }
    }
}
