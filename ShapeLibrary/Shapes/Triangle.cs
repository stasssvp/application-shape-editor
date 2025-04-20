using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShapeLibrary.Shapes
{
    public class Triangle : Shape
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }

        private int _sideAB;
        private int _sideBC;
        private int _sideCA;

        public int SideAB
        {
            get => _sideAB;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Страната AB трябва да е положителна!");
                _sideAB = value;
            }
        }

        public int SideBC
        {
            get => _sideBC;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Страната BC трябва да е положителна!");
                _sideBC = value;
            }
        }

        public int SideCA
        {
            get => _sideCA;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Страната CA трябва да е положителна!");
                _sideCA = value;
            }
        }

        public Triangle(Color fillColor, Color outlineColor, Point a, Point b, Point c)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            PointA = a;
            PointB = b;
            PointC = c;
        }

        public override double GetArea()
        {
            double p = (SideAB + SideBC + SideCA) / 2.0; // полупериметър
            return Math.Sqrt(p * (p - SideAB) * (p - SideBC) * (p - SideCA));
        }

        public override bool ContainsPoint(Point point)
        {
            double areaTotal = Math.Abs(
                (PointB.X - PointA.X) * (PointC.Y - PointA.Y) -
                (PointC.X - PointA.X) * (PointB.Y - PointA.Y)) / 2;

            double area1 = Math.Abs(
                (point.X - PointB.X) * (PointC.Y - PointB.Y) -
                (PointC.X - PointB.X) * (point.Y - PointB.Y)) / 2;

            double area2 = Math.Abs(
                (PointA.X - point.X) * (PointC.Y - point.Y) -
                (PointC.X - point.X) * (PointA.Y - point.Y)) / 2;

            double area3 = Math.Abs(
                (PointA.X - PointB.X) * (point.Y - PointB.Y) -
                (point.X - PointB.X) * (PointA.Y - PointB.Y)) / 2;

            return Math.Abs(areaTotal - (area1 + area2 + area3)) < 0.0001;
        }

        public void UpdatePoints()
        {
            int oldCenterX = (PointA.X + PointB.X + PointC.X) / 3;
            int oldCenterY = (PointA.Y + PointB.Y + PointC.Y) / 3;

            // Строим новия триъгълник с AB по оста X, A в (0,0), B в (AB, 0)
            PointA = new Point(0, 0);
            PointB = new Point(SideAB, 0);

            // Косинусовото правило за намиране на координатите на точка C
            double cosC = (SideAB * SideAB + SideCA * SideCA - SideBC * SideBC) / (2.0 * SideAB * SideCA);
            double angleC = Math.Acos(cosC);

            double cx = SideCA * Math.Cos(angleC);
            double cy = SideCA * Math.Sin(angleC);

            PointC = new Point((int)Math.Round(cx), (int)Math.Round(cy));

            int newCenterX = (PointA.X + PointB.X + PointC.X) / 3;
            int newCenterY = (PointA.Y + PointB.Y + PointC.Y) / 3;

            int dx = oldCenterX - newCenterX;
            int dy = oldCenterY - newCenterY;

            PointA = new Point(PointA.X + dx, PointA.Y + dy);
            PointB = new Point(PointB.X + dx, PointB.Y + dy);
            PointC = new Point(PointC.X + dx, PointC.Y + dy);

            // ако ъгълът АСВ е надолу, завърти триъгълника
            if (PointC.Y > PointA.Y && PointC.Y > PointB.Y)
            {
                PointA = new Point(2 * oldCenterX - PointA.X, 2 * oldCenterY - PointA.Y);
                PointB = new Point(2 * oldCenterX - PointB.X, 2 * oldCenterY - PointB.Y);
                PointC = new Point(2 * oldCenterX - PointC.X, 2 * oldCenterY - PointC.Y);
            }
        }

        public override void Move(int dx, int dy)
        {
            PointA = new Point(PointA.X + dx, PointA.Y + dy);
            PointB = new Point(PointB.X + dx, PointB.Y + dy);
            PointC = new Point(PointC.X + dx, PointC.Y + dy);
        }

        public override Shape Copy()
        {
            var copy = new Triangle(
                this.FillColor,
                this.OutlineColor,
                new Point(this.PointA.X, this.PointA.Y),
                new Point(this.PointB.X, this.PointB.Y),
                new Point(this.PointC.X, this.PointC.Y)
            );
            copy.OutlineWidth = this.OutlineWidth;
            return copy;
        }

        public Point GetCenter()
        {
            int centerX = (PointA.X + PointB.X + PointC.X) / 3;
            int centerY = (PointA.Y + PointB.Y + PointC.Y) / 3;

            return new Point(centerX, centerY);
        }

        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var brush = new SolidBrush(FillColor))
            {
                Point[] points = { PointA, PointB, PointC };
                g.FillPolygon(brush, points);
            }

            using (var pen = new Pen(OutlineColor, OutlineWidth))
            {
                Point[] points = { PointA, PointB, PointC };
                g.DrawPolygon(pen, points);
            }
        }
    }
}