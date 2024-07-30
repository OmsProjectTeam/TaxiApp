


namespace Infarstuructre.BL
{
    public interface IIPhotoAboutHomeContent
    {
        List<TBPhotoAboutHomeContent> GetAll();
        TBPhotoAboutHomeContent GetById(int IdPhotoAboutHomeContent);
        bool saveData(TBPhotoAboutHomeContent savee);
        bool UpdateData(TBPhotoAboutHomeContent updatss);
        bool deleteData(int IdPhotoAboutHomeContent);
        List<TBPhotoAboutHomeContent> GetAllv(int IdPhotoAboutHomeContent);
        bool DELETPhoto(int IdPhotoAboutHomeContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBPhotoAboutHomeContent: IIPhotoAboutHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoAboutHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBPhotoAboutHomeContent> GetAll()
        {
            List<TBPhotoAboutHomeContent> MySlider = dbcontext.TBPhotoAboutHomeContents.OrderByDescending(n => n.IdPhotoAboutHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoAboutHomeContent GetById(int IdPhotoAboutHomeContent)
        {
            TBPhotoAboutHomeContent sslid = dbcontext.TBPhotoAboutHomeContents.FirstOrDefault(a => a.IdPhotoAboutHomeContent == IdPhotoAboutHomeContent);
            return sslid;
        }
        public bool saveData(TBPhotoAboutHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBPhotoAboutHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoAboutHomeContent updatss)
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
        public bool deleteData(int IdPhotoAboutHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoAboutHomeContent);
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
        public List<TBPhotoAboutHomeContent> GetAllv(int IdPhotoAboutHomeContent)
        {
            List<TBPhotoAboutHomeContent> MySlider = dbcontext.TBPhotoAboutHomeContents.OrderByDescending(n => n.IdPhotoAboutHomeContent == IdPhotoAboutHomeContent).Where(a => a.IdPhotoAboutHomeContent == IdPhotoAboutHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdPhotoAboutHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoAboutHomeContent);
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
