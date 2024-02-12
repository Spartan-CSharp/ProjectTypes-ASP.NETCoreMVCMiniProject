using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ClassLibrary;

namespace MVCWebApplicationUI.Models
{
	public class PersonViewModel
	{
		public PersonViewModel()
		{
			Addresses = new List<AddressViewModel>();
		}

		public PersonViewModel(PersonModel personModel)
		{
			FirstName = personModel.FirstName;
			LastName = personModel.LastName;
			if ( personModel.IsActive == null )
			{
				IsActive = false;
			}
			else
			{
				IsActive = (bool)personModel.IsActive;
			}
			foreach ( AddressModel addressModel in personModel.Addresses )
			{
				Addresses.Add(new AddressViewModel(addressModel));
			}
		}

		[Required]
		[Display(Name = "First Name")]
		public string FirstName
		{
			get; set;
		}

		[Required]
		[Display(Name = "Last Name")]
		public string LastName
		{
			get; set;
		}

		[Required]
		[Display(Name = "Is Active")]
		public bool IsActive
		{
			get; set;
		}

		public List<AddressViewModel> Addresses
		{
			get; set;
		}

		public PersonModel ToPersonModel()
		{
			return new PersonModel
			{
				FirstName = FirstName,
				LastName = LastName,
				IsActive = IsActive,
				Addresses = Addresses.ConvertAll(address => address.ToAddressModel())
			};
		}
	}
}
