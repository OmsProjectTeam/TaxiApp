using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewDriverInformation
    {
        public int IdDriverInformation { get; set; }
        public string IdDriverUser { get; set; }
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public int IdDriverCategory { get; set; }
        public string DriverCategoryAr { get; set; }
        public string DriverCategoryEn { get; set; }
        public string DriverCategoryKr1 { get; set; }
        public string DriverCategoryKr2 { get; set; }
        public int IdDrivingLicenseCategory { get; set; }
        public string DrivingLicenseCategoryAr { get; set; }
        public string DrivingLicenseCategoryEn { get; set; }
        public string DrivingLicenseCategoryKr1 { get; set; }
        public string DrivingLicenseCategoryKr2 { get; set; }
        public string DriverNameAr { get; set; }
        public string DriverNameEn { get; set; }
        public string DriverNameKr1 { get; set; }
        public string DriverNameKr2 { get; set; }
        public string GenderAr { get; set; }
        public string GenderEn { get; set; }
        public string GenderKr1 { get; set; }
        public string GenderKr2 { get; set; }
        public DateOnly dateOfbirth { get; set; }
        public string NationalNumber { get; set; }
        public string FamilyNumber { get; set; }
        public string CurrentAddressAr { get; set; }
        public string CurrentAddressEn { get; set; }
        public string CurrentAddressKr1 { get; set; }
        public string CurrentAddressKr2 { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
