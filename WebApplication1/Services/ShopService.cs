using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;
public interface IShopService
{
    Task<ClientResponseDto> getClientByIdASyc(int id);
}

public class ShopService : IShopService
{
    public Task<ClientResponseDto> getClientByIdASyc(int id)
    {
        throw new NotImplementedException();
    }
}