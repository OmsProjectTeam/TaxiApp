

namespace Infarstuructre.BL
{
    public interface IISliderHomeContent
    {
        List<TBSliderHomeContent> GetAll();
        TBSliderHomeContent GetById(int IdSliderHomeContent);
        bool saveData(TBSliderHomeContent savee);
        bool UpdateData(TBSliderHomeContent updatss);
        bool deleteData(int IdSliderHomeContent);
        bool DELETPhoto(int IdSliderHomeContent);
        List<TBSliderHomeContent> GetAllv(int IdSliderHomeContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBSliderHomeContent: IISliderHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBSliderHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBSliderHomeContent> GetAll()
        {
            List<TBSliderHomeContent> MySlider = dbcontext.TBSliderHomeContents.OrderByDescending(n => n.IdSliderHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBSliderHomeContent GetById(int IdSliderHomeContent)
        {
            TBSliderHomeContent sslid = dbcontext.TBSliderHomeContents.FirstOrDefault(a => a.IdSliderHomeContent == IdSliderHomeContent);
            return sslid;
        }
        public bool saveData(TBSliderHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBSliderHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBSliderHomeContent updatss)
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
        public bool deleteData(int IdSliderHomeContent)
        {
            try
            {
                var catr = GetById(IdSliderHomeContent);
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
        public List<TBSliderHomeContent> GetAllv(int IdSliderHomeContent)
        {
            List<TBSliderHomeContent> MySlider = dbcontext.TBSliderHomeContents.OrderByDescending(n => n.IdSliderHomeContent == IdSliderHomeContent).Where(a => a.IdSliderHomeContent == IdSliderHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdSliderHomeContent)
        {
            try
            {
                var catr = GetById(IdSliderHomeContent);
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
