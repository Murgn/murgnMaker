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
            newCursorPosition = uiTilemap.WorldToCell(cameraMain.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

            if (oldCursorPosition != newCursorPosition)
            {
                uiTilemap.SetTile(oldCursorPosition, null);
                uiTilemap.SetTile(newCursorPosition, worldRenderer.tiles[(int)Tiles.Cursor]);
            }

            oldCursorPosition = newCursorPosition;
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