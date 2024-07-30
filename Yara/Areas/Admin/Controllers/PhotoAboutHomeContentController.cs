

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoAboutHomeContentController : Controller
    {
        IIPhotoAboutHomeContent iPhotoAboutHomeContent;
        public PhotoAboutHomeContentController(IIPhotoAboutHomeContent iPhotoAboutHomeContent1)
        {
            iPhotoAboutHomeContent = iPhotoAboutHomeContent1;
        }
        public IActionResult MYPhotoAboutHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            return View(vmodel);
        } 
        public IActionResult AddEditPhotoAboutHomeContent(int? IdPhotoAboutHomeContent)
        {     
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            if (IdPhotoAboutHomeContent != null)
            {
                vmodel.PhotoAboutHomeContent = iPhotoAboutHomeContent.GetById(Convert.ToInt32(IdPhotoAboutHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoAboutHomeContentImage(int? IdPhotoAboutHomeContent)
        {
    
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoAboutHomeContent = iPhotoAboutHomeContent.GetAll();
            if (IdPhotoAboutHomeContent != null)
            {
                vmodel.PhotoAboutHomeContent = iPhotoAboutHomeContent.GetById(Convert.ToInt32(IdPhotoAboutHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoAboutHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoAboutHomeContent = model.PhotoAboutHomeContent.IdPhotoAboutHomeContent;
              
                slider.Photo = model.PhotoAboutHomeContent.Photo;
           
                slider.DateTimeEntry = model.PhotoAboutHomeContent.DateTimeEntry;
                slider.DataEntry = model.PhotoAboutHomeContent.DataEntry;
                slider.CurrentState = model.PhotoAboutHomeContent.CurrentState;        
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoAboutHomeContent == 0 || slider.IdPhotoAboutHomeContent == null)
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
                 

                    var reqwest = iPhotoAboutHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoAboutHomeContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoAboutHomeContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoAboutHomeContent.DELETPHOTO(slider.IdPhotoAboutHomeContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoAboutHomeContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoAboutHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoAboutHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoAboutHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoAboutHomeContent.DELETPhoto(slider.IdPhotoAboutHomeContent);
                        var reqestUpdate2 = iPhotoAboutHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoAboutHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoAboutHomeContent.DELETPhotoWethError(PhotoNAme);
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
                    //var delet = iPhotoAboutHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoAboutHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoAboutHomeContent)
        {
            var reqwistDelete = iPhotoAboutHomeContent.deleteData(IdPhotoAboutHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoAboutHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoAboutHomeContent");
            }
        }
    }
}