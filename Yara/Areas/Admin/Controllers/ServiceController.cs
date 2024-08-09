namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        MasterDbcontext dbcontext;
        IIService iService;
        public ServiceController(MasterDbcontext dbcontext1, IIService iService1)
        {
            dbcontext = dbcontext1;
            iService = iService1;
        }
        public IActionResult MYService()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListService = iService.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditService(int? IdService)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListService = iService.GetAll();
            if (IdService != null)
            {
                vmodel.Service = iService.GetById(Convert.ToInt32(IdService));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditServiceImage(int? IdService)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListService = iService.GetAll();
            if (IdService != null)
            {
                vmodel.Service = iService.GetById(Convert.ToInt32(IdService));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBService slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdService = model.Service.IdService;
                slider.ServiceAr = model.Service.ServiceAr;
                slider.ServiceEn = model.Service.ServiceEn;
                slider.ServiceKr1 = model.Service.ServiceKr1;
                slider.ServiceKr2 = model.Service.ServiceKr2;
                slider.UrlServiceAr = model.Service.UrlServiceAr;
                slider.UrlServiceEn = model.Service.UrlServiceEn;
                slider.UrlServiceKr1 = model.Service.UrlServiceKr1;
                slider.UrlServiceKr2 = model.Service.UrlServiceKr2;
                slider.Active = model.Service.Active;
                slider.Photo = model.Service.Photo;
                slider.DateTimeEntry = model.Service.DateTimeEntry;
                slider.DataEntry = model.Service.DataEntry;
                slider.CurrentState = model.Service.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdService == 0 || slider.IdService == null)
                {
                    if (dbcontext.TBServices.Where(a => a.ServiceAr == slider.ServiceAr).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLServiceDoplceted;
                        return RedirectToAction("AddEditService");
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
                        return RedirectToAction("AddEditService");
                    }
                    var reqwest = iService.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYService");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iService.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditService");
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iService.DELETPHOTO(slider.IdService);

                    if (file.Count() == 0)
                    {
                        slider.Photo = model.Service.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iService.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYService");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iService.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditServiceImage");
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iService.DELETPhoto(slider.IdService);
                        var reqestUpdate2 = iService.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYService");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iService.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditServiceImage");
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
                    //var delet = iService.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditService");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iService.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditService");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdService)
        {
            var reqwistDelete = iService.deleteData(IdService);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYService");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYService");
            }
        }
    }
}