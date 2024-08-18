

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarCategorieController : Controller
    {
        MasterDbcontext dbcontext;
        IICarCategorie iCarCategorie;
        public CarCategorieController(MasterDbcontext dbcontext1,IICarCategorie iCarCategorie1)
        {
            dbcontext= dbcontext1;
            iCarCategorie = iCarCategorie1;
        }
        public IActionResult MYCarCategorie()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditCarCategorie(int? IdCarCategories)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            if (IdCarCategories != null)
            {
                vmodel.CarCategorie = iCarCategorie.GetById(Convert.ToInt32(IdCarCategories));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditCarCategorieImage(int? IdCarCategories)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCarCategorie = iCarCategorie.GetAll();
            if (IdCarCategories != null)
            {
                vmodel.CarCategorie = iCarCategorie.GetById(Convert.ToInt32(IdCarCategories));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBCarCategorie slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdCarCategories = model.CarCategorie.IdCarCategories;
                slider.CarCategorieAr = model.CarCategorie.CarCategorieAr;
                slider.CarCategorieEn = model.CarCategorie.CarCategorieEn;
                slider.CarCategorieKr1 = model.CarCategorie.CarCategorieKr1;
                slider.CarCategorieKr2 = model.CarCategorie.CarCategorieKr2;           
                slider.Active = model.CarCategorie.Active;
                slider.Photo = model.CarCategorie.Photo;
                slider.DateTimeEntry = model.CarCategorie.DateTimeEntry;
                slider.DataEntry = model.CarCategorie.DataEntry;
                slider.CurrentState = model.CarCategorie.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdCarCategories == 0 || slider.IdCarCategories == null)
                {
                    if (dbcontext.TBCarCategories.Where(a => a.CarCategorieAr == slider.CarCategorieAr).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLCarCategorieDoplceted;
                        return RedirectToAction("AddEditCarCategorie");
                    }
                    if (file.Count() > 0)
                    {
                        string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        slider.Photo = Photo;
                        fileStream.Close();
                    }
                    else
                    {
                        TempData["Message"] = ResourceWeb.VLimageuplode;
                        return RedirectToAction("AddEditCarCategorie");
                    }
                    var reqwest = iCarCategorie.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYCarCategorie");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iCarCategorie.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditCarCategorie");
                    }
                }
                else
                {    
                    if (file.Count() == 0)
                    {
                        slider.Photo = model.CarCategorie.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iCarCategorie.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYCarCategorie");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iCarCategorie.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditCarCategorieImage");
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iCarCategorie.DELETPhoto(slider.IdCarCategories);
                        var reqestUpdate2 = iCarCategorie.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYCarCategorie");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iCarCategorie.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditCarCategorieImage");
                        }
                    }
                }
            }
            catch
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count() == 0)

                {
                    //var PhotoNAme = slider.Photo;
                    //var delet = iCarCategorie.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditCarCategorie");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iCarCategorie.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditCarCategorie");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdCarCategories)
        {
            var reqwistDelete = iCarCategorie.deleteData(IdCarCategories);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYCarCategorie");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYCarCategorie");
            }
        }
    }
}