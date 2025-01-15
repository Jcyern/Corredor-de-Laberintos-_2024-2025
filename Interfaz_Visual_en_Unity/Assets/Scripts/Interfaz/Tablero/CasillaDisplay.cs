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
using F1;
using Unity.VisualScripting;

public class CasillaDisplay : MonoBehaviour
{   
    public Sprite pared;

    public Sprite camino;

    public Sprite trampa_sprite ;
    public int x;
    public int y;
    public Casilla casilla ;

    public TrampaInterface trampa;



    

    public  void LoadCasillaDisplay(Casilla casilla)
    {
        x =casilla.Fila;
        y=casilla.Columna;

        this.casilla = casilla;

        if(this.casilla.IsPared == false)
        {   
            //sino es una pared pon para q se pueda pasar por encima de el 
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }

        if(casilla.trampa != null)
        {
            //si existe trampa 
            trampa = new TrampaInterface(casilla.trampa);
        }

    
    }

#region  Logica Trigger
    void OnTriggerEnter2D ( Collider2D  objeto )
    {
        var rb = objeto.GetComponent<Rigidbody2D>();
        var player = objeto.GetComponent<PlayerMovement>();

        //si la casilla es la salida
        if(this.casilla.salida == true)
        {
            Debug.Log("Hay un player en la salida ");
            //parar el timer 
            var  reloj = GameObject.Find("Canvas").GetComponent<Reloj>();
            reloj.Stop();//parar el reloj pq la ficha llego a su fin
            
            Debug.Log("You win");
            //activar la ficha
            objeto.gameObject.SetActive(true);
            

                var list = TableroInterface.casillas_de_vicotria[player.Owner]; //buscar la lista de las posibles casillas de las victoria q corresponda al id del jugador 
                Menu_Seleccion.arrays[player.Owner][player.components.Colocacion]= true; //diciendo en true para q esa ficha no pueda seguir participando 

                //recorremos la lista 
                for( int i = 0 ; i< list.Count ; i ++)
                {
                    if(list[i].Item2== false )//si la pos para poner el objeto no esta ocupada por otra ficha 
                    {   

                        var pos = list[i].Item1;
                        rb.position = list[i].Item1;
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        player.Win = true ;
                        list[i]= new (pos,true);
                        
                        objeto.GetComponent<Collider2D>().isTrigger = true ; //incesario pero por si las moscas 
                        

                        //para congelar el rigidbody en una las pos en la que esta 
                        objeto.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                    
                        break ;
                        //cuando encuetre uno disponible , rompelo
                    }
                }

                //verificar si todas las fichas estan en la meta y es un ganador 
                Winner.Wins(objeto.GetComponent<PlayerMovement>().Owner);
            
        }


        else 
        {   if(casilla.trampa != null)
            {   
                //se para el tiempo del jugador 
                var reloj =GameObject.Find("Canvas").GetComponent<Reloj>();
                reloj.Pausar();
                Debug.Log($"Nos encontramos sobre una trampa del tipo {trampa.trampa.Type}");

                Debug.Log("activar trampa ");
                {  
                    //asociar trampa creada 
                    player.tramp = trampa;
                    
                    //asoiale ell gamobject ficha para someterla a los efectos 
                    player.tramp.ficha = objeto.gameObject;
                    //cargar components 
                    player.tramp.LoadComponents();
                    player.tramp.Activate();
                    
                }
                //se reanuda el tiempo del jugador 
                reloj.Reanudar();
                
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
                SpriteRender_.sprite = trampa_sprite;
            }

            else 
            {
                SpriteRender_.sprite = camino;
                GetComponent<Collider2D>().isTrigger= true ;
            }

        }
    }
}
