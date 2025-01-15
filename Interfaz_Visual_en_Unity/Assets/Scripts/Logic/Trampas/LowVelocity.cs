

using System;
using System.Diagnostics;
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
        
            return(2,ficha.Velocidad);

        

        }
        else{
            throw new Exception ( "La ficha esta en null");
        }
    }

    public override void Desactivate()
    {
        
    }
}