using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame.src
{
    public class Button : Shape
    {
        public Button(string thing) : base (thing)
        {
            _thing = thing;
        }
    }
}
