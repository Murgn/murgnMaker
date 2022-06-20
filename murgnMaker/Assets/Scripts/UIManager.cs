using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

namespace Murgn
{
    public class UIManager : MonoBehaviour
	{
        [Header("Cursor")]
        [SerializeField] private Transform cursor;

        [Header("Tilemap")]
        [SerializeField] private Tilemap uiTilemap;
        private World world;
        private WorldRenderer worldRenderer;
        private WorldManager worldManager;
        private Camera cameraMain;

        private Vector3Int newCursorPosition;
        private Vector3Int oldCursorPosition;

        private int width;
        private int height;
        private void Awake()
        {
            world = World.instance;
            worldRenderer = WorldRenderer.instance;
            worldManager = WorldManager.instance;
            cameraMain = Camera.main;
        }

        private void Update()
        {
            SetCursor();
            CursorPlace();
        }

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
                world.SetValue(Tiles.Wall, newCursorPosition.x, newCursorPosition.y);

            if (Mouse.current.rightButton.isPressed)
                world.SetValue(Tiles.Floor, newCursorPosition.x, newCursorPosition.y);
        }

        private bool IsInMap()
        {
            return newCursorPosition.x >= 0 && newCursorPosition.x < world.width && newCursorPosition.y >= 0 && newCursorPosition.y < world.height;
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(250, 50, 150, 100), "Restart"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }   
}