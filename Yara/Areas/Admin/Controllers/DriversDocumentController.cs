
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DriversDocumentController : Controller
    {
        IIDriversDocument iDriversDocument;
        IIDriverInformation iDriverInformation;
        public DriversDocumentController(IIDriversDocument iDriversDocument1,IIDriverInformation iDriverInformation1)
        {
            iDriversDocument=iDriversDocument1;
            iDriverInformation= iDriverInformation1;
        }
        public IActionResult MYDriversDocument()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewDriversDocument = iDriversDocument.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditDriversDocument(int? IdDriversDocument)
        {
            ViewBag.DriverInformation = iDriverInformation.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewDriversDocument = iDriversDocument.GetAll();
            if (IdDriversDocument != null)
            {
                vmodel.DriversDocument = iDriversDocument.GetById(Convert.ToInt32(IdDriversDocument));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditDriversDocumentImage(int? IdDriversDocument)
        {
            ViewBag.DriverInformation = iDriverInformation.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewDriversDocument = iDriversDocument.GetAll();
            if (IdDriversDocument != null)
            {
                vmodel.DriversDocument = iDriversDocument.GetById(Convert.ToInt32(IdDriversDocument));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBDriversDocument slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdDriversDocument = model.DriversDocument.IdDriversDocument;
                slider.IdDriverInformation = model.DriversDocument.IdDriverInformation;

                slider.Photo = model.DriversDocument.Photo;
                slider.Description = model.DriversDocument.Description;

                slider.DateTimeEntry = model.DriversDocument.DateTimeEntry;
                slider.DataEntry = model.DriversDocument.DataEntry;
                slider.CurrentState = model.DriversDocument.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdDriversDocument == 0 || slider.IdDriversDocument == null)
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


                    var reqwest = iDriversDocument.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYDriversDocument");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iDriversDocument.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iDriversDocument.DELETPHOTO(slider.IdDriversDocument);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.DriversDocument.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iDriversDocument.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYDriversDocument");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iDriversDocument.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iDriversDocument.DELETPhoto(slider.IdDriversDocument);
                        var reqestUpdate2 = iDriversDocument.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYDriversDocument");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iDriversDocument.DELETPhotoWethError(PhotoNAme);
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
                    //var delet = iDriversDocument.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iDriversDocument.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdDriversDocument)
        {
            var reqwistDelete = iDriversDocument.deleteData(IdDriversDocument);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYDriversDocument");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYDriversDocument");
            }
        }
    }
}
