using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToristAgency.Contracts;
using ToristAgency.DAL;

namespace TouristAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelAgencyContext context = new TravelAgencyContext();
        private readonly IGenericRepository<Role> _roleRepository;

        public HomeController(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public ActionResult Index()
        {
            _roleRepository.Create(new Role() { Name = "admin" });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}