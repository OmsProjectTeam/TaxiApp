using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BointChooseUsHomeContentController : Controller
    {
        MasterDbcontext dbcontext;
        IIBointChooseUsHomeContent iBointChooseUsHomeContent;
        public BointChooseUsHomeContentController(MasterDbcontext dbcontext1,IIBointChooseUsHomeContent iBointChooseUsHomeContent1)
        {
            dbcontext= dbcontext1;
            iBointChooseUsHomeContent= iBointChooseUsHomeContent1;
        }
        public IActionResult MYBointChooseUsHomeContent()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditBointChooseUsHomeContent(int? IdBointChooseUsHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            if (IdBointChooseUsHomeContent != null)
            {
                vmodel.BointChooseUsHomeContent = iBointChooseUsHomeContent.GetById(Convert.ToInt32(IdBointChooseUsHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditBointChooseUsHomeContentImage(int? IdBointChooseUsHomeContent)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListBointChooseUsHomeContent = iBointChooseUsHomeContent.GetAll();
            if (IdBointChooseUsHomeContent != null)
            {
                vmodel.BointChooseUsHomeContent = iBointChooseUsHomeContent.GetById(Convert.ToInt32(IdBointChooseUsHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBBointChooseUsHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdBointChooseUsHomeContent = model.BointChooseUsHomeContent.IdBointChooseUsHomeContent;
                slider.TitelOneAr = model.BointChooseUsHomeContent.TitelOneAr;
                slider.FirstDescriptionAr = model.BointChooseUsHomeContent.FirstDescriptionAr;
                slider.TitelOneEn = model.BointChooseUsHomeContent.TitelOneEn;
                slider.FirstDescriptionEn = model.BointChooseUsHomeContent.FirstDescriptionEn;
                slider.TitelOneKr1 = model.BointChooseUsHomeContent.TitelOneKr1;
                slider.FirstDescriptionKr1 = model.BointChooseUsHomeContent.FirstDescriptionKr1;
                slider.TitelOneKr2 = model.BointChooseUsHomeContent.TitelOneKr2;
                slider.FirstDescriptionKr2 = model.BointChooseUsHomeContent.FirstDescriptionKr2;           
                slider.Photo = model.BointChooseUsHomeContent.Photo;
                slider.DateTimeEntry = model.BointChooseUsHomeContent.DateTimeEntry;
                slider.DataEntry = model.BointChooseUsHomeContent.DataEntry;
                slider.CurrentState = model.BointChooseUsHomeContent.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdBointChooseUsHomeContent == 0 || slider.IdBointChooseUsHomeContent == null)
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
                        return RedirectToAction("AddEditBointChooseUsHomeContent");
                    }


                    var reqwest = iBointChooseUsHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYBointChooseUsHomeContent");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iBointChooseUsHomeContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditBointChooseUsHomeContent");

                    }
                }
                else
                {
                    //var reqweistDeletPoto = iBointChooseUsHomeContent.DELETPHOTO(slider.IdBointChooseUsHomeContent);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.BointChooseUsHomeContent.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iBointChooseUsHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYBointChooseUsHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iBointChooseUsHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditBointChooseUsHomeContent");

                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iBointChooseUsHomeContent.DELETPhoto(slider.IdBointChooseUsHomeContent);
                        var reqestUpdate2 = iBointChooseUsHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYBointChooseUsHomeContent");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iBointChooseUsHomeContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditBointChooseUsHomeContentImage");
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
                    //var delet = iBointChooseUsHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditBointChooseUsHomeContent");
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iBointChooseUsHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditBointChooseUsHomeContent");
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdBointChooseUsHomeContent)
        {
            var reqwistDelete = iBointChooseUsHomeContent.deleteData(IdBointChooseUsHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYBointChooseUsHomeContent");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYBointChooseUsHomeContent");
            }
        }
    }
}
