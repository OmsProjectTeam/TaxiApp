

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoContentHomeBookNowController : Controller
    {
        IIPhotoContentHomeBookNow iPhotoContentHomeBookNow;
        public PhotoContentHomeBookNowController(IIPhotoContentHomeBookNow iPhotoContentHomeBookNow1)
        {
            iPhotoContentHomeBookNow= iPhotoContentHomeBookNow1;
        }
        public IActionResult MYPhotoContentHomeBookNow()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoContentHomeBookNow = iPhotoContentHomeBookNow.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditPhotoContentHomeBookNow(int? IdPhotoContentHomeBookNow)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoContentHomeBookNow = iPhotoContentHomeBookNow.GetAll();
            if (IdPhotoContentHomeBookNow != null)
            {
                vmodel.PhotoContentHomeBookNow = iPhotoContentHomeBookNow.GetById(Convert.ToInt32(IdPhotoContentHomeBookNow));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditPhotoContentHomeBookNowImage(int? IdPhotoContentHomeBookNow)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListPhotoContentHomeBookNow = iPhotoContentHomeBookNow.GetAll();
            if (IdPhotoContentHomeBookNow != null)
            {
                vmodel.PhotoContentHomeBookNow = iPhotoContentHomeBookNow.GetById(Convert.ToInt32(IdPhotoContentHomeBookNow));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPhotoContentHomeBookNow slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPhotoContentHomeBookNow = model.PhotoContentHomeBookNow.IdPhotoContentHomeBookNow;

                slider.Photo = model.PhotoContentHomeBookNow.Photo;

                slider.DateTimeEntry = model.PhotoContentHomeBookNow.DateTimeEntry;
                slider.DataEntry = model.PhotoContentHomeBookNow.DataEntry;
                slider.CurrentState = model.PhotoContentHomeBookNow.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPhotoContentHomeBookNow == 0 || slider.IdPhotoContentHomeBookNow == null)
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


                    var reqwest = iPhotoContentHomeBookNow.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYPhotoContentHomeBookNow");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPhotoContentHomeBookNow.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPhotoContentHomeBookNow.DELETPHOTO(slider.IdPhotoContentHomeBookNow);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.PhotoContentHomeBookNow.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPhotoContentHomeBookNow.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoContentHomeBookNow");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPhotoContentHomeBookNow.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPhotoContentHomeBookNow.DELETPhoto(slider.IdPhotoContentHomeBookNow);
                        var reqestUpdate2 = iPhotoContentHomeBookNow.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYPhotoContentHomeBookNow");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPhotoContentHomeBookNow.DELETPhotoWethError(PhotoNAme);
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
                    //var delet = iPhotoContentHomeBookNow.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPhotoContentHomeBookNow.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPhotoContentHomeBookNow)
        {
            var reqwistDelete = iPhotoContentHomeBookNow.deleteData(IdPhotoContentHomeBookNow);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYPhotoContentHomeBookNow");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYPhotoContentHomeBookNow");
            }
        }
    }
}
