using System;

namespace BinarySearchConsoleUI.AdditionalClasses
{
    internal struct Point2D
    {
        #region Properties

        /// <summary>
        ///     X-th coordinate of the point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        ///     Y-th coordinate of the point
        /// </summary>
        public double Y { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes point with custom coordinates
        /// </summary>
        /// <param name="x">X-th coordinates</param>
        /// <param name="y">Y-th coordinate</param>
        public Point2D(double x, double y) : this()
        {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("The coordinates of a point must be a numbers");
            X = x;
            Y = y;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return "{" + X + " " + Y + "}";
        }

        #endregion
    }
}