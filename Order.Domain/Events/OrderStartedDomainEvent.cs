using MediatR;

namespace Order.Domain.Events
{
    public class OrderStartedDomainEvent:INotification
    {
        public AggregateModels.OrderModels.Order Order  { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }

        public OrderStartedDomainEvent(AggregateModels.OrderModels.Order order, string buyerFirstName, string buyerLastName)
        {
            Order = order;
            BuyerFirstName = buyerFirstName;
            BuyerLastName = buyerLastName;
        }
    }
}
