using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Text : Shape
    {
        //fields
        private string text;
        private Font theFont;
        private Rectangle box;
        //constructors
        public Text (string stuff, Color color, Font font, int x, int y) : base ()
        {
            box = new Rectangle();
            theFont = font;
            text = stuff;
        }
        public Text () : this ("",)
        //properties
        //methods
    }
}
