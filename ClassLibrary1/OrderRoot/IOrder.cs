namespace Core.OrderRoot;

public interface IOrder
{
    public int Id { get; }

    public string Name { get; set; }

    public DateTime Date { get; set; }

    public IReadOnlyList<OrderItem> Items { get; }

    public void AddItem(string itemName, int quantity, double price);

    public void RemoveItem(int itemId);

    public void UpdateItemName(int itemId, string name);

    public void UpdateItemQuantity(int itemId, int quantity);

    public void UpdateItemPrice(int itemId, double price);

    public void UpdateItemAddress(int itemId, string country, string city);
}