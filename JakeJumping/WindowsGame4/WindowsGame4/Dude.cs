﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JakeJumper
{
    public class Dude : Sprite
    {
        KeyboardState _lastks;
        private float _moveSpeed = .20f;
        float YMovement = 0;
        
        public bool canJump = false;

        int jumpCount = 0;

        float gravity = .05f;
        float jumpPower = .5f;


        public Dude(ThemeTextureSet image, Vector2 position, Vector2 size, Color tint)
            : base(image, position, size, tint)
        {
            Layer = .5f;
        }

        public void Update(GameTime gameTime, KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.Right))
            {
                SpriteEffects = SpriteEffects.None;
                int newX = (int)(Position.X + 1 + _moveSpeed);

                Tile tileTopRight = GameScreen.mapTiles[new Vector2(newX, (int)(Position.Y + .01f))];
                Tile tileBottomRight = GameScreen.mapTiles[new Vector2(newX, (int)(Position.Y - .01f) + 1)];

                if ((tileTopRight.BlockType == BlockType.Background || tileTopRight.BlockType == BlockType.HangingObject || tileTopRight.BlockType == BlockType.Backdrop || tileTopRight.BlockType == BlockType.Grass|| tileTopRight.BlockType == BlockType.DetailTerrian) &&
                    (tileBottomRight.BlockType == BlockType.Background || tileBottomRight.BlockType == BlockType.HangingObject || tileBottomRight.BlockType == BlockType.Backdrop || tileTopRight.BlockType == BlockType.Grass|| tileBottomRight.BlockType == BlockType.DetailTerrian))
                {
                    Position.X += _moveSpeed;
                }
                else
                {
                    Position.X = newX - 1;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                SpriteEffects = SpriteEffects.FlipHorizontally;
                int newX = (int)(Position.X - _moveSpeed);

                Tile tileTopLeft = GameScreen.mapTiles[new Vector2(newX, (int)(Position.Y + .01f))];
                Tile tileBottomLeft = GameScreen.mapTiles[new Vector2(newX, (int)(Position.Y - .01f) + 1)];

                if ((tileTopLeft.BlockType == BlockType.Background || tileTopLeft.BlockType == BlockType.HangingObject || tileTopLeft.BlockType == BlockType.Backdrop || tileTopLeft.BlockType == BlockType.Grass || tileTopLeft.BlockType == BlockType.DetailTerrian) &&
                    (tileBottomLeft.BlockType == BlockType.Background || tileBottomLeft.BlockType == BlockType.HangingObject || tileBottomLeft.BlockType == BlockType.Backdrop || tileBottomLeft.BlockType == BlockType.Grass || tileBottomLeft.BlockType == BlockType.DetailTerrian))
                {
                    Position.X -= _moveSpeed;
                }
                else
                {
                    Position.X = newX + 1;
                }
            }

            if (canJump && ks.IsKeyDown(Keys.Up) && _lastks.IsKeyUp(Keys.Up) && jumpCount < 2)
            {
                jumpCount++;
                YMovement = -jumpPower;
            }
            YMovement += gravity;

            YMovement = MathHelper.Clamp(YMovement, -.5f, .5f);



            if (YMovement > 0)
            {
                int newY = (int)(Position.Y + YMovement + 1);
                Tile tileLeftFloor = GameScreen.mapTiles[new Vector2((int)(Position.X), newY)];
                Tile tileRightFloor = GameScreen.mapTiles[new Vector2((int)(Position.X + 1), newY)];

                Tile tileBelow = GameScreen.mapTiles[new Vector2((int)Position.X, (int)(Math.Round(Position.Y + 0.99f)))];

                if (tileBelow.BlockType == BlockType.Spike)//tileLeftFloor.BlockType == BlockType.Spike || tileRightFloor.BlockType == BlockType.Spike)
                {
                    //Tile GameScreen.mapTiles[tileLeftFloor.Position + new Vector2(0, 0.01f)];
                    //die x_x
                    GameScreen.dead = true;
                    
                    
                }

                if ((tileLeftFloor.BlockType == BlockType.Background || tileLeftFloor.BlockType == BlockType.HangingObject || tileLeftFloor.BlockType == BlockType.Backdrop || tileLeftFloor.BlockType == BlockType.Grass || tileLeftFloor.BlockType == BlockType.DetailTerrian) &&
                    (tileRightFloor.BlockType == BlockType.Background || tileRightFloor.BlockType == BlockType.HangingObject || tileRightFloor.BlockType == BlockType.Backdrop || tileRightFloor.BlockType == BlockType.Grass || tileRightFloor.BlockType == BlockType.DetailTerrian))
                {
                    Position.Y += YMovement;

                }
                else
                {
                    Position.Y = newY - 1;
                    jumpCount = 0;
                    canJump = true;
                }


                
            }
            else
            {
                int newY = (int)(Position.Y + YMovement);
                Tile tileLeftCeiling = GameScreen.mapTiles[new Vector2((int)(Position.X), newY)];
                Tile tileRightCeiling = GameScreen.mapTiles[new Vector2((int)(Position.X + 1), newY)];


                if ((tileLeftCeiling.BlockType == BlockType.Background || tileLeftCeiling.BlockType == BlockType.HangingObject || tileLeftCeiling.BlockType == BlockType.Backdrop || tileLeftCeiling.BlockType == BlockType.Grass || tileLeftCeiling.BlockType == BlockType.DetailTerrian) &&
                    (tileRightCeiling.BlockType == BlockType.Background || tileRightCeiling.BlockType == BlockType.HangingObject || tileRightCeiling.BlockType == BlockType.Backdrop || tileRightCeiling.BlockType == BlockType.Grass || tileRightCeiling.BlockType == BlockType.DetailTerrian))
                {
                    Position.Y += YMovement;
                }
                else if (tileLeftCeiling.BlockType == BlockType.Spike || tileRightCeiling.BlockType == BlockType.Spike)
                {
                    //die
                }
                else
                {
                    Position.Y = newY + 1;
                }
            }

            base.Update(gameTime);
            _lastks = ks;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            /*
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X + 2 + _moveSpeed), (int)(Position.Y)),              null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height)/2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X + 2 + _moveSpeed), (int)(Position.Y) + 1),          null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height) / 2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);

            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X - _moveSpeed), (int)(Position.Y)),                  null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height)/2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X - _moveSpeed), (int)(Position.Y) + 1),              null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height)/2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
           
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X + 1), (int)(Position.Y + YMovement + 1)), null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height) / 2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X), (int)(Position.Y + YMovement + 1)), null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height) / 2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);

            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X + 1), (int)(Position.Y + YMovement)),                   null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height)/2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
            spriteBatch.Draw(imageSet.CurrentImage, new Vector2((int)(Position.X), (int)(Position.Y + YMovement)),                   null, Color.Red, 0f, new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height)/2, Vector2.One * .1f / new Vector2(ImageSet.CurrentImage.Width, ImageSet.CurrentImage.Height), SpriteEffects, Layer);
            */
        }
    }
}

/* private bool IsMoveAllowed()
 {
     Color[] moveToAreaData = new Color[(int)(_moveSpeed * HitBox.Width)];
     Rectangle dataRect = new Rectangle();

     if (_facingDirection == FacingDirection.Left)
     {
         //Position.X -= _moveSpeed;
         dataRect = new Rectangle((int)(Position.X - _moveSpeed), (int)Position.Y, (int)_moveSpeed, HitBox.Width);
     }
     else if (_facingDirection == FacingDirection.Right)
     {
         //Position.X += _moveSpeed;
         dataRect = new Rectangle((int)(Position.X + _moveSpeed), (int)Position.Y, (int)_moveSpeed, HitBox.Width);
     }

     try
     {
         //Game1.Map.Image.GetData<Color>(0, dataRect, moveToAreaData, 0, (int)_moveSpeed * HitBox.Width);
     }
     catch
     {
         return false;
     }

     bool moveAllowed = true;

     for (int i = 0; i < _moveSpeed * HitBox.Height; i++)
     {
         if (moveToAreaData[i] != Color.White)
         {
             moveAllowed = false;
             break;
         }
     }
     return moveAllowed;
 }

 private bool shouldCharacterFall()
 {
     //Gravity check
     Color[] fallArea = new Color[HitBox.Width];
     //Game1.Map.Image.GetData<Color>(0, new Rectangle((int)Position.X, (int)Position.Y + HitBox.Height, HitBox.Width, 1), fallArea, 0, HitBox.Width);

     bool shouldCharacterFall = true;
     //_jumpCompleted = true;

     foreach (Color pixel in fallArea)
     {
         if (pixel != Color.White)
         {
             shouldCharacterFall = false;
             //_groundLevel = Position.Y;
             //_jumpCompleted = false;
             //_isFreeFallMode = false;
         }
     }
     return shouldCharacterFall;
 }

 private int allowedJumpHeight(int maxJumpHeight, int characterWidth)
 {
     int allowedJump = 0;

     for (int i = 0; i < maxJumpHeight; i++)
     {
         Color[] jumpArea = new Color[characterWidth];

         try
         {
             //Game1.Map.Image.GetData<Color>(0, new Rectangle((int)Position.X, (int)Position.Y - i, characterWidth, 1), jumpArea, 0, characterWidth);
         }
         catch
         {
             return allowedJump;
         }

         bool isRowAllowed = true;

         foreach (Color pixel in jumpArea)
         {
             if (pixel != Color.White)
             {
                 isRowAllowed = false;
                 return allowedJump;
             }
         }

         if (isRowAllowed)
         {
             allowedJump++;
         }
         else if (!(isRowAllowed))
         {
             shouldCharacterFall();
         }
     }

     return allowedJump;
 }
}
}
 * 
 * /*if (Game1.mapTiles.ContainsKey(new Vector2((int)(Position.X + .01f), newY)))
                    {
                        if (Game1.mapTiles[new Vector2((int)(Position.X + .01f), newY)] is LavaTile)
                        {
                            Position.Y += YMovement;
                        }
                    }
                    else if (Game1.mapTiles.ContainsKey(new Vector2((int)(Position.X - .01f) + 1, newY)))
                    {
                        if (Game1.mapTiles[new Vector2((int)(Position.X - .01f) + 1, newY)] is LavaTile)
                        {
                            Position.Y += YMovement;
                        }
                    }
                    else
                    {*/

#region OldJumpCode
//if (ks.IsKeyDown(Keys.Up) && isGrounded && !JumpBlocked)
//{
//    isJumping = true;
//    isGrounded = false;
//}
//if (isJumping)
//{
//    elapsedJumpTime += gameTime.ElapsedGameTime;

//    if (elapsedJumpTime < jumpTime)
//    {
//        CurrentSpeed.Y = -MaxSpeed.Y;
//    }
//    else
//    {
//        elapsedJumpTime = TimeSpan.Zero;
//        isJumping = false;
//        CurrentSpeed.Y = MaxSpeed.Y;
//    }
//}
//else if (!isGrounded)
//{
//    //CurrentSpeed.Y = MaxSpeed.Y;
//}
//else
//{
//    CurrentSpeed.Y = 0;
//}
#endregion*/