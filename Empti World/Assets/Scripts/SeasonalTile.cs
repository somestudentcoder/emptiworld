using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

[CreateAssetMenu(fileName = "New Seasonal Tile", menuName = "Tiles/Seasonal Tile")]
public class SeasonalTile : Tile
{
    public Sprite Spring;
    public Sprite Summer;
    public Sprite Fall;
    public Sprite Winter;

    private Sprite newSprite;
 
    public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
    {
        base.GetTileData(location, tileMap, ref tileData);

        if (GameObject.Find("GameManager"))
        {
            //    Get season
            int season = GameObject.Find("GameManager").GetComponent<SeasonScript>().currentSeason;

            switch (season)
            {
                case 0:
                    newSprite = Spring;
                    break;
                case 1:
                    newSprite = Summer;
                    break;
                case 2:
                    newSprite = Fall;
                    break;
                case 3:
                    newSprite = Winter;
                    break;
            }
        }
     
        //    Change Sprite
        tileData.sprite = newSprite;
    }

    [CreateTileFromPalette]
    public static TileBase CreateSeasonalTile(Sprite sprite)
    {
        var seasonalTile = ScriptableObject.CreateInstance<SeasonalTile>();
        seasonalTile.Spring = sprite;
        return seasonalTile;
    }
}