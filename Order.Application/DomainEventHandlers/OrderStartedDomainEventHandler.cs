using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository _buyerRepository;

        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Order.BuyerId == 0)
            {
                var buyer = new Buyer(notification.BuyerFirstName, notification.BuyerLastName);

               // _buyerRepository.add(buyer);

            }
            return Task.CompletedTask;
        }
    }
}
