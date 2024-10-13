namespace Shopping.Web.Services;

public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<Result<IEnumerable<ProductModel>>> GetProducts(int? pageNumber= 1, int? pageSize = 10);

    [Get("/catalog-service/products/{id}")]
    Task<Result<IEnumerable<ProductModel>>> GetProduct(Guid id);

    [Get("/catalog-service/products/category/{category}")]
    Task<Result<ProductModel>> GetProductsByCategory(string category);
}
