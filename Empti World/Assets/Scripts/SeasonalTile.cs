using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.AssetImporters;
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
        int sprite_number = int.Parse(sprite.name.Substring(sprite.name.LastIndexOf('_') + 1));
        Debug.Log("Tileset Summer_" + sprite_number);
        Sprite[] summerTiles = Resources.LoadAll<Sprite>("Tileset Summer");
        Sprite[] fallTiles = Resources.LoadAll<Sprite>("Tileset Fall");
        Sprite[] winterTiles = Resources.LoadAll<Sprite>("Tileset Winter");
        var seasonalTile = ScriptableObject.CreateInstance<SeasonalTile>();
        seasonalTile.Spring = sprite;
        seasonalTile.Summer = summerTiles[sprite_number];
        seasonalTile.Fall = fallTiles[sprite_number];
        seasonalTile.Winter = winterTiles[sprite_number];
        return seasonalTile;
    }
}