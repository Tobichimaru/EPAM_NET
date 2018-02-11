using System;

namespace ShapesLib
{
    /// <summary>
    /// Structure describes point with real coordinates on the plane
    /// </summary>
    public struct Point2D
    {
        #region Properties
        /// <summary>
        /// X-th coordinate of the point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y-th coordinate of the point
        /// </summary>
        public double Y { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes point with custom coordinates
        /// </summary>
        /// <param name="x">X-th coordinates</param>
        /// <param name="y">Y-th coordinate</param>
        public Point2D(double x, double y) : this()
        {
            if (Double.IsNaN(x) || Double.IsNaN(y) || Double.IsInfinity(x) || Double.IsInfinity(y))
                throw new ArgumentException("The coordinates of a point must be a numbers");
            X = x;
            Y = y;
        }
        #endregion
    }
}
