using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile.../animated Tile", fileName = "New Animated Tile")]
public class AnimatedTile : TileBase
{
    public Sprite[] sprites;
    // Start is called before the first frame update
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if(sprites != null && sprites.Length > 0)
        {
            tileData.sprite = sprites[0];
        }
    }

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        if(sprites.Length > 0)
        {
            tileAnimationData.animatedSprites = sprites;
            tileAnimationData.animationSpeed = 5;
            tileAnimationData.animationStartTime = 0;
            return true;
        }

        return false;
    }
}
