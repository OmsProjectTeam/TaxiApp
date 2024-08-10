

namespace Infarstuructre.BL
{
    public interface IIBointChooseUsHomeContent
    {
        List<TBBointChooseUsHomeContent> GetAll();
        TBBointChooseUsHomeContent GetById(int IdBointChooseUsHomeContent);
        bool saveData(TBBointChooseUsHomeContent savee);
        bool UpdateData(TBBointChooseUsHomeContent updatss);
        bool deleteData(int IdBointChooseUsHomeContent);
        List<TBBointChooseUsHomeContent> GetAllv(int IdBointChooseUsHomeContent);
        bool DELETPhoto(int IdBointChooseUsHomeContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBBointChooseUsHomeContent: IIBointChooseUsHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBBointChooseUsHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBBointChooseUsHomeContent> GetAll()
        {
            List<TBBointChooseUsHomeContent> MySlider = dbcontext.TBBointChooseUsHomeContents.OrderByDescending(n => n.IdBointChooseUsHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBBointChooseUsHomeContent GetById(int IdBointChooseUsHomeContent)
        {
            TBBointChooseUsHomeContent sslid = dbcontext.TBBointChooseUsHomeContents.FirstOrDefault(a => a.IdBointChooseUsHomeContent == IdBointChooseUsHomeContent);
            return sslid;
        }
        public bool saveData(TBBointChooseUsHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBBointChooseUsHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBBointChooseUsHomeContent updatss)
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
        public bool deleteData(int IdBointChooseUsHomeContent)
        {
            try
            {
                var catr = GetById(IdBointChooseUsHomeContent);
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
        public List<TBBointChooseUsHomeContent> GetAllv(int IdBointChooseUsHomeContent)
        {
            List<TBBointChooseUsHomeContent> MySlider = dbcontext.TBBointChooseUsHomeContents.OrderByDescending(n => n.IdBointChooseUsHomeContent == IdBointChooseUsHomeContent).Where(a => a.IdBointChooseUsHomeContent == IdBointChooseUsHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdBointChooseUsHomeContent)
        {
            try
            {
                var catr = GetById(IdBointChooseUsHomeContent);
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
