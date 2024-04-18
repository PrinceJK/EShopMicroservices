using Catalog.API.Exceptions;
using Catalog.API.Products.DeleteProduct;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<Result<GetProductByIdResult>>;
    public record GetProductByIdResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    //public class GetCommandValidator : AbstractValidator<GetProductByIdQuery>
    //{
    //    public GetCommandValidator()
    //    {
    //        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    //    }
    //}

    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, Result<GetProductByIdResult>>
    {
        public async Task<Result<GetProductByIdResult>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if(product is null)
                throw new ProductNotFoundException(query.Id);

            var productResponse = product.Adapt<GetProductByIdResult>();

            return Result<GetProductByIdResult>.Success(productResponse);
        }
    }
}
