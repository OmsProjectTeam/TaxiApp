

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoTestimonialHomeContentController : Controller
    {
        IIPhotoTestimonialHomeContent iPhotoTestimonialHomeContent;
        public PhotoTestimonialHomeContentController(IIPhotoTestimonialHomeContent iPhotoTestimonialHomeContent1)
        {
            iPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent1;
        }
        public IActionResult MYPhotoTestimonialHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditPhotoTestimonialHomeContent(int? IdPhotoTestimonialHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll();
            if (IdPhotoTestimonialHomeContent != null)
            {
                vmodel.PhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetById(Convert.ToInt32(IdPhotoTestimonialHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoTestimonialHomeContentImage(int? IdPhotoTestimonialHomeContent)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetAll();
            if (IdPhotoTestimonialHomeContent != null)
            {
                vmodel.PhotoTestimonialHomeContent = iPhotoTestimonialHomeContent.GetById(Convert.ToInt32(IdPhotoTestimonialHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoTestimonialHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoTestimonialHomeContent = model.PhotoTestimonialHomeContent.IdPhotoTestimonialHomeContent;

                slider.Photo = model.PhotoTestimonialHomeContent.Photo;

                slider.DateTimeEntry = model.PhotoTestimonialHomeContent.DateTimeEntry;
                slider.DataEntry = model.PhotoTestimonialHomeContent.DataEntry;
                slider.CurrentState = model.PhotoTestimonialHomeContent.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoTestimonialHomeContent == 0 || slider.IdPhotoTestimonialHomeContent == null)
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


                    var reqwest = iPhotoTestimonialHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoTestimonialHomeContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoTestimonialHomeContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoTestimonialHomeContent.DELETPHOTO(slider.IdPhotoTestimonialHomeContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoTestimonialHomeContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoTestimonialHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoTestimonialHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoTestimonialHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoTestimonialHomeContent.DELETPhoto(slider.IdPhotoTestimonialHomeContent);
                        var reqestUpdate2 = iPhotoTestimonialHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoTestimonialHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoTestimonialHomeContent.DELETPhotoWethError(PhotoNAme);
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
                    //var delet = iPhotoTestimonialHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoTestimonialHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoTestimonialHomeContent)
        {
            var reqwistDelete = iPhotoTestimonialHomeContent.deleteData(IdPhotoTestimonialHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoTestimonialHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoTestimonialHomeContent");
            }
        }
    }
}
