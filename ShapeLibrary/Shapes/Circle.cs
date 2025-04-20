using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShapeLibrary.Shapes
{
    public class Circle : Shape
    {
        private int _radius;
        public Point Center;

        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0) throw new ArgumentException("Радиусът трябва да бъде положителено число.");
                _radius = value;
            }
        }

        public Circle(Color fillColor, Color outlineColor, Point center, int radius)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            Center = center;
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;

        public override bool ContainsPoint(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2));

            return distance <= Radius;
        }

        public override void Move(int dx, int dy) => Center = new Point(Center.X + dx, Center.Y + dy);

        public override Shape Copy()
        {
            var copy = new Circle(this.FillColor, this.OutlineColor, new Point(this.Center.X, this.Center.Y), this.Radius);
            copy.OutlineWidth = this.OutlineWidth;
            return copy;
        }

        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var outlinePen = new Pen(OutlineColor, OutlineWidth)) g.DrawEllipse(outlinePen, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            using (var fillBrush = new SolidBrush(FillColor)) g.FillEllipse(fillBrush, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
}