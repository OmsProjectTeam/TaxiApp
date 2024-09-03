

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class TestimonialHomeContentController : Controller
	{
		IITestimonialHomeContent iTestimonialHomeContent;
		public TestimonialHomeContentController(IITestimonialHomeContent iTestimonialHomeContent1)
        {
			iTestimonialHomeContent = iTestimonialHomeContent1;

		}


		public IActionResult MyTestimonialHomeContent()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll();
			return View(vmodel);
		}
		public IActionResult AddTestimonialHomeContent(int? IdTestimonialHomeContent)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTestimonialHomeContent = iTestimonialHomeContent.GetAll();
			if (IdTestimonialHomeContent != null)
			{
				vmodel.TestimonialHomeContent = iTestimonialHomeContent.GetById(Convert.ToInt32(IdTestimonialHomeContent));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTestimonialHomeContent slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdTestimonialHomeContent = model.TestimonialHomeContent.IdTestimonialHomeContent;
				slider.TitelOneEn = model.TestimonialHomeContent.TitelOneEn;
				slider.TitelOneAr = model.TestimonialHomeContent.TitelOneAr;
				slider.TitelOneKr1 = model.TestimonialHomeContent.TitelOneKr1;
				slider.TitelOneKr2 = model.TestimonialHomeContent.TitelOneKr2;
				slider.TitelTwoEn = model.TestimonialHomeContent.TitelTwoEn;
				slider.TitelTwoAr = model.TestimonialHomeContent.TitelTwoAr;
				slider.TitelTwoKr1 = model.TestimonialHomeContent.TitelTwoKr1;
				slider.TitelTwoKr2 = model.TestimonialHomeContent.TitelTwoKr2;
				slider.TitelThreeAr = model.TestimonialHomeContent.TitelThreeAr;
				slider.TitelThreeEn = model.TestimonialHomeContent.TitelThreeEn;
				slider.TitelThreeKr1 = model.TestimonialHomeContent.TitelThreeKr1;
				slider.TitelThreeKr2 = model.TestimonialHomeContent.TitelThreeKr2;
				slider.DataEntry = model.TestimonialHomeContent.DataEntry;
				slider.DateTimeEntry = model.TestimonialHomeContent.DateTimeEntry;
				slider.CurrentState = model.TestimonialHomeContent.CurrentState;
				if (slider.IdTestimonialHomeContent == 0 || slider.IdTestimonialHomeContent == null)
				{
					var reqwest = iTestimonialHomeContent.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyTestimonialHomeContent");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return RedirectToAction("AddTestimonialHomeContent");
					}
				}
				else
				{
					var reqestUpdate = iTestimonialHomeContent.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyTestimonialHomeContent");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
						return RedirectToAction("AddTestimonialHomeContent");
					}
				}
			}
			catch
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
				return RedirectToAction("AddTestimonialHomeContent");
			}
		}
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteData(int IdTestimonialHomeContent)
		{
			var reqwistDelete = iTestimonialHomeContent.deleteData(IdTestimonialHomeContent);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyTestimonialHomeContent");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyTestimonialHomeContent");

			}
		}
	}
}
