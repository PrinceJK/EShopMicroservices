namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

    public class GetProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsQuery request, ISender sender) =>
            {
                var result = await sender.Send(request);

                return Results.Ok(result);
            })
                .WithName("GetProduct")
                .Produces<Result<IList<GetProductsResult>>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}
