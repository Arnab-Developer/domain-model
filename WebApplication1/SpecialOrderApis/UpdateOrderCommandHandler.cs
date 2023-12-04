namespace WebApplication1.SpecialOrderApis;

internal class UpdateSpecialOrderCommandHandler : IRequestHandler<UpdateSpecialOrderCommand, bool>
{
    private readonly ISpecialOrderService _service;
    private readonly ISpecialOrderRepo _repo;

    public UpdateSpecialOrderCommandHandler(ISpecialOrderService service, ISpecialOrderRepo repo)
    {
        _service = service;
        _repo = repo;
    }

    public async Task<bool> Handle(UpdateSpecialOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repo.Get(request.OrderId);
        _service.UpdateOrder(order, request.RemoveItemId, request.UpdateItemId);
        await _repo.Update(order);
        return true;
    }
}