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

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IIAboutHomeContent iAboutHomeContent1,IIPhotoAboutHomeContent iPhotoAboutHomeContent1,IISliderHomeContent iSliderHomeContent1)
		{
			_logger = logger;
			_userManager= userManager;
			iAboutHomeContent = iAboutHomeContent1;
            iPhotoAboutHomeContent = iPhotoAboutHomeContent1;
            iSliderHomeContent = iSliderHomeContent1;

        }

		public async Task<IActionResult> Index()
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
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
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();



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
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();



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
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();


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
