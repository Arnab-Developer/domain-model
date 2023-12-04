using Core.Common;

namespace WebApplication1.Common;

public class UpdateSpecialItemQuantityNotificationHandler : INotificationHandler<UpdateSpecialItemQuantityNotification>
{
    private readonly IBuyerRepo _buyerRepo;

    public UpdateSpecialItemQuantityNotificationHandler(IBuyerRepo buyerRepo)
    {
        _buyerRepo = buyerRepo;
    }

    public async Task Handle(UpdateSpecialItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        var buyer = await _buyerRepo.Get(notification.OrderId);
        Service.UpdateBuyer(buyer);
        await _buyerRepo.Update(buyer);
    }
}