namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                if(result.Status == ResultStatus.NotFound)
                    return Results.NotFound(result);

                return Results.Json(result);
            })
                 .WithName("GetProductById")
                 .Produces<Result<GetProductByIdResult>>(StatusCodes.Status200OK)
                 .ProducesProblem(StatusCodes.Status400BadRequest)
                 .ProducesProblem(StatusCodes.Status404NotFound)
                 .WithSummary("Get Product by Id")
                 .WithDescription("Get Product by Id");
        }
    }
}
