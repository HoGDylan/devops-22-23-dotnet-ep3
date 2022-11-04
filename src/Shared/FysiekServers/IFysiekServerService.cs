using System.Threading.Tasks;

namespace Shared.FysiekeServers
{
    public interface IFysiekeServerService
    {
        Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request);
        Task<FysiekeServerResponse.GetDetail> GetDetailAsync(FysiekeServerRequest.GetDetail request);
        Task DeleteAsync(FysiekeServerRequest.Delete request);
        Task<FysiekeServerResponse.Create> CreateAsync(FysiekeServerRequest.Create request);
        Task<FysiekeServerResponse.Edit> EditAsync(FysiekeServerRequest.Edit request);
    }
}
