

namespace Infarstuructre.BL
{
    public interface IITaxiInfoStep
    {
        List<TBTaxiInfoStep> GetAll();
        TBTaxiInfoStep GetById(int IdTaxiInfoStep);
        bool saveData(TBTaxiInfoStep savee);
        bool UpdateData(TBTaxiInfoStep updatss);
        bool deleteData(int IdTaxiInfoStep);
        List<TBTaxiInfoStep> GetAllv(int IdTaxiInfoStep);
        bool DELETPhoto(int IdTaxiInfoStep);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBTaxiInfoStep: IITaxiInfoStep
    {
        MasterDbcontext dbcontext;
        public CLSTBTaxiInfoStep(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBTaxiInfoStep> GetAll()
        {
            List<TBTaxiInfoStep> MySlider = dbcontext.TBTaxiInfoSteps.OrderByDescending(n => n.IdTaxiInfoStep).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTaxiInfoStep GetById(int IdTaxiInfoStep)
        {
            TBTaxiInfoStep sslid = dbcontext.TBTaxiInfoSteps.FirstOrDefault(a => a.IdTaxiInfoStep == IdTaxiInfoStep);
            return sslid;
        }
        public bool saveData(TBTaxiInfoStep savee)
        {
            try
            {
                dbcontext.Add<TBTaxiInfoStep>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTaxiInfoStep updatss)
        {
            try
            {
                dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteData(int IdTaxiInfoStep)
        {
            try
            {
                var catr = GetById(IdTaxiInfoStep);
                catr.CurrentState = false;
                //TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                //dbcontex.TbSubCateegoorys.Remove(dele);
                dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<TBTaxiInfoStep> GetAllv(int IdTaxiInfoStep)
        {
            List<TBTaxiInfoStep> MySlider = dbcontext.TBTaxiInfoSteps.OrderByDescending(n => n.IdTaxiInfoStep == IdTaxiInfoStep).Where(a => a.IdTaxiInfoStep == IdTaxiInfoStep).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdTaxiInfoStep)
        {
            try
            {
                var catr = GetById(IdTaxiInfoStep);
                //using (FileStream fs = new FileStream(catr.Photo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //{
                if (!string.IsNullOrEmpty(catr.Photo))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", catr.Photo);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }
                //}


                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DELETPhotoWethError(string PhotoNAme)
        {
            try
            {
                if (!string.IsNullOrEmpty(PhotoNAme))
                {
                    // إذا كان هناك صورة قديمة، قم بمسحها من الملف
                    var oldFilePath = Path.Combine(@"wwwroot/Images/Home", PhotoNAme);
                    if (System.IO.File.Exists(oldFilePath))
                    {


                        // استخدم FileShare.None للسماح بحذف الملف أثناء استخدامه
                        using (FileStream fs = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            System.Threading.Thread.Sleep(200);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }

                        System.IO.File.Delete(oldFilePath);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // يفضل ألا تترك البرنامج يتجاوز الأخطاء بصمت، يفضل تسجيل الخطأ أو إعادة رميه
                return false;
            }
        }
    }
}
