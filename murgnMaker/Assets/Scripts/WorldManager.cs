using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

namespace Murgn
{
    [System.Serializable]
    public struct TilemapSettings
    {
        public string settingName;
        public Vector2Int tilemapSize;
        public Vector2Int cameraSize;
    }

    public enum Tiles
    {
        Air,
        Wall,
        Player,
        Cursor,
    }

    public class WorldManager : Singleton<WorldManager>
	{
        [SerializeField] private int selectedSize;
        
        [NonReorderable] [SerializeField] private TilemapSettings[] tilemapSettings;
        
        [SerializeField] private Transform tileMapGrid;
        [SerializeField] private Tilemap floorTilemap;
        [SerializeField] private Tilemap wallTilemap;
        [SerializeField] private Tilemap playerTilemap;
        public TileBase[] tiles;

        public Action<int, int> OnMapGenerate;
        public Action DoMapResetAndRead;
        
        public byte[,] worldMap;

        private int width;
        private int height;

        private Camera cameraMain;

        private void Start()
        {
            cameraMain = Camera.main;
            GenerateMap();

            DoMapResetAndRead?.Invoke();
            CopyMapToClipboard();
        }

        private void OnEnable() => DoMapResetAndRead += ResetAndReadMap;
        private void OnDisable() => DoMapResetAndRead -= ResetAndReadMap;

        private void GenerateMap()
        {
            worldMap = new byte[tilemapSettings[selectedSize].tilemapSize.x + 2, tilemapSettings[selectedSize].tilemapSize.y + 2];

            width = worldMap.GetLength(0);
            height = worldMap.GetLength(1);

            var offset = new Vector2((-tilemapSettings[selectedSize].tilemapSize.x - 2) / 2.0f, (-tilemapSettings[selectedSize].tilemapSize.y - 2) / 2.0f);
            tileMapGrid.position = offset;

            cameraMain.GetComponent<PixelPerfectCamera>().refResolutionX = tilemapSettings[selectedSize].cameraSize.x;
            cameraMain.GetComponent<PixelPerfectCamera>().refResolutionY = tilemapSettings[selectedSize].cameraSize.y;

            // Generates Walls
            for (int x = 0; x < width; x++)
            {
                worldMap.SetValue((byte)Tiles.Wall, x, 0);
                worldMap.SetValue((byte)Tiles.Wall, x, height - 1);
            }

            for (int y = 0; y < height; y++)
            {
                worldMap.SetValue((byte)Tiles.Wall, 0, y);
                worldMap.SetValue((byte)Tiles.Wall, width - 1, y);
            }
            
            OnMapGenerate?.Invoke(width, height);
        }

        private void ResetAndReadMap()
        {
            // Resets the Tilemap
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    floorTilemap.SetTile(new Vector3Int(x, y), null);
                    wallTilemap.SetTile(new Vector3Int(x, y), null);
                    playerTilemap.SetTile(new Vector3Int(x, y), null);
                }
            }
            
            // Reads the map and generates tiles
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    SetMapValues(worldMap[x, y], x, y);
                }
            }
        }

        private void OnGUI()
        {
            
            if (GUI.Button(new Rect(150, 150, 100, 100), "Generate +1"))
            {
                selectedSize++;
                GenerateMap();
                DoMapResetAndRead?.Invoke();
                CopyMapToClipboard();
            }
            
            if (GUI.Button(new Rect(50, 50, 100, 100), "Generate -1"))
            {
                selectedSize--;
                GenerateMap();
                DoMapResetAndRead?.Invoke();
                CopyMapToClipboard();
            }
            
            if (GUI.Button(new Rect(150, 50, 100, 100), "Read"))
            {
                ReadClipboardToMap();
            }
            if (GUI.Button(new Rect(50, 150, 100, 100), "Clear"))
            {
                DoMapResetAndRead?.Invoke();
            }
        }

        private void CopyMapToClipboard()
        {
            string mapString = string.Empty;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    mapString += worldMap[x, y];
                }
            }
            
            GUIUtility.systemCopyBuffer = mapString;
        }

        private void ReadClipboardToMap()
        {
            string clipboard = GUIUtility.systemCopyBuffer;

            int[] intMap = Array.ConvertAll(clipboard.ToCharArray(), c => (int)char.GetNumericValue(c));

            int pos = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    SetMapValues(intMap[pos], x, y);
                    pos++;
                }
            }
        }

        private void SetMapValues(int value, int x, int y)
        {
            switch(value)
            {
                case (int)Tiles.Air:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Air]);
                    playerTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Air]);
                    break;

                case (int)Tiles.Wall:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Air]);
                    wallTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Wall]);
                    break;

                case (int)Tiles.Player:
                    floorTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Air]);
                    playerTilemap.SetTile(new Vector3Int(x, y), tiles[(int)Tiles.Player]);
                    break;
            }
        }
    }
}   
