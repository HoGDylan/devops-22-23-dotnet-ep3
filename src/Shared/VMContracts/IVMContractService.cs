using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public interface IVMContractService
    {
        Task<VMContractResponse.GetIndex> GetIndexAsync(VMContractRequest.GetIndex request);
        Task<VMContractResponse.GetDetail> GetDetailAsync(VMContractRequest.GetDetail request);
        Task DeleteAsync(VMContractRequest.Delete request);
        Task<VMContractResponse.Create> CreateAsync(VMContractRequest.Create request);
        Task<VMContractResponse.Edit> EditAsync(VMContractRequest.Edit request);
    }
}
