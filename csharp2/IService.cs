
using System.Threading.Tasks;

namespace AwsDotnetCsharp
{
    public interface IService
    {
        Task<string> GetMessageToReturn();
    }
}
