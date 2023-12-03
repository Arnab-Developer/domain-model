namespace WebApplication1.Common;

internal interface IService<T> where T : IOrder
{
    public void UpdateOrder(T order, int removeItemId, int updateItemId);
}