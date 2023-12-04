namespace WebApplication1.SpecialOrderApis;

internal class UpdateSpecialOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }

    public int RemoveItemId { get; set; }

    public int UpdateItemId { get; set; }
}