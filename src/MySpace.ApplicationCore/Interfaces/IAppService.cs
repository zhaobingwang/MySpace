using System.Threading.Tasks;

namespace MySpace.ApplicationCore.Interfaces
{
    public interface IAppService
    {
        Task CreateAppAsync(string name);
    }
}
