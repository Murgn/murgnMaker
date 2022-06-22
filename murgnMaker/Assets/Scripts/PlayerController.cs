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
    
    public class PlayerController : Singleton<PlayerController>
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

        private bool playerEnabled;

        private new void Awake()
        {
            world = World.instance;
            worldRenderer = WorldRenderer.instance;
            worldManager = WorldManager.instance;
            input = new PlayerInput();
        }

        private void Update()
        {
            if(playerEnabled)
                PlayerMovement();
        }

        #region Enable/Disable
        
        private void OnEnable()
        {
            input.Enable();
            EventManager.OnMapGenerate += OnMapGenerate;
            EventManager.SetPlayerPosition += SetPosition;
            EventManager.EnablePlayer += EnablePlayer;
            EventManager.DisablePlayer += DisablePlayer;
        }


        private void OnDisable()
        {
            input.Disable();
            EventManager.OnMapGenerate -= OnMapGenerate;
            EventManager.SetPlayerPosition -= SetPosition;
            EventManager.EnablePlayer -= EnablePlayer;
            EventManager.DisablePlayer -= DisablePlayer;
        }
        
        #endregion

        private void EnablePlayer()
        {
            playerEnabled = true;
        }

        private void DisablePlayer()
        {
            playerEnabled = false;
            world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
        }
        
        private void OnMapGenerate(int width, int height)
        {
            this.width = width;
            this.height = height;
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
            bool check = !(position.x >= 0 && position.x < width && position.y >= 0 && position.y < height) || world.GetValue(position) != (int)Tiles.Floor;

            if(check)
                EventManager.DoScreenShake?.Invoke(0.05f, 0.0f, 0.1f);
            
            return check;
        }
        
        private void SetPosition(int x, int y)
        {
            Debug.Log(string.Format("Setting Position To: {0}, {1}", x, y));
            world.SetValue(Tiles.Floor, playerPosition.x, playerPosition.y);
            playerPosition.x = x;
            playerPosition.y = y;
            world.SetValue(Tiles.Player, playerPosition.x, playerPosition.y);
        }
    }
}
