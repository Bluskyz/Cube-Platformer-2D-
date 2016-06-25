﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FontEffectsLib.FontTypes;
using FontEffectsLib.SpriteTypes;


namespace JakeJumper
{
    class MenuScreen : Screen
    {
        Sprite jakeJumperLogo;
        Sprite jakeJumperBackround;
        Sprite jakeGround;
        Sprite jakeRoof;
        Sprite play;
        GameScreen gameScreen;

        AccelDropInFont dropText;


        KeyboardState keyboard;
        MouseState ms;

        public MenuScreen(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            MouseState mouse = Mouse.GetState();

            jakeJumperLogo = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper"))),
                new Vector2(270,-100), new Vector2(690,600), Color.White);

            jakeGround = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Ground"), Content.Load<Texture2D>("Ground")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Ground"), Content.Load<Texture2D>("Ground"))),
                new Vector2(270, -100), new Vector2(690, 600), Color.White);

            jakeRoof = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Roof"), Content.Load<Texture2D>("Roof")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Roof"), Content.Load<Texture2D>("Roof"))),
                new Vector2(270, -100), new Vector2(1000, 600), Color.White);

            jakeJumperBackround = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround"))),
                new Vector2(0, 0), new Vector2(0, 0), Color.White);

            jakeJumperBackround.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f); 
            
            play = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play"))),
                new Vector2(470,280), new Vector2(290,250), Color.White);

            //dropText = new AccelDropInFont(Content.Load<SpriteFont>("SpriteFont1"), new Vector2(0, 0), new Vector2(0, GraphicsDevice.Viewport.Height - 50), new Vector2(0, 3), "SUH DOOD", Color.Blue, new Vector2(0, 2));
            //MESS WITH THE LIBRARY FONTS, FIND OUT HOW TO GAIN ACCESS OF STATE CHANGES, AND TRY TO GET IT TO REPEAT THE LAST FEW MOMENTS OF THE DROP REPEATEDLY AS IF
            //THE TEXT IS BOUNCING <(^_^)>(#) WAFFLE
        }

       

        public override void Update(GameTime gameTime)
        {

            ms = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (play.HitBox.Contains(ms.X, ms.Y) && play.IsClicked(ms))
            {
                Game1.screenState = ScreenState.Game;
            }

            //dropText.Update(gameTime);

            base.Update(gameTime);
           
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //jakeJumperBackround.Draw(spriteBatch);
            jakeGround.Draw(spriteBatch);
            jakeRoof.Draw(spriteBatch);
            jakeJumperLogo.Draw(spriteBatch);
            play.Draw(spriteBatch);

            //dropText.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(spriteBatch);
        }



    }
}
