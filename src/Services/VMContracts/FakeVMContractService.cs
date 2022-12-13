using Domain.VirtualMachines.Contract;
using Shared.VMContracts;


namespace Services.VMContracts
{
    public class FakeVMContractService : IVMContractService
    {
        private List<VMContract> _contracts;

        public FakeVMContractService()
        {
            _contracts = VMContractFaker.Instance.Generate(100);

        }

        public Task<VMContractResponse.Detail> GetDetailAsync(VMContractRequest.GetDetail request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.Index> GetFromDate(VMContractRequest.GetByDate request)
        {
            throw new NotImplementedException();
        }
    }
}
