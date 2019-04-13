using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.src
{
    public class Shape
    {
        protected string _thing;
        public Shape(string thing)
        {
            _thing = thing;
        }
        public string Thing { get => _thing; }
    }
}
