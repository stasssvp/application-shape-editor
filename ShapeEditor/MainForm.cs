using System;
using System.Linq;
using System.Text;
using System.Drawing;
using ShapeLibrary.Shapes;
using System.Windows.Forms;
using ShapeLibrary.Serialization;
using System.Collections.Generic;

namespace GraphicShapesCoursework
{
    public partial class MainForm : Form
    {
        public List<Shape> shapes = new List<Shape>();
        private Shape selectedShape = null;

        private readonly DrawingForm drawingForm;

        // Стойности по подразбиране
        private Color fillColor = Color.Transparent;
        private Color outlineColor = Color.Black;

        private readonly Stack<List<Shape>> undoStack = new Stack<List<Shape>>();
        private readonly Stack<List<Shape>> redoStack = new Stack<List<Shape>>();

        public MainForm()
        {
            InitializeComponent();

            Width = 550;
            Height = 400;

            InitializeControls();
            HideShapeFields(); // Скрива полетата (преди избор на фигура)

            drawingForm = new DrawingForm();

            drawingForm.ShapesToDraw = shapes;

            drawingForm.OnShapeSelected = (shape) =>
            {
                selectedShape = shape;
                ShowShapeFields(shape);
            };

            drawingForm.OnHideShapeFields = () => { HideShapeFields(); };

            drawingForm.Show();
        }

        private Dictionary<string, (Label lbl, TextBox txt)> formControls;

        private void InitializeControls()
        {
            formControls = new Dictionary<string, (Label, TextBox)>
        {
            { "SideLength", (lblSideLength, txtSideLength) },
            { "SideAB", (lblSideAB, txtSideAB) },
            { "SideBC", (lblSideBC, txtSideBC) },
            { "SideAC", (lblSideAC, txtSideAC) },
            { "Width", (lblWidth, txtWidth) },
            { "Height", (lblHeight, txtHeight) },
            { "Radius", (lblRadius, txtRadius) },
            { "RadiusY", (lblRadiusY, txtRadiusY) }
            };
        }

        public void HideShapeFields()
        {
            lblParameters.Visible = false;

            foreach (var i in formControls.Values)
            {
                i.lbl.Visible = false;
                i.txt.Visible = false;
            }
        }

        public void ShowShapeFields(Shape shape)
        {
            HideShapeFields();

            if (shape == null) return;

            lblParameters.Visible = true;

            if (shape is Square)
            {
                formControls["SideLength"].lbl.Visible = true;
                formControls["SideLength"].txt.Visible = true;
            }
            else if (shape is ShapeLibrary.Shapes.Rectangle)
            {
                formControls["Width"].lbl.Visible = true;
                formControls["Width"].txt.Visible = true;
                formControls["Height"].lbl.Visible = true;
                formControls["Height"].txt.Visible = true;
            }
            else if (shape is Triangle)
            {
                formControls["SideAB"].lbl.Visible = true;
                formControls["SideAB"].txt.Visible = true;
                formControls["SideBC"].lbl.Visible = true;
                formControls["SideBC"].txt.Visible = true;
                formControls["SideAC"].lbl.Visible = true;
                formControls["SideAC"].txt.Visible = true;
            }
            else if (shape is Circle)
            {
                formControls["Radius"].lbl.Visible = true;
                formControls["Radius"].txt.Visible = true;
            }
            else if (shape is Ellipse)
            {
                formControls["Radius"].lbl.Visible = true;
                formControls["Radius"].lbl.Text = "Radius X";
                formControls["Radius"].txt.Visible = true;
                formControls["RadiusY"].lbl.Visible = true;
                formControls["RadiusY"].txt.Visible = true;
            }
        }

        private bool IsShapeSelected()
        {
            if (selectedShape == null)
            {
                MessageBox.Show("Моля, първо изберете фигура.", "Няма избрана фигура", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            if (comboBoxShapes.SelectedItem == null)
            {
                IsShapeSelected();
                return;
            }

            // Генерира случайна позиция и размер на фигурата
            Random random = new Random();
            int x = drawingForm.ClientSize.Width / 2 + random.Next(-50, 50);
            int y = drawingForm.ClientSize.Height / 2 + random.Next(-50, 50);
            int defaultSize = 80 + random.Next(-10, 10);

            Shape newShape = CreateShape(comboBoxShapes.SelectedItem.ToString(), x, y, defaultSize);

            SaveCurrentState(); // Запазва текущото състояние преди добавяне на нова фигура

            shapes.Add(newShape);
            ShowShapeFields(newShape);

            UpdateDrawingForm();
        }

        private Shape CreateShape(string shapeType, int x, int y, int defaultSize)
        {
            Point location = new Point(x, y);

            switch (shapeType)
            {
                case nameof(Square):
                    return new Square(fillColor, outlineColor, x, y, defaultSize);
                case nameof(ShapeLibrary.Shapes.Rectangle):
                    return new ShapeLibrary.Shapes.Rectangle(
                        fillColor, outlineColor, x, y, defaultSize * 2, defaultSize);
                case nameof(Triangle):
                    return CreateTriangle(x, y, defaultSize);
                case nameof(Circle):
                    return new Circle(fillColor, outlineColor, location, defaultSize);
                case nameof(Ellipse):
                    return new Ellipse(fillColor, outlineColor, location, defaultSize, defaultSize / 2);
                default:
                    throw new ArgumentException($"Неизвестен тип фигура: {shapeType}");
            }
        }

        private Triangle CreateTriangle(int x, int y, int size)
        {
            return new Triangle(
                fillColor, outlineColor,
                new Point(x, y - size),
                new Point(x - size, y + size / 2),
                new Point(x + size, y + size));
        }

        private void UpdateDrawingForm()
        {
            if (drawingForm != null && !drawingForm.IsDisposed)
            {
                drawingForm.ShapesToDraw = new List<Shape>(shapes);
                drawingForm.Invalidate();
            }
        }

        private void ChangeColor(Action<Color> updateColor)
        {
            if (!IsShapeSelected()) return;

            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() != DialogResult.OK) return;

                SaveCurrentState();
                updateColor(colorDialog.Color);
                drawingForm.Invalidate();
            }
        }

        private void btnChangeFillColor_Click(object sender, EventArgs e)
        {
            ChangeColor(color => selectedShape.FillColor = color);
        }

        private void btnChangleOutlineColor_Click(object sender, EventArgs e)
        {
            ChangeColor(color => selectedShape.OutlineColor = color);
        }

        private void btnDeleteShape_Click(object sender, EventArgs e)
        {
            if (!IsShapeSelected()) return;

            SaveCurrentState();

            shapes.Remove(selectedShape);
            selectedShape = null;
            HideShapeFields();

            UpdateDrawingForm();
        }

        private void btnCalculateArea_Click(object sender, EventArgs e)
        {
            if (!IsShapeSelected()) return;

            try
            {
                double area = 0;

                switch (selectedShape)
                {
                    case Square square:
                        int sideLength = int.Parse(txtSideLength.Text);
                        square.SideLength = sideLength;
                        area = square.GetArea();
                        break;
                    case ShapeLibrary.Shapes.Rectangle rectangle:
                        int width = int.Parse(txtWidth.Text);
                        int length = int.Parse(txtHeight.Text);

                        rectangle.Width = width;
                        rectangle.Length = length;

                        area = rectangle.GetArea();
                        break;
                    case Triangle triangle:
                        triangle.SideAB = int.Parse(txtSideAB.Text);
                        triangle.SideBC = int.Parse(txtSideBC.Text);
                        triangle.SideCA = int.Parse(txtSideAC.Text);

                        if (!IsValidTriangle(triangle.SideAB, triangle.SideBC, triangle.SideCA))
                        {
                            MessageBox.Show("Въведените страни не образуват валиден триъгълник.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        area = triangle.GetArea();
                        break;
                    case Circle circle:
                        circle.Radius = int.Parse(txtRadius.Text);

                        area = circle.GetArea();
                        break;
                    case Ellipse ellipse:
                        ellipse.RadiusX = int.Parse(txtRadius.Text);
                        ellipse.RadiusY = int.Parse(txtRadiusY.Text);

                        area = ellipse.GetArea();
                        break;
                    default:
                        throw new InvalidOperationException("Неизвестен тип фигура.");
                }

                MessageBox.Show($"Лице: {area:F2} см\u00b2", "Информация за фигурата", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Моля, въведете чсислови стойности.", "Невалиден формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Възникна грешка: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidTriangle(int ab, int bc, int ca) => ab + bc > ca && ab + ca > bc && bc + ca > ab;

        private void UpdateShapeDimensions()
        {
            if (!IsShapeSelected()) return;

            try
            {
                if (selectedShape is Square square)
                {
                    int sideLength = int.Parse(txtSideLength.Text);
                    square.SideLength = sideLength;
                }
                else if (selectedShape is ShapeLibrary.Shapes.Rectangle rectangle)
                {
                    int width = int.Parse(txtWidth.Text);
                    int length = int.Parse(txtHeight.Text);

                    rectangle.Width = width;
                    rectangle.Length = length;
                }
                else if (selectedShape is Triangle triangle)
                {
                    if (!IsValidTriangle(int.Parse(txtSideAB.Text), int.Parse(txtSideBC.Text), int.Parse(txtSideAC.Text)))
                    {
                        MessageBox.Show("Въведените страни не образуват валиден триъгълник.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    triangle.SideAB = int.Parse(txtSideAB.Text);
                    triangle.SideBC = int.Parse(txtSideBC.Text);
                    triangle.SideCA = int.Parse(txtSideAC.Text);

                    triangle.UpdatePoints();
                }
                else if (selectedShape is Circle circle) circle.Radius = int.Parse(txtRadius.Text);
                else if (selectedShape is Ellipse ellipse)
                {
                    ellipse.RadiusX = int.Parse(txtRadius.Text);
                    ellipse.RadiusY = int.Parse(txtRadiusY.Text);
                }
                else throw new InvalidOperationException("Неизвестен тип фигура.");

                drawingForm.Invalidate();
            }
            catch (FormatException)
            {
                MessageBox.Show("Моля, въведете числови стойности.", "Невалиден формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Възникна грешка: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDimensions_Click(object sender, EventArgs e)
        {
            SaveCurrentState();
            UpdateShapeDimensions();
        }

        // TODO: Undo/Redo функционалност
        private List<Shape> CopyShapeCollection(List<Shape> originalList) => originalList.Select(shape => shape.Copy()).ToList();

        private void SaveCurrentState()
        {
            undoStack.Push(shapes.Select(shape => shape.Copy()).ToList());
            redoStack.Clear();
        }

        private void btnUndo_Click(object sender, EventArgs e) 
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(CopyShapeCollection(shapes));
                shapes = undoStack.Pop();
                UpdateDrawingForm();
            }
            else MessageBox.Show("Няма действие за отмяна.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRedo_Click(object sender, EventArgs e) 
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(CopyShapeCollection(shapes));
                shapes = redoStack.Pop();
                UpdateDrawingForm();
            }
            else MessageBox.Show("Няма действие за възстановяване.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Shape> GetShapes()
        {
            return shapes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    var shapes = GetShapes();
                    JsonSerializationService.SaveShapesToFile(filePath, shapes);
                    MessageBox.Show("Фигурите бяха успешно записани!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    shapes.Clear();

                    var loadedShapes = JsonSerializationService.LoadShapesFromFile(filePath);

                    shapes.AddRange(loadedShapes);
                    drawingForm.ShapesToDraw = shapes;
                    drawingForm.Invalidate();

                    MessageBox.Show("Фигурите бяха успешно заредени!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shapes.Count == 0) lblResult.Text = "Няма фигури на\nкoординатната система.";
            else
            {
                switch (cmbOperations.SelectedItem.ToString())
                {
                    case "Групирай по тип":
                        GroupShapesByType(shapes);
                        break;
                    case "Средна площ":
                        CalculateAverageArea();
                        break;
                    case "Най-голяма фигура":
                        FindLargestShapeByArea(shapes);
                        break;
                    case "Най-малка фигура":
                        FindSmallestShapeByArea(shapes);
                        break;
                }                       
            }
        }

        private void CalculateAverageArea()
        {
            double averageArea = shapes.Average(shape => shape.GetArea());
            lblResult.Text = $"Средна площ: {averageArea:F2} см²";
        }

        private void GroupShapesByType(List<Shape> shapes)
        {
            var groupedShapes = shapes.GroupBy(shape => shape.GetType().Name).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var i in groupedShapes) result.AppendLine($"{i.Key} (брой): {i.Count()}");

            lblResult.Text = result.ToString();
        }

        private void FindSmallestShapeByArea(List<Shape> shapes)
        {
            var smallestShape = shapes.OrderBy(shape => shape.GetArea()).FirstOrDefault();

            lblResult.Text = $"{smallestShape.GetType().Name}: {smallestShape.GetArea():F2} см²";

        }

        private void FindLargestShapeByArea(List<Shape> shapes)
        {
            var largestShape = shapes.OrderByDescending(shape => shape.GetArea()).FirstOrDefault();

            lblResult.Text = $"{largestShape.GetType().Name}: {largestShape.GetArea():F2} см²";
        }   
    }
}