namespace Infra.Common;

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