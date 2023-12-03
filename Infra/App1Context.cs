using Core.Common;
using MediatR;

namespace Infra;

public class App1Context : DbContext
{
    private readonly IMediator? _mediator;

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<SpecialOrder> SpecialOrders { get; set; }

    public DbSet<SpecialOrderItem> SpecialOrderItems { get; set; }

    public DbSet<SpecialItemData> SpecialItemDatas { get; set; }

    public DbSet<LocalOrder> LocalOrders { get; set; }

    public DbSet<LocalOrderItem> LocalOrderItems { get; set; }

    //public DbSet<LocalItemData> LocalItemDatas { get; set; }

    public App1Context(DbContextOptions<App1Context> options)
        : base(options)
    {
    }

    public App1Context(DbContextOptions<App1Context> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>().OwnsOne(o => o.Address);
    }

    public async Task Save()
    {
        if (_mediator is not null)
        {
            await _mediator.Notify(this);
        }

        await SaveChangesAsync();
    }
}

public static class MediatorExtensions
{
    public async static Task Notify(this IMediator mediator, App1Context context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<IRoot>()
            .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Notifications)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearAllNotification());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}