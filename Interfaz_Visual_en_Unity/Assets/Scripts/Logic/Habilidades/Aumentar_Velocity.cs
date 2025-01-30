
using System.Diagnostics;
using EnumHab;
using FICHA;

public class Aumentar_velocity : Hability
{
    public Aumentar_velocity(Ficha ficha) : base(ficha)
    {
        Name = EnumHability.Aumentar_Velocity;
    }

    public override void Activate()
    {
        
        Activated = true ;
        //aumenta la velocidad en 5
        ficha.Velocidad += 5;
        
    }

    public override void Desactivate()
    {
            //volver a poner la velocidad  actual de la ficha 
            ficha.Velocidad = copy.Velocidad;

            Activated = false ; 
    }
}