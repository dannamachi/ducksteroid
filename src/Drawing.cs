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
        private List<Shape> shapes;
        private Bitmap background;
        //constructors
        public Drawing(Bitmap bkground)
        {
            shapes = new List<Shape>();
            background = bkground;
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
                foreach (Shape sh in shapes)
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
                return shapes.Count;
            }
        }
        public Bitmap Background
        {
            get => background;
            set => background = value;
        }
        //methods
        public void Draw()
        {
            foreach (Shape sh in shapes)
            {
                sh.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape sh in shapes)
            {
                if (sh.IsAt(pt))
                    sh.Selected = true;
            }
        }
        public void AddShape(Shape s)
        {
            if (s != null)
                shapes.Add(s);
        }
    }
}
