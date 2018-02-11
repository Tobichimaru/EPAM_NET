using System;

namespace ShapesLib
{
    /// <summary>
    /// Class describes plane figure circle
    /// </summary>
    public class Circle : IFigure
    {
        #region Constructors 
        /// <summary>
        /// Initialize default circle with the center at the beginning of coordinates and radius equal to one
        /// </summary>
        public Circle()
        {
            Initialize(new Point2D(), 1);
        }

        /// <summary>
        /// Initialize custom circle with the custom center and radius equal to one
        /// </summary>
        /// <param name="center">point which will be the center of the circle</param>
        public Circle(Point2D center)
        {
            Initialize(center, 1);
        }

        /// <summary>
        /// Initialize custom circle with the center at the beginning of coordinates and radius equal to custom value
        /// </summary>
        /// <param name="radius">radius of the circle</param>
        public Circle(double radius)
        {
            Initialize(new Point2D(), radius);
        }

        /// <summary>
        /// Initialize circle with the custom center and radius equal to custom value
        /// </summary>
        /// <param name="center">the center of the circle</param>
        /// <param name="radius">the radius of the circle</param>
        public Circle(Point2D center, double radius)
        {
            Initialize(center, radius);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Calculates an area of the circle
        /// </summary>
        /// <returns>The area of the circle</returns>
        public double Area()
        {
            return Math.PI*Radius*Radius;
        }

        /// <summary>
        /// Calculates a perimeter of the circle
        /// </summary>
        /// <returns>The perimeter of the circle</returns>
        public double Perimeter()
        {
            return Math.PI*Radius*2;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Radius of the circle
        /// </summary>
        public double Radius { get; private set; }
        
        /// <summary>
        /// The center of the circle - point at the plane
        /// </summary>
        public Point2D Center { get; private set; }
        #endregion

        #region Private Methods
        private void Initialize(Point2D center, double radius)
        {
            if (Double.IsNaN(radius) || Double.IsInfinity(radius) || radius <= 0) throw new ArgumentException("Invalid radius"); 
            Center = center;
            Radius = radius;
        }
        #endregion
    }
}
