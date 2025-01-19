

using System;
using FICHA;
using Game_Logic.Trampas;
using Gammepay;
using UnityEngine;

public class Freeze : Trampa
{   

    public Freeze((int,int)pos) : base(pos)
    {
        position = pos;
        Type = TypeTramps.Freeze;
    }


    public override Ficha Activate()
    {

        if( Target != null)
        {  
            if(Activated== true )
            return null;

            Activated = true;
            Target.Velocidad = 0;

            return Target;
            
        }
        else
        {
            throw new Exception(" La ficha de subclase Freeze que hereda de trampa ");
        }


    }

    public override Ficha Desactivate()
    {   
        return copy;
    }
}