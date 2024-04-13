
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<Result>;
    public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) 
        : ICommandHandler<UpdateProductCommand, Result>
    {
        public async Task<Result> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
                return Result.NotFound("Product not found");

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
