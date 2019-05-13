using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    class Circle : Shape
    {
        private int _rad;
        private int _x;
        private int _y;
        public int X
        {
            get => _x;
            set => _x = value;
        }
        public int Y
        {
            get => _y;
            set => _y = value;
        }
        public int Rad { get => _rad; set => _rad = value; }

        public Circle() : this(Color.Yellow, 0, 0, 200)
        {

        }
        public Circle(Color A, int X, int Y, int R)
        {
            _x = X;
            _y = Y;
            _rad = R;
        }
        public override bool IsAt(Point2D pt)
        {
            bool select = SwinGame.PointInCircle(pt, _x, _y, _rad);
            return select;
        }
        public override void Draw()
        {
            SwinGame.FillCircle(Color.White, _x, _y, _rad);
        }
    }
}
