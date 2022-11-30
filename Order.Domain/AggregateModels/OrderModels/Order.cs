using MediatR;
using Order.Domain.Events;
using Order.Domain.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRoot
    {
     


        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }


        public int BuyerId { get; private set; }
        public string OrderStatus { get; private set; }

        public Address Address { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, int buyerId, string orderStatus, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
            {
                throw new Exception("Orderdate must be greater than now");
            }
            if (address.City == "")
            {
                throw new Exception("City cannot be empty");
            }
            OrderDate = orderDate;
            Description = description;
            BuyerId = buyerId;
            OrderStatus = orderStatus;
            Address = address;
            OrderItems = orderItems;

            AddDomainEvents(new OrderStartedDomainEvent(this,"",""));
        }

        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}
