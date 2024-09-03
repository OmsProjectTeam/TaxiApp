namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class latestNewsBlogHomeContentController : Controller
    {
        IIlatestNewsBlogHomeContent ilatestNewsBlogHomeContent;
        public latestNewsBlogHomeContentController(IIlatestNewsBlogHomeContent ilatestNewsBlogHomeContent1)
        {
            ilatestNewsBlogHomeContent= ilatestNewsBlogHomeContent1;
        }
        public IActionResult MylatestNewsBlogHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddlatestNewsBlogHomeContent(int? IdlatestNewsBlogHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListlatestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetAll();
            if (IdlatestNewsBlogHomeContent != null)
            {
                vmodel.latestNewsBlogHomeContent = ilatestNewsBlogHomeContent.GetById(Convert.ToInt32(IdlatestNewsBlogHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBlatestNewsBlogHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdlatestNewsBlogHomeContent = model.latestNewsBlogHomeContent.IdlatestNewsBlogHomeContent;
                slider.TitelOneEn = model.latestNewsBlogHomeContent.TitelOneEn;
                slider.TitelOneAr = model.latestNewsBlogHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.latestNewsBlogHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.latestNewsBlogHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.latestNewsBlogHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.latestNewsBlogHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.latestNewsBlogHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.latestNewsBlogHomeContent.TitelTwoKr2;
                slider.TitelThreeEn = model.latestNewsBlogHomeContent.TitelThreeEn;
                slider.TitelThreeAr = model.latestNewsBlogHomeContent.TitelThreeAr;
                slider.TitelThreeKr1 = model.latestNewsBlogHomeContent.TitelThreeKr1;
                slider.TitelThreeKr2 = model.latestNewsBlogHomeContent.TitelThreeKr2;
                slider.TitleButtonEn = model.latestNewsBlogHomeContent.TitleButtonEn;
                slider.TitleButtonAr = model.latestNewsBlogHomeContent.TitleButtonAr;
                slider.TitleButtonKr1 = model.latestNewsBlogHomeContent.TitleButtonKr1;
                slider.TitleButtonKr2 = model.latestNewsBlogHomeContent.TitleButtonKr2;
                slider.UrlButtonEn = model.latestNewsBlogHomeContent.UrlButtonEn;
                slider.UrlButtonAr = model.latestNewsBlogHomeContent.UrlButtonAr;
                slider.UrlButtonKr1 = model.latestNewsBlogHomeContent.UrlButtonKr1;
                slider.UrlButtonKr2 = model.latestNewsBlogHomeContent.UrlButtonKr2;       
                slider.DataEntry = model.latestNewsBlogHomeContent.DataEntry;
                slider.DateTimeEntry = model.latestNewsBlogHomeContent.DateTimeEntry;
                slider.CurrentState = model.latestNewsBlogHomeContent.CurrentState;
                if (slider.IdlatestNewsBlogHomeContent == 0 || slider.IdlatestNewsBlogHomeContent == null)
                {
                    var reqwest = ilatestNewsBlogHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MylatestNewsBlogHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = ilatestNewsBlogHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MylatestNewsBlogHomeContent");
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
        public IActionResult DeleteData(int IdlatestNewsBlogHomeContent)
        {
            var reqwistDelete = ilatestNewsBlogHomeContent.deleteData(IdlatestNewsBlogHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MylatestNewsBlogHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MylatestNewsBlogHomeContent");

            }



        }
    }
}