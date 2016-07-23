using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JakeJumper
{
    class GameScreen : Screen
    {
        public static Dictionary<Vector2, Tile> mapTiles = new Dictionary<Vector2, Tile>();
        Matrix view;
        Matrix projection;
        Vector2 cameraPosition = new Vector2(0, 0);
        float cameraRotation = MathHelper.ToRadians(270);
        BasicEffect basicEffect;
        public static bool dead = false;

        Texture2D maptexture;
        Dude myDude;
        KeyboardState keyboard;
        Sprite pauseButton;
        AnimatedSprite characterdeath;

        public GameScreen(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            pauseButton = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Pause"), Content.Load<Texture2D>("Pause")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Pause"), Content.Load<Texture2D>("Pause"))),
                new Vector2(15), new Vector2(70), Color.White);

            characterdeath = new AnimatedSprite(new ThemeTextureSet(
               new QualityControlTexture2D(Content.Load<Texture2D>("Explosion"), Content.Load<Texture2D>("Explosion")),
               new QualityControlTexture2D(Content.Load<Texture2D>("Explosion"), Content.Load<Texture2D>("Explosion"))),
               new Vector2(100), new Vector2(100), Color.White);

            //characterdeath.addframe(new rectangle(13, 13, 6, 6));
            //characterdeath.addframe(new rectangle(44, 12, 8, 8));
            //characterdeath.addframe(new rectangle(75, 11, 10, 10));
            //characterdeath.addframe(new rectangle(106, 10, 12, 12));
            //characterdeath.addframe(new rectangle(9, 41, 14, 14));
            //characterdeath.addframe(new rectangle(40, 40, 16, 16));
            //characterdeath.addframe(new rectangle(71, 39, 18, 18));
            //characterdeath.addframe(new rectangle(102, 38, 20, 20));
            //characterdeath.addframe(new rectangle(5, 69, 22, 22));
            //characterdeath.addframe(new rectangle(35, 67, 25, 25));
            //characterdeath.addframe(new rectangle(67, 67, 26, 26));
            //characterdeath.addframe(new rectangle(98, 66, 28, 28));
            //characterdeath.addframe(new rectangle(1, 97, 30, 30));
            //characterdeath.addframe(new rectangle(34, 98, 30, 30));
            //characterdeath.addframe(new rectangle(71, 103, 25, 25));
            //characterdeath.addframe(new rectangle(113, 113, 15, 15));

            maptexture = Content.Load<Texture2D>("Cubeverse");

            Color[] mapColors = new Color[maptexture.Width * maptexture.Height];
            maptexture.GetData<Color>(mapColors);

            for (int y = 0; y < maptexture.Height; y++)
            {
                for (int x = 0; x < maptexture.Width; x++)
                {
                    Color mapColor = mapColors[x + y * maptexture.Width];
                    Vector2 tilePosition = new Vector2(x, y);
                    CreateBlock(mapColor, tilePosition);
                }
            }

            if (myDude == null)
            {
                throw new ArgumentNullException("Kevin said this guy isnt in the key map!");
            }

            int totalPixels = 20;
            MouseState mouse = Mouse.GetState();

            projection = Matrix.CreateOrthographic(GraphicsDevice.Viewport.AspectRatio * totalPixels, totalPixels, 0, 100);
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Projection = projection;
            basicEffect.World = Matrix.Identity;
            basicEffect.TextureEnabled = true;
            basicEffect.VertexColorEnabled = true;
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

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (dead == true)
            {
                characterdeath.AddFrame(new Rectangle(13, 13, 6, 6));
                characterdeath.AddFrame(new Rectangle(44, 12, 8, 8));
                characterdeath.AddFrame(new Rectangle(75, 11, 10, 10));
                characterdeath.AddFrame(new Rectangle(106, 10, 12, 12));
                characterdeath.AddFrame(new Rectangle(9, 41, 14, 14));
                characterdeath.AddFrame(new Rectangle(40, 40, 16, 16));
                characterdeath.AddFrame(new Rectangle(71, 39, 18, 18));
                characterdeath.AddFrame(new Rectangle(102, 38, 20, 20));
                characterdeath.AddFrame(new Rectangle(5, 69, 22, 22));
                characterdeath.AddFrame(new Rectangle(35, 67, 25, 25));
                characterdeath.AddFrame(new Rectangle(67, 67, 26, 26));
                characterdeath.AddFrame(new Rectangle(98, 66, 28, 28));
                characterdeath.AddFrame(new Rectangle(1, 97, 30, 30));
                characterdeath.AddFrame(new Rectangle(34, 98, 30, 30));
                characterdeath.AddFrame(new Rectangle(71, 103, 25, 25));
                characterdeath.AddFrame(new Rectangle(113, 113, 15, 15));
            }

            myDude.Update(gameTime, keyboard);
            cameraPosition = new Vector2(myDude.Position.X, myDude.Position.Y);//- (myDude.HitBox.Height * 6));
            characterdeath.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            view = Matrix.CreateLookAt(new Vector3(cameraPosition, -10), new Vector3(cameraPosition, 0), new Vector3((float)Math.Cos(cameraRotation), (float)Math.Sin(cameraRotation), 0));
            basicEffect.View = view;
            MouseState mouse = Mouse.GetState();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, basicEffect);

            foreach (Sprite tile in mapTiles.Values)
            {
                tile.Draw(spriteBatch);
            }
            
            myDude.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            pauseButton.Draw(spriteBatch);
            characterdeath.Draw(spriteBatch);      

            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }
}
