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
    public class HotelController : Controller
    {
        private readonly IGenericRepository<Hotel> _hotelRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IGenericRepository<Room> _roomRepository;

        public HotelController(IGenericRepository<Hotel> hotelRepository,
            IGenericRepository<City> cityRepository,
            IGenericRepository<Country> countryRepository,
            IGenericRepository<Room> roomRepository)
        {
            _hotelRepository = hotelRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _roomRepository = roomRepository;
        }

        // GET: Hotel
        public ActionResult Index()
        {
            var hotels = Mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelViewModel>>(_hotelRepository.Get());
            foreach (var hotel in hotels)
            {
                hotel.CountryName = _countryRepository.FindById(hotel.City.CountryId).Name;
                hotel.FreeRooms = _roomRepository.Get(r => r.HotelId == hotel.Id && !r.IsBooked).Count();
            }
            return View(hotels);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            var hotel = Mapper.Map<Hotel, HotelViewModel>(_hotelRepository.FindById(id));
            return View(hotel);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            var hotel = new HotelViewModel()
            {
                Countries = _countryRepository.Get(),
                Cities = _cityRepository.Get()
            };
            return View(hotel);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(HotelViewModel hotelViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", hotelViewModel);
                }
                var hotel = Mapper.Map<HotelViewModel, Hotel>(hotelViewModel);
                _hotelRepository.Create(hotel);
                CreateRoomsInHotel(hotelViewModel.RoomsCount, hotel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetStates(int countryId)
        {
            if (countryId != 0)
            {
                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }

            var data = _cityRepository.Get(c => c.CountryId == countryId);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            var hotel = Mapper.Map<Hotel, HotelViewModel>(_hotelRepository.FindById(id));
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(HotelViewModel hotelViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", hotelViewModel);
                }
                _hotelRepository.Update(Mapper.Map<HotelViewModel, Hotel>(hotelViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            var hotel = Mapper.Map<Hotel, HotelViewModel>(_hotelRepository.FindById(id));
            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(HotelViewModel hotelViewModel)
        {
            try
            {
                _hotelRepository.Remove(Mapper.Map<HotelViewModel, Hotel>(hotelViewModel));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }


        private void CreateRoomsInHotel(int count, int hotelId)
        {
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                _roomRepository.Create(new Room
                {
                    Name = i + 1,
                    IsBooked = false,
                    HotelId = hotelId,
                    Cost = rand.Next(100, 1000),
                    RoomTypeId = rand.Next(1, 3),
                    TourId = null
                });
            }
        }
    }
}
