using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.VirtualMachines;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class VirtualMachineController : ControllerBase
    {
        private readonly IVirtualMachineService virtualMachineService;

        public VirtualMachineController(IVirtualMachineService virtualMachineService)
        {
            this.virtualMachineService = virtualMachineService;
        }


        [AllowAnonymous]
        [HttpGet]
        public Task<VirtualMachineResponse.GetIndex> GetIndexAsync([FromQuery] VirtualMachineRequest.GetIndex request)
        {
            return virtualMachineService.GetIndexAsync(request);
        }

        [AllowAnonymous]
        [HttpGet("{VirtualMachineId}")]
        public Task<VirtualMachineResponse.GetDetail> GetDetailAsync([FromRoute] VirtualMachineRequest.GetDetail request)
        {
            return virtualMachineService.GetDetailAsync(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{VirtualMachineId}")]
        public Task DeleteAsync([FromRoute] VirtualMachineRequest.Delete request)
        {
            return virtualMachineService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<VirtualMachineResponse.Create> CreateAsync([FromBody] VirtualMachineRequest.Create request)
        {
            return virtualMachineService.CreateAsync(request);
        }

        [HttpPut]
        public Task<VirtualMachineResponse.Edit> EditAsync([FromBody] VirtualMachineRequest.Edit request)
        {
            return virtualMachineService.EditAsync(request);
        }
    }
}