using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace JakeJumper
{
    public class QualityControlTexture2D
    {
        public Texture2D CurrentImage
        {
            get
            {
                return qualityImages[Settings.Quality];
            }
        }

        private Dictionary<Quality, Texture2D> qualityImages = new Dictionary<Quality, Texture2D>();

        public QualityControlTexture2D(Texture2D low, Texture2D high)
        {
            qualityImages.Add(Quality.Low, low);
            qualityImages.Add(Quality.High, high);
        }
    }
}
