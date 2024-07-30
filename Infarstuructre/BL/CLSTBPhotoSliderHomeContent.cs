using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
    public interface IIPhotoSliderHomeContent
    {
        List<TBViewPhotoSliderHomeContent> GetAll();
        TBPhotoSliderHomeContent GetById(int IdPhotoSliderHomeContent);
        bool saveData(TBPhotoSliderHomeContent savee);
        bool UpdateData(TBPhotoSliderHomeContent updatss);
        bool deleteData(int IdPhotoSliderHomeContent);
        List<TBPhotoSliderHomeContent> GetAllv(int IdPhotoSliderHomeContent);
        bool DELETPHOTO(int IdPhotoSliderHomeContent);
        bool DELETPHOTOWethError(string PhotoNAme);

    }
    public class CLSTBPhotoSliderHomeContent: IIPhotoSliderHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBPhotoSliderHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBViewPhotoSliderHomeContent> GetAll()
        {
            List<TBViewPhotoSliderHomeContent> MySlider = dbcontext.ViewPhotoSliderHomeContent.OrderByDescending(n => n.IdPhotoSliderHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBPhotoSliderHomeContent GetById(int IdPhotoSliderHomeContent)
        {
            TBPhotoSliderHomeContent sslid = dbcontext.TBPhotoSliderHomeContents.FirstOrDefault(a => a.IdPhotoSliderHomeContent == IdPhotoSliderHomeContent);
            return sslid;
        }
        public bool saveData(TBPhotoSliderHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBPhotoSliderHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBPhotoSliderHomeContent updatss)
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
        public bool deleteData(int IdPhotoSliderHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoSliderHomeContent);
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
        public List<TBPhotoSliderHomeContent> GetAllv(int IdPhotoSliderHomeContent)
        {
            List<TBPhotoSliderHomeContent> MySlider = dbcontext.TBPhotoSliderHomeContents.OrderByDescending(n => n.IdPhotoSliderHomeContent == IdPhotoSliderHomeContent).Where(a => a.IdPhotoSliderHomeContent == IdPhotoSliderHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPHOTO(int IdPhotoSliderHomeContent)
        {
            try
            {
                var catr = GetById(IdPhotoSliderHomeContent);
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
        public bool DELETPHOTOWethError(string PhotoNAme)
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
