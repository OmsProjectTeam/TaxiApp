using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DriverInformationController : Controller
    {
        MasterDbcontext dbcontext;
        IIUserInformation iUserInformation;
        IIDriverCategory iDriverCategory;
        IIDriverInformation iDriverInformation;
        IIDrivingLicenseCategory iDrivingLicenseCategory;
        public DriverInformationController(MasterDbcontext dbcontext1, IIUserInformation iUserInformation1,IIDriverCategory iDriverCategory1,IIDriverInformation iDriverInformation1,IIDrivingLicenseCategory iDrivingLicenseCategory1)
        {
            dbcontext=dbcontext1;
            iUserInformation=iUserInformation1;
            iDriverCategory=iDriverCategory1;
            iDriverInformation =iDriverInformation1;
            iDrivingLicenseCategory =iDrivingLicenseCategory1;
        }
        public IActionResult MyDriverInformation()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewDriverInformation = iDriverInformation.GetAll();
            return View(vmodel);
        }
        public IActionResult AddDriverInformation(int? IdDriverInformation)
        {
            ViewBag.user = iUserInformation.GetAllByRole("Driver,Admin");
            ViewBag.DriverCategory = iDriverCategory.GetAll();
            ViewBag.DrivingLicenseCategory = iDrivingLicenseCategory.GetAll();






            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewDriverInformation = iDriverInformation.GetAll();
            if (IdDriverInformation != null)
            {
                vmodel.DriverInformation = iDriverInformation.GetById(Convert.ToInt32(IdDriverInformation));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBDriverInformation slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdDriverInformation = model.DriverInformation.IdDriverInformation;
                slider.IdDriverUser = model.DriverInformation.IdDriverUser;
                slider.IdDriverCategory = model.DriverInformation.IdDriverCategory;
                slider.IdDrivingLicenseCategory = model.DriverInformation.IdDrivingLicenseCategory;
                slider.DriverNameAr = model.DriverInformation.DriverNameAr;
                slider.DriverNameEn = model.DriverInformation.DriverNameEn;
                slider.DriverNameKr1 = model.DriverInformation.DriverNameKr1;
                slider.DriverNameKr2 = model.DriverInformation.DriverNameKr2;
                slider.GenderAr = model.DriverInformation.GenderAr;
                slider.GenderEn = model.DriverInformation.GenderEn;
                slider.GenderKr1 = model.DriverInformation.GenderKr1;
                slider.GenderKr2 = model.DriverInformation.GenderKr2;
                slider.dateOfbirth = model.DriverInformation.dateOfbirth;
                slider.NationalNumber = model.DriverInformation.NationalNumber;
                slider.FamilyNumber = model.DriverInformation.FamilyNumber;
                slider.CurrentAddressAr = model.DriverInformation.CurrentAddressAr;
                slider.CurrentAddressEn = model.DriverInformation.CurrentAddressEn;
                slider.CurrentAddressKr1 = model.DriverInformation.CurrentAddressKr1;
                slider.CurrentAddressKr2 = model.DriverInformation.CurrentAddressKr2;                    
                slider.DataEntry = model.DriverInformation.DataEntry;
                slider.DateTimeEntry = model.DriverInformation.DateTimeEntry;
                slider.CurrentState = model.DriverInformation.CurrentState;
                if (slider.IdDriverInformation == 0 || slider.IdDriverInformation == null)
                {

                    if (dbcontext.TBDriverInformations.Where(a => a.IdDriverUser == slider.IdDriverUser).ToList().Count > 0)
                    {
                        TempData["Message"] = ResourceWeb.VLCarCategorieDoplceted;
                        return RedirectToAction("AddDriverInformation");
                    }





                    var reqwest = iDriverInformation.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyDriverInformation");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iDriverInformation.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyDriverInformation");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return Redirect(returnUrl);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdDriverInformation)
        {
            var reqwistDelete = iDriverInformation.deleteData(IdDriverInformation);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyDriverInformation");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyDriverInformation");
            }
        }

      
    }
}
