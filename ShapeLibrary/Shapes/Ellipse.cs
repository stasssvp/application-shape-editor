using System;
using System.Drawing;

namespace ShapeLibrary.Shapes
{
    public class Ellipse : Shape
    {
        public Point Center;
        private int _radiusX;
        private int _radiusY;

        public int RadiusX
        {
            get { return _radiusX; }
            set
            {
                if (value <= 0) throw new ArgumentException("Радиусът трябва да бъде положителено число.");
                _radiusX = value;
            }
        }

        public int RadiusY
        {
            get { return _radiusY; }
            set
            {
                if (value <= 0) throw new ArgumentException("Радиусът трябва да бъде положителено число.");
                _radiusY = value;
            }
        }

        public Ellipse(Color fillColor, Color outlineColor, Point center, int radiusX, int radiusY)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;
        }

        public override double GetArea() => Math.PI * RadiusX * RadiusY;

        public override bool ContainsPoint(Point point)
        {
            double nx = (point.X - Center.X) / (double)RadiusX;
            double ny = (point.Y - Center.Y) / (double)RadiusY;

            return (nx * nx) + (ny * ny) <= 1; // Уравнение на елипса: (x²/a²) + (y²/b²) ≤ 1
        }

        public override void Move(int deltaX, int deltaY) => Center = new Point(Center.X + deltaX, Center.Y + deltaY);

        public override Shape Copy()
        {
            var copy = new Ellipse(this.FillColor, this.OutlineColor, new Point(this.Center.X, this.Center.Y), this.RadiusX, this.RadiusY);
            copy.OutlineWidth = this.OutlineWidth;
            return copy;
        }

        public override void Draw(Graphics graphics)
        {
            using (var fillBrush = new SolidBrush(FillColor)) graphics.FillEllipse(fillBrush, Center.X - RadiusX, Center.Y - RadiusY, 2 * RadiusX, 2 * RadiusY);

            using (var outlinePen = new Pen(OutlineColor, OutlineWidth)) graphics.DrawEllipse(outlinePen, Center.X - RadiusX, Center.Y - RadiusY, 2 * RadiusX, 2 * RadiusY);
        }
    }
}