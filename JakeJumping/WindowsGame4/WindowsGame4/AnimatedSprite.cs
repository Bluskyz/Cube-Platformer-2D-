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
    public class AnimatedSprite : Sprite
    {
        protected List<Rectangle> _frames;
        private int _index;

        public TimeSpan FramesPerSecond;
        private TimeSpan _elapsedFrameTime;
        public bool IsAnimating = true;

        public AnimatedSprite(ThemeTextureSet image, Vector2 position, Vector2 size, Color tint)
            :base(image, position, size, tint)
        {
            _index = 0;
            _frames = new List<Rectangle>();

            _elapsedFrameTime = TimeSpan.Zero;
            FramesPerSecond = TimeSpan.FromMilliseconds(45);
        }

        public void AddFrame(Rectangle frame)
        {
            _frames.Add(frame);
        }

        public override void Update(GameTime gameTime)
        {
            if (IsAnimating)
            {
                _elapsedFrameTime += gameTime.ElapsedGameTime;
                if (_elapsedFrameTime >= FramesPerSecond)
                {
                    _elapsedFrameTime = TimeSpan.Zero;

                    _index++;
                    if (_index >= _frames.Count)
                    {
                        _index = 0;
                        IsAnimating = false;
                        IsVisible = false;
                    }

                   // sourceRectangle = _frames[_index];
                }
            }

            base.Update(gameTime);
        }
    }
}
