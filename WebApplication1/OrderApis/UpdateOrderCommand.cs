namespace WebApplication1.OrderApis;

internal class UpdateOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }

    public int RemoveItemId { get; set; }

    public int UpdateItemId { get; set; }
}