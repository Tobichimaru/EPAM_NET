using System.Data;

namespace DAL.Interfaces
{
    public interface IMapper
    {
        T Map<T>(IDataReader reader) where T : new();
    }
}