using System.Threading.Tasks;

namespace Shared.FysiekServers
{
    public interface IFysiekServerService
    {
        Task<FysiekServerResponse.GetIndex> GetIndexAsync(FysiekServerRequest.GetIndex request);
        Task<FysiekServerResponse.GetDetail> GetDetailAsync(FysiekServerRequest.GetDetail request);
        Task DeleteAsync(FysiekServerRequest.Delete request);
        Task<FysiekServerResponse.Create> CreateAsync(FysiekServerRequest.Create request);
        Task<FysiekServerResponse.Edit> EditAsync(FysiekServerRequest.Edit request);
    }
}
