using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Murgn
{
    public enum Tiles: byte
    {
        Floor,
        Wall,
        Player,
        Cursor,
    }
    
    public class WorldRenderer : Singleton<WorldRenderer>
	{
        public TileBase[] tiles;
        [SerializeField] private Tilemap floorTilemap;
        [SerializeField] private Tilemap wallTilemap;
        [SerializeField] private Tilemap playerTilemap;
        
        public Action DoMapReset;
        public Action DoMapRead;
        public Action DoMapResetAndRead;

        private World world;

        private new void Awake()
        {
            world = World.instance;
        }
        
        private void OnEnable()
        {
            DoMapReset += ResetMap;
            DoMapRead += ReadMap;
            DoMapResetAndRead += ResetAndReadMap;
        }

        private void OnDisable()
        {
            DoMapReset -= ResetMap;
            DoMapRead -= ReadMap;
            DoMapResetAndRead -= ResetAndReadMap;
        }

        private void ResetAndReadMap()
        {
            ResetMap();
            ReadMap();
        }

        private void ResetMap()
        {
            // Resets the Tilemap
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    floorTilemap.SetTile(new Vector3Int(x, y), null);
                    wallTilemap.SetTile(new Vector3Int(x, y), null);
                    playerTilemap.SetTile(new Vector3Int(x, y), null);
                }
            }
        }

        private void ReadMap()
        {
            // Reads the map and generates tiles
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    SetValue(world.map[x, y], x, y);
                }
            }
        }
        
        public void SetValue(int value, int x, int y)
        {
            switch(value)
            {
                case (int)Tiles.Floor:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    wallTilemap.SetTile(new Vector3Int(x, y), null);
                    playerTilemap.SetTile(new Vector3Int(x, y), null);
                    break;

                case (int)Tiles.Wall:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    wallTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Wall]);
                    break;

                case (int)Tiles.Player:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    playerTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Player]);
                    break;
            }
        }
    }   
}