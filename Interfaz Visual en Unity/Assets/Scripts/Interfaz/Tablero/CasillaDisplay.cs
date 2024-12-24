using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Case;
using UnityEditor.Callbacks;
using Labenterface;

public class CasillaDisplay : MonoBehaviour
{   
    public Sprite pared;

    public Sprite camino;
    public int x;
    public int y;
    public Casilla casilla ;



    void Start( )
    {
        this.GetComponent<Collider2D>().isTrigger = false ;
    }




    public  CasillaDisplay(Casilla casilla)
    {
        x =casilla.Fila;
        y=casilla.Columna;

        this.casilla = casilla;
    }

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
    }

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


    public void Build()
    {
        var SpriteRender_ = GetComponent<SpriteRenderer>();
        if(casilla != null)
        {
            if( casilla.IsPared)
            {
                SpriteRender_.sprite = pared;
                
            }

            else 
            {
                SpriteRender_.sprite = camino;
                GetComponent<Collider2D>().isTrigger= true ;
            }

        }
    }
}
