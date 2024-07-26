using Azure;
using Domin.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Merchant")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;
		
		public HomeController(UserManager<ApplicationUser> userManager,  IIUserInformation iUserInformation1)
        {
            _userManager = userManager;
            iUserInformation = iUserInformation1;
		
		}
        public async Task<IActionResult> Index(string userId)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

           

            return View(vmodel);
        }

		public async Task<IActionResult> IndexAr(string userId)
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

         

            return View(vmodel);
        }

		//[HttpPost("GetOrdersByPhone/{phoneNumber}")]
		//public async Task<ActionResult<IEnumerable<TBViewOrderNew>>> GetNewOrdersByPhone(string phoneNumber)
		//{
		//		var orders = await iOrderNew.GetOrdersByPhoneAsync(phoneNumber);
				
		//		return Ok(orders);
		//}
		//public async Task<ActionResult<IEnumerable<TBViewOrder>>> GetOldOrdersByPhone(string phoneNumber)
		//{
		//	var orders = await iOrder.GetOrdersByPhoneAsync(phoneNumber);

		//	return Ok(orders);
		//}
	}
}
