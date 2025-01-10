

using Game_Logic.Trampas;
using Gammepay;

public class Freeze : Trampa
{
    int velocidad;
    public Freeze((int, int) pos) : base(pos)
    {
        position = pos;
        Type = TypeTramps.Freeze;
    }

    public override (int, int) Activate()
    {
        if( ficha != null)
        {
            velocidad=  ficha.Velocidad;
            //hacer cero la velocidad en esa ficha 
            
                ficha.Velocidad = 0;
            
        }
        else{
            throw new Exception(" La ficha de subclase Freeze que hereda de trampa ");
        }

        return ((0,0));
    }

    public override void Desactivate()
    {   
        if(ficha != null)
        ficha.Velocidad = velocidad;
    }
}