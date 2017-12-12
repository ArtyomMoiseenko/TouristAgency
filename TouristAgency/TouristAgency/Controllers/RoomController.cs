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
    public class RoomController : Controller
    {
        private readonly IGenericRepository<Room> _roomRepository;

        public RoomController(IGenericRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: Room
        public ActionResult Index()
        {
            var rooms = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(_roomRepository.Get());
            return View(rooms);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            var room = Mapper.Map<Room, RoomViewModel>(_roomRepository.FindById(id));
            return View(room);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(RoomViewModel roomViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", roomViewModel);
                }
                _roomRepository.Create(roomViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            var room = Mapper.Map<Room, RoomViewModel>(_roomRepository.FindById(id));
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(RoomViewModel roomViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", roomViewModel);
                }
                _roomRepository.Update(roomViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            var room = Mapper.Map<Room, RoomViewModel>(_roomRepository.FindById(id));
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(RoomViewModel roomViewModel)
        {
            try
            {
                _roomRepository.Remove(roomViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
