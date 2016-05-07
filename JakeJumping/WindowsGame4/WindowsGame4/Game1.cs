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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Matrix view;
        Matrix projection;

        Sprite pauseButton;
        AnimatedSprite characterDeath;

        Vector2 cameraPosition = new Vector2(0, 0);
        float cameraRotation = MathHelper.ToRadians(270);

       
        

        public static Dictionary<Vector2, Tile> mapTiles = new Dictionary<Vector2, Tile>();



        BasicEffect basicEffect;
        KeyboardState keyboard;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D pixel;
        Texture2D maptexture;

        Dude myDude;

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

            pauseButton = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Pause"), Content.Load<Texture2D>("Pause")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Pause"), Content.Load<Texture2D>("Pause"))),
                new Vector2(15), new Vector2(70),  Color.White);

            characterDeath = new AnimatedSprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Explosion"), Content.Load<Texture2D>("Explosion")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Explosion"), Content.Load<Texture2D>("Explosion"))),
                new Vector2(100), new Vector2(100), Color.White);

            characterDeath.AddFrame(new Rectangle(13,13,6,6));
            characterDeath.AddFrame(new Rectangle(44,12,8,8));
            characterDeath.AddFrame(new Rectangle(75,11,10,10));
            characterDeath.AddFrame(new Rectangle(106,10,12,12));
            characterDeath.AddFrame(new Rectangle(9,41,14,14));
            characterDeath.AddFrame(new Rectangle(40,40,16,16));
            characterDeath.AddFrame(new Rectangle(71,39,18,18));
            characterDeath.AddFrame(new Rectangle(102,38,20,20));
            characterDeath.AddFrame(new Rectangle(5,69,22,22));
            characterDeath.AddFrame(new Rectangle(35,67,25,25));
            characterDeath.AddFrame(new Rectangle(67,67,26,26));
            characterDeath.AddFrame(new Rectangle(98,66,28,28));
            characterDeath.AddFrame(new Rectangle(1,97,30,30));
            characterDeath.AddFrame(new Rectangle(34,98,30,30));
            characterDeath.AddFrame(new Rectangle(71,103,25,25));
            characterDeath.AddFrame(new Rectangle(113,113,15,15));


            IsMouseVisible = true;
            int totalPixels = 20;


            projection = Matrix.CreateOrthographic(GraphicsDevice.Viewport.AspectRatio * totalPixels, totalPixels, 0, 100);
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Projection = projection;
            basicEffect.World = Matrix.Identity;
            basicEffect.TextureEnabled = true;
            basicEffect.VertexColorEnabled = true;


            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            maptexture = Content.Load<Texture2D>("Cubeverse");

            Color[] mapColors = new Color[maptexture.Width * maptexture.Height];
            maptexture.GetData<Color>(mapColors);

            for (int y = 0; y < maptexture.Height; y++)
            {
                for (int x = 0; x < maptexture.Width; x++)
                {
                    Color mapColor = mapColors[x + y * maptexture.Width];
                    Vector2 tilePosition = new Vector2(x, y);

                    //mapBackgrounds.Add(new Sprite(ThemeTextureSets.Sets[BlockType.Background], tilePosition, Vector2.One, Color.White));
                    CreateBlock(mapColor, tilePosition);
                }
            }
            if (myDude == null)
            {
                throw new ArgumentNullException("Kevin said this guy isnt in the key map!");
            }
        }

        void CreateBlock(Color color, Vector2 position)
        {
            if (ThemeTextureSets.ColorToBlock.ContainsKey(color))
            {
                BlockType blockType = ThemeTextureSets.ColorToBlock[color];
                if (blockType == BlockType.Character)
                {
                    mapTiles.Add(position, new Tile(ThemeTextureSets.Sets[BlockType.Background], position, Vector2.One, Color.White, BlockType.Background));
                    myDude = new Dude(ThemeTextureSets.Sets[blockType], position, Vector2.One, Color.White);
                }
                else if (blockType == BlockType.Lava)
                {
                    mapTiles.Add(position, new LavaTile(ThemeTextureSets.Sets[blockType], position));
                    mapTiles.Add(new Vector2(position.X + .1f, position.Y),
                        new Tile(ThemeTextureSets.Sets[blockType], position, Vector2.One, Color.Red, blockType));
                }
                else
                {
                    mapTiles.Add(position, new Tile(ThemeTextureSets.Sets[blockType], position, Vector2.One, Color.White, blockType));
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            
            //IF THE PAUSE BUTTON IS CLICK THEN...

            //if (pauseButton.IsClicked(mouse))
            //{
            //    Settings.Theme = Theme.Medieval;
            //}

            if (keyboard.IsKeyDown(Keys.A))
            {
                Settings.Theme = Theme.Medieval;
            }
            else
            {
                Settings.Theme = Theme.Simple;
            }
            myDude.Update(gameTime, keyboard);
            characterDeath.Update(gameTime);
            cameraPosition = new Vector2(myDude.Position.X, myDude.Position.Y);//- (myDude.HitBox.Height * 6));
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            view = Matrix.CreateLookAt(new Vector3(cameraPosition, -10), new Vector3(cameraPosition, 0), new Vector3((float)Math.Cos(cameraRotation), (float)Math.Sin(cameraRotation), 0));
            basicEffect.View = view;



            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, basicEffect);
            /*foreach (Sprite tile in mapBackgrounds)
            {
                tile.Draw(spriteBatch);
            }*/



            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, basicEffect);

            foreach (Sprite tile in mapTiles.Values)
            {
                tile.Draw(spriteBatch);
            }
            myDude.Draw(spriteBatch);
            spriteBatch.End();


            spriteBatch.Begin();

            pauseButton.Draw(spriteBatch);
            characterDeath.Draw(spriteBatch);


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
