using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ToristAgency.Contracts;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;

        public UserController(IGenericRepository<User> userRepository, IGenericRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>> (_userRepository.Get());
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = Mapper.Map<User, UserViewModel>(_userRepository.FindById(id));
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var roles = _roleRepository.Get(r => r.Id != (int)RoleType.ADMIN);
            return View(new UserViewModel { Roles = roles });
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", userViewModel);
                }
                _userRepository.Create(Mapper.Map <UserViewModel, User>(userViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = Mapper.Map<User, UserViewModel>(_userRepository.FindById(id));
            user.Roles = _roleRepository.Get(r => r.Id != (int)RoleType.ADMIN);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", userViewModel);
                }
                _userRepository.Update(Mapper.Map<UserViewModel, User>(userViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = Mapper.Map<User, UserViewModel>(_userRepository.FindById(id));
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserViewModel userViewModel)
        {
            try
            {
                _userRepository.Remove(Mapper.Map<UserViewModel, User>(userViewModel));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
