
namespace Infarstuructre.BL
{
    public interface IIDriversDocument
    {
        List<TBViewDriversDocument> GetAll();
        TBDriversDocument GetById(int IdDriverInformation);
        bool saveData(TBDriversDocument savee);
        bool UpdateData(TBDriversDocument updatss);
        bool deleteData(int IdDriverInformation);
        List<TBViewDriversDocument> GetAllv(int IdDriverInformation);
        bool DELETPhoto(int IdDriverInformation);
        bool DELETPhotoWethError(string PhotoNAme);


    }
    public class CLSTBDriversDocument: IIDriversDocument
    {
        MasterDbcontext dbcontext;
        public CLSTBDriversDocument(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBViewDriversDocument> GetAll()
        {
            List<TBViewDriversDocument> MySlider = dbcontext.ViewDriversDocument.OrderByDescending(n => n.IdDriverInformation).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBDriversDocument GetById(int IdDriverInformation)
        {
            TBDriversDocument sslid = dbcontext.TBDriversDocuments.FirstOrDefault(a => a.IdDriverInformation == IdDriverInformation);
            return sslid;
        }
        public bool saveData(TBDriversDocument savee)
        {
            try
            {
                dbcontext.Add<TBDriversDocument>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBDriversDocument updatss)
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
        public bool deleteData(int IdDriverInformation)
        {
            try
            {
                var catr = GetById(IdDriverInformation);
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
        public List<TBViewDriversDocument> GetAllv(int IdDriverInformation)
        {
            List<TBViewDriversDocument> MySlider = dbcontext.ViewDriversDocument.OrderByDescending(n => n.IdDriverInformation == IdDriverInformation).Where(a => a.IdDriverInformation == IdDriverInformation).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdDriverInformation)
        {
            try
            {
                var catr = GetById(IdDriverInformation);
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
