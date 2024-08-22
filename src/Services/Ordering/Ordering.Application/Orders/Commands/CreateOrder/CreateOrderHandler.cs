
namespace Ordering.Application.Orders.Commands.CreateOrder;
public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //create command entiry
        //save to database
        //return result
        throw new NotImplementedException();
    }
}
