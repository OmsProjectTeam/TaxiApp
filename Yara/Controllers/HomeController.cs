using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Yara.Models;

namespace Yara.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		UserManager<ApplicationUser> _userManager;
		IIAboutHomeContent iAboutHomeContent;
        IIPhotoAboutHomeContent iPhotoAboutHomeContent;
        IISliderHomeContent iSliderHomeContent;
        IIPhotoSliderHomeContent iPhotoSliderHomeContent;
        IITaxiInfoStep iTaxiInfoStep;
        IIServicesHomeContent iServicesHomeContent;
        IIService iService;
        IIChooseUsHomeContent iChooseUsHomeContent;
        IIBointChooseUsHomeContent iBointChooseUsHomeContent;
        IICarCategorie iCarCategorie;
        IITaxiRatesHomeContent iTaxiRatesHomeContent;
        IIPhotoBookYourRideContent iPhotoBookYourRideContent;
        IITaxiType iTaxiType;
        IITaxizAppHomeContent iTaxizAppHomeContent;
        IIPhotoTaxizAppHomeContent iPhotoTaxizAppHomeContent;
        IITestimonialHomeContent iTestimonialHomeContent;
        IIPhotoTestimonialHomeContent iPhotoTestimonialHomeContent;
        IIlatestNewsBlogHomeContent ilatestNewsBlogHomeContent;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IIAboutHomeContent iAboutHomeContent1,IIPhotoAboutHomeContent iPhotoAboutHomeContent1,IISliderHomeContent iSliderHomeContent1,IIPhotoSliderHomeContent iPhotoSliderHomeContent1,IITaxiInfoStep iTaxiInfoStep1,IIServicesHomeContent iServicesHomeContent1,IIService iService1,IIChooseUsHomeContent iChooseUsHomeContent1,IIBointChooseUsHomeContent iBointChooseUsHomeContent1,IICarCategorie iCarCategorie1,IITaxiRatesHomeContent iTaxiRatesHomeContent1,IIPhotoBookYourRideContent iPhotoBookYourRideContent1,IITaxiType iTaxiType1,IITaxizAppHomeContent iTaxizAppHomeContent1,IIPhotoTaxizAppHomeContent iPhotoTaxizAppHomeContent1,IITestimonialHomeContent iTestimonialHomeContent1,IIPhotoTestimonialHomeContent iPhotoTestimonialHomeContent1,IIlatestNewsBlogHomeContent ilatestNewsBlogHomeContent1)
		{
			_logger = logger;
			_userManager= userManager;
			iAboutHomeContent = iAboutHomeContent1;
            iPhotoAboutHomeContent = iPhotoAboutHomeContent1;
            iSliderHomeContent = iSliderHomeContent1;
            iPhotoSliderHomeContent=    iPhotoSliderHomeContent1;
            iTaxiInfoStep=  iTaxiInfoStep1;
            iServicesHomeContent= iServicesHomeContent1;
            iService= iService1;
            iChooseUsHomeContent = iChooseUsHomeContent1;
            iBointChooseUsHomeContent = iBointChooseUsHomeContent1;
            iCarCategorie=  iCarCategorie1;
            iTaxiRatesHomeContent= iTaxiRatesHomeContent1;
            iPhotoBookYourRideContent = iPhotoBookYourRideContent1;
            iTaxiType= iTaxiType1;
            iTaxizAppHomeContent = iTaxizAppHomeContent1;
            iPhotoTaxizAppHomeContent=  iPhotoTaxizAppHomeContent1;
            iTestimonialHomeContent = iTestimonialHomeContent1;
            iPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent1;
            ilatestNewsBlogHomeContent = ilatestNewsBlogHomeContent1;
        }

		public async Task<IActionResult> Index()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll().Take(1);
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll().Take(1);
            vmodel.ListService = iService.GetAllHome();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll().Take(1);
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll().Take(1);
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll().Take(1);
            vmodel.ListTaxiType = iTaxiType.GetAll();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll().Take(1);

            var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return View(vmodel);
			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);
			ViewBag.UserRole = role.FirstOrDefault();
           
            return View(vmodel);
		}
		public async Task<IActionResult> IndexAr()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll().Take(1);
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll().Take(1);
            vmodel.ListService = iService.GetAllHome();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll().Take(1);
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll().Take(1);
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll().Take(1);
            vmodel.ListTaxiType = iTaxiType.GetAll();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll().Take(1);



            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(vmodel);
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();
         
            return View(vmodel);
        }
		public async Task<IActionResult> IndexKr1()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll().Take(1);
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll().Take(1);
            vmodel.ListService = iService.GetAllHome();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll().Take(1);
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll().Take(1);
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll().Take(1);
            vmodel.ListTaxiType = iTaxiType.GetAll();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll().Take(1);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(vmodel);
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();

            return View(vmodel);
        }
		public async Task<IActionResult> IndexKr2()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll().Take(1);
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll().Take(1);
            vmodel.ListService = iService.GetAllHome();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll().Take(1);
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll().Take(1);
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll().Take(1);
            vmodel.ListTaxiType = iTaxiType.GetAll();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll().Take(1);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(vmodel);
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();

            return View(vmodel);
        }
		public IActionResult Privacy()
		{
			return View();
		}	
        public async Task<IActionResult> Denied()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll().Take(1);
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll().Take(1);
            vmodel.ListService = iService.GetAllHome();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll().Take(1);
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll().Take(1);
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll().Take(1);
            vmodel.ListTaxiType = iTaxiType.GetAll();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll().Take(1);
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll().Take(1);
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll().Take(1);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(vmodel);
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();

            return View(vmodel);
        }

	
	}
}
