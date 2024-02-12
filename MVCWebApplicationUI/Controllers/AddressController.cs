using System;
using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MVCWebApplicationUI.Models;

namespace MVCWebApplicationUI.Controllers
{
	public class AddressController : Controller
	{
		private readonly ILogger<AddressController> _logger;
		private PersonViewModel _person { get; set; }

		[BindProperty]
		private AddressViewModel _address { get; set; }

		public AddressController(ILogger<AddressController> logger, PersonViewModel person, AddressViewModel address)
		{
			_logger = logger;
			_person = person;
			_address = address;
		}

		// GET: Address
		public ActionResult Index()
		{
			_logger.LogInformation("GET, Address Controller, Index View, Address View Model");
			return View(_person.Addresses);
		}

		// GET: Address/Details/5
		public ActionResult Details(int id)
		{
			_logger.LogInformation("GET, Address Controller, Details View, Address View Model with Id = {id}", id);
			return View(_person.Addresses[id]);
		}

		// GET: Address/Create
		public ActionResult Create()
		{
			_logger.LogInformation("GET, Address Controller, Create View, Address View Model");
			return View();
		}

		// POST: Address/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AddressViewModel address)
		{
			_logger.LogInformation("POST, Address Controller, Create View, Address View Model with StreetAddress = {StreetAddress}, City = {City}, State = {State}, and ZipCode = {ZipCode}", address.StreetAddress, address.City, address.State, address.ZipCode);
			try
			{
				if ( ModelState.IsValid )
				{
					address.PrimaryKey = _person.Addresses.Count;
					_person.Addresses.Add(address);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View(address);
				}
			}
			catch
			{
				return View();
			}
		}

		// GET: Address/Edit/5
		public ActionResult Edit(int id)
		{
			_logger.LogInformation("GET, Address Controller, Edit View, Address View Model with Id = {id}", id);
			return View(_person.Addresses[id]);
		}

		// POST: Address/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, AddressViewModel address)
		{
			_logger.LogInformation("POST, Address Controller, Edit View, Address View Model with StreetAddress = {StreetAddress}, City = {City}, State = {State}, and ZipCode = {ZipCode}", address.StreetAddress, address.City, address.State, address.ZipCode);
			try
			{
				if ( ModelState.IsValid )
				{
					_person.Addresses[id].StreetAddress = address.StreetAddress;
					_person.Addresses[id].City = address.City;
					_person.Addresses[id].State = address.State;
					_person.Addresses[id].ZipCode = address.ZipCode;
					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View(address);
				}
			}
			catch
			{
				return View();
			}
		}

		// GET: Address/Delete/5
		public ActionResult Delete(int id)
		{
			_logger.LogInformation("GET, Address Controller, Delete View, Address View Model with Id = {id}", id);
			return View(_person.Addresses[id]);
		}

		// POST: Address/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AddressViewModel address)
		{
			_logger.LogInformation("POST, Address Controller, Delete View, Address View Model with StreetAddress = {StreetAddress}, City = {City}, State = {State}, and ZipCode = {ZipCode}", address.StreetAddress, address.City, address.State, address.ZipCode);
			try
			{
				_person.Addresses.RemoveAt(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
