using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

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
        
        private void OnEnable() => worldManager.OnMapGenerate += OnMapGenerate;
        private void OnDisable() => worldManager.OnMapGenerate -= OnMapGenerate;

        private void OnMapGenerate(int width, int height)
        {
            this.width = width;
            this.height = height;
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
            return newCursorPosition.x >= 1 && newCursorPosition.x < width - 1 && newCursorPosition.y >= 1 && newCursorPosition.y < height - 1;
        }
        
    }   
}