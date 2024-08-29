
namespace Infarstuructre.BL
{
    public interface IIPhotoTaxizAppHomeContent
    {
        List<TBPhotoTaxizAppHomeContent> GetAll();
        TBPhotoTaxizAppHomeContent GetById(int IdPhotoTaxizAppHomeContent);
        bool saveData(TBPhotoTaxizAppHomeContent savee);
        bool UpdateData(TBPhotoTaxizAppHomeContent updatss);
        bool deleteData(int IdPhotoTaxizAppHomeContent);
        bool DELETPhoto(int IdPhotoTaxizAppHomeContent);
        List<TBPhotoTaxizAppHomeContent> GetAllv(int IdPhotoTaxizAppHomeContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBPhotoTaxizAppHomeContent: IIPhotoTaxizAppHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoTaxizAppHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBPhotoTaxizAppHomeContent> GetAll()
        {
            List<TBPhotoTaxizAppHomeContent> MySlider = dbcontext.TBPhotoTaxizAppHomeContents.OrderByDescending(n => n.IdPhotoTaxizAppHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoTaxizAppHomeContent GetById(int IdPhotoTaxizAppHomeContent)
        {
            TBPhotoTaxizAppHomeContent sslid = dbcontext.TBPhotoTaxizAppHomeContents.FirstOrDefault(a => a.IdPhotoTaxizAppHomeContent == IdPhotoTaxizAppHomeContent);
            return sslid;
        }
        public bool saveData(TBPhotoTaxizAppHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBPhotoTaxizAppHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoTaxizAppHomeContent updatss)
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
        public bool deleteData(int IdPhotoTaxizAppHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoTaxizAppHomeContent);
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
        public List<TBPhotoTaxizAppHomeContent> GetAllv(int IdPhotoTaxizAppHomeContent)
        {
            List<TBPhotoTaxizAppHomeContent> MySlider = dbcontext.TBPhotoTaxizAppHomeContents.OrderByDescending(n => n.IdPhotoTaxizAppHomeContent == IdPhotoTaxizAppHomeContent).Where(a => a.IdPhotoTaxizAppHomeContent == IdPhotoTaxizAppHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdPhotoTaxizAppHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoTaxizAppHomeContent);
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
