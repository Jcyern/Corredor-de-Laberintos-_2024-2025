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
    
    public static    List<(Vector2Int,bool)> casillas_de_vicotria = new List<(Vector2Int, bool)>()
    {
        (new Vector2Int(35,-12),false),
        (new Vector2Int(37,-12),false),
        (new Vector2Int(39,-12),false),
        (new Vector2Int(41,-12),false)
    };

    void Start()
    {
        Game.Generar_Maze(23,34); 
        Debug.Log (" Se creo el maze ");

        Asociate();
    }
    public void Asociate()
    {
        //Vamos a asociar con el tablero Generado
        var Laberinto = Game.Maze;

        for (int i = 0; i < Filas.Count; i++)
        {

            var fila = Filas[i];
            

            for (int j = 0 ; j<fila.transform.childCount ; j ++)
            {
                //Asociamos las casillas y llamamos Build para activar imagenes y respectivos Collider
                    fila.transform.GetChild(j).GetComponent<CasillaDisplay>().casilla = Laberinto[i,j];  // asociamos casillas por cuestion de comodidad
                    fila.transform.GetChild(j).GetComponent<CasillaDisplay>().Build();
            }
        }
    }
}


}
