using EShop.Domain.Domain;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ICollection<TicketInOrder> findProductsForCertainOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return _orderRepository.GetDetailsForOrder(id);
        }
    }
}
