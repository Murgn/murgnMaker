using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Murgn
{
    public class UIManager : MonoBehaviour
	{
        private PlayerInput input;
        private World world;
        private WorldRenderer worldRenderer;
        private WorldManager worldManager;
        private Camera cameraMain;

        [Header("Canvases")] 
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject gameCanvas;
        [SerializeField] private GameObject importantCanvas;
        
        [Header("Cursor")]
        [SerializeField] private Transform cursor;

        [Header("Tilemap")]
        [SerializeField] private Tilemap uiTilemap;

        private Vector3Int newCursorPosition;
        private Vector3Int oldCursorPosition;

        private int width;
        private int height;

        [Header("Tiles")] 
        [SerializeField] private GameObject[] tileObjects;

        [SerializeField] private Sprite[] uiImages;
        private Tiles currentTile = Tiles.Wall;
        private GameObject newTile;
        private GameObject oldTile;
        
        private void Awake()
        {
            world = World.instance;
            worldRenderer = WorldRenderer.instance;
            worldManager = WorldManager.instance;
            cameraMain = Camera.main;

            // I shouldn't make a new PlayerInput I should grab it from the player or a GameManager
            input = new PlayerInput();
        }
        
        #region Enable/Disable

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        #endregion

        private void Update()
        {
            SetCursor();
            CursorPlace();

            if (gameCanvas.activeSelf == true)
                TileSelector();

            DebugFunctions();
        }

        #region CursorController
        
        private void SetCursor()
        {
            if (worldManager.gameState == GameStates.Playing)
            {
                Vector3 mousePos = Mouse.current.position.ReadValue();
                mousePos.z = 10;
                newCursorPosition = uiTilemap.WorldToCell(cameraMain.ScreenToWorldPoint(mousePos));
                if (IsInMap())
                {
                    if (oldCursorPosition != newCursorPosition)
                    {
                        uiTilemap.SetTile(oldCursorPosition, null);
                        uiTilemap.SetTile(newCursorPosition, worldRenderer.tiles[(int)Tiles.Cursor]);
                    }

                    oldCursorPosition = newCursorPosition;
                    
                    cursor.gameObject.SetActive(false);
                }
                else
                {
                    cursor.gameObject.SetActive(true);
                    uiTilemap.SetTile(oldCursorPosition, null);
                    oldCursorPosition = newCursorPosition + Vector3Int.one;
                }
            }
            else
            {
                uiTilemap.SetTile(oldCursorPosition, null);
            }
            cursor.position = Mouse.current.position.ReadValue();
        }

        private void CursorPlace()
        {
            if (!IsInMap()) return;

            if (Mouse.current.leftButton.isPressed)
                TilePlacer(currentTile, newCursorPosition.x, newCursorPosition.y);

            if (Mouse.current.rightButton.isPressed)
                TileDeleter(newCursorPosition.x, newCursorPosition.y);
        }
        
        private bool IsInMap()
        {
            return newCursorPosition.x >= 0 && newCursorPosition.x < world.width && newCursorPosition.y >= 0 && newCursorPosition.y < world.height;
        }
        
        #endregion
        
        #region TileController

        private void TilePlacer(Tiles tile, int x, int y)
        {
            switch (tile)
            {
                case Tiles.Wall:
                    world.SetValue(tile, x, y);
                    break;
                
                case Tiles.Player:
                    EventManager.EnablePlayer?.Invoke();
                    EventManager.SetPlayerPosition?.Invoke(x, y);
                    break;
                
                case Tiles.Enemy:
                    world.SetValue(tile, x, y);
                    break;
                
                case Tiles.Key:
                    world.SetValue(tile, x, y);
                    break;
                
                case Tiles.Exit:
                    world.SetValue(tile, x, y);
                    break;
            }
        }

        private void TileDeleter(int x, int y)
        {
            switch (world.GetValue(x, y))
            {
                case (int)Tiles.Wall:
                    world.SetValue(Tiles.Floor, x, y);
                    break;
                
                case (int)Tiles.Player:
                    EventManager.DisablePlayer?.Invoke();
                    break;
                
                case (int)Tiles.Enemy:
                    world.SetValue(Tiles.Floor, x, y);
                    break;
                
                case (int)Tiles.Key:
                    world.SetValue(Tiles.Floor, x, y);
                    break;
                
                case (int)Tiles.Exit:
                    world.SetValue(Tiles.Floor, x, y);
                    break;
            }
        }
        
        private void TileSelector()
        {
            if (input.Menu.SelectTile1.WasPerformedThisFrame())
                currentTile = Tiles.Wall;
            
            if (input.Menu.SelectTile2.WasPerformedThisFrame())
                currentTile = Tiles.Player;
            
            if (input.Menu.SelectTile3.WasPerformedThisFrame())
                currentTile = Tiles.Enemy;
            
            if (input.Menu.SelectTile4.WasPerformedThisFrame())
                currentTile = Tiles.Key;
            
            if (input.Menu.SelectTile5.WasPerformedThisFrame())
                currentTile = Tiles.Exit;
            
            TileVisualizer();
        }

        private void TileVisualizer()
        {
            switch (currentTile)
            {
                default:
                    newTile = tileObjects[0];
                    break;
                
                case Tiles.Player:
                    newTile = tileObjects[1];
                    break;
                
                case Tiles.Enemy:
                    newTile = tileObjects[2];
                    break;
                
                case Tiles.Key:
                    newTile = tileObjects[3];
                    break;
                
                case Tiles.Exit:
                    newTile = tileObjects[4];
                    break;
            }

            if (oldTile != newTile)
            {
                if (oldTile != null)
                {
                    oldTile.transform.GetComponent<Image>().sprite = uiImages[0];
                    newTile.transform.GetComponent<Image>().sprite = uiImages[1];

                }
                else
                    newTile.transform.GetComponent<Image>().sprite = uiImages[1];
            }
            
            oldTile = newTile;
        }
        
        #endregion

        private void DebugFunctions()
        { 
            // Debug Functions
            if (worldManager.gameState == GameStates.Playing)
            {
                if(input.Debug.Restart.WasPerformedThisFrame())
                    Restart();

                if (input.Debug.Copy.WasPerformedThisFrame())
                    Copy();
            
                if(input.Debug.Load.WasPerformedThisFrame())
                    Load();
            }
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Copy()
        {
            EventManager.DoMapClipboardCopy?.Invoke();
            EventManager.DoMapResetAndRead?.Invoke(); 
        }

        public void Load()
        {
            EventManager.DoMapClipboardRead?.Invoke(GUIUtility.systemCopyBuffer);
        }
        
    }   
}