using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using DiccionarioPo;
using Gammepay;
using System.Runtime.ConstrainedExecution;
public class PlayerMovement : MonoBehaviour
{
    //Este script se encargara del movimiento del jugador  
    
    [SerializeField] int velocity =5;
    private Vector2 movement ;
    private Rigidbody2D rb;

    public Tilemap tilemap;
    public TileBase wall ;

    //posicion de la salida final


    void Awake()
    {
        //se le asigna al componente q se encuentra en el objeto 
        rb = GetComponent<Rigidbody2D>();
        

    }
    void Start()
    {
        rb.position = new Vector2(23,-9);
    }

    void Update()
    {
        if(Game.final_pos !=(0,0)  && rb.position == new Vector2(Game.final_pos.Item1,Game.final_pos.Item2 ))
        {
            Debug.Log("Llego a la metaaa    !!!!!!!!!!!!!!!!");
        }
    }





    private void OnMovement(InputValue value)  //se activara cuando se activen uno de los  botones referencias para el movimiento ( W,A,S,D)
    {
        //Se pasa un input value para saber en q direccion y en q eje se esta presionando 

        movement = value.Get<Vector2>();  // le asigna el valor del vector
    }

    
    private void FixedUpdate()
    {
        //se le pasa el valor del movimiento al rigidbody  
        // El metodo MovePosition se encarga de mover el rigidbody a una posicion dada,
        // en este caso se le pasa la posicion actual del rigidbody mas el vector de movimiento 
        // multiplicado por el tiempo pasado desde la ultima vez que se llamo este metodo (fixedDeltaTime)
        // esto es para que el movimiento sea independiente de la velocidad de la maquina
        // y que el objeto se mueva a una velocidad constante en cualquier maquina
        
        rb.MovePosition(rb.position + movement *  velocity * Time.fixedDeltaTime);
        
    
    }

    // private void OnCollisionEnter2D (Collision2D collision)
    // {
    //     //Itera sobre los puntos de contacto de la colision 
    //     foreach ( ContactPoint2D point in collision.contacts)
    //     {
    //         { Vector3Int cellPosition = tilemap.WorldToCell(point.point);
    //         TileBase tile = tilemap.GetTile(cellPosition);

    //         if( tile == wall)
    //         {
    //             Debug.Log("HIT WALL");

    //             rb.velocity = Vector2.zero; //Detener velocidad 

    //             //collisionSound.Play(); // Reproducir el sonido de colisión
    //         }
    //     }
        

    // }
    
}



