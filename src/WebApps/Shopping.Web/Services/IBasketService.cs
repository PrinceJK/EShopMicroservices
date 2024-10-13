using System.Net;

namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<Result<ShoppingCartModel>> GetBasket(string userName);

    [Post("/basket-service/basket")]
    Task<Result<string>> StoreBasket(StoreBasketRequest request);

    [Delete("/basket-service/basket/{userName}")]
    Task<Result> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<Result> CheckoutBasket(CheckoutBasketRequest request);

    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        // Get Basket If Not Exist Create New Basket with Default Logged In User Name: swn
        var userName = "swn";
        ShoppingCartModel basket;

        try
        {
            var getBasketResponse = await GetBasket(userName);
            basket = getBasketResponse.Value;
        }
        catch (ApiException apiException) when (apiException.StatusCode == HttpStatusCode.NotFound)
        {
            basket = new ShoppingCartModel
            {
                UserName = userName,
                Items = []
            };
        }

        return basket;
    }
}

