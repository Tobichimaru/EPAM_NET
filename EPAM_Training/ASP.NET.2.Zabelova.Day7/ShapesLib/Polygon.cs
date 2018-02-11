using System;

namespace ShapesLib
{
    /// <summary>
    /// Class describes convex polygon and its properties
    /// </summary>
    public class Polygon : IFigure
    {
        #region Constructors
        /// <summary>
        /// static constructor for initializing epsilon value
        /// </summary>
        static Polygon()
        {
            Epsilon = 0.000001;
        }

        /// <summary>
        /// Empty constructor for possible inheritors
        /// </summary>
        protected Polygon()
        {
        }

        /// <summary>
        /// Initializes vertices of polygon
        /// </summary>
        /// <param name="points">vertices of polygon - points on the plane</param>
        public Polygon(params Point2D[] points)
        {
            if (ReferenceEquals(points, null)) throw new ArgumentNullException();
            if (points.Length < 3) throw new ArgumentException("The Polynom must containt 3 or more vertices");

            vertices = new Point2D[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i] = points[i];
            }

            if (!IsConvex()) throw new ArgumentException("The Polynom must be convex.");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method for calculating area of the polygon
        /// </summary>
        /// <returns>the area of the polygon</returns>
        public virtual double Area()
        {
            double s = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                s += 0.5*Math.Abs((vertices[i].X + vertices[i + 1].X)*(vertices[i].Y - vertices[i + 1].Y));
            }
            s += 0.5*
                 Math.Abs((vertices[vertices.Length - 1].X + vertices[0].X)*
                          (vertices[vertices.Length - 1].Y - vertices[0].Y));
            return s;
        }

        /// <summary>
        /// Method for calculating perimeter of the polygon
        /// </summary>
        /// <returns>the perimeter of the polygon</returns>
        public virtual double Perimeter()
        {
            double p = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                p +=
                    Math.Sqrt(Math.Pow(vertices[i].X - vertices[i + 1].X, 2) +
                              Math.Pow(vertices[i].Y - vertices[i + 1].Y, 2));
            }
            p +=
                Math.Sqrt(Math.Pow(vertices[vertices.Length - 1].X - vertices[0].X, 2) +
                          Math.Pow(vertices[vertices.Length - 1].Y - vertices[0].Y, 2));
            return p;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Determine either polygon convex or not
        /// </summary>
        /// <returns>true - if polygon is convex, otherwise - false</returns>
        private bool IsConvex()
        {
            if (vertices.Length == 3)
                return (Math.Abs((vertices[2].X - vertices[0].X) / (vertices[1].X - vertices[0].X) - 
                    (vertices[2].Y - vertices[0].Y) / (vertices[1].Y - vertices[0].Y)) > Epsilon);

            int flag = 0;
            for (int i = 0; i < vertices.Length; i++)
            {
                int j = (i + 1) % (vertices.Length-1);
                int k = (i + 2) % (vertices.Length-1);
                double z = (vertices[j].X - vertices[i].X)*(vertices[k].Y - vertices[j].Y) - 
                    (vertices[j].Y - vertices[i].Y)*(vertices[k].X - vertices[j].X);

                if (z < 0) flag++;
                if (z > 0) flag--;
            }
            return (Math.Abs(flag) == vertices.Length);
        }
        #endregion

        #region Fields and Properties
        /// <summary>
        /// Value for determination of absolute error
        /// </summary>
        protected static double Epsilon { get; private set; }

        private readonly Point2D[] vertices;
        #endregion
    }
} 
