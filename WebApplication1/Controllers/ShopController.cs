using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api")]
public class ShopController : ControllerBase
{
    public readonly IShopService Service;
    
    [HttpGet("clients")]
    public async Task<IActionResult> getClientByIdASyc([FromRoute] int id)
    {
        return Ok(await Service.getClientByIdASyc(id));
    }
    [HttpPost("subscriptions")]
    public async Task<int> InsertSubscriptionAsync([FromBody] SubscriptionRequestDto dto, [FromRoute]double amount)
    {
        return Ok(await Service.InsertSubscriptionAsync(dto, amount));
    }
}