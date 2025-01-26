
using EnumHab;
using FICHA;

public class AntiTramp : Hability
{ 
    bool anti_tramp ;

    public AntiTramp(Ficha ficha) : base(ficha)
    {
        Name =EnumHability.AntiTramps;
    }

    public override void Activate()
    {
        if(Activated)
        anti_tramp = true ;

        else{
            System.Console.WriteLine("aun no se puede activar la trampa");
        }
    }


    public override void Desactivate()
    {
        if(Activated)
        {
            anti_tramp = false ;
            variacion = 0;
            Activated = false ;
        }
    }
}