

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentHomeBookNowController : Controller
    {
        IIContentHomeBookNow iContentHomeBookNow;
        public ContentHomeBookNowController(IIContentHomeBookNow iContentHomeBookNow1)
        {
            iContentHomeBookNow=iContentHomeBookNow1;
        }
        public IActionResult MyContentHomeBookNow()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListContentHomeBookNow = iContentHomeBookNow.GetAll();
            return View(vmodel);
        }
        public IActionResult AddContentHomeBookNow(int? IdContentHomeBookNow)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListContentHomeBookNow = iContentHomeBookNow.GetAll();
            if (IdContentHomeBookNow != null)
            {
                vmodel.ContentHomeBookNow = iContentHomeBookNow.GetById(Convert.ToInt32(IdContentHomeBookNow));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBContentHomeBookNow slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdContentHomeBookNow = model.ContentHomeBookNow.IdContentHomeBookNow;
                slider.TitelOneEn = model.ContentHomeBookNow.TitelOneEn;
                slider.TitelOneAr = model.ContentHomeBookNow.TitelOneAr;
                slider.TitelOneKr1 = model.ContentHomeBookNow.TitelOneKr1;
                slider.TitelOneKr2 = model.ContentHomeBookNow.TitelOneKr2;
                slider.TitelTwoEn = model.ContentHomeBookNow.TitelTwoEn;
                slider.TitelTwoAr = model.ContentHomeBookNow.TitelTwoAr;
                slider.TitelTwoKr1 = model.ContentHomeBookNow.TitelTwoKr1;
                slider.TitelTwoKr2 = model.ContentHomeBookNow.TitelTwoKr2;           
                slider.TitleButtonEn = model.ContentHomeBookNow.TitleButtonEn;
                slider.TitleButtonAr = model.ContentHomeBookNow.TitleButtonAr;
                slider.TitleButtonKr1 = model.ContentHomeBookNow.TitleButtonKr1;
                slider.TitleButtonKr2 = model.ContentHomeBookNow.TitleButtonKr2;
                slider.UrlButtonEn = model.ContentHomeBookNow.UrlButtonEn;
                slider.UrlButtonAr = model.ContentHomeBookNow.UrlButtonAr;
                slider.UrlButtonKr1 = model.ContentHomeBookNow.UrlButtonKr1;
                slider.UrlButtonKr2 = model.ContentHomeBookNow.UrlButtonKr2;
                slider.DataEntry = model.ContentHomeBookNow.DataEntry;
                slider.DateTimeEntry = model.ContentHomeBookNow.DateTimeEntry;
                slider.CurrentState = model.ContentHomeBookNow.CurrentState;
                if (slider.IdContentHomeBookNow == 0 || slider.IdContentHomeBookNow == null)
                {
                    var reqwest = iContentHomeBookNow.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyContentHomeBookNow");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iContentHomeBookNow.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyContentHomeBookNow");
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
        public IActionResult DeleteData(int IdContentHomeBookNow)
        {
            var reqwistDelete = iContentHomeBookNow.deleteData(IdContentHomeBookNow);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyContentHomeBookNow");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyContentHomeBookNow");
            }
        }
    }
}