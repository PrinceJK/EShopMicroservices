﻿namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;
public record GetOrdersByCustomerQuery(Guid CustomerId)
    : IQuery<Result<IEnumerable<OrderDto>>>;