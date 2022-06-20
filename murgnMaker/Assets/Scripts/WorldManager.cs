using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace Murgn
{
    public enum GameStates
    {
        Menu,
        Playing
    }

    public class WorldManager : Singleton<WorldManager>
	{
        [SerializeField] private int selectedSize;
        
        [SerializeField] private Transform tileMapGrid;
        
        private World world;

        public GameStates gameState;

        private new void Awake()
        {
            world = World.instance;
        }

        private void OnEnable()
        {
            EventManager.DoMapGenerate += GenerateMap;
            EventManager.OnGoButtonPress += OnGoButtonPress;
        }

        private void OnDisable()
        {
            EventManager.DoMapGenerate -= GenerateMap;
            EventManager.OnGoButtonPress -= OnGoButtonPress;
        }

        private void OnGoButtonPress()
        {
            gameState = GameStates.Playing;
        }

        private void GenerateMap(int x, int y)
        {
            world.map = new byte[x, y];

            EventManager.DoMapResetWalls?.Invoke();
            world.width = world.map.GetLength(0);
            world.height = world.map.GetLength(1);

            Vector2 offset = new Vector2(-x / 2.0f, -y / 2.0f);
            tileMapGrid.position = offset;

            EventManager.GenerateWalls?.Invoke();
            
            EventManager.OnMapGenerate?.Invoke(world.width, world.height);
            EventManager.DoMapResetAndRead?.Invoke();
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(150, 50, 100, 100), "Read"))
            {
                ReadClipboardToMap();
                EventManager.DoMapResetAndRead?.Invoke();
            }

            if (GUI.Button(new Rect(150, 150, 100, 100), "Copy"))
            {
                CopyMapToClipboard();
            }
        }

        private void CopyMapToClipboard()
        {
            string mapString = string.Empty;
            mapString += world.width;
            mapString += '/';
            mapString += world.height;
            mapString += '/';
            
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
            EventManager.DoMapReset?.Invoke();
            world.ResetMap();
            // Player needs to be told where to spawn from the clipboard
            string[] clipboard = GUIUtility.systemCopyBuffer.Split('/');

            world.map = new byte[int.Parse(clipboard[0]), int.Parse(clipboard[1])];
            EventManager.DoMapResetWalls?.Invoke();
            world.width = world.map.GetLength(0);
            world.height = world.map.GetLength(1);
            
            Vector2 offset = new Vector2(-world.width / 2.0f, -world.height / 2.0f);
            tileMapGrid.position = offset;
            
            EventManager.GenerateWalls?.Invoke();

            int[] intMap = Array.ConvertAll(clipboard[2].ToCharArray(), c => (int)char.GetNumericValue(c));

            int pos = 0;
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    world.SetValue((byte)intMap[pos], x, y);
                    
                    if(intMap[pos] == 2)
                        EventManager.SetPlayerPosition?.Invoke(x, y);
                    
                    pos++;
                }
            }
            
            EventManager.OnMapGenerate?.Invoke(world.width, world.height);
            EventManager.DoMapResetAndRead?.Invoke();
        }
    }
}   
