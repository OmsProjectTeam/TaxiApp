

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DrivingLicenseCategoryController : Controller
    {
        MasterDbcontext dbcontext;
        IIDrivingLicenseCategory iDrivingLicenseCategory;
        public DrivingLicenseCategoryController(MasterDbcontext dbcontex1,IIDrivingLicenseCategory iDrivingLicenseCategory1)
        {
            dbcontext=dbcontex1;
            iDrivingLicenseCategory =iDrivingLicenseCategory1;
        }

        public IActionResult MyDrivingLicenseCategory()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListDrivingLicenseCategory = iDrivingLicenseCategory.GetAll();
            return View(vmodel);
        }
        public IActionResult AddDrivingLicenseCategory(int? IdDrivingLicenseCategory)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListDrivingLicenseCategory = iDrivingLicenseCategory.GetAll();
            if (IdDrivingLicenseCategory != null)
            {
                vmodel.DrivingLicenseCategory = iDrivingLicenseCategory.GetById(Convert.ToInt32(IdDrivingLicenseCategory));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBDrivingLicenseCategory slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdDrivingLicenseCategory = model.DrivingLicenseCategory.IdDrivingLicenseCategory;
                slider.DrivingLicenseCategoryAr = model.DrivingLicenseCategory.DrivingLicenseCategoryAr;
                slider.DrivingLicenseCategoryEn = model.DrivingLicenseCategory.DrivingLicenseCategoryEn;
                slider.DrivingLicenseCategoryKr1 = model.DrivingLicenseCategory.DrivingLicenseCategoryKr1;
                slider.DrivingLicenseCategoryKr2 = model.DrivingLicenseCategory.DrivingLicenseCategoryKr2;
                slider.Active = model.DrivingLicenseCategory.Active;
                slider.DataEntry = model.DrivingLicenseCategory.DataEntry;
                slider.DateTimeEntry = model.DrivingLicenseCategory.DateTimeEntry;
                slider.CurrentState = model.DrivingLicenseCategory.CurrentState;
                if (slider.IdDrivingLicenseCategory == 0 || slider.IdDrivingLicenseCategory == null)
                {


                    if (dbcontext.TBDrivingLicenseCategorys.Where(a => a.DrivingLicenseCategoryAr == slider.DrivingLicenseCategoryAr).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDrivingLicenseCategoryArDoplceted;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                    if (dbcontext.TBDrivingLicenseCategorys.Where(a => a.DrivingLicenseCategoryEn == slider.DrivingLicenseCategoryEn).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDrivingLicenseCategoryEnDoplceted;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                    if (dbcontext.TBDrivingLicenseCategorys.Where(a => a.DrivingLicenseCategoryKr1 == slider.DrivingLicenseCategoryKr1).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDrivingLicenseCategoryKr1Doplceted;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                    if (dbcontext.TBDrivingLicenseCategorys.Where(a => a.DrivingLicenseCategoryKr2 == slider.DrivingLicenseCategoryKr2).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDrivingLicenseCategoryKr2Doplceted;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                    var reqwest = iDrivingLicenseCategory.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyDrivingLicenseCategory");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                }
                else
                {
                    var reqestUpdate = iDrivingLicenseCategory.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyDrivingLicenseCategory");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddDrivingLicenseCategory");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddDrivingLicenseCategory");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdDrivingLicenseCategory)
        {
            var reqwistDelete = iDrivingLicenseCategory.deleteData(IdDrivingLicenseCategory);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyDrivingLicenseCategory");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyDrivingLicenseCategory");

            }
        }
    }
}
