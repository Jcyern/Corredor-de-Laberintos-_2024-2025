// See https://aka.ms/new-console-template for more information


using A_Start;

public class Program 
{
    static void Main(string[] args)
    {
        bool [,] lab = new bool[3,4];
        lab[1,0] = true ;

        var list = Algortim_A_Start.EncontrarCamino( new Nodo(0,0), new Nodo(2,0), lab);
        if ( list != null ) 
        foreach ( var item in list)
        {
            System.Console.WriteLine( $"pos {item.Fila}, {item.Columna}");
        }
        
        else
        System.Console.WriteLine("No hay camino ");
    }
}
