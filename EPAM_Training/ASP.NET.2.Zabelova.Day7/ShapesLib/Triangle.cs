
namespace ShapesLib
{
    /// <summary>
    /// Class describes plane figure triangle and its properties
    /// </summary>
    public class Triangle : Polygon
    {
        #region Constructors
        /// <summary>
        /// Empty constructor for possible inheritors
        /// </summary>
        protected Triangle()
        {
        }

        /// <summary>
        /// Initializes triangle by three vertices
        /// </summary>
        /// <param name="p1">first vertex</param>
        /// <param name="p2">second vertex</param>
        /// <param name="p3">third vertex</param>
        public Triangle(Point2D p1, Point2D p2, Point2D p3)
            : base(p1, p2, p3)
        {
            vertices = new[] {p1, p2, p3};
        }
        #endregion

        #region Private Fields
        private readonly Point2D[] vertices;
        #endregion
    }
}
