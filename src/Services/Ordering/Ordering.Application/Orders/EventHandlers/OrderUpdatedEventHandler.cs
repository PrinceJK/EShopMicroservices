using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers;
public record OrderUpdatedEvent(Order order) : IDomainEvent;
