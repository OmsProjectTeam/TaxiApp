using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
	public class TBCarInformation
	{
		[Key]
        public int IdCarInformation { get; set; }
		public int IdDriverInformation { get; set; }
		public int IdCarCategories { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCarNumber")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength50")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string CarNumber { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTypeCar")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength50")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string TypeCar { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlChassisNumber")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength50")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string ChassisNumber { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlYearManufacture")]
		[MaxLength(5, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength5")]
		[MinLength(5, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength5")]
		public string YearManufacture { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlReleaseDate")]
		public DateOnly ReleaseDate { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlExpiryDate")]
		public DateOnly ExpiryDate { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlLicenseNumber")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength50")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string LicenseNumber { get; set; }
		public string DataEntry { get; set; }
		public DateTime DateTimeEntry { get; set; }
		public bool CurrentState { get; set; }
	}
}
