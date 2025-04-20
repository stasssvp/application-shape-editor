using System;
using System.Linq;
using System.Drawing;
using ShapeLibrary.Shapes;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GraphicShapesCoursework
{
    public partial class DrawingForm : Form
    {
        public Action<Shape> OnShapeSelected { get; set; }
        public Action OnHideShapeFields { get; set; }

        public List<Shape> ShapesToDraw { get; set; } = new List<Shape>();
        public Shape SelectedShape { get; set; }

        private bool isDragging = false;
        private bool isResizing = false;

        private int selectedTrianglePoint = -1;
        private int previousMouseX, previousMouseY;

        private const int Grip = 8;
        private const int MinSize = 10;

        public DrawingForm()
        {
            InitializeComponent();

            // стартов размер на формата
            Width = 700;
            Height = 700;       

            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            MouseUp += MainForm_MouseUp;

            FormClosing += (s, e) => e.Cancel = true; // предотвратява затварянето на формата
        }

        public void SetShapes(List<Shape> newShapes)
        {
            ShapesToDraw = newShapes;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            DrawGrid(g);

            foreach (var shape in ShapesToDraw.Where(s => s != SelectedShape)) shape.Draw(g);

            if (SelectedShape != null && ShapesToDraw.Contains(SelectedShape))
            {
                SelectedShape.Draw(g);
                DrawResizeHandle(g);
            }
        }

        private void DrawGrid(Graphics g)
        {
            int gridSize = 40; // Размер на едно квадратче

            //  Намира центъра на формата
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            using (Pen gridPen = new Pen(Color.LightGray, 1))

            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                // Чертае вертикални линии от центъра надясно и наляво
                for (int i = centerX; i <= this.ClientSize.Width; i += gridSize)
                    g.DrawLine(gridPen, i, 0, i, this.ClientSize.Height);
                for (int i = centerX; i >= 0; i -= gridSize)
                    g.DrawLine(gridPen, i, 0, i, this.ClientSize.Height);

                // Чертае хоризонтални линии от центъра надолу и нагоре
                for (int i = centerY; i <= this.ClientSize.Height; i += gridSize)
                    g.DrawLine(gridPen, 0, i, this.ClientSize.Width, i);
                for (int i = centerY; i >= 0; i -= gridSize)
                    g.DrawLine(gridPen, 0, i, this.ClientSize.Width, i);

                g.DrawLine(axisPen, centerX, 0, centerX, this.ClientSize.Height); // чертае вертикалната ос
                g.DrawLine(axisPen, 0, centerY, this.ClientSize.Width, centerY); // чертае хоризонталната ос
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedShape != null && IsMouseOnResizeHandle(e.Location))
            {
                StartResizing(e);
                return;
            }

            SelectedShape = FindShapeAt(e.Location);

            if (SelectedShape != null)
            {
                if (IsMouseOnResizeHandle(e.Location)) StartResizing(e);
                else StartDragging(e);

                OnShapeSelected?.Invoke(SelectedShape);
            }
            else CancelSelection();

            Invalidate();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedShape == null) return;

            UpdateCursor(e.Location);

            if (isDragging) MoveSelectedShape(e);

            else if (isResizing)
            {
                ResizeSelectedShape(e.Location);
                Invalidate();
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedShape = FindShapeAt(e.Location);

            if (SelectedShape == null) CancelSelection();

            Invalidate();
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            isResizing = false;
        }

        private Shape FindShapeAt(Point location) => ShapesToDraw.FirstOrDefault(shape => shape.ContainsPoint(location) && shape != SelectedShape);

        private void StartDragging(MouseEventArgs e)
        {
            isDragging = true;
            isResizing = false;
            previousMouseX = e.X;
            previousMouseY = e.Y;
        }

        private void StartResizing(MouseEventArgs e)
        {
            isResizing = true;
            isDragging = false;
            previousMouseX = e.X;
            previousMouseY = e.Y;
        }

        private void CancelSelection()
        {
            SelectedShape = null;
            isDragging = false;
            isResizing = false;
            OnHideShapeFields?.Invoke();
        }

        private void MoveSelectedShape(MouseEventArgs e)
        {
            if (!isDragging || SelectedShape == null) return;

            int dx = e.X - previousMouseX;
            int dy = e.Y - previousMouseY;

            if (dx != 0 || dy != 0)
            {
                SelectedShape.Move(dx, dy);
                previousMouseX = e.X;
                previousMouseY = e.Y;
                Invalidate();
            }
        }

        private void UpdateCursor(Point location)
        {
            if(SelectedShape != null && IsMouseOnResizeHandle(location)) Cursor = Cursors.SizeNWSE;
            else if (ShapesToDraw.Any(shape => shape.ContainsPoint(location))) Cursor = Cursors.Hand;
            else Cursor = Cursors.Default;
        }

        public void DrawResizeHandle(Graphics g)
        {
            void DrawHandle(Graphics gr, int x, int y) => gr.FillRectangle(Brushes.ForestGreen, x - Grip / 2, y - Grip / 2, Grip, Grip);

            switch (SelectedShape)
            {
                case Square s:
                    DrawHandle(g, s.PositionX + s.SideLength, s.PositionY + s.SideLength);
                    break;
                case ShapeLibrary.Shapes.Rectangle r:
                    DrawHandle(g, r.PositionX + r.Width, r.PositionY + r.Length);
                    break;
                case Triangle t:
                    DrawHandle(g, t.PointA.X, t.PointA.Y);
                    DrawHandle(g, t.PointB.X, t.PointB.Y);
                    DrawHandle(g, t.PointC.X, t.PointC.Y);
                    break;
                case Circle c:
                    DrawHandle(g, c.Center.X + c.Radius, c.Center.Y + c.Radius);
                    break;
                case Ellipse e:
                    DrawHandle(g, e.Center.X + e.RadiusX, e.Center.Y + e.RadiusY);
                    break;
            }
        }

        private void ResizeSelectedShape(Point mouseLocation)
        {
            if (SelectedShape == null) return;

            switch (SelectedShape)
            {
                case Square s:
                    s.SideLength = Math.Max(MinSize, mouseLocation.X - s.PositionX);
                    break;
                case ShapeLibrary.Shapes.Rectangle r:
                    r.Width = Math.Max(MinSize, mouseLocation.X - r.PositionX);
                    r.Length = Math.Max(MinSize, mouseLocation.Y - r.PositionY);

                    if (r.Width == r.Length)
                    {
                        MessageBox.Show("Страните не могат да бъдат равни!\nМоля, ръчно оразмерете една от тях.",
                                        "Вниамние", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                case Triangle t:
                    var newPoint = new Point(mouseLocation.X, mouseLocation.Y);

                    switch (selectedTrianglePoint)
                    {
                        case 0: t.PointA = newPoint; break;
                        case 1: t.PointB = newPoint; break;
                        case 2: t.PointC = newPoint; break;
                    }
                    break;
                case Circle c:
                    int dx = mouseLocation.X - c.Center.X;
                    int dy = mouseLocation.Y - c.Center.Y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    c.Radius = Math.Max(MinSize, (int)distance);
                    break;
                case Ellipse e:
                    dx = mouseLocation.X - e.Center.X;
                    dy = mouseLocation.Y - e.Center.Y;

                    double distanceX = Math.Abs(dx);
                    double distanceY = Math.Abs(dy);

                    e.RadiusX = Math.Max(MinSize, (int)distanceX);
                    e.RadiusY = Math.Max(MinSize, (int)distanceY);

                    if (e.RadiusX == e.RadiusY)
                    {
                        MessageBox.Show("Радиусите не могат да бъдат равни!\nМоля, ръчно оразмерете единия от тях.",
                                        "Вниамние", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }
        }

        private bool IsMouseOnResizeHandle(Point mouseLocation)
        {
            if (SelectedShape == null) return false;

            if (SelectedShape is Square s) return IsInsideGrip(mouseLocation, s.PositionX + s.SideLength - Grip / 2, s.PositionY + s.SideLength - Grip / 2);
            else if (SelectedShape is ShapeLibrary.Shapes.Rectangle r) return IsInsideGrip(mouseLocation, r.PositionX + r.Width - Grip / 2, r.PositionY + r.Length - Grip / 2);
            else if (SelectedShape is Triangle t)
            {
                var points = new[] { t.PointA, t.PointB, t.PointC };
                for (int i = 0; i < points.Length; i++)
                {
                    int handleX = points[i].X - Grip / 2;
                    int handleY = points[i].Y - Grip / 2;

                    if (IsInsideGrip(mouseLocation, handleX, handleY))
                    {
                        selectedTrianglePoint = i;
                        return true;
                    }
                }
                return false;
            }
            else if (SelectedShape is Circle c) return IsInsideGrip(mouseLocation, c.Center.X + c.Radius - Grip / 2, c.Center.Y + c.Radius - Grip / 2);
            else if (SelectedShape is Ellipse e) return IsInsideGrip(mouseLocation, e.Center.X + e.RadiusX - Grip / 2, e.Center.Y + e.RadiusY - Grip / 2);

            return false;
        }

        // Проверява дали курсорът е върху на grip-a
        private bool IsInsideGrip(Point p, int x, int y) => p.X >= x && p.X <= x + Grip && p.Y >= y && p.Y <= y + Grip;
    }
}