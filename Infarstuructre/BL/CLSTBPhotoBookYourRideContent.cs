

namespace Infarstuructre.BL
{
    public interface IIPhotoBookYourRideContent
    {
        List<TBPhotoBookYourRideContent> GetAll();
        TBPhotoBookYourRideContent GetById(int IdPhotoBookYourRideContent);
        bool saveData(TBPhotoBookYourRideContent savee);
        bool UpdateData(TBPhotoBookYourRideContent updatss);
        bool deleteData(int IdPhotoBookYourRideContent);
        List<TBPhotoBookYourRideContent> GetAllv(int IdPhotoBookYourRideContent);
        bool DELETPhoto(int IdPhotoBookYourRideContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBPhotoBookYourRideContent: IIPhotoBookYourRideContent
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoBookYourRideContent(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1; 
        }
        public List<TBPhotoBookYourRideContent> GetAll()
        {
            List<TBPhotoBookYourRideContent> MySlider = dbcontext.TBPhotoBookYourRideContents.OrderByDescending(n => n.IdPhotoBookYourRideContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoBookYourRideContent GetById(int IdPhotoBookYourRideContent)
        {
            TBPhotoBookYourRideContent sslid = dbcontext.TBPhotoBookYourRideContents.FirstOrDefault(a => a.IdPhotoBookYourRideContent == IdPhotoBookYourRideContent);
            return sslid;
        }
        public bool saveData(TBPhotoBookYourRideContent savee)
        {
            try
            {
                dbcontext.Add<TBPhotoBookYourRideContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoBookYourRideContent updatss)
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
        public bool deleteData(int IdPhotoBookYourRideContent)
        {
            try
            {
                var catr = GetById(IdPhotoBookYourRideContent);
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
        public List<TBPhotoBookYourRideContent> GetAllv(int IdPhotoBookYourRideContent)
        {
            List<TBPhotoBookYourRideContent> MySlider = dbcontext.TBPhotoBookYourRideContents.OrderByDescending(n => n.IdPhotoBookYourRideContent == IdPhotoBookYourRideContent).Where(a => a.IdPhotoBookYourRideContent == IdPhotoBookYourRideContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdPhotoBookYourRideContent)
        {
            try
            {
                var catr = GetById(IdPhotoBookYourRideContent);
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
