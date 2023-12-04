namespace WebApplication1.Common;

internal class TransactionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly App1Context _context;

    public TransactionBehavior(App1Context context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var tran = await _context.Database.BeginTransactionAsync(cancellationToken);
        var response = await next();
        await tran.CommitAsync(cancellationToken);
        return response;
    }
}