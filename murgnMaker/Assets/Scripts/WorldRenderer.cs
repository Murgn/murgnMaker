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
        Enemy,
        Key,
        Exit,
        Cursor,
    }
    
    public class WorldRenderer : Singleton<WorldRenderer>
	{
        public TileBase[] tiles;
        [SerializeField] private Tilemap floorTilemap;
        [SerializeField] private Tilemap wallTilemap;
        [SerializeField] private Tilemap entityTilemap;

        private World world;

        private new void Awake()
        {
            world = World.instance;
        }
        
        private void OnEnable()
        {
            EventManager.DoMapReset += ResetMap;
            EventManager.DoMapResetWalls += ResetWalls;
            EventManager.DoMapRead += ReadMap;
            EventManager.DoMapResetAndRead += ResetAndReadMap;
            EventManager.GenerateWalls += GenerateWalls;
        }

        private void OnDisable()
        {
            EventManager.DoMapReset -= ResetMap;
            EventManager.DoMapResetWalls -= ResetWalls;
            EventManager.DoMapRead -= ReadMap;
            EventManager.DoMapResetAndRead -= ResetAndReadMap;
            EventManager.GenerateWalls -= GenerateWalls;
        }

        private void ResetAndReadMap()
        {
            ResetMap();
            ReadMap();
        }

        private void ResetMap()
        {
            // Resets the Tilemap
            for (int x = 1; x < world.width; x++)
            {
                for (int y = 1; y < world.height; y++)
                {
                    floorTilemap.SetTile(new Vector3Int(x, y), null);
                    wallTilemap.SetTile(new Vector3Int(x, y), null);
                    entityTilemap.SetTile(new Vector3Int(x, y), null);
                }
            }
        }

        private void ResetWalls()
        {
            // Resets the Walls
            for (int x = -1; x <= world.width; x++)
            {
                for (int y = -1; y <= world.height; y++)
                {
                    floorTilemap.SetTile(new Vector3Int(x, y), null);
                    wallTilemap.SetTile(new Vector3Int(x, y), null);
                }
            }
        }

        private void GenerateWalls()
        {
            // Generates Walls
            for (int x = -1; x <= world.width; x++)
            {
                SetValue((int)Tiles.Wall, x, -1);
                SetValue((int)Tiles.Wall, x, world.height);
            }
            
            for (int y = 0; y < world.height; y++)
            {
                SetValue((int)Tiles.Wall, -1, y);
                SetValue((int)Tiles.Wall, world.width, y);
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
                    entityTilemap.SetTile(new Vector3Int(x, y), null);
                    break;

                case (int)Tiles.Wall:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    wallTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Wall]);
                    break;

                case (int)Tiles.Player:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    entityTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Player]);
                    break;
                
                case (int)Tiles.Enemy:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    entityTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Enemy]);
                    break;
                
                case (int)Tiles.Key:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    entityTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Key]);
                    break;
                
                case (int)Tiles.Exit:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Floor]);
                    entityTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Exit]);
                    break;
            }
        }
    }   
}