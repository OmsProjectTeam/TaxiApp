
namespace Infarstuructre.BL
{
    public interface IIService
    {
        List<TBService> GetAll();
        TBService GetById(int IdService);
        bool saveData(TBService savee);
        bool UpdateData(TBService updatss);
        bool deleteData(int IdService);
        List<TBService> GetAllv(int IdService);
        bool DELETPhoto(int IdService);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class ClSTBService: IIService 
    {
        MasterDbcontext dbcontext;
        public ClSTBService(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBService> GetAll()
        {
            List<TBService> MySlider = dbcontext.TBServices.OrderByDescending(n => n.IdService).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBService GetById(int IdService)
        {
            TBService sslid = dbcontext.TBServices.FirstOrDefault(a => a.IdService == IdService);
            return sslid;
        }
        public bool saveData(TBService savee)
        {
            try
            {
                dbcontext.Add<TBService>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBService updatss)
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
        public bool deleteData(int IdService)
        {
            try
            {
                var catr = GetById(IdService);
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
        public List<TBService> GetAllv(int IdService)
        {
            List<TBService> MySlider = dbcontext.TBServices.OrderByDescending(n => n.IdService == IdService).Where(a => a.IdService == IdService).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdService)
        {
            try
            {
                var catr = GetById(IdService);
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
