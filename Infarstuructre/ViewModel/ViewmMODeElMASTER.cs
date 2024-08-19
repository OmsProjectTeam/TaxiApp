using Domin.Entity;
using Domin.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.ViewModel
{
	public class ViewmMODeElMASTER
	{
		public returnUrl returnUrl { get; set; }
        public IEnumerable<IdentityRole> ListIdentityRole { get; set; }
        public IdentityRole? sIdentityRole { get; set; } 
        public IEnumerable<VwUser> ListVwUser { get; set; }
        public IEnumerable<ApplicationUser> ListlicationUser { get; set; }
        public VwUser sVwUser { get; set; }
        public ApplicationUser sUser { get; set; }
        public RegisterViewModel ruser { get; set; }
        public NewRegister SNewRegister { get; set; }
		public IEnumerable<RegisterViewModel> ListRegisterViewModel { get; set; }
		public IEnumerable<NewRegister> ListNewRegister { get; set; }
		public ChangePasswordViewModel SChangePassword { get; set; }
        public bool Rememberme { get; set; }
        public List<SelectListItem> Roles1 { get; set; }
        public string SelectedRoleId { get; set; }
        public string UserName { get; set; }
		public string UserId { get; set; }
		public string UserImage { get; set; }
		public string Name { get; set; }
		public string UserRole { get; set; }
		public NewRegister NewRegister { get; set; }
		public string Id { get; set; }
		public string RoleName { get; set; }
		public string Email { get; set; }
		public string? ImageUser { get; set; }
		public bool ActiveUser { get; set; }
		public string Password { get; set; }
		public string ComparePassword { get; set; }
		public string userName { get; set; }
		public string PhoneNumber { get; set; }		
		public List<IdentityRole> Roles { get; set; }
		public List<VwUser> Users { get; set; }
        public IEnumerable<TBAboutHomeContent> ListAboutHomeContent { get; set; }
        public TBAboutHomeContent AboutHomeContent { get; set; }   
		public IEnumerable<TBPhotoAboutHomeContent> ListPhotoAboutHomeContent { get; set; }
        public TBPhotoAboutHomeContent PhotoAboutHomeContent { get; set; }
        public IEnumerable<TBSliderHomeContent> ListSliderHomeConten { get; set; }
        public TBSliderHomeContent SliderHomeConten { get; set; }   
		public IEnumerable<TBViewPhotoSliderHomeContent> ListViewPhotoSliderHomeContent { get; set; }
        public TBPhotoSliderHomeContent PhotoSliderHomeContent { get; set; }
		public IEnumerable<TBTaxiInfoStep> ListTaxiInfoStep { get; set; }
        public TBTaxiInfoStep TaxiInfoStep { get; set; }
		public IEnumerable<TBServicesHomeContent> ListServicesHomeContent { get; set; }
        public TBServicesHomeContent ServicesHomeContent { get; set; }	
		public IEnumerable<TBService> ListService { get; set; }
        public TBService Service { get; set; }
		public IEnumerable<TBChooseUsHomeContent> ListChooseUsHomeContent { get; set; }
        public TBChooseUsHomeContent ChooseUsHomeContent { get; set; }	
		public IEnumerable<TBBointChooseUsHomeContent> ListBointChooseUsHomeContent { get; set; }
        public TBBointChooseUsHomeContent BointChooseUsHomeContent { get; set; }
        public IEnumerable<TBCarCategorie> ListCarCategorie { get; set; }
        public TBCarCategorie CarCategorie { get; set; }  
		public IEnumerable<TBTaxiRatesHomeContent> ListTaxiRatesHomeContent { get; set; }
        public TBTaxiRatesHomeContent TaxiRatesHomeContent { get; set; }
		public IEnumerable<TBPhotoBookYourRideContent> ListPhotoBookYourRideContent { get; set; }
        public TBPhotoBookYourRideContent PhotoBookYourRideContent { get; set; }
		public IEnumerable<TBTaxiType> ListTaxiType { get; set; }
        public TBTaxiType TaxiType { get; set; }
    }
 }

