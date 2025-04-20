using System;
using System.Drawing;

namespace ShapeLibrary.Shapes
{
    public class Rectangle : Shape
    {
        private int _width;
        private int _length;

        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширината трябва да е положително число!");          
                _width = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Дължината трябва да е положително число!");             
                _length = value;
            }
        }

        public Rectangle(Color fillColor, Color outlineColor, int positionX, int positionY, int width, int length)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            PositionX = positionX;
            PositionY = positionY;
            Width = width;
            Length = length;
        }

        public override double GetArea() => Width * Length;

        public override bool ContainsPoint(Point point) => 
            point.X >= PositionX && point.X <= PositionX + Width && point.Y >= PositionY && point.Y <= PositionY + Length;

        public override void Move(int dx, int dy)
        {
            PositionX += dx;
            PositionY += dy;
        }

        public override Shape Copy()
        {
            var copy = new Rectangle(this.FillColor, this.OutlineColor, this.PositionX, this.PositionY, this.Width, this.Length);
            copy.OutlineWidth = this.OutlineWidth;
            return copy;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(FillColor)) g.FillRectangle(brush, PositionX, PositionY, Width, Length);
            using (Pen pen = new Pen(OutlineColor, OutlineWidth)) g.DrawRectangle(pen, PositionX, PositionY, Width, Length);
        }
    }
}