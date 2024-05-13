using EShop.Domain.Domain;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_App.Service.Interface;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ITicketService _ticketService;
        private readonly IConcertService _concertService;
        public AdminController(IOrderService orderService, ITicketService ticketService, IConcertService concertService)
        {
            _orderService = orderService;
            _ticketService = ticketService;
            _concertService = concertService;
        }
        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }
        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity id)
        {

            var o = this._orderService.GetDetailsForOrder(id);
            var a = o;

            return a;
        }
        [HttpPost("[action]")]
        public List<TicketInOrder> GetDetailsForOrderProducts(BaseEntity? id)
        {
            var o = this._orderService.GetDetailsForOrder(id).ProductInOrders.ToList();
            var a = o;
            return a;
        }
        [HttpPost("[action]")]
        public List<Ticket> GetDetailsForOrderProductsReal(BaseEntity? id)
        {
            var all = new List<Ticket>();
            var o = this._orderService.GetDetailsForOrder(id).ProductInOrders.ToList();

            for (int i = 0; i < o.Count; i++)
            {
                all.Add(o[i].OrderedProduct);
            }
            return all;
        }
        [HttpPost("[action]")]
        public List<Concert> GetDetailsForOrderProductsRealConcert(BaseEntity? id)
        {
            var all = new List<Concert>();
            var o = this._orderService.GetDetailsForOrder(id).ProductInOrders.ToList();

            for (int i = 0; i < o.Count; i++)
            {
                all.Add(o[i].OrderedProduct.Concert);
            }
            return all;
        }
        [HttpPost("[action]")]
        public Ticket GetDetailsTicket(BaseEntity? id)
        {
            return _ticketService.GetProductById(id.Id);
        }
        [HttpPost("[action]")]
        public Concert GetDetailsConcert(BaseEntity? id)
        {
            return _concertService.GetDetailsForConcert(id.Id);
        }



        [HttpPost("[action]")]
        public bool ImportAllConcerts(List<Concert> concerts)
        {
            bool status = true;

            foreach (var item in concerts)
            {
                try
                {
                    _concertService.CreateNewConcert(item);
                }
                catch (Exception ex)
                {
                    status = false;
                }
            }
            return status;
        }



    }
}
