using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tiles
{
    [Serializable]
    public class Tile<TEnum> 
        where TEnum : Enum
    {
        public Vector2Int position;
        public TEnum type;

        public Tile(Vector2Int position)
        {
            this.position = position;
        }
    }
}