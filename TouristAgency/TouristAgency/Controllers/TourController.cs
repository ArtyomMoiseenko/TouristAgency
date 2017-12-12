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
    public class TourController : Controller
    {
        private readonly IGenericRepository<Tour> _tourRepository;
        private readonly IGenericRepository<TourType> _tourTypeRepository;
        private readonly IGenericRepository<Diet> _dietRepository;
        private readonly IGenericRepository<Hotel> _hotelRepository;

        public TourController(IGenericRepository<Tour> tourRepository,
            IGenericRepository<TourType> tourTypeRepository,
            IGenericRepository<Diet> dietRepository,
            IGenericRepository<Hotel> hotelRepository,
            IGenericRepository<Room> roomRepository)
        {
            _tourRepository = tourRepository;
            _tourTypeRepository = tourTypeRepository;
            _dietRepository = dietRepository;
            _hotelRepository = hotelRepository;
        }

        // GET: Tour
        public ActionResult Index()
        {
            var tours = Mapper.Map<IEnumerable<Tour>, IEnumerable<TourViewModel>>(_tourRepository.Get());
            return View(tours);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            var tour = new TourViewModel();
            tour.StartDate = DateTime.Today;
            tour.EndDate = DateTime.Today;
            tour.TourTypes = _tourTypeRepository.Get();
            tour.Diets = _dietRepository.Get();
            tour.Hotels = _hotelRepository.Get();
            return View(tour);
        }

        // POST: Tour/Create
        [HttpPost]
        public ActionResult Create(TourViewModel tourViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", tourViewModel);
                }
                _tourRepository.Create(Mapper.Map<TourViewModel, Tour>(tourViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            var tour = Mapper.Map<Tour, TourViewModel>(_tourRepository.FindById(id));
            tour.TourTypes = _tourTypeRepository.Get();
            tour.Diets = _dietRepository.Get();
            tour.Hotels = _hotelRepository.Get();
            return View(tour);
        }

        // POST: Tour/Edit/5
        [HttpPost]
        public ActionResult Edit(TourViewModel tourViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", tourViewModel);
                }
                _tourRepository.Update(Mapper.Map<TourViewModel, Tour>(tourViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            var tour = Mapper.Map<Tour, TourViewModel>(_tourRepository.FindById(id));
            return View(tour);
        }

        // POST: Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(TourViewModel tourViewModel)
        {
            try
            {
                _tourRepository.Remove(Mapper.Map<TourViewModel, Tour>(tourViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
