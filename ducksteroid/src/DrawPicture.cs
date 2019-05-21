using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    class DrawPicture
    {
        private List<Bitmap> _pics;
        private int _x;
        private int _y;
        private Bitmap _pic;

        public DrawPicture(Bitmap pic, int X, int Y)
        {
            _y = Y;
            _x = X;
            _pic = pic;
        }
    
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

        public Bitmap Image
        {
            get => _pic;
            set => _pic = value;
        }
        public void AddPic(Bitmap F)
        {
            if (_pic != null)
            {
                _pics.Add(F);
            }
        }
        public void DrawIt()
        {
            SwinGame.DrawBitmap(_pic, _x, _y);

        }
        public bool IsAt(Point2D pt)
        {
           return SwinGame.PointOnScreen(pt);
        }
 
    }
}
