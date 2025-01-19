
using System.IO.Compression;
using Base_Datos;
using FICHA;

namespace Game_Logic.Trampas
{
    public abstract class Trampa 
    {
        public Ficha Target {get;set;}

        public Ficha copy ;
        public TypeTramps Type ;
        public bool Activated ;
        public (int,int) position;

        public abstract Ficha Activate ();
        
        public abstract Ficha Desactivate();

        public void Objetivo (Ficha ficha)
        {
            Target = ficha;
            copy = new Ficha(SQlite.instancia.GetFicha(ficha.id));
            if(copy== null)
            throw new System.Exception("La coppia es null revisa los metodos ");
        }





        //builder

        public Trampa((int,int)pos )
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