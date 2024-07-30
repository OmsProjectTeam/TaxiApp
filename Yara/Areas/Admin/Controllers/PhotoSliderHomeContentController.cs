

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoSliderHomeContentController : Controller
    {
        IIPhotoSliderHomeContent iPhotoSliderHomeContent;
        IISliderHomeContent iSliderHomeContent;
        public PhotoSliderHomeContentController(IIPhotoSliderHomeContent iPhotoSliderHomeContent1, IISliderHomeContent iSliderHomeContent1)
        {
            iPhotoSliderHomeContent = iPhotoSliderHomeContent1;
            iSliderHomeContent = iSliderHomeContent1;
        }
        public IActionResult MYPhotoSliderHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditPhotoSliderHomeContent(int? IdPhotoSliderHomeContent)
        {
            ViewBag.Categorie = iSliderHomeContent.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            if (IdPhotoSliderHomeContent != null)
            {
                vmodel.PhotoSliderHomeContent = iPhotoSliderHomeContent.GetById(Convert.ToInt32(IdPhotoSliderHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoSliderHomeContentImage(int? IdPhotoSliderHomeContent)
        {
            ViewBag.Categorie = iSliderHomeContent.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPhotoSliderHomeContent = iPhotoSliderHomeContent.GetAll();
            if (IdPhotoSliderHomeContent != null)
            {
                vmodel.PhotoSliderHomeContent = iPhotoSliderHomeContent.GetById(Convert.ToInt32(IdPhotoSliderHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoSliderHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoSliderHomeContent = model.PhotoSliderHomeContent.IdPhotoSliderHomeContent;
                slider.IdSliderHomeContent = model.PhotoSliderHomeContent.IdSliderHomeContent;
                slider.Photo = model.PhotoSliderHomeContent.Photo;
                slider.DateTimeEntry = model.PhotoSliderHomeContent.DateTimeEntry;
                slider.DataEntry = model.PhotoSliderHomeContent.DataEntry;
                slider.CurrentState = model.PhotoSliderHomeContent.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoSliderHomeContent == 0 || slider.IdPhotoSliderHomeContent == null)
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
                        return Redirect(returnUrl);
                    }
                    var reqwest = iPhotoSliderHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoSliderHomeContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoSliderHomeContent.DELETPHOTO(slider.IdPhotoSliderHomeContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoSliderHomeContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoSliderHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoSliderHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoSliderHomeContent.DELETPHOTO(slider.IdPhotoSliderHomeContent);
                        var reqestUpdate2 = iPhotoSliderHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoSliderHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
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
                    //var delet = iPhotoSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoSliderHomeContent)
        {
            var reqwistDelete = iPhotoSliderHomeContent.deleteData(IdPhotoSliderHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoSliderHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoSliderHomeContent");
            }
        }
    }
}
