using UnityEngine;
using UnityEngine.Tilemaps;

namespace Murgn
{
    [System.Serializable]
    public struct TilemapSettings
    {
        public string settingName;
        public Vector2Int tilemapSize;
        public int cameraSize;
    }

    public class WorldManager : MonoBehaviour
	{
        [SerializeField] private int[,] terrainMap;
        [SerializeField] private int selectedSize;

        [NonReorderable] [SerializeField] private TilemapSettings[] tilemapSettings;

        [SerializeField] private Transform tileMapGrid;
        [SerializeField] private Tilemap tileMap;
        [SerializeField] private Tile[] tiles;

        private byte[,] map;

        private int width;
        private int height;

        private Camera cameraMain;

        private void Start()
        {
            cameraMain = Camera.main;
        }

        private void FixedUpdate()
        {
	    // i need to reset the tiles whenever i swap the selectedSize

            map = new byte[tilemapSettings[selectedSize].tilemapSize.x + 2, tilemapSettings[selectedSize].tilemapSize.y + 2];

            width = map.GetLength(0);
            height = map.GetLength(1);

            Vector2 offset = new Vector2((-tilemapSettings[selectedSize].tilemapSize.x - 2) / 2.0f, (-tilemapSettings[selectedSize].tilemapSize.y - 2) / 2.0f);
            tileMapGrid.position = offset;

            cameraMain.orthographicSize = tilemapSettings[selectedSize].cameraSize;

            // Generates Walls
            for (int x = 0; x < width; x++)
            {
                map.SetValue((byte)1, x, 0);
                map.SetValue((byte)1, x, height - 1);
            }

            for (int y = 0; y < height; y++)
            {
                map.SetValue((byte)1, 0, y);
                map.SetValue((byte)1, width - 1, y);
            }

            // Reads the map and generates tiles
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch(map[x, y])
                    {
                        case 0:
                            tileMap.SetTile(new Vector3Int(x, y), tiles[0]);
                            break;

                        case 1:
                            tileMap.SetTile(new Vector3Int(x, y), tiles[1]);
                            break;

                        case 2:
                            tileMap.SetTile(new Vector3Int(x, y), tiles[2]);
                            break;
                    }
                }
            }
        }
    }
}   
