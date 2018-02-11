using System;

namespace ShapesLib
{
    /// <summary>
    /// Class describes plane figure rectangle and its properties
    /// </summary>
    public class Rectangle : Polygon
    {
        #region Constructors
        /// <summary>
        /// Initialize default rectangle with the lower left vertex at the beginning of coordinates and side length equal to one and two
        /// </summary>
        public Rectangle()
        {
            Initialize(new Point2D(), 1, 2);
        }

        /// <summary>
        /// Initialize the rectangle by the lower left vertex and the upper right vertex.
        /// </summary>
        /// <param name="p1">the lower left vertex of the rectangle</param>
        /// <param name="p2">the upper right vertex of the rectangle</param>
        public Rectangle(Point2D p1, Point2D p2)
            : base(new Point2D(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y)),
            new Point2D(Math.Min(p1.X, p2.X), Math.Max(p1.Y, p2.Y)),
            new Point2D(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y)),
            new Point2D(Math.Max(p1.X, p2.X), Math.Min(p1.Y, p2.Y))
            )
        {
            vertices = new []
            {
                new Point2D(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y)),
                new Point2D(Math.Min(p1.X, p2.X), Math.Max(p1.Y, p2.Y)),
                new Point2D(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y)),
                new Point2D(Math.Max(p1.X, p2.X), Math.Min(p1.Y, p2.Y))
            };
        }


        /// <summary>
        /// Initializes rectangle by the length of its sides
        /// </summary>
        /// <param name="a">the length of one side (x-th coord)</param>
        /// <param name="b">the length of other side (y-th coord)</param>
        public Rectangle(double a, double b)
            : base(new Point2D(0, 0),
            new Point2D(0, b),
            new Point2D(a, b),
            new Point2D(a, 0)
            )
        {
            Initialize(new Point2D(), a, b);
        }

        /// <summary>
        /// Initializes rectangle by the lower left vertex and the length of its sides
        /// </summary>
        /// <param name="p">the lower left vertex of the rectangle</param>
        /// <param name="a">the length of one side (x-th coord)</param>
        /// <param name="b">the length of other side (y-th coord)</param>
        public Rectangle(Point2D p, double a, double b)
            : base(p,
            new Point2D(p.X, p.Y + b),
            new Point2D(p.X + a, p.Y + b),
            new Point2D(p.X + a, p.Y)
            )
        {
            Initialize(p, a, b);
        }
        #endregion 

        #region Private Methods
        /// <summary>
        /// Checks if parametr is sutable as length of smth
        /// </summary>
        /// <param name="a">parametr to check</param>
        /// <returns>true, if the parametr is positive number, false otherwise</returns>
        private bool IsSideLength(double a)
        {
            return !(Double.IsNaN(a) || Double.IsInfinity(a) || a <= 0);
        }

        private void Initialize(Point2D p, double a, double b)
        {
            if (!(IsSideLength(a) && IsSideLength(b))) throw new ArgumentException("Invalid side length");
            vertices = new[]
            {
                p,
                new Point2D(p.X, p.Y + b),
                new Point2D(p.X + a, p.Y + b),
                new Point2D(p.X + a, p.Y)
            };
        }
        #endregion

        #region Private Fields
        private Point2D[] vertices;
        #endregion
    }

}
