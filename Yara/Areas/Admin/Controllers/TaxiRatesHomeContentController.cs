

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaxiRatesHomeContentController : Controller
    {
        IITaxiRatesHomeContent iTaxiRatesHomeContent;
        public TaxiRatesHomeContentController(IITaxiRatesHomeContent iTaxiRatesHomeContent1)
        {
            iTaxiRatesHomeContent= iTaxiRatesHomeContent1;
        }
        public IActionResult MyTaxiRatesHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTaxiRatesHomeContent(int? IdTaxiRatesHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiRatesHomeContent = iTaxiRatesHomeContent.GetAll();
            if (IdTaxiRatesHomeContent != null)
            {
                vmodel.TaxiRatesHomeContent = iTaxiRatesHomeContent.GetById(Convert.ToInt32(IdTaxiRatesHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTaxiRatesHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTaxiRatesHomeContent = model.TaxiRatesHomeContent.IdTaxiRatesHomeContent;
                slider.TitelOneEn = model.TaxiRatesHomeContent.TitelOneEn;
                slider.TitelOneAr = model.TaxiRatesHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.TaxiRatesHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.TaxiRatesHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.TaxiRatesHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.TaxiRatesHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.TaxiRatesHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.TaxiRatesHomeContent.TitelTwoKr2;
                slider.TitelThreeAr = model.TaxiRatesHomeContent.TitelThreeAr;
                slider.TitelThreeEn = model.TaxiRatesHomeContent.TitelThreeEn;
                slider.TitelThreeKr1 = model.TaxiRatesHomeContent.TitelThreeKr1;
                slider.TitelThreeKr2 = model.TaxiRatesHomeContent.TitelThreeKr2;
                slider.DataEntry = model.TaxiRatesHomeContent.DataEntry;
                slider.DateTimeEntry = model.TaxiRatesHomeContent.DateTimeEntry;
                slider.CurrentState = model.TaxiRatesHomeContent.CurrentState;
                if (slider.IdTaxiRatesHomeContent == 0 || slider.IdTaxiRatesHomeContent == null)
                {
                    var reqwest = iTaxiRatesHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTaxiRatesHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddTaxiRatesHomeContent");
                    }
                }
                else
                {
                    var reqestUpdate = iTaxiRatesHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTaxiRatesHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddTaxiRatesHomeContent");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddTaxiRatesHomeContent");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdTaxiRatesHomeContent)
        {
            var reqwistDelete = iTaxiRatesHomeContent.deleteData(IdTaxiRatesHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTaxiRatesHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTaxiRatesHomeContent");

            }
        }
    }
}

