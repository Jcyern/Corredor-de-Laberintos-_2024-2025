
using EnumHab;
using FICHA;

public class AntiTramp : Hability
{ 


    public AntiTramp(Ficha ficha) : base(ficha)
    {
        Name =EnumHability.AntiTramps;
    }

    public override void Activate()
    {
        //al pasar por una trampa le permitira esquivarla
        Activated= true ;


    }


    public override void Desactivate()
    {

            variacion = 0;
            Activated = false ;
    }
}