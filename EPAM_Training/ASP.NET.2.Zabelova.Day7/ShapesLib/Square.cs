using System;

namespace ShapesLib
{
    /// <summary>
    /// Class describes plane figure square and its properties
    /// </summary>
    public class Square : Rectangle
    {
        #region Constructors
        /// <summary>
        /// Initialize default square with the left lower vertex at the beginning of coordinates and side length equal to one
        /// </summary>
        public Square()
        {
            Initialize(new Point2D(), 1);
        }

        /// <summary>
        /// Initialize a square figure by the bottom left vertex and the length of the side
        /// </summary>
        /// <param name="point">bottom left vertex of the square</param>
        /// <param name="a">the length of the side of the square</param>
        public Square(Point2D point, double a)
            : base(point, a, a)
        {
            Initialize(point, a);
        }

        /// <summary>
        /// Initialize a square figure by the length of the side
        /// </summary>
        /// <param name="a">the length of the side of the square</param>
        public Square(double a)
            : base(a, a)
        {
            Initialize(new Point2D(), a);
        }
        #endregion

        #region Private Methods
        private void Initialize(Point2D point, double a)
        {
            if (Double.IsNaN(a) || Double.IsInfinity(a) || a <= 0) throw new ArgumentException("Invalid edge length");
            vertices = new[]
            {
                point,
                new Point2D(point.X, point.Y + a),
                new Point2D(point.X + a, point.Y + a),
                new Point2D(point.X + a, point.Y),
            };
        }
        #endregion 

        #region Private Fields
        private Point2D[] vertices;
        #endregion
    }
}
