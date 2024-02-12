using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MVCWebApplicationUI.Models;

namespace MVCWebApplicationUI.Controllers
{
	public class PersonController : Controller
	{
		private readonly ILogger<PersonController> _logger;

		[BindProperty]
		private PersonViewModel _person { get; set; }

		public PersonController(ILogger<PersonController> logger, PersonViewModel person)
		{
			_logger = logger;
			_person = person;
		}

		// GET: Person
		public ActionResult Index()
		{
			List<PersonViewModel> people = new List<PersonViewModel>();
			if ( !string.IsNullOrWhiteSpace(_person.FirstName) && !string.IsNullOrWhiteSpace(_person.LastName) )
			{
				people.Add(_person);
			}

			_logger.LogInformation("GET, Person Controller, Index View, Person View Model");
			return View(people);
		}

		// GET: Person/Details/5
		public ActionResult Details(int id)
		{
			_logger.LogInformation("GET, Person Controller, Details View, Person View Model with Id = {id}", id);
			return View(_person);
		}

		// GET: Person/Create
		public ActionResult Create()
		{
			_logger.LogInformation("GET, Person Controller, Details View, Person View Model");
			_person.FirstName = "";
			_person.LastName = "";
			_person.IsActive = false;
			_person.Addresses.Clear();
			return View(_person);
		}

		// POST: Person/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PersonViewModel person)
		{
			_logger.LogInformation("POST, Person Controller, Details View, Person View Model with FirstName = {FirstName}, LastName = {LastName}, IsActive = {IsActive}, and {AddressCount} Addresses", person.FirstName, person.LastName, person.IsActive, person.Addresses.Count);
			try
			{
				if ( ModelState.IsValid )
				{
					_person.FirstName = person.FirstName;
					_person.LastName = person.LastName;
					_person.IsActive = person.IsActive;
					_person.Addresses.Clear();
					foreach ( AddressViewModel address in person.Addresses )
					{
						_person.Addresses.Add(address);
					}

					return RedirectToAction(nameof(Details), new { id = 5 });
				}
				else
				{
					return View(person);
				}
			}
			catch
			{
				return View(person);
			}
		}

		// GET: Person/Edit/5
		public ActionResult Edit(int id)
		{
			_logger.LogInformation("GET, Person Controller, Edit View, Person View Model with Id = {id}", id);
			return View(_person);
		}

		// POST: Person/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, PersonViewModel person)
		{
			_logger.LogInformation("POST, Person Controller, Edit View, Person View Model with Id = {id}, FirstName = {FirstName}, LastName = {LastName}, IsActive = {IsActive}, and {AddressCount} Addresses", id, person.FirstName, person.LastName, person.IsActive, person.Addresses.Count);
			try
			{
				if ( ModelState.IsValid )
				{
					_person.FirstName = person.FirstName;
					_person.LastName = person.LastName;
					_person.IsActive = person.IsActive;
					_person.Addresses.Clear();
					foreach ( AddressViewModel address in person.Addresses )
					{
						_person.Addresses.Add(address);
					}

					return RedirectToAction(nameof(Details), new { id = 5 });
				}
				else
				{
					return View(person);
				}
			}
			catch
			{
				return View(person);
			}
		}

		// GET: Person/Delete/5
		public ActionResult Delete(int id)
		{
			_logger.LogInformation("GET, Person Controller, Delete View, Person View Model with Id = {id}", id);
			return View(_person);
		}

		// POST: Person/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, PersonViewModel person)
		{
			_logger.LogInformation("POST, Person Controller, Edit View, Person View Model with Id = {id}, FirstName = {FirstName}, LastName = {LastName}, IsActive = {IsActive}, and {AddressCount} Addresses", id, person.FirstName, person.LastName, person.IsActive, person.Addresses.Count);
			try
			{
				_person.FirstName = "";
				_person.LastName = "";
				_person.IsActive = false;
				_person.Addresses.Clear();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(person);
			}
		}
	}
}
