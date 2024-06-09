namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<Result<ShoppingCart>>;
//public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler(/*IBasketRepository repository*/)
: IQueryHandler<GetBasketQuery, Result<ShoppingCart>>
{
    public async Task<Result<ShoppingCart>> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //var basket = await repository.GetBasket(query.UserName);

        return Result<ShoppingCart>.Success(new ShoppingCart("swn"));
    }
}
