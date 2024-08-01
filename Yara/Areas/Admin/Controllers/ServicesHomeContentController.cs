namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServicesHomeContentController : Controller
    {
        IIServicesHomeContent iServicesHomeContent;
        public ServicesHomeContentController(IIServicesHomeContent iServicesHomeContent1)
        {
            iServicesHomeContent = iServicesHomeContent1;
        }
        public IActionResult MyServicesHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddServicesHomeContent(int? IdServicesHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListServicesHomeContent = iServicesHomeContent.GetAll();
            if (IdServicesHomeContent != null)
            {
                vmodel.ServicesHomeContent = iServicesHomeContent.GetById(Convert.ToInt32(IdServicesHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBServicesHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdServicesHomeContent = model.ServicesHomeContent.IdServicesHomeContent;          
                slider.TitelOneEn = model.ServicesHomeContent.TitelOneEn;
                slider.TitelOneAr = model.ServicesHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.ServicesHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.ServicesHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.ServicesHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.ServicesHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.ServicesHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.ServicesHomeContent.TitelTwoKr2;
                slider.TitelThreeAr = model.ServicesHomeContent.TitelThreeAr;
                slider.TitelThreeEn = model.ServicesHomeContent.TitelThreeEn;
                slider.TitelThreeKr1 = model.ServicesHomeContent.TitelThreeKr1;
                slider.TitelThreeKr2 = model.ServicesHomeContent.TitelThreeKr2;         
                slider.DataEntry = model.ServicesHomeContent.DataEntry;
                slider.DateTimeEntry = model.ServicesHomeContent.DateTimeEntry;
                slider.CurrentState = model.ServicesHomeContent.CurrentState;
                if (slider.IdServicesHomeContent == 0 || slider.IdServicesHomeContent == null)
                {
                    var reqwest = iServicesHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyServicesHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddServicesHomeContent");
                    }
                }
                else
                {
                    var reqestUpdate = iServicesHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyServicesHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddServicesHomeContent");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddServicesHomeContent"); 
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdServicesHomeContent)
        {
            var reqwistDelete = iServicesHomeContent.deleteData(IdServicesHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyServicesHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyServicesHomeContent");

            }
        }
    }
}