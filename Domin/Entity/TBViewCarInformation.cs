using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
	public class TBViewCarInformation
	{
        public int IdCarInformation { get; set; }
        public int IdDriverInformation { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverCategoryAr { get; set; }
        public string DriverCategoryEn { get; set; }
        public string DriverCategoryKr1 { get; set; }
        public string DriverCategoryKr2 { get; set; }
        public string DrivingLicenseCategoryAr { get; set; }
        public string DrivingLicenseCategoryEn { get; set; }
        public string DrivingLicenseCategoryKr1 { get; set; }
        public string DrivingLicenseCategoryKr2 { get; set; }
        public string DriverNameAr { get; set; }
        public string DriverNameEn { get; set; }
        public string DriverNameKr1 { get; set; }
        public string DriverNameKr2 { get; set; }
        public string NationalNumber { get; set; }
        public int IdCarCategories { get; set; }
        public string CarCategorieAr { get; set; }
        public string CarCategorieEn { get; set; }
        public string CarCategorieKr1 { get; set; }
        public string CarCategorieKr2 { get; set; }
        public string CarNumber { get; set; }
        public string TypeCar { get; set; }
        public string YearManufacture { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string LicenseNumber { get; set; }
		public string DataEntry { get; set; }
		public DateTime DateTimeEntry { get; set; }
		public bool CurrentState { get; set; }
	}
}
