using Core.Common;

namespace WebApplication1.Common;

public class UpdateItemQuantityNotificationHandler : INotificationHandler<UpdateItemQuantityNotification>
{
    private readonly IBuyerRepo _buyerRepo;

    public UpdateItemQuantityNotificationHandler(IBuyerRepo buyerRepo)
    {
        _buyerRepo = buyerRepo;
    }

    public async Task Handle(UpdateItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        var buyer = new Buyer("buyer 1");
        await _buyerRepo.Create(buyer);
    }
}