using Domain.VirtualMachines.Contract;
using Shared.VMContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VMContracts
{
    public class FakeVMContractService : IVMContractService
    {
        private List<VMContract> _contracts;

        public FakeVMContractService()
        {
            _contracts = new VMContractFaker().Generate(50);

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
