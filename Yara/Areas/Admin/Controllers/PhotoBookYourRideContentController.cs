

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoBookYourRideContentController : Controller
    {
        IIPhotoBookYourRideContent iPhotoBookYourRideContent;
        public PhotoBookYourRideContentController(IIPhotoBookYourRideContent iPhotoBookYourRideContent1)
        {
            iPhotoBookYourRideContent=iPhotoBookYourRideContent1;
        }
        public IActionResult MYPhotoBookYourRideContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditPhotoBookYourRideContent(int? IdPhotoBookYourRideContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll();
            if (IdPhotoBookYourRideContent != null)
            {
                vmodel.PhotoBookYourRideContent = iPhotoBookYourRideContent.GetById(Convert.ToInt32(IdPhotoBookYourRideContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoBookYourRideContentImage(int? IdPhotoBookYourRideContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll();
            if (IdPhotoBookYourRideContent != null)
            {
                vmodel.PhotoBookYourRideContent = iPhotoBookYourRideContent.GetById(Convert.ToInt32(IdPhotoBookYourRideContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoBookYourRideContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoBookYourRideContent = model.PhotoBookYourRideContent.IdPhotoBookYourRideContent;
                slider.Photo = model.PhotoBookYourRideContent.Photo;
                slider.DateTimeEntry = model.PhotoBookYourRideContent.DateTimeEntry;
                slider.DataEntry = model.PhotoBookYourRideContent.DataEntry;
                slider.CurrentState = model.PhotoBookYourRideContent.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoBookYourRideContent == 0 || slider.IdPhotoBookYourRideContent == null)
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
                    var reqwest = iPhotoBookYourRideContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoBookYourRideContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoBookYourRideContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditPhotoBookYourRideContent");
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoBookYourRideContent.DELETPHOTO(slider.IdPhotoBookYourRideContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoBookYourRideContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoBookYourRideContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoBookYourRideContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoBookYourRideContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditPhotoBookYourRideContentImage");
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoBookYourRideContent.DELETPhoto(slider.IdPhotoBookYourRideContent);
                        var reqestUpdate2 = iPhotoBookYourRideContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoBookYourRideContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoBookYourRideContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditPhotoBookYourRideContentImage");
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
                    //var delet = iPhotoBookYourRideContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditPhotoBookYourRideContent");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoBookYourRideContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditPhotoBookYourRideContentImage");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoBookYourRideContent)
        {
            var reqwistDelete = iPhotoBookYourRideContent.deleteData(IdPhotoBookYourRideContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoBookYourRideContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoBookYourRideContent");
            }
        }

        public IActionResult MYPhotoBookYourRideContent1()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoBookYourRideContent = iPhotoBookYourRideContent.GetAll();
            return View(vmodel);
        }

    }
}