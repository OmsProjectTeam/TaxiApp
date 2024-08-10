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

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IIAboutHomeContent iAboutHomeContent1,IIPhotoAboutHomeContent iPhotoAboutHomeContent1,IISliderHomeContent iSliderHomeContent1,IIPhotoSliderHomeContent iPhotoSliderHomeContent1,IITaxiInfoStep iTaxiInfoStep1,IIServicesHomeContent iServicesHomeContent1,IIService iService1,IIChooseUsHomeContent iChooseUsHomeContent1)
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

	
	}
}
