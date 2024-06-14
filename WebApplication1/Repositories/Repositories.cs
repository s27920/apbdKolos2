using System.Globalization;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1;

public interface IClientRepository
{
    public Task<ClientResponseDto> GetClientByIdAsync(int id);
    public Task InsertSubscriptionAsync(SubscriptionRequestDto dto, double amount);
    public Task<bool> CheckIfClientExistsByIdAsync(int id);
    public Task<bool> CheckIfSubscriptionExistsAndIsActiveByIdAsync(int id);
    public Task<bool> CheckSubscriptionPaymentAsync(int clientId, int subscriptionId);
    public Task<bool> CheckPaymentCorrectness(int paymentId, double amount);
    public Task<int> CheckIfSaleForSubscriptionExists(int idSubscription);
}

public class Repositories : IClientRepository
{
    private readonly ShopContext _context;

    public Repositories(ShopContext context)
    {
        _context = context;
    }

    public async Task<ClientResponseDto> GetClientByIdAsync(int id)
    {
        var toReturn = await _context.Clients.FirstOrDefaultAsync(client => client.IdCient == id);
        if (toReturn == null)
        {
            throw new NotFoundException("Client with provided Id could not be located");
        }

        ICollection<Sale> sales = await _context.Sales.Where(sale => sale.IdClient == id).ToListAsync();
        ICollection<Subscription> subscriptions = new List<Subscription>();
        foreach (Sale sale in sales)
        {
            subscriptions.Add( await _context.Subscriptions.FirstAsync(subscription=>subscription.IdSubscription == sale.IdSubscription));
        }

        return new ClientResponseDto
        {
            Email = toReturn.Email,
            FirstName = toReturn.FirstName,
            LastName = toReturn.LastName,
            Phone = toReturn.Phone,
            Subscriptions = subscriptions
        };
    }

    public async Task InsertSubscriptionAsync(SubscriptionRequestDto dto, double amount)
    {
        if (await CheckIfClientExistsByIdAsync(dto.IdClient) &&
            await CheckIfSubscriptionExistsAndIsActiveByIdAsync(dto.IdSubscription) &&
            !await CheckSubscriptionPaymentAsync(dto.IdClient, dto.IdSubscription) &&
            await CheckPaymentCorrectness(dto.IdSubscription, amount))
        {
            await _context.Subscriptions.AddAsync(new Subscription
            {
                IdSubscription = _context.Subscriptions.Max(sub => sub.IdSubscription),
                EndTime = DateTime.Today,
                Name = (await _context.Clients.FirstAsync(client => client.IdCient == dto.IdClient)).FirstName,
                RenewalPeriod = 1,
                Price = amount,
                Sales = null

            });
            

        }
    }

    public async Task<bool> CheckIfClientExistsByIdAsync(int id)
    {
        return await _context.Clients.FirstOrDefaultAsync(client => client.IdCient == id) != null;
    }

    public async Task<bool> CheckIfSubscriptionExistsAndIsActiveByIdAsync(int id)
    {
        Subscription subscription = await _context.Subscriptions.FirstOrDefaultAsync(sub => sub.IdSubscription == id);
        if (subscription == null || subscription.EndTime < DateTime.Now)
        {
            throw new ConflictException("Subscription does not exist or has been deactivated");
        }

        return true;
    }

    public async Task<bool> CheckSubscriptionPaymentAsync(int clientId, int paymentId)
    {
        var client = await _context.Clients.FirstAsync(client => client.IdCient == clientId);
        return client.Payments.FirstOrDefault(payment => payment.IdPayment == paymentId) != null;
    }
    

    public async Task<bool> CheckPaymentCorrectness(int subscriptionId, double ammount)
    {
        var subscription = await _context.Subscriptions.FirstAsync(sub => sub.IdSubscription == subscriptionId);
        if (ammount > subscription.Price - subscription.Price *
            (await CheckIfSaleForSubscriptionExists(subscription.IdSubscription) / 100.0))
        {
            return true;
        }

        throw new ConflictException("Amount paid is too low");
    }

    public async Task<int> CheckIfSaleForSubscriptionExists(int idSubscription)
    {
        ICollection<Discount> avtiveDiscounts = await _context.Discounts
            .Where(discounnt => discounnt.IdSubscription == idSubscription).ToListAsync();
        if (avtiveDiscounts.Count < 1)
        {
            return 0;
        }
        return avtiveDiscounts.Max(disc => disc.Value);
    }
}