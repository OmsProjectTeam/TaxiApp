

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChooseUsHomeContentController : Controller
    {
        MasterDbcontext dbcontext;
        IIChooseUsHomeContent iChooseUsHomeContent;
        public ChooseUsHomeContentController(MasterDbcontext dbcontext1,IIChooseUsHomeContent iChooseUsHomeContent1)
        {
            dbcontext=dbcontext1;
            iChooseUsHomeContent=iChooseUsHomeContent1;
        }
        public IActionResult MyChooseUsHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddChooseUsHomeContent(int? IdChooseUsHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListChooseUsHomeContent = iChooseUsHomeContent.GetAll();
            if (IdChooseUsHomeContent != null)
            {
                vmodel.ChooseUsHomeContent = iChooseUsHomeContent.GetById(Convert.ToInt32(IdChooseUsHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBChooseUsHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdChooseUsHomeContent = model.ChooseUsHomeContent.IdChooseUsHomeContent;
                slider.TitelOneEn = model.ChooseUsHomeContent.TitelOneEn;
                slider.TitelOneAr = model.ChooseUsHomeContent.TitelOneAr;
                slider.TitelOneKr1 = model.ChooseUsHomeContent.TitelOneKr1;
                slider.TitelOneKr2 = model.ChooseUsHomeContent.TitelOneKr2;
                slider.TitelTwoEn = model.ChooseUsHomeContent.TitelTwoEn;
                slider.TitelTwoAr = model.ChooseUsHomeContent.TitelTwoAr;
                slider.TitelTwoKr1 = model.ChooseUsHomeContent.TitelTwoKr1;
                slider.TitelTwoKr2 = model.ChooseUsHomeContent.TitelTwoKr2;
                slider.TitelThreeAr = model.ChooseUsHomeContent.TitelThreeAr;
                slider.TitelThreeEn = model.ChooseUsHomeContent.TitelThreeEn;
                slider.TitelThreeKr1 = model.ChooseUsHomeContent.TitelThreeKr1;
                slider.TitelThreeKr2 = model.ChooseUsHomeContent.TitelThreeKr2;
                slider.DataEntry = model.ChooseUsHomeContent.DataEntry;
                slider.DateTimeEntry = model.ChooseUsHomeContent.DateTimeEntry;
                slider.CurrentState = model.ChooseUsHomeContent.CurrentState;
                if (slider.IdChooseUsHomeContent == 0 || slider.IdChooseUsHomeContent == null)
                {
                    var reqwest = iChooseUsHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyChooseUsHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddChooseUsHomeContent");
                    }
                }
                else
                {
                    var reqestUpdate = iChooseUsHomeContent.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyChooseUsHomeContent");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddChooseUsHomeContent");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddChooseUsHomeContent");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdChooseUsHomeContent)
        {
            var reqwistDelete = iChooseUsHomeContent.deleteData(IdChooseUsHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyChooseUsHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyChooseUsHomeContent");

            }
        }
    }
}
