using FICHA;
public class Hability 
{
    public int variacion ;
    public int enfriamineto;

    public bool Activated ;
    
    public string Name ;

    public Ficha ficha;
    public Ficha copy ;

    public Hability ( Ficha ficha  )
    {
        this.ficha= ficha ;
        copy = new Ficha(ficha);
        variacion =0 ;
        enfriamineto = ficha.Enfriamiento;
        Name = "";
    }


    public virtual void Activate()
    {
    }

    public virtual  void Desactivate()
    {
    }


    public void On()
    {
        if( enfriamineto== variacion)
        {
            Activated = true ;
        }
        else
        {
            System.Console.WriteLine($"Variacion {variacion} != Enfriamiento {enfriamineto}");
        }
    }

    public void Variacion()
    {
        if(variacion!= enfriamineto)
        {
            variacion+= 1;
        }
        else
        {
            System.Console.WriteLine("Variacion == Enfriamiento");
            System.Console.WriteLine("You can activated Hability ");
        }
    }
}