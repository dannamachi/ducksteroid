using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Drawing
    {
        //fields
        private List<Shape> _shapes;
        private Bitmap _background;
        //constructors
        public Drawing(Bitmap bkground)
        {
            _shapes = new List<Shape>();
            _background = bkground;
        }
        public Drawing() : this(new Bitmap(1,1))
        {
        }
        //properties
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape sh in _shapes)
                {
                    if (sh.Selected)
                        result.Add(sh);
                }
                return result;
            }
        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public Bitmap Background
        {
            get => _background;
            set => _background = value;
        }
        //methods
        public void Draw()
        {
            foreach (Shape sh in _shapes)
            {
                sh.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape sh in _shapes)
            {
                if (sh.IsAt(pt))
                    sh.Selected = true;
            }
        }
        public void AddShape(Shape s)
        {
            if (s != null)
                _shapes.Add(s);
        }
    }
}
