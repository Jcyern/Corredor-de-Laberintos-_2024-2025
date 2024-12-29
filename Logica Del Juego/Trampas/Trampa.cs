
using FICHA;

namespace Game_Logic.Trampas
{
    public abstract class Trampa 
    {
        public Ficha? ficha ;
        public (int,int) position;

        public abstract (int,int) Activate ();
        
        public abstract void Desactivate();





        //builder

        public Trampa((int,int)pos)
        {
            position = pos;
        }
    }
}