using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.FysiekeServers;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class FysiekeServerController : ControllerBase
    {
        private readonly IFysiekeServerService fysiekServerService;

        public FysiekeServerController(IFysiekeServerService fysiekServerService)
        {
            this.fysiekServerService = fysiekServerService;
        }


        [HttpGet]
        public Task<FysiekeServerResponse.GetIndex> GetIndexAsync([FromQuery] FysiekeServerRequest.GetIndex request)
        {
            return fysiekServerService.GetIndexAsync(request);
        }

        [HttpGet("{FysiekeServerId}")]
        public Task<FysiekeServerResponse.GetDetail> GetDetailAsync([FromRoute] FysiekeServerRequest.GetDetail request)
        {
            return fysiekServerService.GetDetailAsync(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{FysiekeServerId}")]
        public Task DeleteAsync([FromRoute] FysiekeServerRequest.Delete request)
        {
            return fysiekServerService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<FysiekeServerResponse.Create> CreateAsync([FromBody] FysiekeServerRequest.Create request)
        {
            return fysiekServerService.CreateAsync(request);
        }

        [HttpPut]
        public Task<FysiekeServerResponse.Edit> EditAsync([FromBody] FysiekeServerRequest.Edit request)
        {
            return fysiekServerService.EditAsync(request);
        }
    }
}