using System.Drawing;

namespace ShapeLibrary.Shapes
{
    public abstract class Shape
    {
        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }
        public float OutlineWidth { get; set; } = 1.5f;

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public abstract double GetArea();

        public abstract bool ContainsPoint(Point point);
        public abstract void Move(int dx, int dy);
        public abstract Shape Copy();

        public abstract void Draw(Graphics graphics);
    }
}