namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutHomeContentController : Controller
    {
        IIAboutHomeContent iAboutHomeContent;
        public AboutHomeContentController(IIAboutHomeContent iAboutHomeContent1)
        {
           iAboutHomeContent = iAboutHomeContent1;
        }
        public IActionResult MyAboutHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddAboutHomeContent(int? IdAboutHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListAboutHomeContent = iAboutHomeContent.GetAll();
            if (IdAboutHomeContent != null)
            {
                vmodel.AboutHomeContent = iAboutHomeContent.GetById(Convert.ToInt32(IdAboutHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }   
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBAboutHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdAboutHomeContent = model.AboutHomeContent.IdAboutHomeContent;
                slider.YearsExperience = model.AboutHomeContent.YearsExperience;
                slider.DescriptionYearsExperienceEn = model.AboutHomeContent.DescriptionYearsExperienceEn;
                slider.DescriptionYearsExperienceAr = model.AboutHomeContent.DescriptionYearsExperienceAr;
                slider.DescriptionYearsExperienceKr1 = model.AboutHomeContent.DescriptionYearsExperienceKr1;
                slider.DescriptionYearsExperienceKr2 = model.AboutHomeContent.DescriptionYearsExperienceKr2;
                slider.TitelOneEn = model.AboutHomeContent.TitelOneEn;
                slider.TitelOneAr = model.AboutHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.AboutHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.AboutHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.AboutHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.AboutHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.AboutHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.AboutHomeContent.TitelTwoKr2;
                slider.FirstDescriptionEN = model.AboutHomeContent.FirstDescriptionEN;
                slider.FirstDescriptionAr = model.AboutHomeContent.FirstDescriptionAr;
                slider.FirstDescriptionKr1 = model.AboutHomeContent.FirstDescriptionKr1;
                slider.FirstDescriptionKr2 = model.AboutHomeContent.FirstDescriptionKr2;
                slider.SecandDescriptionEn = model.AboutHomeContent.SecandDescriptionEn;
                slider.SecandDescriptionAr = model.AboutHomeContent.SecandDescriptionAr;
                slider.SecandDescriptionKr1 = model.AboutHomeContent.SecandDescriptionKr1;
                slider.SecandDescriptionKr2 = model.AboutHomeContent.SecandDescriptionKr2;
                slider.PhoneDescriptionEn = model.AboutHomeContent.PhoneDescriptionEn;
                slider.PhoneDescriptionAr = model.AboutHomeContent.PhoneDescriptionAr;
                slider.PhoneDescriptionKr1 = model.AboutHomeContent.PhoneDescriptionKr1;
                slider.PhoneDescriptionKr2 = model.AboutHomeContent.PhoneDescriptionKr2;
                slider.DataEntry = model.AboutHomeContent.DataEntry;
                slider.DateTimeEntry = model.AboutHomeContent.DateTimeEntry;
                slider.CurrentState = model.AboutHomeContent.CurrentState;
                if (slider.IdAboutHomeContent == 0 || slider.IdAboutHomeContent == null)
                {                
                    var reqwest = iAboutHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyAboutHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iAboutHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyAboutHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return Redirect(returnUrl);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdAboutHomeContent)
        {
            var reqwistDelete = iAboutHomeContent.deleteData(IdAboutHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyAboutHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyAboutHomeContent");

            }



        }
    }
}