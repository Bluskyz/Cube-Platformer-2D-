﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JakeJumper
{
    public class LavaTile : Tile
    {
        public LavaTile(ThemeTextureSet image, Vector2 position)
            :base(image, position, Vector2.One, Color.White, BlockType.Lava)
        {
            Layer = 1;
        }
    }
}
