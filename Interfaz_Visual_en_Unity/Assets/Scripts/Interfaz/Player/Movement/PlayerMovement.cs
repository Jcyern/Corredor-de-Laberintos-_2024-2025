using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Gammepay;
using FICHA;
using System.Runtime.ConstrainedExecution;
public class PlayerMovement : MonoBehaviour
{
    public (int,int)position;
    public InputAction movection;
    //Componentes fichas
    public Ficha components ;
    //visible en el board para identificar las cosas 

    public int  Owner ;
    public int  pos;

    public bool IsSelected;

    public bool Casilla_Origen= true ;

    public int segundos  = 5 ;

    public bool Win;
    public bool is_active ;

    //Propiedades

    public int Velocidad => components.Velocidad;
    public int Enfriamineto => components.Enfriamiento;
    public string Hability => components.Hability;




    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void  LoadFicha( (Ficha ficha, int number, int  pos) dupla )
    {
        components = dupla.ficha ;
        Owner = dupla.number;
        pos= dupla.pos;

        //cambiarle el nombre al gameobject por comodidad 
        gameObject.name = dupla.ficha.Name;

    }


    
    
    //Este script se encargara del movimiento del jugador  
    
    public int velocity =5;
    private Vector2 movement ;
    private Rigidbody2D rb;

    private void OnMovement(InputValue value)  
    {
        
            

            
                if(is_active)
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
        if(is_active)
        rb.MovePosition(rb.position + movement*Time.deltaTime* velocity );
        
    
    }


    public void Activar()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezeRotation;
        movement = Vector2.zero;
        is_active = true ;
        gameObject.GetComponent<Collider2D>().isTrigger = false ;
        gameObject.SetActive(true);

    }

    public void Desactivar()
    { 
        gameObject.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezeAll; //congelar el rigidbody
        movement = Vector2.zero;
        is_active = false ;
        gameObject.SetActive(false);
        gameObject.GetComponent<Collider2D>().isTrigger = false ;
    }









    
    
}



