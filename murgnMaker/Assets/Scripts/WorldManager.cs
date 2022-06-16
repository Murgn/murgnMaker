using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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

    public class WorldManager : Singleton<WorldManager>
	{
        [SerializeField] private int selectedSize;
        
        [NonReorderable] [SerializeField] private TilemapSettings[] tilemapSettings;
        
        [SerializeField] private Transform tileMapGrid;

        public Action<int, int> OnMapGenerate;

        private Camera cameraMain;
        private World world;
        private WorldRenderer worldRenderer;

        private new void Awake()
        {
            cameraMain = Camera.main;
            world = World.instance;
            worldRenderer = WorldRenderer.instance;
        }
        private void Start()
        {
            GenerateMap();
        }
        
        private void GenerateMap()
        {
            world.map = new byte[tilemapSettings[selectedSize].tilemapSize.x + 2, tilemapSettings[selectedSize].tilemapSize.y + 2];

            world.width = world.map.GetLength(0);
            world.height = world.map.GetLength(1);

            var offset = new Vector2((-tilemapSettings[selectedSize].tilemapSize.x - 2) / 2.0f, (-tilemapSettings[selectedSize].tilemapSize.y - 2) / 2.0f);
            tileMapGrid.position = offset;

            cameraMain.GetComponent<PixelPerfectCamera>().refResolutionX = tilemapSettings[selectedSize].cameraSize.x;
            cameraMain.GetComponent<PixelPerfectCamera>().refResolutionY = tilemapSettings[selectedSize].cameraSize.y;

            // Generates Walls
            for (int x = 0; x < world.width; x++)
            {
                world.SetValue(Tiles.Wall, x, 0);
                world.SetValue(Tiles.Wall, x, world.height - 1);
            }

            for (int y = 0; y < world.height; y++)
            {
                world.SetValue(Tiles.Wall, 0, y);
                world.SetValue(Tiles.Wall, world.width - 1, y);
            }
            
            OnMapGenerate?.Invoke(world.width, world.height);
            worldRenderer.DoMapResetAndRead?.Invoke();
        }

        private void OnGUI()
        {

            if (GUI.Button(new Rect(50, 150, 100, 100), "Generate +1"))
            {
                selectedSize++;
                worldRenderer.DoMapReset?.Invoke();
                GenerateMap();
                worldRenderer.DoMapRead?.Invoke();
            }

            if (GUI.Button(new Rect(50, 50, 100, 100), "Generate -1"))
            {
                selectedSize--;
                worldRenderer.DoMapReset?.Invoke();
                GenerateMap();
                worldRenderer.DoMapRead?.Invoke();
                
            }

            if (GUI.Button(new Rect(150, 50, 100, 100), "Read"))
            {
                ReadClipboardToMap();
                worldRenderer.DoMapResetAndRead?.Invoke();
            }

            if (GUI.Button(new Rect(150, 150, 100, 100), "Copy"))
            {
                CopyMapToClipboard();
            }
        }

        private void CopyMapToClipboard()
        {
            string mapString = string.Empty;
            
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    mapString += world.map[x, y];
                }
            }
            
            GUIUtility.systemCopyBuffer = mapString;
        }

        private void ReadClipboardToMap()
        {
            // Player needs to be told where to spawn from the clipboard
            string clipboard = GUIUtility.systemCopyBuffer;

            int[] intMap = Array.ConvertAll(clipboard.ToCharArray(), c => (int)char.GetNumericValue(c));

            int pos = 0;
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    world.SetValue((byte)intMap[pos], x, y);
                    pos++;
                }
            }
        }
    }
}   
