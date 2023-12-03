namespace Infra;

public class LocalOrderRepo : ILocalOrderRepo
{
    private readonly App1Context _context;

    public LocalOrderRepo(App1Context context)
    {
        _context = context;
    }

    public async Task Create(LocalOrder item)
    {
        await _context.LocalOrders.AddAsync(item);
        await _context.Save();
    }

    public async Task<LocalOrder> Get(int id)
    {
        LocalOrder o = await _context.LocalOrders
            .Include(o => o.Items)
            .ThenInclude(oi => ((LocalOrderItem)oi).LocalItemDatas)
            .SingleAsync(o => o.Id == id);

        return o;
    }

    public async Task Update(LocalOrder item)
    {
        await _context.Save();
    }
}