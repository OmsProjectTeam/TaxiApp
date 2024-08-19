namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaxiTypeController : Controller
    {
        MasterDbcontext dbcontext;
        IITaxiType iTaxiType;
        public TaxiTypeController(MasterDbcontext dbcontext1,IITaxiType iTaxiType1)
        {
            dbcontext=dbcontext1;
            iTaxiType =iTaxiType1;
        }
        public IActionResult MYTaxiType()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiType = iTaxiType.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditTaxiType(int? IdTaxiType)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiType = iTaxiType.GetAll();
            if (IdTaxiType != null)
            {
                vmodel.TaxiType = iTaxiType.GetById(Convert.ToInt32(IdTaxiType));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditTaxiTypeImage(int? IdTaxiType)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiType = iTaxiType.GetAll();
            if (IdTaxiType != null)
            {
                vmodel.TaxiType = iTaxiType.GetById(Convert.ToInt32(IdTaxiType));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTaxiType slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTaxiType = model.TaxiType.IdTaxiType;
                slider.TaxiTypeAr = model.TaxiType.TaxiTypeAr;
                slider.TaxiTypeEn = model.TaxiType.TaxiTypeEn;
                slider.TaxiTypeKr1 = model.TaxiType.TaxiTypeKr1;
                slider.TaxiTypeKr2 = model.TaxiType.TaxiTypeKr2;
                slider.Active = model.TaxiType.Active;
                slider.Photo = model.TaxiType.Photo;
                slider.DateTimeEntry = model.TaxiType.DateTimeEntry;
                slider.DataEntry = model.TaxiType.DataEntry;
                slider.CurrentState = model.TaxiType.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdTaxiType == 0 || slider.IdTaxiType == null)
                {
                    if (dbcontext.TBTaxiTypes.Where(a => a.TaxiTypeAr == slider.TaxiTypeAr).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLTaxiTypeDoplceted;
                        return RedirectToAction("AddEditTaxiType");
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
                        return RedirectToAction("AddEditTaxiType");
                    }
                    var reqwest = iTaxiType.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYTaxiType");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iTaxiType.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditTaxiType");
                    }
                }
                else
                {
                    if (file.Count() == 0)
                    {
                        slider.Photo = model.TaxiType.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iTaxiType.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYTaxiType");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iTaxiType.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditTaxiTypeImage");
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iTaxiType.DELETPhoto(slider.IdTaxiType);
                        var reqestUpdate2 = iTaxiType.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYTaxiType");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iTaxiType.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditTaxiTypeImage");
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
                    //var delet = iTaxiType.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditTaxiType");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iTaxiType.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditTaxiType");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdTaxiType)
        {
            var reqwistDelete = iTaxiType.deleteData(IdTaxiType);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYTaxiType");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYTaxiType");
            }
        }
    }
}