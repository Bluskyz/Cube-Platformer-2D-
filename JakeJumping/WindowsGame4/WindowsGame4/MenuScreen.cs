using Microsoft.Xna.Framework.Content;
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
        Sprite jakeJumperBack;
        Sprite jakeJumperBack2;
        Sprite jakeJumperRoof;
        Sprite jakeJumperRoof2;
        Sprite jakeJumperFloor;
        Sprite jakeJumperFloor2;


       
        

        //Sprite jakeJumperBackround;
        //Sprite jakeGround;
        //Sprite jakeRoof;
        Sprite play;
        GameScreen gameScreen;
        GraphicsDevice GraphicsDevice;

        AccelDropInFont dropText;


        KeyboardState keyboard;
        MouseState ms;

        public MenuScreen(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            MouseState mouse = Mouse.GetState();
            this.GraphicsDevice = GraphicsDevice;

            jakeJumperLogo = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper"), Content.Load<Texture2D>("Jake Jumper"))),
                new Vector2(270,-100), new Vector2(690,600), Color.White);

            /*

            jakeGround = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Ground"), Content.Load<Texture2D>("Ground")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Ground"), Content.Load<Texture2D>("Ground"))),
                new Vector2(270, -100), new Vector2(690, 600), Color.White);
                
            

            jakeRoof = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Roof"), Content.Load<Texture2D>("Roof")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Roof"), Content.Load<Texture2D>("Roof"))),
                new Vector2(270, -100), new Vector2(1000, 1000), Color.White);


            jakeJumperBackround = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Jake Jumper Backround"), Content.Load<Texture2D>("Jake Jumper Backround"))),
                new Vector2(0, 0), new Vector2(0, 0), Color.White);

            jakeJumperBackround.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f); 

             */

            jakeJumperBack = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBR"), Content.Load<Texture2D>("JakeJBR")),
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBR"), Content.Load<Texture2D>("JakeJBR"))),
                new Vector2(0, 0), new Vector2(0, 0), Color.White);
            jakeJumperBack.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);

            jakeJumperBack2 = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBR"), Content.Load<Texture2D>("JakeJBR")),
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBR"), Content.Load<Texture2D>("JakeJBR"))),
                new Vector2(0, 0), new Vector2(0, 0), Color.White);
            jakeJumperBack2.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);





            jakeJumperRoof = new Sprite(new ThemeTextureSet(
                       new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRroof"), Content.Load<Texture2D>("JakeJBRroof")),
                       new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRroof"), Content.Load<Texture2D>("JakeJBRroof"))),
                       new Vector2(0, 0), new Vector2(800, 450), Color.White);
            jakeJumperRoof.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);

            jakeJumperRoof2 = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRroof"), Content.Load<Texture2D>("JakeJBRroof")),
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRroof"), Content.Load<Texture2D>("JakeJBRroof"))),
                new Vector2(0, 0), new Vector2(800, 450), Color.White);
            jakeJumperRoof2.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);



            jakeJumperFloor = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRfloor"), Content.Load<Texture2D>("JakeJBRfloor")),
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRfloor"), Content.Load<Texture2D>("JakeJBRfloor"))),
                new Vector2(0, 0), new Vector2(800, 450), Color.White);
            jakeJumperFloor.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);

            jakeJumperFloor2 = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRfloor"), Content.Load<Texture2D>("JakeJBRfloor")),
                new QualityControlTexture2D(Content.Load<Texture2D>("JakeJBRfloor"), Content.Load<Texture2D>("JakeJBRfloor"))),
                new Vector2(0, 0), new Vector2(800, 450), Color.White);
            jakeJumperFloor2.Size = new Vector2(GraphicsDevice.Viewport.Width * 2, GraphicsDevice.Viewport.Height * 1.5f);





            play = new Sprite(new ThemeTextureSet(
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play")),
                new QualityControlTexture2D(Content.Load<Texture2D>("Play"), Content.Load<Texture2D>("Play"))),
                new Vector2(470,280), new Vector2(290,250), Color.White);

            jakeJumperRoof2.Position = new Vector2(jakeJumperRoof.Position.X + jakeJumperRoof.ImageSet.CurrentImage.Width * 2, jakeJumperRoof2.Position.Y);
            jakeJumperFloor2.Position = new Vector2(jakeJumperFloor.Position.X + jakeJumperFloor.ImageSet.CurrentImage.Width * 2, jakeJumperFloor2.Position.Y);
            jakeJumperBack2.Position = new Vector2(jakeJumperBack.Position.X + jakeJumperBack.ImageSet.CurrentImage.Width * 2, jakeJumperBack2.Position.Y);

            //Move both backgrounds towards the left or right at a certain speed (low amount)

            //Use an if statement and check if the right side of either backgrounds hits 0, move that background's x to GraphicsDevice.Viewport.Width

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

            if (jakeJumperFloor.Position.X + (jakeJumperFloor.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperFloor.Position.X = jakeJumperFloor2.Position.X + jakeJumperFloor2.ImageSet.CurrentImage.Width * 2;
            }

            if (jakeJumperFloor2.Position.X + (jakeJumperFloor2.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperFloor2.Position.X = jakeJumperFloor.Position.X + jakeJumperFloor.ImageSet.CurrentImage.Width * 2;
            }

            if (jakeJumperRoof.Position.X + (jakeJumperRoof.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperRoof.Position.X = jakeJumperRoof2.Position.X + jakeJumperRoof2.ImageSet.CurrentImage.Width * 2;
            }

            if (jakeJumperRoof2.Position.X + (jakeJumperRoof2.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperRoof2.Position.X = jakeJumperRoof.Position.X + jakeJumperRoof.ImageSet.CurrentImage.Width * 2;
            }



            if (jakeJumperBack.Position.X + (jakeJumperBack.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperBack.Position.X = jakeJumperBack2.Position.X + jakeJumperBack2.ImageSet.CurrentImage.Width * 2;
            }

            if (jakeJumperBack2.Position.X + (jakeJumperBack2.ImageSet.CurrentImage.Width * 2) <= 0)
            {
                jakeJumperBack2.Position.X = jakeJumperBack.Position.X + jakeJumperBack.ImageSet.CurrentImage.Width * 2;
            }



            //dropText.Update(gameTime);          
            jakeJumperFloor.Position.X-=4;
            jakeJumperRoof.Position.X -=4;
            jakeJumperFloor2.Position.X-=4;
            jakeJumperRoof2.Position.X-=4;
            jakeJumperBack.Position.X-=1;
            jakeJumperBack2.Position.X-=1;

            base.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //jakeJumperBackround.Draw(spriteBatch);
            //jakeGround.Draw(spriteBatch);

            jakeJumperBack.Draw(spriteBatch);
            jakeJumperBack2.Draw(spriteBatch);

            jakeJumperFloor.Draw(spriteBatch);
            jakeJumperFloor2.Draw(spriteBatch);

            jakeJumperRoof.Draw(spriteBatch);
            jakeJumperRoof2.Draw(spriteBatch);

            jakeJumperLogo.Draw(spriteBatch);
            play.Draw(spriteBatch);

            //dropText.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(spriteBatch);
        }



    }
}
