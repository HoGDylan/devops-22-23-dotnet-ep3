using Microsoft.AspNetCore.Mvc;
using Example.Shared;

namespace Example.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class VirtualMachineController : ControllerBase
{
    private readonly ILogger<VirtualMachineController> _logger;

    public VirtualMachineController(ILogger<VirtualMachineController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Task<IEnumerable<VirtualMachineDto.Index>> GetIndexAsync()
    {
        return virtualMachineService.GetIndexAsync();
    }

    [HttpGet("id")]
    public Task<VirtualMachineDto.Detail> GetDetailAsync(int id)
    {
        return virtualMachineService.GetDetailAsync(id);
    }

    [HttpDelete("id")]
    public Task DeleteAsync(int id)
    {
        return virtualMachineService.DeleteAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateAsync(VirtualMachineDto.Create model)
    {
        var id = await virtualMachineService.CreateAsync(model);
        return CreatedAtAction("GetDetail", id);
    }
}
