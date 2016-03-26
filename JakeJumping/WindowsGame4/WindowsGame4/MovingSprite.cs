using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JakeJumper
{
    public class MovingSprite : Sprite
    {
        public Vector2 CurrentSpeed;

        public MovingSprite(Texture2D image, Vector2 position, Vector2 size, Color color, Vector2 speed) :
            base(image, position, size, color)
        {
            CurrentSpeed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            Position += CurrentSpeed;
            base.Update(gameTime);
        }
    }
}
