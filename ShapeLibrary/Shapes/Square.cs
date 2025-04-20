using System.Drawing;

namespace ShapeLibrary.Shapes
{
    public class Square : Shape
    {
        private int _sideLength;

        public int SideLength
        {
            get { return _sideLength; }
            set
            {
                if (0 >= value) throw new System.ArgumentException("Дължината на страната трябва да бъде положителна.");
                _sideLength = value;
            }
        }

        public Square(Color fillColor, Color outlineColor, int positionX, int positionY, int sideLength)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            PositionX = positionX;
            PositionY = positionY;
            SideLength = sideLength;
        }

        public override double GetArea() => SideLength * SideLength;

        public override bool ContainsPoint(Point point) =>
            point.X >= PositionX && point.X <= PositionX + SideLength && point.Y >= PositionY && point.Y <= PositionY + SideLength;

        public override void Move(int dx, int dy)
        {
            PositionX += dx;
            PositionY += dy;
        }

        public override Shape Copy()
        {
            var copy = new Square(this.FillColor, this.OutlineColor, this.PositionX, this.PositionY, this.SideLength);
            copy.OutlineWidth = this.OutlineWidth; //
            return copy;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(FillColor)) g.FillRectangle(brush, PositionX, PositionY, SideLength, SideLength);
            using (Pen pen = new Pen(OutlineColor, OutlineWidth)) g.DrawRectangle(pen, PositionX, PositionY, SideLength, SideLength);
        }
    }
}