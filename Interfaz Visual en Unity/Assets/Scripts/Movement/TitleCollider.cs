using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TitleCollider : MonoBehaviour
{
    //Lo Usaremos para hacer un collider a un title en especifico 


    public Tilemap tilemap ;
    public TileBase wall;


        void Start(){
            //ActivateCollider();
        }

    public void ActivateCollider()
    {
        //obtiene los limites de las celdas del tilemap
        BoundsInt bounds = tilemap.cellBounds;

        for ( int x = bounds.xMin ; x< bounds.xMax ; x++)
        {
            for ( int y = bounds.yMin ; y< bounds.yMax ; y++)
            {
                Vector3Int actualpos =  new  Vector3Int(x,y,0);
                TileBase tile = tilemap.GetTile(actualpos); // te da el tile q se encuentra  en la pos pasada 
                
                if(tile == wall) // es una pared 
                {
                    //Elimina cualquier flag especial del tile 
                    tilemap.SetTileFlags(actualpos, TileFlags.None);

                    // Configura un colisionador en el tile específico usando la forma del sprite 
                    tilemap.SetColliderType(actualpos, Tile.ColliderType.Sprite);

                }
            }
        }
    }
}
