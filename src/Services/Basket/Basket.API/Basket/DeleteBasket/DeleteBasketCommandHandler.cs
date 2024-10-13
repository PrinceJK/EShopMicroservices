namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<Result>;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
    }
}

public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: delete basket from database and cache
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return Result.Success();
    }
}