using UnityEngine;
using UnityEngine.Tilemaps;

namespace Murgn
{
    public class UIManager : MonoBehaviour
	{
        [SerializeField] private Tilemap uiTilemap;
        private WorldManager worldManager;
        private Camera cameraMain;

        private Vector3Int newCursorPosition;
        private Vector3Int oldCursorPosition;
        private void Start()
        {
            cameraMain = Camera.main;
            worldManager = WorldManager.instance;
        }

        private void Update()
        {
            SetCursor();

            CursorPlace();
        }

        private void SetCursor()
        {
            newCursorPosition = uiTilemap.WorldToCell(cameraMain.ScreenToWorldPoint(Input.mousePosition));
            
            if(oldCursorPosition != newCursorPosition)
                uiTilemap.SetTile(oldCursorPosition, null);
            
            uiTilemap.SetTile(newCursorPosition, worldManager.tiles[(int)Tiles.Cursor]);

            oldCursorPosition = newCursorPosition;
        }

        private void CursorPlace()
        {
            Debug.Log(newCursorPosition);
            
            if (Input.GetMouseButton(0))
            {
                Debug.Log("left click");
                worldManager.worldMap.SetValue((byte)Tiles.Wall, newCursorPosition.x, newCursorPosition.y);
                worldManager.DoMapResetAndRead?.Invoke();
            }

            if (Input.GetMouseButton(1))
            {
                Debug.Log("right click");
                worldManager.worldMap.SetValue((byte)0, newCursorPosition.x, newCursorPosition.y);
                worldManager.DoMapResetAndRead?.Invoke();
            }
        }
        
    }   
}