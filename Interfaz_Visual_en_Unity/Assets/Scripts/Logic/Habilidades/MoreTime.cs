
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using FICHA;

public class MoreTime : Hability
{
    public MoreTime(Ficha ficha) : base(ficha)
    {
        Name = EnumHab.EnumHability.MoreTime;
    }


    public override void Activate()
    {
            Activated= true ;
            //se le suman 6 segudos de movimineto a la ficha 
            ficha.Seconds += 6;
        
    }

    public override void Desactivate()
    {

            ficha.Seconds = copy.Seconds;
            variacion =0;
            Activated = false ;
        
    }
}