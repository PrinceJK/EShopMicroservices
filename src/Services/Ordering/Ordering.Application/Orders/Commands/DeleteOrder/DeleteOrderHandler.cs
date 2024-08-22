namespace Ordering.Application.Orders.Commands.DeleteOrder;
public class DeleteOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {

        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken) ?? throw new OrderNotFoundException(command.OrderId);

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
