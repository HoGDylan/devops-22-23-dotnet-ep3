using System.Threading.Tasks;

namespace Shared.Users
{
    public interface IUserService
    {
        Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request);
        Task<UserResponse.Create> CreateAsync(UserRequest.Create request);
        Task<UserResponse.AllKlantenIndex> GetAllKlanten(UserRequest.AllKlantenIndex request);
        Task<UserResponse.DetailKlant> GetDetailKlant(UserRequest.DetailKlant request);
        Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request);
        Task EditAsync(UserRequest.Edit request);


    }
}

