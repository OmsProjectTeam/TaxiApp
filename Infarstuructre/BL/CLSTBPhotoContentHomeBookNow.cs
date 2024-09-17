

namespace Infarstuructre.BL
{
    public interface IIPhotoContentHomeBookNow
    {
        List<TBPhotoContentHomeBookNow> GetAll();
        TBPhotoContentHomeBookNow GetById(int IdPhotoContentHomeBookNow);
        bool saveData(TBPhotoContentHomeBookNow savee);
        bool UpdateData(TBPhotoContentHomeBookNow updatss);
        bool deleteData(int IdPhotoContentHomeBookNow);
        List<TBPhotoContentHomeBookNow> GetAllv(int IdPhotoContentHomeBookNow);
        bool DELETPhoto(int IdPhotoContentHomeBookNow);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBPhotoContentHomeBookNow: IIPhotoContentHomeBookNow
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoContentHomeBookNow(MasterDbcontext dbcontext1)

        {
            dbcontext = dbcontext1;
        }

        public List<TBPhotoContentHomeBookNow> GetAll()
        {
            List<TBPhotoContentHomeBookNow> MySlider = dbcontext.TBPhotoContentHomeBookNows.OrderByDescending(n => n.IdPhotoContentHomeBookNow).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoContentHomeBookNow GetById(int IdPhotoContentHomeBookNow)
        {
            TBPhotoContentHomeBookNow sslid = dbcontext.TBPhotoContentHomeBookNows.FirstOrDefault(a => a.IdPhotoContentHomeBookNow == IdPhotoContentHomeBookNow);
            return sslid;
        }
        public bool saveData(TBPhotoContentHomeBookNow savee)
        {
            try
            {
                dbcontext.Add<TBPhotoContentHomeBookNow>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoContentHomeBookNow updatss)
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
        public bool deleteData(int IdPhotoContentHomeBookNow)
        {
            try
            {
                var catr = GetById(IdPhotoContentHomeBookNow);
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
        public List<TBPhotoContentHomeBookNow> GetAllv(int IdPhotoContentHomeBookNow)
        {
            List<TBPhotoContentHomeBookNow> MySlider = dbcontext.TBPhotoContentHomeBookNows.OrderByDescending(n => n.IdPhotoContentHomeBookNow == IdPhotoContentHomeBookNow).Where(a => a.IdPhotoContentHomeBookNow == IdPhotoContentHomeBookNow).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdPhotoContentHomeBookNow)
        {
            try
            {
                var catr = GetById(IdPhotoContentHomeBookNow);
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
