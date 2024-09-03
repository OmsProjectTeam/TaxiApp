

namespace Infarstuructre.BL
{
    public interface IIPhotoTestimonialHomeContent
    {
        List<TBPhotoTestimonialHomeContent> GetAll();
        TBPhotoTestimonialHomeContent GetById(int IdPhotoTestimonialHomeContent);
        bool saveData(TBPhotoTestimonialHomeContent savee);
        bool UpdateData(TBPhotoTestimonialHomeContent updatss);
        bool deleteData(int IdPhotoTestimonialHomeContent);
        List<TBPhotoTestimonialHomeContent> GetAllv(int IdPhotoTestimonialHomeContent);
        bool DELETPhoto(int IdPhotoTestimonialHomeContent);
        bool DELETPhotoWethError(string PhotoNAme);
    }
    public class CLSTBPhotoTestimonialHomeContent: IIPhotoTestimonialHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoTestimonialHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }

        public List<TBPhotoTestimonialHomeContent> GetAll()
        {
            List<TBPhotoTestimonialHomeContent> MySlider = dbcontext.TBPhotoTestimonialHomeContents.OrderByDescending(n => n.IdPhotoTestimonialHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoTestimonialHomeContent GetById(int IdPhotoTestimonialHomeContent)
        {
            TBPhotoTestimonialHomeContent sslid = dbcontext.TBPhotoTestimonialHomeContents.FirstOrDefault(a => a.IdPhotoTestimonialHomeContent == IdPhotoTestimonialHomeContent);
            return sslid;
        }
        public bool saveData(TBPhotoTestimonialHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBPhotoTestimonialHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoTestimonialHomeContent updatss)
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
        public bool deleteData(int IdPhotoTestimonialHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoTestimonialHomeContent);
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
        public List<TBPhotoTestimonialHomeContent> GetAllv(int IdPhotoTestimonialHomeContent)
        {
            List<TBPhotoTestimonialHomeContent> MySlider = dbcontext.TBPhotoTestimonialHomeContents.OrderByDescending(n => n.IdPhotoTestimonialHomeContent == IdPhotoTestimonialHomeContent).Where(a => a.IdPhotoTestimonialHomeContent == IdPhotoTestimonialHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdPhotoTestimonialHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoTestimonialHomeContent);
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
