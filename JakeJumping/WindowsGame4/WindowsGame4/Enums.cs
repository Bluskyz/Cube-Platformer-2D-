using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JakeJumper
{
    public enum FacingDirection
    {
        Left,
        Right
    }

    public enum Quality
    {
        Low,
        High
    }

    public enum Theme
    {
        Simple,
        Medieval
    }

    public enum GameState
    {
        InGame,
        Menu,
        Pause
    }

    public enum BlockType
    {
        Background,
        Grass,
        Backdrop,
        Terrian,
        DetailTerrian,
        Lava,
        Character,
        Spike,
        HangingObject
    }
}
