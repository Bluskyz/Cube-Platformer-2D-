using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace JakeJumper
{
    public class ThemeTextureSet
    {
        public Texture2D CurrentImage
        {
            get
            {
                return themeSet[Settings.Theme].CurrentImage;
            }
        }

        private Dictionary<Theme, QualityControlTexture2D> themeSet = new Dictionary<Theme, QualityControlTexture2D>();

        public ThemeTextureSet(QualityControlTexture2D simple, QualityControlTexture2D medieval)
        {
            themeSet.Add(Theme.Simple, simple);
            themeSet.Add(Theme.Medieval, medieval);
        }
    }

    public static class ThemeTextureSets
    {
        public static Dictionary<BlockType, ThemeTextureSet> Sets = new Dictionary<BlockType, ThemeTextureSet>();

        public static void Initialize(ContentManager Content)
        {
            Sets.Add(BlockType.Background,
                   new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Biege"), Content.Load<Texture2D>("Biege")),
                                       new QualityControlTexture2D(Content.Load<Texture2D>("Background Brick"), Content.Load<Texture2D>("Background Brick"))));
            Sets.Add(BlockType.Terrian,
                    new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Red"), Content.Load<Texture2D>("Red")),
                                        new QualityControlTexture2D(Content.Load<Texture2D>("Stone"), Content.Load<Texture2D>("Stone"))));
            Sets.Add(BlockType.DetailTerrian,
                       new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Detail"), Content.Load<Texture2D>("Detail")),
                                           new QualityControlTexture2D(Content.Load<Texture2D>("Metal"), Content.Load<Texture2D>("Metal"))));
            Sets.Add(BlockType.Lava,
                   new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Lava"), Content.Load<Texture2D>("Lava")),
                                       new QualityControlTexture2D(Content.Load<Texture2D>("Lava"), Content.Load<Texture2D>("Lava"))));
            Sets.Add(BlockType.Character,
                    new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Blue"), Content.Load<Texture2D>("Blue")),
                                        new QualityControlTexture2D(Content.Load<Texture2D>("Face#1"), Content.Load<Texture2D>("Face#1"))));
            Sets.Add(BlockType.Spike,
                    new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Spikes"), Content.Load<Texture2D>("Spikes")),
                                        new QualityControlTexture2D(Content.Load<Texture2D>("Spikes"), Content.Load<Texture2D>("Spikes"))));
            Sets.Add(BlockType.HangingObject,
                       new ThemeTextureSet(new QualityControlTexture2D(Content.Load<Texture2D>("Chain"), Content.Load<Texture2D>("Chain")),
                                           new QualityControlTexture2D(Content.Load<Texture2D>("Chain"), Content.Load<Texture2D>("Chain"))));
        }
    }
}
