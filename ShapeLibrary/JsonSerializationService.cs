using System;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using ShapeLibrary.Shapes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ShapeLibrary.Serialization
{
    public static class JsonSerializationService
    {
        public static void SaveShapesToFile(string filePath, List<Shape> shapes)
        {
            try
            {
                var shapeData = new List<object>();

                foreach (var shape in shapes)
                {
                    var shapeInfo = new JObject
                    {
                        ["Type"] = shape.GetType().Name,
                        ["FillColor"] = shape.FillColor.Name,
                        ["OutlineColor"] = shape.OutlineColor.Name,
                        ["OutlineWidth"] = shape.OutlineWidth
                    };

                    if (shape is Circle circle)
                    {
                        shapeInfo["Radius"] = circle.Radius;
                        shapeInfo["X"] = circle.Center.X;
                        shapeInfo["Y"] = circle.Center.Y;
                    }
                    else if (shape is ShapeLibrary.Shapes.Rectangle rectangle)
                    {
                        shapeInfo["Width"] = rectangle.Width;
                        shapeInfo["Height"] = rectangle.Length;
                        shapeInfo["X"] = rectangle.PositionX;
                        shapeInfo["Y"] = rectangle.PositionY;
                    }
                    else if (shape is Square square)
                    {
                        shapeInfo["SideLength"] = square.SideLength;
                        shapeInfo["X"] = square.PositionX;
                        shapeInfo["Y"] = square.PositionY;
                    }
                    else if (shape is Ellipse ellipse)
                    {
                        shapeInfo["RadiusX"] = ellipse.RadiusX;
                        shapeInfo["RadiusY"] = ellipse.RadiusY;

                        shapeInfo["X"] = ellipse.Center.X;
                        shapeInfo["Y"] = ellipse.Center.Y;
                    }
                    else if (shape is Triangle triangle)
                    {
                        shapeInfo["PointAX"] = triangle.PointA.X;
                        shapeInfo["PointAY"] = triangle.PointA.Y;
                        shapeInfo["PointBX"] = triangle.PointB.X;
                        shapeInfo["PointBY"] = triangle.PointB.Y;
                        shapeInfo["PointCX"] = triangle.PointC.X;
                        shapeInfo["PointCY"] = triangle.PointC.Y;
                    }

                    shapeData.Add(shapeInfo);
                }

                string jsonString = JsonConvert.SerializeObject(shapeData, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error saving shapes to file: {ex.Message}");
            }
        }

        public static List<Shape> LoadShapesFromFile(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var shapeData = JArray.Parse(jsonString);
                var shapes = new List<Shape>();

                foreach (var item in shapeData)
                {
                    string type = item["Type"]?.ToString();
                    int x = item["X"].Value<int>();
                    int y = item["Y"].Value<int>();

                    var center = new Point(x, y);

                    string fillColorName = item["FillColor"]?.ToString();
                    string outlineColorName = item["OutlineColor"]?.ToString();
                    Color fillColor = Color.FromName(fillColorName);
                    Color outlineColor = Color.FromName(outlineColorName);

                    if (type == "Circle")
                    {
                        int radius = item["Radius"].Value<int>();
                        shapes.Add(new Circle(fillColor, outlineColor, center, radius));
                    }
                    else if (type == "Rectangle")
                    {
                        int width = item["Width"].Value<int>();
                        int length = item["Height"].Value<int>();
                        shapes.Add(new ShapeLibrary.Shapes.Rectangle(fillColor, outlineColor, x, y, width, length));
                    }
                    else if (type == "Square")
                    {
                        int sideLength = item["SideLength"].Value<int>();
                        shapes.Add(new Square(fillColor, outlineColor, x, y, sideLength));
                    }
                    else if (type == "Ellipse")
                    {
                        int radiusX = item["RadiusX"].Value<int>();
                        int radiusY = item["RadiusY"].Value<int>();
                        shapes.Add(new Ellipse(fillColor, outlineColor, center, radiusX, radiusY));
                    }
                    else if (type == "Triangle")
                    {
                        var pointAX = item["PointAX"]?.Value<int>();
                        var pointAY = item["PointAY"]?.Value<int>();
                        var pointBX = item["PointBX"]?.Value<int>();
                        var pointBY = item["PointBY"]?.Value<int>();
                        var pointCX = item["PointCX"]?.Value<int>();
                        var pointCY = item["PointCY"]?.Value<int>();

                        if (pointAX == null || pointAY == null || pointBX == null || pointBY == null || pointCX == null || pointCY == null)
                        {
                            throw new InvalidOperationException("Липсва информация за координатите на триъгълника.");
                        }

                        var pointA = new Point(pointAX.Value, pointAY.Value);
                        var pointB = new Point(pointBX.Value, pointBY.Value);
                        var pointC = new Point(pointCX.Value, pointCY.Value);

                        shapes.Add(new Triangle(fillColor, outlineColor, pointA, pointB, pointC));
                    }
                }

                return shapes;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Грешка при зареждане на фигури от файл: {ex.Message}");
            }
        }
    }
}