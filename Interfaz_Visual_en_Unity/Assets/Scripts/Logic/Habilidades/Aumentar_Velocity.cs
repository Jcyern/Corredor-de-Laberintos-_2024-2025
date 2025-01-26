
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
        if(Activated)
        {  
            //aumenta la velocidad en 5
            ficha.Velocidad += 5;
        }
    }

    public override void Desactivate()
    {
        if(Activated)
        {
            //volver a poner bien la velocidad 
            ficha.Velocidad = copy.Velocidad;

            Activated = false ; 
        }

    }
}