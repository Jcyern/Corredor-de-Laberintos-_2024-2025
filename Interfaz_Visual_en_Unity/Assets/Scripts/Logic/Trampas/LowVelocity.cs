

using System;
using System.Diagnostics;
using FICHA;
using Game_Logic.Trampas;
using Gammepay;

public class LowVelocity : Trampa
{

    public LowVelocity((int,int)pos) : base(pos)
    {   
        position = pos;
        Type = TypeTramps.LowVelocity;
    }

    public override Ficha Activate()
    {
        if( Target!= null )
        {
            if(Activated == false )
            {   
                Activated = true ;
                Target.Velocidad  = Target.Velocidad -1;
                return Target;
            }
            else
            {
                return null;
            }
        }
        else
        {
            throw new Exception ( "La ficha esta en null");
        }
    }

    public override Ficha Desactivate()
    {
        return copy;
    }
}