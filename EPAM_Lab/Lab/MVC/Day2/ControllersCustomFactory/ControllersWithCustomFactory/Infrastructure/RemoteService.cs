using System.Threading;
using System.Threading.Tasks;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(1000);
            return "thread sleep";
        }

        public async Task<string> GetRemoteDataAsync()
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                return "async thread sleep";
            });
        }
    }
}