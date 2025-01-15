

using System;
using Game_Logic.Trampas;
using Gammepay;

public class Freeze : Trampa
{   
    bool Activated ;
    int velocidad;
    public Freeze((int, int) pos) : base(pos)
    {
        position = pos;
        Type = TypeTramps.Freeze;
    }

    public override (int, int) Activate()
    {

        if( ficha != null)
        {  
            if(Activated== true )
            return (0,0);


            velocidad=  ficha.Velocidad;
            //hacer cero la velocidad en esa ficha 
            Activated = true;
                ficha.Velocidad = 0;

            return(0,velocidad);
            
        }
        else{
            throw new Exception(" La ficha de subclase Freeze que hereda de trampa ");
        }


    }

    public override void Desactivate()
    {   
        if(ficha != null)
        ficha.Velocidad = velocidad;
    }
}