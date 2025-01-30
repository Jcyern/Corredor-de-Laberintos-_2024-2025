using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;


public class Reloj : MonoBehaviour
{
    public Timer timer ;
    public int max_de_segundos;

    public TextMeshProUGUI crono ;

    private GameObject Ficha ;

    bool end ;

    bool isPaused = false ;

    double TimeRemaining;
    double TimeElapsed;

    
    



    public void IniciarTimer( GameObject ficha)
    {   //asociar con el gamobject 
        Ficha = ficha ;
        Debug.Log(ficha.name);
        int segundos  = ficha.GetComponent<PlayerMovement>().segundos;
        TimeRemaining = segundos;
        timer = new Timer(1000); 
        max_de_segundos = segundos;
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true; // repite el evento hasta q se apague el reloj 
        timer.Start() ;  //iniciar el temporizador 

        StartCoroutine(Actualizar_Cronometro_Interface(max_de_segundos));
    }

    public IEnumerator Actualizar_Cronometro_Interface(int segundos)
    {   
        
        int segundos_tranurridos = 0;
            while(segundos_tranurridos<segundos)
            {   
                if(end)break; //es necesario terminar la corutina 
                
                if (isPaused) 
                { //esta en pausa no reducir el tiepo de crono.text
                    yield return null; 
                }// Espera hasta que la pausa termine 
                else
                {   //continua reduciendo el tiempo 
                    yield return new  WaitForSeconds(1);//se detiene un segundo y continua la corrutina 
                    segundos_tranurridos++;
                    crono.text = segundos_tranurridos.ToString();

                }
            }
            
            var pm =Ficha.GetComponent<PlayerMovement>();
            //cuando se acabe hacer el cambio de turno 
            if(pm.tramp !=null)
            {
                //desactivando trampa
                pm.tramp.Desactivate();
                Debug.Log("se desactivo la trampa");
                //quitando la trampa almacenada
                pm.tramp = null;
            }
            //desactivar la habilidad en caso de q este activa 
            if(pm.components.Hability.Activated)
            {  Debug.Log($"desavtivar la habilidad{pm.components.Hability.Nombre}");
                pm.components.Hability.Desactivate();
                Debug.Log($"Variacionn =  {pm.components.Hability.variacion}");
                pm.components.Hability.variacion= 0;
                pm.Actualizar(pm.components);
            }
            //desactivar al player 
            pm.Desactivar(); 
            TurnoInterface.Camibio_de_Turno();
            crono.text ="0";
            end = false ;
        
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        if (!isPaused)
        {
            TimeRemaining -= 1000 ; //reduce el tiempo un segundo 

            if(TimeRemaining <=0)
            {
                timer.Stop();
            }
        }
    }


    public void Stop ()
    {
        timer.Stop() ;
        crono.text = "0";
        Debug.Log("Se detuvo el reloj ");
        end = true ;
    }


    public void Pausar()
    {
        isPaused = true ;
    }

    public void Reanudar ()
    {
        isPaused = false;
    }


    public void  Click()
    {
        // if(isPaused )
        // {
        //     Reanudar();
        // }
        // else
        // {   
        //     //sino esta en pausa 
        //     Pausar();
        // }
    }


}

