namespace Infra;

public class SpecialOrderRepo : ISpecialOrderRepo
{
    private readonly App1Context _context;

    public SpecialOrderRepo(App1Context context)
    {
        _context = context;
    }

    public async Task Create(SpecialOrder item)
    {
        await _context.SpecialOrders.AddAsync(item);
        await _context.Save();
    }

    public async Task<SpecialOrder> Get(int id)
    {
        SpecialOrder o = await _context.SpecialOrders
            .Include(o => o.Items)
            .ThenInclude(oi => ((SpecialOrderItem)oi).SpecialItemDatas)
            .SingleAsync(o => o.Id == id);

        return o;
    }

    public async Task Update(SpecialOrder item)
    {
        await _context.Save();
    }
}
