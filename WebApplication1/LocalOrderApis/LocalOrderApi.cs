namespace WebApplication1.LocalOrderApis;

internal static class LocalOrderApi
{
    public static RouteGroupBuilder MapLocalOrderApi(this IEndpointRouteBuilder endpoints)
    {
        var orderGroup = endpoints.MapGroup("/local-order");

        orderGroup.MapGet("/create", async (ILocalOrderRepo repo) =>
        {
            var order = new LocalOrder("sp order 1", DateTime.Now, "sell 1");

            order.AddItem("milk", 10, 25.4);
            order.AddItem("meat", 3, 204.3);

            await repo.Create(order);
        })
        .WithName("CreateLocalOrder")
        .WithOpenApi();

        orderGroup.MapGet("/update", async (ILocalOrderService service, ILocalOrderRepo repo,
            int orderId, int removeItemId, int updateItemId) =>
        {
            var order = await repo.Get(orderId);
            service.UpdateOrder(order, removeItemId, updateItemId);
            await repo.Update(order);
        })
        .WithName("UpdateLocalOrder")
        .WithOpenApi();

        return orderGroup;
    }
}