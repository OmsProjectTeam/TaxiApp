using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewDriversDocument
    {
        public int IdDriversDocument { get; set; }
        public int IdDriverInformation { get; set; }
        public string ImageUser { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverCategoryAr { get; set; }
        public string DriverCategoryEn { get; set; }
        public string DriverCategoryKr1 { get; set; }
        public string DriverCategoryKr2 { get; set; }
        public string DriverNameAr { get; set; }
        public string DriverNameEn { get; set; }
        public string DriverNameKr1 { get; set; }
        public string DriverNameKr2 { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
