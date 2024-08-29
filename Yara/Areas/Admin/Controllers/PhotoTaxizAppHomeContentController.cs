

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoTaxizAppHomeContentController : Controller
    {
        IIPhotoTaxizAppHomeContent iPhotoTaxizAppHomeContent;
        public PhotoTaxizAppHomeContentController(IIPhotoTaxizAppHomeContent iPhotoTaxizAppHomeContent1)
        {
            iPhotoTaxizAppHomeContent=iPhotoTaxizAppHomeContent1;
        }
        public IActionResult MYPhotoTaxizAppHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditPhotoTaxizAppHomeContent(int? IdPhotoTaxizAppHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            if (IdPhotoTaxizAppHomeContent != null)
            {
                vmodel.PhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetById(Convert.ToInt32(IdPhotoTaxizAppHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoTaxizAppHomeContentImage(int? IdPhotoTaxizAppHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetAll();
            if (IdPhotoTaxizAppHomeContent != null)
            {
                vmodel.PhotoTaxizAppHomeContent = iPhotoTaxizAppHomeContent.GetById(Convert.ToInt32(IdPhotoTaxizAppHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoTaxizAppHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoTaxizAppHomeContent = model.PhotoTaxizAppHomeContent.IdPhotoTaxizAppHomeContent;
                slider.Photo = model.PhotoTaxizAppHomeContent.Photo;
                slider.DateTimeEntry = model.PhotoTaxizAppHomeContent.DateTimeEntry;
                slider.DataEntry = model.PhotoTaxizAppHomeContent.DataEntry;
                slider.CurrentState = model.PhotoTaxizAppHomeContent.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoTaxizAppHomeContent == 0 || slider.IdPhotoTaxizAppHomeContent == null)
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
                    var reqwest = iPhotoTaxizAppHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoTaxizAppHomeContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoTaxizAppHomeContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditPhotoTaxizAppHomeContent");
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoTaxizAppHomeContent.DELETPHOTO(slider.IdPhotoTaxizAppHomeContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoTaxizAppHomeContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoTaxizAppHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoTaxizAppHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoTaxizAppHomeContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditPhotoTaxizAppHomeContentImage");
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoTaxizAppHomeContent.DELETPhoto(slider.IdPhotoTaxizAppHomeContent);
                        var reqestUpdate2 = iPhotoTaxizAppHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoTaxizAppHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoTaxizAppHomeContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditPhotoTaxizAppHomeContentImage");
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
                    //var delet = iPhotoTaxizAppHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditPhotoTaxizAppHomeContent");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoTaxizAppHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditPhotoTaxizAppHomeContentImage");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoTaxizAppHomeContent)
        {
            var reqwistDelete = iPhotoTaxizAppHomeContent.deleteData(IdPhotoTaxizAppHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoTaxizAppHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoTaxizAppHomeContent");
            }
        }
    }
}
