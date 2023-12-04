namespace WebApplication1.OrderApis;

internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderService _service;
    private readonly IOrderRepo _repo;

    public UpdateOrderCommandHandler(IOrderService service, IOrderRepo repo)
    {
        _service = service;
        _repo = repo;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repo.Get(request.OrderId);
        _service.UpdateOrder(order, request.RemoveItemId, request.UpdateItemId);
        await _repo.Update(order);
        return true;
    }
}