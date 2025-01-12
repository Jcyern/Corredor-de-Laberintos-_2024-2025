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
    public static Dictionary<int,List<(Vector2Int,bool)>> casillas_de_vicotria ;
    
    //Las casillas donde se colocaran las fichas ganadoras , algo asi como un podio 


    void Diccionario_WinnerPos()
    {
        Dictionary<int,List<(Vector2Int,bool)> >casillas_vicotoria = new ();

        //listas 
        
        List<(Vector2Int,bool)> j1 = new List<(Vector2Int, bool)>()
        {
        (new Vector2Int(727,319),false),
        (new Vector2Int(729,319),false),
        (new Vector2Int(731,319),false),
        (new Vector2Int(733,319),false),
        (new Vector2Int(735,319),false)
        };

        List<(Vector2Int,bool)> j2 = new List<(Vector2Int, bool)>()
        {
        (new Vector2Int(727,317),false),
        (new Vector2Int(729,317),false),
        (new Vector2Int(731,317),false),
        (new Vector2Int(733,317),false),
        (new Vector2Int(735,317),false)
        };
        List<(Vector2Int,bool)> j3 = new List<(Vector2Int, bool)>()
        {
        (new Vector2Int(727,315),false),
        (new Vector2Int(729,315),false),
        (new Vector2Int(731,315),false),
        (new Vector2Int(733,315),false),
        (new Vector2Int(735,315),false)
        };
        List<(Vector2Int,bool)> j4 = new List<(Vector2Int, bool)>()
        {
        (new Vector2Int(727,313),false),
        (new Vector2Int(729,313),false),
        (new Vector2Int(731,313),false),
        (new Vector2Int(733,313),false),
        (new Vector2Int(735,313),false)
        };

        
    
        casillas_vicotoria[1]=j1;
        casillas_vicotoria[2]=j2;
        casillas_vicotoria[3]=j3;
        casillas_vicotoria[4]=j4;


        casillas_de_vicotria = casillas_vicotoria;;
    }
    

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

        //inicializar el diccionario
        Diccionario_WinnerPos();

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
