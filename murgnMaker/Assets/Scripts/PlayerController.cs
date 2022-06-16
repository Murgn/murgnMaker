using System;
using UnityEngine;
using UnityEngine.InputSystem;
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
        private World world;
        private WorldRenderer worldRenderer;
        private WorldManager worldManager;
        private int width;
        private int height;
        private PlayerPosition playerPosition;

        private PlayerPosition newPlayerPosition;
        private PlayerPosition oldPlayerPosition;

        private PlayerInput input;

        private void Awake()
        {
            world = World.instance;
            worldRenderer = WorldRenderer.instance;
            worldManager = WorldManager.instance;
            input = new PlayerInput();
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void OnEnable()
        {
            input.Enable();
            worldManager.OnMapGenerate += OnMapGenerate;
        }

        private void OnDisable()
        {
            input.Disable();
            worldManager.OnMapGenerate -= OnMapGenerate;
        }

        private void OnMapGenerate(int width, int height)
        {
            /// I should probably get a reference to the worldMap instead and just set WorldManager
            /// worldMap to the player worldMap when im done doing what I need
            
            this.width = width;
            this.height = height;
            
            GeneratePlayer();
            worldRenderer.DoMapResetAndRead?.Invoke();
        }

        private void GeneratePlayer()
        {
            playerPosition = new PlayerPosition(width / 3, height / 2);
            world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
        }

        private void PlayerMovement()
        {
            if (input.Player.Up.WasPerformedThisFrame() && !ColliderCheck(new Vector2Int(playerPosition.x, playerPosition.y + 1)))
            {
                world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
                playerPosition.y++;
                world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
            }
            
            if (input.Player.Down.WasPerformedThisFrame() && !ColliderCheck(new Vector2Int(playerPosition.x, playerPosition.y - 1)))
            {
                world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
                playerPosition.y--;
                world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
            }

            if (input.Player.Left.WasPerformedThisFrame() && !ColliderCheck(new Vector2Int(playerPosition.x - 1, playerPosition.y)))
            {
                world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
                playerPosition.x--;
                world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
            }

            if (input.Player.Right.WasPerformedThisFrame() && !ColliderCheck(new Vector2Int(playerPosition.x + 1, playerPosition.y)))
            {
                world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
                playerPosition.x++;
                world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
            }
            
        }

        private bool ColliderCheck(Vector2Int position)
        {
            bool check = !(position.x >= 1 && position.x < width - 1 && position.y >= 1 && position.y < height - 1) || world.GetValue(position) != (int)Tiles.Floor;

            return check;
        }
        
        private void OnGUI()
        {
            GUI.skin.textField.fontSize = 300;
            GUI.TextArea(new Rect(50, 300, 100, 50), playerPosition.x.ToString());
            GUI.TextArea(new Rect(50, 350, 100, 50), playerPosition.y.ToString());
        }
    }
}
