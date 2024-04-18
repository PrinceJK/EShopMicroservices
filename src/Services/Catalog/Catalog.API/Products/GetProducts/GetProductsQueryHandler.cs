using Marten.Pagination;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<Result<IEnumerable<GetProductsResult>>>;
    public record GetProductsResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, Result<IEnumerable<GetProductsResult>>>
    {
        public async Task<Result<IEnumerable<GetProductsResult>>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

            var result = products.Adapt<IEnumerable<GetProductsResult>>();

            return Result<IEnumerable<GetProductsResult>>.Success(result);
        }
    }
}
