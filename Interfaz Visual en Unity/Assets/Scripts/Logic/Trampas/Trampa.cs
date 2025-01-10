
using FICHA;

namespace Game_Logic.Trampas
{
    public abstract class Trampa 
    {
        public Ficha? ficha ;
        public TypeTramps Type ;
        public (int,int) position;

        public abstract (int,int) Activate ();
        
        public abstract void Desactivate();





        //builder

        public Trampa((int,int)pos)
        {
            position = pos;
            Type= TypeTramps.None;

        }
    }



    public enum TypeTramps
    {   
        None,
        Freeze,
        RandomMove,
        LowVelocity,

    }
}