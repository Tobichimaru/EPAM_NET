using System;
using System.Collections.Generic;
using ShapesLib;
using NUnit.Framework;

namespace ShapesLibTests
{
    public class FiguresTests
    {
        #region Test Methods
        [Test, TestCaseSource(typeof(PolynomFactoryClass), "CalculateAreaCaseDatas")]
        public double CalculateArea_Test(IFigure figure)
        {
            return figure.Area();
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "CalculatePerimeterCaseDatas")]
        public double CalculatePerimeter_Test(IFigure figure)
        {
            return figure.Perimeter();
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "CreatePolygonCaseDatas")]
        public void CreatePolygon_Test(Point2D[] points)
        {
            Polygon polygon = new Polygon(points);
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "CreateTriangleCaseDatas")]
        public void CreateTriangle_Test(Point2D p1, Point2D p2, Point2D p3)
        {
            Triangle triangle = new Triangle(p1, p2, p3);
        }

        [TestCase(1, 1, Result = 2)]
        [TestCase(Double.NaN, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.NegativeInfinity, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.PositiveInfinity, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, Double.NaN, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, Double.NegativeInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, Double.PositiveInfinity, ExpectedException = typeof(ArgumentException))]
        public double Create2DPoint_Test(double x, double y)
        {
            Point2D point = new Point2D(x, y);
            return point.X + point.Y;
        }

        [TestCase(1.0, 0, 1, Result = 1)]
        [TestCase (1.0, 0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(1.0, 0, -1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1.0, 0, Double.NaN, ExpectedException = typeof(ArgumentException))]
        [TestCase(1.0, 0, Double.PositiveInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(1.0, 0, Double.NegativeInfinity, ExpectedException = typeof(ArgumentException))]
        public double CreateCircle_Test(double x, double y, double radius)
        {
            Circle circle = new Circle(new Point2D(x, y), radius);
            return circle.Radius;
        }

        [TestCase(1, 1)]
        [TestCase(0, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, -1, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, Double.NaN, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.NaN, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, Double.PositiveInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.PositiveInfinity, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, Double.NegativeInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.NegativeInfinity, 1, ExpectedException = typeof(ArgumentException))]
        public void CreateRectangle_Test(double x, double y)
        {
            Rectangle rectangle = new Rectangle(x, y);
        }

        [TestCase(1)]
        [TestCase(0, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.NaN, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.NegativeInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(Double.PositiveInfinity, ExpectedException = typeof(ArgumentException))]
        public void CreateSquare_Test(double a)
        {
            Square square = new Square(a);
        }
        #endregion
    }

    public class PolynomFactoryClass
    {
        #region Test Case Datas

        public IEnumerable<TestCaseData> CreatePolygonCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[]
                {
                    new Point2D(0, 0),
                    new Point2D(2, 0),
                    new Point2D(2, 2),
                    new Point2D(1, 1),
                    new Point2D(0, 2), 
                }).Throws(typeof(ArgumentException));

                yield return new TestCaseData(new[]
                {
                    new Point2D(0, 0),
                    new Point2D(2, 0)
                }).Throws(typeof(ArgumentException));

                yield return new TestCaseData(new[]
                {
                    new Point2D(0, 0)
                }).Throws(typeof(ArgumentException));

                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Point2D[] {}).Throws(typeof(ArgumentException));
            }
        } 

        public IEnumerable<TestCaseData> CreateTriangleCaseDatas
        {
            get
            {
                yield return new TestCaseData(new Point2D(0, 0), new Point2D(1, 0), new Point2D(0, 1));
                yield return new TestCaseData(new Point2D(0, 0), new Point2D(1, 0), new Point2D(2, 0)).Throws(typeof(ArgumentException));
            }
        } 

        public IEnumerable<TestCaseData> CalculateAreaCaseDatas
        {
            get
            {
                yield return new TestCaseData(new Square(new Point2D(0, 0), 1)).Returns(1.0);
                yield return new TestCaseData(new Rectangle(new Point2D(0, 0), new Point2D(3, 2))).Returns(6.0);
                yield return new TestCaseData(new Circle(2)).Returns(4*Math.PI);
                yield return new TestCaseData(new Triangle(new Point2D(0, 0), new Point2D(1, 0), new Point2D(0, 1))).Returns(0.5);
            }
        }

        public IEnumerable<TestCaseData> CalculatePerimeterCaseDatas
        {
            get
            {
                yield return new TestCaseData(new Square(new Point2D(0, 0), 1)).Returns(4.0);
                yield return new TestCaseData(new Rectangle(new Point2D(0, 0), new Point2D(3, 2))).Returns(10.0);
                yield return new TestCaseData(new Circle(3)).Returns(6* Math.PI);
                yield return new TestCaseData(new Triangle(new Point2D(0, 0), new Point2D(3, 0), new Point2D(0, 4))).Returns(12.0);
            }
        }
        #endregion
    }
}
