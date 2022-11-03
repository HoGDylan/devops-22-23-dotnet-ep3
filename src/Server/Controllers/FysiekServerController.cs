using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.FysiekServers;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class FysiekServerController : ControllerBase
    {
        private readonly IFysiekServerService fysiekServerService;

        public FysiekServerController(IFysiekServerService fysiekServerService)
        {
            this.fysiekServerService = fysiekServerService;
        }


        [HttpGet]
        public Task<FysiekServerResponse.GetIndex> GetIndexAsync([FromQuery] FysiekServerRequest.GetIndex request)
        {
            return fysiekServerService.GetIndexAsync(request);
        }

        [HttpGet("{FysiekServerId}")]
        public Task<FysiekServerResponse.GetDetail> GetDetailAsync([FromRoute] FysiekServerRequest.GetDetail request)
        {
            return fysiekServerService.GetDetailAsync(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{FysiekServerId}")]
        public Task DeleteAsync([FromRoute] FysiekServerRequest.Delete request)
        {
            return fysiekServerService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<FysiekServerResponse.Create> CreateAsync([FromBody] FysiekServerRequest.Create request)
        {
            return fysiekServerService.CreateAsync(request);
        }

        [HttpPut]
        public Task<FysiekServerResponse.Edit> EditAsync([FromBody] FysiekServerRequest.Edit request)
        {
            return fysiekServerService.EditAsync(request);
        }
    }
}