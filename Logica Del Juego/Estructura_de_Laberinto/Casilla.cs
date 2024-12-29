using System.Collections;
using FICHA;
namespace Case
{
    #region  Casilla

//Constructor de como representar una casilla en el tablero 
public class Casilla
{
    (int, int) Position;

    public int distance { get;set;} 
    public bool IsPared { get; set; }

    //Propiedades de accedo a Columna y Fila 
    public int Fila => Position.Item1;
    public int Columna => Position.Item2;
    public (int, int) Pos => Position;



    public Casilla(int i, int j)
    {
        Position = (i, j);

        IsPared = false;
    }



    //Fichas q se encuentra en esa casilla 
    public List<Ficha> j1 = new ();
    public List<Ficha> j2 = new ();


}
    #endregion
}