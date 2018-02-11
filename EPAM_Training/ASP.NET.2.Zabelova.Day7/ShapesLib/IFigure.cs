
namespace ShapesLib
{
    /// <summary>
    /// Interface containing properties of a geometric figure
    /// </summary>
    public interface IFigure
    {
        #region Public Methods
        /// <summary>
        /// Calculates the area of a plane figure
        /// </summary>
        /// <returns>The area of a figure</returns>
        double Area();

        /// <summary>
        /// Calculates the perimeter of a plane figure
        /// </summary>
        /// <returns>The perimeter of a figure</returns>
        double Perimeter();
        #endregion
    }
}
