using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JakeJumper
{
    class MenuScreen : Screen
    {
        Sprite jakeJumperLogo;
        Sprite play;

        public MenuScreen(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            jakeJumperLogo = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper"))),
                new Vector2(270,-200), new Vector2(690,600), Color.White);

            play = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play"))),
                new Vector2(15), new Vector2(70), Color.White);

        }


        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            jakeJumperLogo.Draw(spriteBatch);
            play.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(spriteBatch);
        }



    }
}
