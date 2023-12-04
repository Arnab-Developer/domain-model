namespace WebApplication1.SpecialOrderApis;

internal static class SpecialOrderApi
{
    public static RouteGroupBuilder MapSpecialOrderApi(this IEndpointRouteBuilder endpoints)
    {
        var orderGroup = endpoints.MapGroup("/special-order");

        orderGroup.MapGet("/create", async (ISpecialOrderRepo repo) =>
        {
            var order = new SpecialOrder("sp order 1", DateTime.Now, "sell 1");

            order.AddItem("milk", 10, 25.4);
            order.AddItem("meat", 3, 204.3);

            await repo.Create(order);
        })
        .WithName("CreateSpecialOrder")
        .WithOpenApi();

        orderGroup.MapGet("/update", async (IMediator mediator,
            int orderId, int removeItemId, int updateItemId) =>
        {
            var command = new UpdateSpecialOrderCommand()
            {
                OrderId = orderId,
                RemoveItemId = removeItemId,
                UpdateItemId = updateItemId
            };
            await mediator.Send(command);
        })
        .WithName("UpdateSpecialOrder")
        .WithOpenApi();

        return orderGroup;
    }
}