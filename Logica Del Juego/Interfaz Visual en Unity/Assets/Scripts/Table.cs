



using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Table : MonoBehaviour
{
    public Tilemap tilemap; // Asignar TileMap en el inspector 
    public TileBase pared ; // Tile para pared 

    //Dicionario de posiciones 

    //En este  diccionario asociaremos las pos de corresponden a la s grillas para asignar si tiene pared o es camino 
    //
    private Dictionary<(int,int),(int,int)> TitlePos = new Dictionary<(int, int), (int, int)>()
    {
        [(0,0)]= (-16,9),
        [(0,1)]= (-16,8)

    };




    void Start ()
    {
        Generate_Board();
    }


    public void Generate_Board ( )
    {
        tilemap.SetTile(new Vector3Int(TitlePos[(0,0)].Item1,TitlePos[(0,0)].Item2, 0), pared );
        
        
    }
}