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
using JakeJumper;

namespace JakeJumper
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GameState screen = GameState.InGame;

        GameScreen gameScreen;

        Sprite Menu;
        Sprite Settings;
        Sprite Game;
        Sprite JakeJumperBackround;
        Sprite JakeJumper;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D pixel;

       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ThemeTextureSets.Initialize(Content);

            gameScreen = new GameScreen(Content, GraphicsDevice);

            JakeJumper = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper"))),
                new Vector2(100), new Vector2(70), Color.White);

            JakeJumperBackround = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround"))),
                new Vector2(100), new Vector2(70), Color.White);

            Menu = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Menu"), Content.Load<Texture2D>("Menu")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Menu"), Content.Load<Texture2D>("Menu"))),
                new Vector2(100), new Vector2(70), Color.White);

            Settings = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Settings"), Content.Load<Texture2D>("Settings")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Settings"), Content.Load<Texture2D>("Settings"))),
                new Vector2(100), new Vector2(70), Color.White);

            Game = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Game"), Content.Load<Texture2D>("Game")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Game"), Content.Load<Texture2D>("Game"))),
                new Vector2(15), new Vector2(70), Color.White);

           

            IsMouseVisible = true;


           


            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            

            // Putting It To Game Menu
            screen = GameState.Menu;
        }

       

        protected override void Update(GameTime gameTime)
        {
            gameScreen.Update(gameTime);         
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            

            if (screen == GameState.InGame)
            {
               
            }

            else if (screen == GameState.Menu)
            {

                spriteBatch.Begin();// SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, basicEffect);

                Game.Draw(spriteBatch);
                // JakeJumper.Draw(spriteBatch);
                // JakeJumperBackround.Draw(spriteBatch);
                //Menu.Draw(spriteBatch)w;
                //Settings.Draw(spriteBatch);  

                

                spriteBatch.End();             
            }

            gameScreen.Draw(spriteBatch);


           

            base.Draw(gameTime);
        }
        
    }
}
