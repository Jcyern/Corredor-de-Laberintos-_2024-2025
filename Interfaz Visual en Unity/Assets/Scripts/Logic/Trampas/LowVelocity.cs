

using System;
using Game_Logic.Trampas;
using Gammepay;

public class LowVelocity : Trampa
{
    public LowVelocity((int, int) pos) : base(pos)
    {
        position = pos;
        Type = TypeTramps.LowVelocity;
    }

    public override (int, int) Activate()
    {
        if( ficha!= null)
        {
        
            ficha.Velocidad-= 2 ;

        

        }
        else{
            throw new Exception ( "La ficha esta en null");
        }

        return ((0,0));
    }

    public override void Desactivate()
    {
        if(ficha != null)
        ficha.Velocidad+=2;
    }
}