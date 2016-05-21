using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JakeJumper
{
    public class Screen
    {

        List<Sprite> sprites = new List<Sprite>();

        public virtual void Update(GameTime gameTime)
        {
            for (int y = 0; y < sprites.Count; y++)
            {
                sprites[y].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int t = 0; t < sprites.Count; t++)
            {
                sprites[t].Draw(spriteBatch);
            }
        }
    }
}
