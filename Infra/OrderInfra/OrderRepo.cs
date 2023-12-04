namespace Infra.OrderInfra;

public class OrderRepo : IOrderRepo
{
    private readonly App1Context _context;

    public OrderRepo(App1Context context)
    {
        _context = context;
    }

    public async Task Create(Order item)
    {
        await _context.Orders.AddAsync(item);
        await _context.Save();
    }

    public async Task<Order> Get(int id)
    {
        Order o = await _context.Orders.Include(o => o.Items).SingleAsync(o => o.Id == id);
        return o;
    }

    public async Task Update(Order item)
    {
        await _context.Save();
    }
}