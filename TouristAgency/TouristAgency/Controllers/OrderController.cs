using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToristAgency.Contracts;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderController(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(_orderRepository.Get());
            foreach (var order in orders)
            {
                order.ClientName = $"{order.User.LastName} {order.User.FirstName}";
                order.Status = order.Status ?? "Ожидает подтверждения";
            }
            return View(orders);
        }

        public ActionResult Accept(int id)
        {
            var order = _orderRepository.FindById(id);
            order.Status = "Подтверждён";
            _orderRepository.Update(order);
            return RedirectToAction("Index");
        }

        public ActionResult Decline(int id)
        {
            var order = _orderRepository.FindById(id);
            order.Status = "Отменён";
            _orderRepository.Update(order);
            return RedirectToAction("Index");
        }
    }
}
