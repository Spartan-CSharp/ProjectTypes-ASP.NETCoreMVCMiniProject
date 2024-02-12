using System.ComponentModel.DataAnnotations;

using ClassLibrary;

namespace MVCWebApplicationUI.Models
{
	public class AddressViewModel
	{
		public AddressViewModel()
		{
		}

		public AddressViewModel(AddressModel addressModel)
		{
			StreetAddress = addressModel.StreetAddress;
			City = addressModel.City;
			State = addressModel.State;
			ZipCode = addressModel.ZipCode;
		}

		[Display(Name = "Primary Key")]
		public int PrimaryKey
		{
			get; set;
		}

		[Required]
		[Display(Name = "Street Address")]
		public string StreetAddress
		{
			get; set;
		}

		[Required]
		public string City
		{
			get; set;
		}

		[Required]
		public string State
		{
			get; set;
		}

		[Required]
		[Display(Name = "Zip Code")]
		public string ZipCode
		{
			get; set;
		}

		public AddressModel ToAddressModel()
		{
			return new AddressModel
			{
				StreetAddress = StreetAddress,
				City = City,
				State = State,
				ZipCode = ZipCode
			};
		}
	}
}
