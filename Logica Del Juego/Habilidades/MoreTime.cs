
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
        if(Activated)
        {   
            //se le suman 6 segudos de movimineto a la ficha 
            ficha.Seconds += 6;
        }
        else{
            System.Console.WriteLine("Todavia no se puede activar ");
        }
    }

    public override void Desactivate()
    {
        if(Activated)
        {
            ficha.Seconds = copy.Seconds;
            variacion =0;
            Activated = false ;
        }
    }
}