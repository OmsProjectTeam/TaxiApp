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

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IIAboutHomeContent iAboutHomeContent1)
		{
			_logger = logger;
			_userManager= userManager;
			iAboutHomeContent = iAboutHomeContent1;

        }

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return View();
			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);
			ViewBag.UserRole = role.FirstOrDefault();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            return View(vmodel);
		}
		public async Task<IActionResult> IndexAr()
		{
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View();
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            return View(vmodel);
        }
		public async Task<IActionResult> IndexKr1()
		{
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View();
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            return View(vmodel);
        }
		public async Task<IActionResult> IndexKr2()
		{
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View();
            // الحصول على دور المستخدم
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.UserRole = role.FirstOrDefault();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll().Take(1);
            return View(vmodel);
        }
		public IActionResult Privacy()
		{
			return View();
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}

		// comment from ali
		// test from ali
	}
}
