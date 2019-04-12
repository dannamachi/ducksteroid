using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.src
{
    public class Shape
    {
        private string _thing;
        public Shape (string thing)
        {
            _thing = thing;
        }
        public string Thing { get => _thing; }
    }
}
