

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DriverCategoryController : Controller
    {
        MasterDbcontext dbcontext;
        IIDriverCategory iDriverCategory;
        public DriverCategoryController(MasterDbcontext dbcontaxt1,IIDriverCategory iDriverCategory1)
        {
            dbcontext= dbcontaxt1;
            iDriverCategory= iDriverCategory1;
        }
        public IActionResult MyDriverCategory()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListDriverCategory = iDriverCategory.GetAll();
            return View(vmodel);
        }
        public IActionResult AddDriverCategory(int? IdDriverCategory)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListDriverCategory = iDriverCategory.GetAll();
            if (IdDriverCategory != null)
            {
                vmodel.DriverCategory = iDriverCategory.GetById(Convert.ToInt32(IdDriverCategory));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBDriverCategory slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdDriverCategory = model.DriverCategory.IdDriverCategory;
                slider.DriverCategoryAr = model.DriverCategory.DriverCategoryAr;
                slider.DriverCategoryEn = model.DriverCategory.DriverCategoryEn;
                slider.DriverCategoryKr1 = model.DriverCategory.DriverCategoryKr1;
                slider.DriverCategoryKr2 = model.DriverCategory.DriverCategoryKr2;
                slider.Active = model.DriverCategory.Active;             
                slider.DataEntry = model.DriverCategory.DataEntry;
                slider.DateTimeEntry = model.DriverCategory.DateTimeEntry;
                slider.CurrentState = model.DriverCategory.CurrentState;
                if (slider.IdDriverCategory == 0 || slider.IdDriverCategory == null)
                {


                    if (dbcontext.TBDriverCategorys.Where(a => a.DriverCategoryAr == slider.DriverCategoryAr).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDriverCategoryArDoplceted;
                        return RedirectToAction("AddDriverCategory");
                    }
                    if (dbcontext.TBDriverCategorys.Where(a => a.DriverCategoryEn == slider.DriverCategoryEn).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDriverCategoryEnDoplceted;
                        return RedirectToAction("AddDriverCategory");
                    }
                    if (dbcontext.TBDriverCategorys.Where(a => a.DriverCategoryKr1 == slider.DriverCategoryKr1).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDriverCategoryKr1Doplceted;
                        return RedirectToAction("AddDriverCategory");
                    }
                    if (dbcontext.TBDriverCategorys.Where(a => a.DriverCategoryKr2 == slider.DriverCategoryKr2).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLDriverCategoryKr2Doplceted;
                        return RedirectToAction("AddDriverCategory");
                    }
                    var reqwest = iDriverCategory.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyDriverCategory");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddDriverCategory");
                    }
                }
                else
                {
                    var reqestUpdate = iDriverCategory.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyDriverCategory");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddDriverCategory");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddDriverCategory");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdDriverCategory)
        {
            var reqwistDelete = iDriverCategory.deleteData(IdDriverCategory);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyDriverCategory");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyDriverCategory");

            }
        }
    }
}
