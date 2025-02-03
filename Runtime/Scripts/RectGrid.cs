using System;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

namespace Fsi.RectGrid
{
    [Serializable]
    public class RectGrid<TEnum, TTile>
        where TEnum : Enum
        where TTile : Tile<TEnum>, new()
    {
        public Vector2Int size;
        public List<TTile> tiles = new();

        public RectGrid()
        {
            size = new Vector2Int(5, 4);
            Refresh();
        }
    
        public RectGrid(Vector2Int size)
        {
            this.size = size;
            Refresh();
        }

        public virtual void Refresh()
        {
            List<TTile> checking = new(tiles);
            foreach (TTile t in checking)
            {
                if (t.position.x >= size.x || t.position.y >= size.y)
                {
                    tiles.Remove(t);
                }
            }
        
            for (var x = 0; x < size.x; x++)
            for (var y = 0; y < size.y; y++)
            {
                Vector2Int pos = new(x, y);
                if (!TryGetTile(pos, out TTile tile))
                {
                    tile = new TTile
                           {
                               position = pos
                           };
                    tiles.Add(tile);
                }
            }
        }
    
        public bool TryGetTile(Vector2Int position, out TTile tile)
        {
            if(position.x < 0 && position.x >= size.x && position.y < 0 && position.y >= size.y)
            {
                tile = null;
                return false;
            }
        
            foreach (TTile t in tiles)
            {
                if (t.position == position)
                {
                    tile = t;
                    return true;
                }
            }

            tile = null;
            return false;
        }
    }
}