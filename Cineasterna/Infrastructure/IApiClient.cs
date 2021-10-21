using System.Threading.Tasks;

namespace Cineasterna.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
