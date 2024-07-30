namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderHomeContentController : Controller
    {
        MasterDbcontext dbcontext;
        IISliderHomeContent iSliderHomeContent;
        public SliderHomeContentController(MasterDbcontext dbcontext1,IISliderHomeContent iSliderHomeContent1)
        {
            dbcontext=dbcontext1;
            iSliderHomeContent=iSliderHomeContent1;
        }
        public IActionResult MYSliderHomeConten()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditSliderHomeConten(int? IdSliderHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            if (IdSliderHomeContent != null)
            {
                vmodel.SliderHomeConten = iSliderHomeContent.GetById(Convert.ToInt32(IdSliderHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditSliderHomeContenImage(int? IdSliderHomeContent)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListSliderHomeConten = iSliderHomeContent.GetAll();
            if (IdSliderHomeContent != null)
            {
                vmodel.SliderHomeConten = iSliderHomeContent.GetById(Convert.ToInt32(IdSliderHomeContent));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBSliderHomeContent slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdSliderHomeContent = model.SliderHomeConten.IdSliderHomeContent;          
                slider.Photo = model.SliderHomeConten.Photo;
                slider.NekName = model.SliderHomeConten.NekName;
                slider.TitelOneEn = model.SliderHomeConten.TitelOneEn;
                slider.TitelOneAr = model.SliderHomeConten.TitelOneAr;
                slider.TitelOneKr1 = model.SliderHomeConten.TitelOneKr1;
                slider.TitelOneKr2 = model.SliderHomeConten.TitelOneKr2;
                slider.TitelTwoEn = model.SliderHomeConten.TitelTwoEn;
                slider.TitelTwoAr = model.SliderHomeConten.TitelTwoAr;
                slider.TitelTwoKr1 = model.SliderHomeConten.TitelTwoKr1;
                slider.TitelTwoKr2 = model.SliderHomeConten.TitelTwoKr2;
                slider.TitelThreeEn = model.SliderHomeConten.TitelThreeEn;
                slider.TitelThreeAr = model.SliderHomeConten.TitelThreeAr;
                slider.TitelThreeKr1 = model.SliderHomeConten.TitelThreeKr1;
                slider.TitelThreeKr2 = model.SliderHomeConten.TitelThreeKr2;
                slider.FirstDescriptionAr = model.SliderHomeConten.FirstDescriptionAr;
                slider.FirstDescriptionEN = model.SliderHomeConten.FirstDescriptionEN;
                slider.FirstDescriptionKr1 = model.SliderHomeConten.FirstDescriptionKr1;
                slider.FirstDescriptionKr2 = model.SliderHomeConten.FirstDescriptionKr2;
                slider.TitleButtonEn = model.SliderHomeConten.TitleButtonEn;
                slider.TitleButtonAr = model.SliderHomeConten.TitleButtonAr;
                slider.TitleButtonKr1 = model.SliderHomeConten.TitleButtonKr1;
                slider.TitleButtonKr2 = model.SliderHomeConten.TitleButtonKr2;
                slider.UrlButtonEn = model.SliderHomeConten.UrlButtonEn;
                slider.UrlButtonAr = model.SliderHomeConten.UrlButtonAr;
                slider.UrlButtonKr1 = model.SliderHomeConten.UrlButtonKr1;
                slider.UrlButtonKr2 = model.SliderHomeConten.UrlButtonKr2;
                slider.UrlYoutubeButton = model.SliderHomeConten.UrlYoutubeButton;
                slider.DateTimeEntry = model.SliderHomeConten.DateTimeEntry;
                slider.DataEntry = model.SliderHomeConten.DataEntry;
                slider.CurrentState = model.SliderHomeConten.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdSliderHomeContent == 0 || slider.IdSliderHomeContent == null)
                {


                    if (dbcontext.TBSliderHomeContents.Where(a => a.NekName == slider.NekName).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLNekNameDoplceted;
                        return RedirectToAction("AddEditSliderHomeConten");
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
                        return RedirectToAction("AddEditSliderHomeConten");
                    }
                    var reqwest = iSliderHomeContent.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYSliderHomeConten");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iSliderHomeContent.DELETPhotoWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddEditSliderHomeConten"); ;
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iSliderHomeContent.DELETPHOTO(slider.IdSliderHomeContent);
                    if (file.Count() == 0)

                    {
                        slider.Photo = model.SliderHomeConten.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iSliderHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYSliderHomeConten");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditSliderHomeConten"); ;
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iSliderHomeContent.DELETPhoto(slider.IdSliderHomeContent);
                        var reqestUpdate2 = iSliderHomeContent.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYSliderHomeConten");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iSliderHomeContent.DELETPhotoWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return RedirectToAction("AddEditSliderHomeConten"); ;
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
                    //var delet = iSliderHomeContent.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditSliderHomeConten"); ;
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iSliderHomeContent.DELETPhotoWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return RedirectToAction("AddEditSliderHomeConten"); ;
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdSliderHomeContent)
        {
            var reqwistDelete = iSliderHomeContent.deleteData(IdSliderHomeContent);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYSliderHomeConten");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYSliderHomeConten");
            }
        }
    }
}