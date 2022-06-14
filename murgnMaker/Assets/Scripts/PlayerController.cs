using UnityEngine;
using UnityEngine.Tilemaps;

namespace Murgn
{
    public struct PlayerPosition
    {
        public int x;
        public int y;

        public PlayerPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    public class PlayerController : MonoBehaviour
    {
        private WorldManager worldManager;
        private int width;
        private int height;
        private PlayerPosition playerPosition;

        private void Awake()
        {
            worldManager = WorldManager.instance;
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void OnEnable() => worldManager.OnMapGenerate += OnMapGenerate;
        private void OnDisable() => worldManager.OnMapGenerate -= OnMapGenerate;

        private void OnMapGenerate(int width, int height)
        {
            /// I should probably get a reference to the worldMap instead and just set WorldManager
            /// worldMap to the player worldMap when im done doing what I need
            
            this.width = width;
            this.height = height;
            
            GeneratePlayer();
            worldManager.DoMapResetAndRead?.Invoke();
        }

        private void GeneratePlayer()
        {
            playerPosition = new PlayerPosition(width / 3, height / 2);
            worldManager.worldMap.SetValue((byte)Tiles.Player, playerPosition.x, playerPosition.y);
        }

        private void PlayerMovement()
        {
            if (Input.GetButtonDown("Vertical"))
            { 
                worldManager.worldMap.SetValue((byte)0, playerPosition.x, playerPosition.y);
                if (Input.GetAxisRaw("Vertical") > 0)
                    playerPosition.y++;

                if (Input.GetAxisRaw("Vertical") < 0)
                    playerPosition.y--;
                
                worldManager.worldMap.SetValue((byte)2, playerPosition.x, playerPosition.y);
                worldManager.DoMapResetAndRead?.Invoke();
            }
            
            if (Input.GetButtonDown("Horizontal"))
            {
                worldManager.worldMap.SetValue((byte)0, playerPosition.x, playerPosition.y);
                if (Input.GetAxisRaw("Horizontal") > 0)
                    playerPosition.x++;

                if (Input.GetAxisRaw("Horizontal") < 0)
                    playerPosition.x--;
                
                worldManager.worldMap.SetValue((byte)2, playerPosition.x, playerPosition.y);
                worldManager.DoMapResetAndRead?.Invoke();
            }
        }
    }
}
