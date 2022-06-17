using System;
using UnityEngine;

namespace Murgn
{
    public class World : Singleton<World>
    {
        public byte[,] map;

        [HideInInspector] public int width;
        [HideInInspector] public int height;

        private WorldRenderer worldRenderer;

        private new void Awake()
        {
            worldRenderer = WorldRenderer.instance;
        }

        public void SetValue(object value, int x, int y)
        {
            byte _value;
            if (value.Equals(0))
                _value = 0;
            else
                _value = (byte)value;
            
            map.SetValue(_value, x, y);
            worldRenderer.SetValue(_value, x, y);
        }

        public void ResetMap()
        {
            map = new byte[width, height];
        }
        
        public int GetValue(int x, int y)
        {
            return map[x, y];
        }
        
        public int GetValue(Vector2Int position)
        {
            return map[position.x, position.y];
        }
    }   
}