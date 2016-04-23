using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JakeJumper
{
    public class Tile : Sprite
    {
        private BlockType blockType;

        public BlockType BlockType
        {
            get { return blockType; }
            set { blockType = value; }
        }

        public Tile(ThemeTextureSet image, Vector2 position, Vector2 size, Color tint, BlockType type)
            : base(image, position, size, tint)
        {
            BlockType = type;
        }
    }
}
