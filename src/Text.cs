using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Text : Rectangle
    {
        //fields
        private string _content;
        private Font _theFont;
        private Color _fontColor;
        //constructors
        public Text (Color fontcolor, string text, Font font) : base ()
        {
            _fontColor = fontcolor;
            _theFont = font;
            _content = text;
        }
        public Text (Color boxcolor, float x, float y, int w, int h, Color fontcolor, string text, Font font) : this (fontcolor,text,font)
        {
            Color = boxcolor;
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
        public Text (Color boxcolor, float x, float y, Color fontcolor, string text) : this (boxcolor,x,y,50,50,fontcolor,text,SwinGame.LoadFont("Arial",20))
        { 
        }
        public Text () : this (Color.White,0,0,Color.Black,"")
        {
        }
        //properties
        public string Content { get => _content; set => _content = value; }
        public Font TheFont { get => _theFont; set => _theFont = value; }
        public Color FontColor { get => _fontColor; set => _fontColor = value; }
        //methods
        public override void Draw()
        {
            base.Draw();
            SwinGame.DrawText(_content, _fontColor, X + 5, Y + 5);
        }
    }
}
