

namespace Infarstuructre.BL
{
    public interface IICarCategorie
    {
        List<TBCarCategorie> GetAll();
        List<TBCarCategorie> GetAllHome();
        TBCarCategorie GetById(int IdCarCategories);
        bool saveData(TBCarCategorie savee);
        bool UpdateData(TBCarCategorie updatss);
        bool deleteData(int IdCarCategories);
        List<TBCarCategorie> GetAllv(int IdCarCategories);
        bool DELETPhoto(int IdCarCategories);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBCarCategorie: IICarCategorie
    {
        MasterDbcontext dbcontext;
        public CLSTBCarCategorie(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBCarCategorie> GetAll()
        {
            List<TBCarCategorie> MySlider = dbcontext.TBCarCategories.OrderByDescending(n => n.IdCarCategories).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public List<TBCarCategorie> GetAllHome()
        {
            List<TBCarCategorie> MySlider = dbcontext.TBCarCategories.OrderByDescending(n => n.IdCarCategories).Where(a => a.CurrentState == true).Where(a => a.Active == true).ToList();
            return MySlider;
        }
        public TBCarCategorie GetById(int IdCarCategories)
        {
            TBCarCategorie sslid = dbcontext.TBCarCategories.FirstOrDefault(a => a.IdCarCategories == IdCarCategories);
            return sslid;
        }
        public bool saveData(TBCarCategorie savee)
        {
            try
            {
                dbcontext.Add<TBCarCategorie>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBCarCategorie updatss)
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
        public bool deleteData(int IdCarCategories)
        {
            try
            {
                var catr = GetById(IdCarCategories);
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
        public List<TBCarCategorie> GetAllv(int IdCarCategories)
        {
            List<TBCarCategorie> MySlider = dbcontext.TBCarCategories.OrderByDescending(n => n.IdCarCategories == IdCarCategories).Where(a => a.IdCarCategories == IdCarCategories).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdCarCategories)
        {
            try
            {
                var catr = GetById(IdCarCategories);
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
