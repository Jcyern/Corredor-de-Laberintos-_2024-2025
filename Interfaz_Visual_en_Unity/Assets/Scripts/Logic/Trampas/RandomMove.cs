
using System;
using System.Diagnostics;
using FICHA;
using Game_Logic.Trampas;
using Gammepay;

public class RandomMove : Trampa
{   

    public RandomMove((int,int)pos) : base(pos)
    {   
        position = pos;
        Type = TypeTramps.RandomMove;
    }

    public override Ficha Activate()
    {
        if(Activated == true  )
        {
            Debug.Print("Ya se activo la trampa una vez ");
            return  null;
        }
        else
        {
            //Coger una pos al azar del tablero q no tenga pared y lo cambia para esa position
            var tablero = Game.Maze;
            if( tablero == null)
            {
                throw new Exception(" Tablero de Game es nulo , crea el maze ");
            }

            //Coger una pos random del tablero y ,madarlo hacia alla 

            Random random = new Random();

            int randFila = random.Next(0,tablero.GetLength(0));
            int randColumn = random.Next(0,tablero.GetLength(1));
            while( tablero[randFila,randColumn].IsPared )
            {
                randFila= random.Next(0,tablero.GetLength(0));
                randColumn = random.Next(0,tablero.GetLength(1));
            }
            Activated= true ;
            Target.position = (randFila,randColumn);
            
            return Target ;
        
        }
    }

    public override Ficha Desactivate()
    {
        return copy;
    }
} 