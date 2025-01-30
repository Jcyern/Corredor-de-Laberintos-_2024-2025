using EnumHab;
using FICHA;
public class Hability 
{
    public int variacion ;
    public int enfriamineto;

    public bool Activated ;
    
    public   EnumHability Name ;

    public Ficha ficha;
    public Ficha copy ;

    public string Nombre => Name.ToString();

    public Hability ( Ficha ficha  )
    {
        this.ficha= ficha ;
        copy = new Ficha(ficha); // creando otra instancia para q no se mezcle a la hora de los cambios
        variacion =0 ;
        enfriamineto = ficha.Enfriamiento;
        Name = EnumHability.None;
    }


    public virtual void Activate()
    {
    }

    public virtual  void Desactivate()
    {
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