using Tasks.Models;

namespace Tasks.Interfaces
{
    public interface IUsersService
    {
        Task<List<UserLogicModel>> Get();
    }
}
