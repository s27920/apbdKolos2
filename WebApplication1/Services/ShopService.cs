using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;
public interface IShopService
{
    Task<ClientResponseDto> getClientByIdASyc(int id);
    public Task<int> InsertSubscriptionAsync(SubscriptionRequestDto dto, double amount);
}

public class ShopService : IShopService
{
    private readonly IClientRepository _repository;

    public ShopService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClientResponseDto> getClientByIdASyc(int id)
    {
        return await _repository.GetClientByIdAsync(id);
    }

    public async Task<int> InsertSubscriptionAsync(SubscriptionRequestDto dto, double amount)
    {
        return await _repository.InsertSubscriptionAsync(dto, amount);
    }
}