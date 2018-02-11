using University.Classes;

namespace University.Interfaces
{
    /// <summary>
    /// Describes student interface
    /// </summary>
    public interface IStudent : IObserver<HomeTask>, INameId
    {
    }
}
