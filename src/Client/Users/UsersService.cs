using Client.Extentions;
using Shared.Projecten;
using Shared.Users;
using System.Net.Http.Json;

namespace Client.Users
{
    public class UsersService : IUserService
    {
        private readonly HttpClient _httpClient;
        private const string endpoint = "api/User";
        public UsersService(HttpClient client)
        {
            this._httpClient = client;
        }


        public async Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.AllAdminsIndex>($"{endpoint}?queryParam");
            return response;
        }

        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.GetIndex>($"{endpoint}?queryParam");
            return response;
        }

        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.Create>($"{endpoint}?queryParam");
            return response;
        }

        public async Task<UserResponse.Detail> GetDetail(UserRequest.Detail request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.Detail>($"{endpoint}?queryParam");
            return response;
        }

        public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {
            var queryParam = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<UserResponse.Edit>($"{endpoint}?queryParam");
            return response;
        }
    }
}
