using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api")]
public class ShopController : ControllerBase
{
    public readonly IShopService Service;
    
    [HttpGet("/clients/{int:id}")]
    public Task<IActionResult> getClientByIdASyc(int id)
    {
        return Ok(await Service.getClientByIdASyc(id));
    }

}