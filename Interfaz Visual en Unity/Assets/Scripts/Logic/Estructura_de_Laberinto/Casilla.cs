using System.Collections.Generic;
using FICHA;
using Game_Logic.Trampas;
namespace Case
{
    #region  Casilla

//Constructor de como representar una casilla en el tablero 
public class Casilla
{
    (int, int) Position;
    public bool IsPared { get; set; }
    
    public bool inicio;
    public bool salida ;

    public Trampa? trampa;

    //Propiedades de accedo a Columna y Fila 
    public int Fila => Position.Item1;
    public int Columna => Position.Item2;
    public (int, int) Pos => Position;



    public Casilla(int i, int j)
    {
        Position = (i, j);

        IsPared = false;

        salida = false ;

        trampa = null;
    }



    //Fichas q se encuentra en esa casilla 
    public List<Ficha> j1 = new ();
    public List<Ficha> j2 = new ();


}
    #endregion


}