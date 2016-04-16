using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JakeJumper
{
    public class AnimatedSprite : Sprite
    {
        public AnimatedSprite(ThemeTextureSet image, Vector2 position, Vector2 size, Color tint)
            :base(image, position, size, tint)
        {

        }
    }
}
