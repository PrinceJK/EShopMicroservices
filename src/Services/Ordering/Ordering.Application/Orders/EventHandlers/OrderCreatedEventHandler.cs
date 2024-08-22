using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers;
public record OrderCreatedEvent(Order order) : IDomainEvent;