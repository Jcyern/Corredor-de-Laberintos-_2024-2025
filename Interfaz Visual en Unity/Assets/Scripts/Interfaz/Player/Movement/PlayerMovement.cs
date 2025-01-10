using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using DiccionarioPo;
using Gammepay;
using FICHA;
using System.Runtime.ConstrainedExecution;
public class PlayerMovement : MonoBehaviour
{
    public InputAction movection;
    //Componentes fichas
    public Ficha components ;
    //visible en el board para identificar las cosas 
    public string Name ;
    public int  velocidad;
    public int  enfriamiento ;

    public bool IsSelected;

    public bool Casilla_Origen= true ;


    public bool is_active ;


    public void  LoadFicha( Ficha ficha  )
    {
        components = ficha ;
        Name = ficha.Name ;
        velocidad = ficha.Velocidad ;
        enfriamiento = ficha.Enfriamiento ;

        //cambiarle el nombre al gameobject por comodidad 
        gameObject.name = ficha.Name;

    }


    

    void Awake( )
    {
        
        rb = GetComponent<Rigidbody2D>();
        movection = GetComponent<PlayerInput>().actions.FindAction("Movement");
        velocidad = components.Velocidad;
        Debug.Log(components.Velocidad);
    }
    
    //Este script se encargara del movimiento del jugador  
    
    public int velocity =5;
    private Vector2 movement ;
    private Rigidbody2D rb;

    private void OnMovement(InputValue value)  //se activara cuando se activen uno de los  botones referencias para el movimiento ( W,A,S,D)
    {
        

            
        
                movement = value.Get<Vector2>(); // le asigna el valor del vector
    
        
    }

    
    public  void FixedUpdate()
    {
        //se le pasa el valor del movimiento al rigidbody  
        // El metodo MovePosition se encarga de mover el rigidbody a una posicion dada,
        // en este caso se le pasa la posicion actual del rigidbody mas el vector de movimiento 
        // multiplicado por el tiempo pasado desde la ultima vez que se llamo este metodo (fixedDeltaTime)
        // esto es para que el movimiento sea independiente de la velocidad de la maquina
        // y que el objeto se mueva a una velocidad constante en cualquier maquina
        
        rb.MovePosition(rb.position + movement *  velocity * Time.fixedDeltaTime);
        
    
    }


    public void Activar()
    {
        movement = Vector2.zero;
        is_active = true ;
        velocidad = components.Velocidad;
        gameObject.GetComponent<Collider2D>().isTrigger = false ;
        gameObject.SetActive(true);

    }

    public void Desactivar()
    {
        movement = Vector2.zero;
        is_active = false ;
        gameObject.SetActive(false);
        gameObject.GetComponent<Collider2D>().isTrigger = false ;
    }









    
    
}



