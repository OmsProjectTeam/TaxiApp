using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewPhotoSliderHomeContent
    {
        public int IdPhotoSliderHomeContent { get; set; }
        public int IdSliderHomeContent { get; set; }
        public string NekName { get; set; }
        public string Photo { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
