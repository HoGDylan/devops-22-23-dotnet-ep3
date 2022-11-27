using Client.Extentions;
using Shared.Projects;
using Shared.Users;
using System.Net.Http.Json;

namespace Client.Users
{
    public class UsersService : IUserService
    {
        private readonly HttpClient _httpClient;
        private const string endpoint = "api/klanten";
        public UsersService(HttpClient client)
        {
            this._httpClient = client;
        }
        public async Task<UserResponse.AllKlantenIndex> GetAllKlanten(UserRequest.AllKlantenIndex request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.AllKlantenIndex>($"{endpoint}?queryParam");
            return response;
        }

        public async Task<UserResponse.DetailKlant> GetDetailKlant(UserRequest.DetailKlant request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.DetailKlant>($"{endpoint}?queryParam");
            return response;
        }
        public async Task EditAsync(UserRequest.Edit request)
        {
            
        }
        public async Task CreateAsync(UserRequest.Create request)
        {

        }

        public Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            throw new NotImplementedException();
        }

        
    }
}
