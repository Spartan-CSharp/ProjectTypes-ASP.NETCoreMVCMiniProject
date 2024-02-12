using System.Collections.Generic;

namespace ClassLibrary
{
	public class PersonModel
	{
		public string FirstName
		{
			get; set;
		}

		public string LastName
		{
			get; set;
		}

		public bool? IsActive
		{
			get; set;
		}

		public List<AddressModel> Addresses
		{
			get; set;
		} = new List<AddressModel>();
	}
}
