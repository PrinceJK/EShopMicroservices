﻿namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<Result<IEnumerable<GetProductByCategoryResult>>>;
    public record GetProductByCategoryResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, Result<IEnumerable<GetProductByCategoryResult>>>
    {
        public async Task<Result<IEnumerable<GetProductByCategoryResult>>> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(query.Category))
                .ToListAsync(cancellationToken);

            if (!products.Any())
                return Result<IEnumerable<GetProductByCategoryResult>>.NotFound("Product not found!");

            var productsResponse = products.Adapt<IList<GetProductByCategoryResult>>();

            return Result<IEnumerable<GetProductByCategoryResult>>.Success(productsResponse);
        }
    }
}
