namespace Core.BuyerRoot;

public interface IBuyer
{
    public int Id { get; }

    string Name { get; set; }

    public IReadOnlyList<BuyerDetail> BuyerDetails { get; }

    public void AddDetail(string name);
}
