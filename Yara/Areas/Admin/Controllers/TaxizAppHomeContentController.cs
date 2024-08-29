

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaxizAppHomeContentController : Controller
    {
        IITaxizAppHomeContent iTaxizAppHomeContent;
        public TaxizAppHomeContentController(IITaxizAppHomeContent iTaxizAppHomeContent1)
        {
            iTaxizAppHomeContent= iTaxizAppHomeContent1;
        }
        public IActionResult MyTaxizAppHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTaxizAppHomeContent(int? IdTaxizAppHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxizAppHomeContent = iTaxizAppHomeContent.GetAll();
            if (IdTaxizAppHomeContent != null)
            {
                vmodel.TaxizAppHomeContent = iTaxizAppHomeContent.GetById(Convert.ToInt32(IdTaxizAppHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTaxizAppHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTaxizAppHomeContent = model.TaxizAppHomeContent.IdTaxizAppHomeContent;
                slider.TitelOneEn = model.TaxizAppHomeContent.TitelOneEn;
                slider.TitelOneAr = model.TaxizAppHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.TaxizAppHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.TaxizAppHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.TaxizAppHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.TaxizAppHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.TaxizAppHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.TaxizAppHomeContent.TitelTwoKr2;
                slider.TitelThreeAr = model.TaxizAppHomeContent.TitelThreeAr;
                slider.TitelThreeEn = model.TaxizAppHomeContent.TitelThreeEn;
                slider.TitelThreeKr1 = model.TaxizAppHomeContent.TitelThreeKr1;
                slider.TitelThreeKr2 = model.TaxizAppHomeContent.TitelThreeKr2;
                slider.FirstDescriptionEN = model.TaxizAppHomeContent.FirstDescriptionEN;
                slider.FirstDescriptionAr = model.TaxizAppHomeContent.FirstDescriptionAr;
                slider.FirstDescriptionKr1 = model.TaxizAppHomeContent.FirstDescriptionKr1;
                slider.FirstDescriptionKr2 = model.TaxizAppHomeContent.FirstDescriptionKr2;
                slider.UrlAndrAppAr = model.TaxizAppHomeContent.UrlAndrAppAr;
                slider.UrlAndrAppEn = model.TaxizAppHomeContent.UrlAndrAppEn;
                slider.UrlAndrAppKr1 = model.TaxizAppHomeContent.UrlAndrAppKr1;
                slider.UrlAndrAppKr2 = model.TaxizAppHomeContent.UrlAndrAppKr2;
                slider.UrlAppEn = model.TaxizAppHomeContent.UrlAppEn;
                slider.UrlAppAr = model.TaxizAppHomeContent.UrlAppAr;
                slider.UrlAppKr1 = model.TaxizAppHomeContent.UrlAppKr1;
                slider.UrlAppKr2 = model.TaxizAppHomeContent.UrlAppKr2;
                slider.DataEntry = model.TaxizAppHomeContent.DataEntry;
                slider.DateTimeEntry = model.TaxizAppHomeContent.DateTimeEntry;
                slider.CurrentState = model.TaxizAppHomeContent.CurrentState;
                if (slider.IdTaxizAppHomeContent == 0 || slider.IdTaxizAppHomeContent == null)
                {
                    var reqwest = iTaxizAppHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTaxizAppHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddTaxizAppHomeContent");
                    }
                }
                else
                {
                    var reqestUpdate = iTaxizAppHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTaxizAppHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddTaxizAppHomeContent");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddTaxizAppHomeContent");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdTaxizAppHomeContent)
        {
            var reqwistDelete = iTaxizAppHomeContent.deleteData(IdTaxizAppHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTaxizAppHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTaxizAppHomeContent");
            }
        }
    }
}