using System.Collections;
using System.Collections.Generic;
using Gammepay;
using UnityEngine;
namespace Labenterface
{
public class TableroInterface : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Se guardan las filas del tablero 
    public List<GameObject> Filas = new List<GameObject>();
    
    //Las casillas donde se colocaran las fichas ganadoras , algo asi como un podio 
    public static    List<(Vector2Int,bool)> casillas_de_vicotria = new List<(Vector2Int, bool)>()
    {
        (new Vector2Int(35,-12),false),
        (new Vector2Int(37,-12),false),
        (new Vector2Int(39,-12),false),
        (new Vector2Int(41,-12),false)
    };

    public void LoadLaberintoInterface()
    {   
        Debug.Log("///////////////////////////////////Genrerando maze////////////////////////");

        Game.Generar_Maze(23,34); 
        Debug.Log (" Se creo el maze de 23 x 34 ");
        
        Debug.Log("////////////////// Generating Tramps/////////////////// ");
        Game.Maze.CreateTramps();

        Debug.Log("/////////////// Tramps is ready  ///////////////");



        //ASOCIAMOS LAS CASILLAS CON SUS REPECTIVAS FOTOS , POSICIONES Y COMPONENTES 
        Asociate();
        Debug.Log("se asocio el maze correctamente ");


        //cargamos la escena del laberinto 
        GameObject.Find("Canvas").GetComponent<Escena>().LoadLaberinto();

    }
    
    
    
    
    
    
    
    
    private  void Asociate()
    {
        //Vamos a asociar con el tablero Generado
        var Laberinto = Game.Maze;

        for (int i = 0; i < Filas.Count; i++)
        {

            var fila = Filas[i];
            

            for (int j = 0 ; j<fila.transform.childCount ; j ++)
            {
                //Asociamos las casillas y llamamos Build para activar imagenes y respectivos Collider
                    fila.transform.GetChild(j).GetComponent<CasillaDisplay>().LoadCasillaDisplay( Laberinto[i,j]);  // asociamos casillas por cuestion de comodidad
                    fila.transform.GetChild(j).GetComponent<CasillaDisplay>().LoadImages();
            }
        }
    }
}


}
