namespace WebApplication1.OrderApis;

internal static class OrderApi
{
    public static RouteGroupBuilder MapOrderApi(this IEndpointRouteBuilder endpoints)
    {
        var orderGroup = endpoints.MapGroup("/order");

        orderGroup.MapGet("/create", async (IOrderRepo repo) =>
        {
            var order = new Order("order 1", DateTime.Now);

            order.AddItem("milk", 10, 25.4);
            order.AddItem("meat", 3, 204.3);

            await repo.Create(order);
        })
        .WithName("CreateOrder")
        .WithOpenApi();

        orderGroup.MapGet("/update", async (IMediator mediator, int orderId, int removeItemId,
            int updateItemId) =>
        {
            var updateCommand = new UpdateOrderCommand()
            {
                OrderId = orderId,
                RemoveItemId = removeItemId,
                UpdateItemId = updateItemId
            };
            await mediator.Send(updateCommand);
        })
        .WithName("UpdateOrder")
        .WithOpenApi();

        return orderGroup;
    }
}