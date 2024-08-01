namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaxiInfoStepController : Controller
    {
        IITaxiInfoStep iTaxiInfoStep;
        public TaxiInfoStepController(IITaxiInfoStep iTaxiInfoStep1)
        {
            iTaxiInfoStep= iTaxiInfoStep1;
        }
        public IActionResult MYTaxiInfoStep()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditTaxiInfoStep(int? IdTaxiInfoStep)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll();
            if (IdTaxiInfoStep != null)
            {
                vmodel.TaxiInfoStep = iTaxiInfoStep.GetById(Convert.ToInt32(IdTaxiInfoStep));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditTaxiInfoStepImage(int? IdTaxiInfoStep)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaxiInfoStep = iTaxiInfoStep.GetAll();
            if (IdTaxiInfoStep != null)
            {
                vmodel.TaxiInfoStep = iTaxiInfoStep.GetById(Convert.ToInt32(IdTaxiInfoStep));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTaxiInfoStep slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTaxiInfoStep = model.TaxiInfoStep.IdTaxiInfoStep;
                slider.Photo = model.TaxiInfoStep.Photo;             
                slider.TitelOneEn = model.TaxiInfoStep.TitelOneEn;
                slider.TitelOneAr = model.TaxiInfoStep.TitelOneAr;
                slider.TitelOneKr1 = model.TaxiInfoStep.TitelOneKr1;
                slider.TitelOneKr2 = model.TaxiInfoStep.TitelOneKr2;
                slider.TitelTwoEn = model.TaxiInfoStep.TitelTwoEn;
                slider.TitelTwoAr = model.TaxiInfoStep.TitelTwoAr;
                slider.TitelTwoKr1 = model.TaxiInfoStep.TitelTwoKr1;
                slider.TitelTwoKr2 = model.TaxiInfoStep.TitelTwoKr2;
                slider.TitelThreeEn = model.TaxiInfoStep.TitelThreeEn;
                slider.TitelThreeAr = model.TaxiInfoStep.TitelThreeAr;
                slider.TitelThreeKr1 = model.TaxiInfoStep.TitelThreeKr1;
                slider.TitelThreeKr2 = model.TaxiInfoStep.TitelThreeKr2;
                slider.TitelForEn = model.TaxiInfoStep.TitelForEn;
                slider.TitelForAr = model.TaxiInfoStep.TitelForAr;
                slider.TitelForKr1 = model.TaxiInfoStep.TitelForKr1;
                slider.TitelForKr2 = model.TaxiInfoStep.TitelForKr2;
                slider.TitelVifeEn = model.TaxiInfoStep.TitelVifeEn;
                slider.TitelVifeAr = model.TaxiInfoStep.TitelVifeAr;
                slider.TitelVifeKr1 = model.TaxiInfoStep.TitelVifeKr1;
                slider.TitelVifeKr2 = model.TaxiInfoStep.TitelVifeKr2;
                slider.TitelSixEn = model.TaxiInfoStep.TitelSixEn;
                slider.TitelSixAr = model.TaxiInfoStep.TitelSixAr;
                slider.TitelSixKr1 = model.TaxiInfoStep.TitelSixKr1;
                slider.TitelSixKr2 = model.TaxiInfoStep.TitelSixKr2;   
                slider.DateTimeEntry = model.TaxiInfoStep.DateTimeEntry;
                slider.DataEntry = model.TaxiInfoStep.DataEntry;
                slider.CurrentState = model.TaxiInfoStep.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdTaxiInfoStep == 0 || slider.IdTaxiInfoStep == null)
                {
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
                        return RedirectToAction("AddEditTaxiInfoStep");
                    }
                    var reqwest = iTaxiInfoStep.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYTaxiInfoStep");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iTaxiInfoStep.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditTaxiInfoStep"); ;
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iTaxiInfoStep.DELETPHOTO(slider.IdTaxiInfoStep);
                    if (file.Count() == 0)

                    {
                        slider.Photo = model.TaxiInfoStep.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iTaxiInfoStep.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYTaxiInfoStep");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iTaxiInfoStep.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditTaxiInfoStep"); ;
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iTaxiInfoStep.DELETPhoto(slider.IdTaxiInfoStep);
                        var reqestUpdate2 = iTaxiInfoStep.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYTaxiInfoStep");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iTaxiInfoStep.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditTaxiInfoStep"); ;
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
                    //var delet = iTaxiInfoStep.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditTaxiInfoStep"); ;
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iTaxiInfoStep.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditTaxiInfoStep"); ;
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdTaxiInfoStep)
        {
            var reqwistDelete = iTaxiInfoStep.deleteData(IdTaxiInfoStep);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYTaxiInfoStep");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYTaxiInfoStep");
            }
        }
    }
}