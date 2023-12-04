namespace Infra.BuyerInfra;

public class BuyerRepo : IBuyerRepo
{
    private readonly App1Context _context;

    public BuyerRepo(App1Context context)
    {
        _context = context;
    }

    public async Task Create(Buyer item)
    {
        await _context.Buyers.AddAsync(item);
        await _context.Save();
    }

    public async Task<Buyer> Get(int id)
    {
        Buyer o = await _context.Buyers.Include(o => o.BuyerDetails).SingleAsync(o => o.Id == id);
        return o;
    }

    public async Task Update(Buyer item)
    {
        await _context.Save();
    }
}