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

        Vector2 cameraPosition = new Vector2(0, 0);
        float cameraRotation = MathHelper.ToRadians(270);

        public static Dictionary<Vector2, Sprite> mapTiles = new Dictionary<Vector2, Sprite>();
        public List<Sprite> mapBackgrounds = new List<Sprite>();

        BasicEffect basicEffect;
        KeyboardState keyboard;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D pixel;
        Texture2D maptexture;

        Dude myDude;

        bool simpleTheme = false;

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

                    if (simpleTheme == false)
                    {

                        mapBackgrounds.Add(new Sprite(ThemeTextureSets.Sets[BlockType.Background], tilePosition, Vector2.One, Color.White));

                        if (mapColor == new Color(0, 0, 0, 255))
                        {
                            mapTiles.Add(tilePosition, new Sprite(ThemeTextureSets.Sets[BlockType.Terrian], tilePosition, Vector2.One, Color.LightGray));
                        }

                        else if (mapColor == new Color(255, 0, 0, 255))
                        {
                            mapTiles.Add(tilePosition, new LavaTile(ThemeTextureSets.Sets[BlockType.Lava], tilePosition));
                            mapTiles.Add(new Vector2(tilePosition.X + .1f, tilePosition.Y),
                                new Sprite(ThemeTextureSets.Sets[BlockType.Lava], tilePosition, Vector2.One, Color.Red));
                        }

                        else if (mapColor == new Color(0, 0, 255, 255))
                        {
                            myDude = new Dude(ThemeTextureSets.Sets[BlockType.Character], tilePosition, new Vector2(1, 1), Color.White);
                        }

                        else if (mapColor == new Color(100, 0, 0, 255))
                        {
                            mapBackgrounds.Add(new Sprite(ThemeTextureSets.Sets[BlockType.Spike], tilePosition, Vector2.One, Color.LightGray));
                        }
                        else if (mapColor == new Color(0, 255, 0, 255))
                        {
                            mapTiles.Add(tilePosition, new Sprite(ThemeTextureSets.Sets[BlockType.DetailTerrian], tilePosition, Vector2.One, Color.LightGray));
                        }

                        else if (mapColor == new Color(0, 200, 0, 255))
                        {
                            mapBackgrounds.Add(new Sprite(ThemeTextureSets.Sets[BlockType.HangingObject], tilePosition, Vector2.One, Color.LightGray));
                        }

                    }

                }
            }
            if (myDude == null)
            {
                throw new ArgumentNullException("Kevin said this guy isnt in the key map!");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.A))
            {
                Settings.Theme = Theme.Medieval;
            }
            else
            {
                Settings.Theme = Theme.Simple;
            }
            myDude.Update(gameTime, keyboard);
            cameraPosition = new Vector2(myDude.Position.X, myDude.Position.Y);//- (myDude.HitBox.Height * 6));
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            view = Matrix.CreateLookAt(new Vector3(cameraPosition, -10), new Vector3(cameraPosition, 0), new Vector3((float)Math.Cos(cameraRotation), (float)Math.Sin(cameraRotation), 0));
            basicEffect.View = view;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, basicEffect);

            foreach (Sprite tile in mapBackgrounds)
            {
                tile.Draw(spriteBatch);
            }

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, basicEffect);

            foreach (Sprite tile in mapTiles.Values)
            {
                tile.Draw(spriteBatch);
            }
            myDude.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
