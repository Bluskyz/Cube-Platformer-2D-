using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JakeJumper
{
    public class Sprite
    {
        private ThemeTextureSet imageSet;

        public ThemeTextureSet ImageSet
        {
            get { return imageSet; }
            set { imageSet = value; }
        }

        public Vector2 Position;
        public Vector2 Size;
        public Color Tint;
        public Rectangle HitBox;
        public float Layer = 0;
        public SpriteEffects SpriteEffects;

        public Sprite(ThemeTextureSet image, Vector2 position, Vector2 size, Color tint)
        {
            ImageSet = image;
            Position = position;
            Size = size;
            Tint = tint;
            SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageSet.CurrentImage, Position, null, Tint, 0, Vector2.Zero, Size / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
        }
    }
}
