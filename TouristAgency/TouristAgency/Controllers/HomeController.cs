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
        private readonly IGenericRepository<User> _userRepository;

        public HomeController(IGenericRepository<Role> roleRepository, IGenericRepository<User> userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var roles = GetAllRoles();
            var users = GetAllUsers();
            return View();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.Get();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.Get();
        }
    }
}