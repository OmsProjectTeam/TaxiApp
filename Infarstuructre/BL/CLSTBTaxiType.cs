
using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IITaxiType
    {
        List<TBTaxiType> GetAll();
        List<TBTaxiType> GetAllHome();
        TBTaxiType GetById(int IdTaxiType);
        bool saveData(TBTaxiType savee);
        bool UpdateData(TBTaxiType updatss);
        bool deleteData(int IdTaxiType);
        List<TBTaxiType> GetAllv(int IdTaxiType);
        bool DELETPhoto(int IdTaxiType);
        bool DELETPhotoWethError(string PhotoNAme);

        /// //////////////////////////API//////////////////////////

        Task<List<TBTaxiType>> GetAllAsync();
        Task<List<TBTaxiType>> GetAllvAsync(int id);
        Task<TBTaxiType> GetByIdAsync(int id);
        Task<bool> AddDataAsync(TBTaxiType savee);
        Task<bool> UpdateDataAsync(TBTaxiType updatss);
        Task<bool> DeletDataAsync(int id);
        Task<bool> DeletePhotoAsync(int id);
        Task<bool> DeletePhotoWithErrorAsync(string name);
    }

    public class CLSTBTaxiType: IITaxiType
    {
        MasterDbcontext dbcontext;
        public CLSTBTaxiType(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }

        public List<TBTaxiType> GetAll()
        {
            List<TBTaxiType> MySlider = dbcontext.TBTaxiTypes.OrderByDescending(n => n.IdTaxiType).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public List<TBTaxiType> GetAllHome()
        {
            List<TBTaxiType> MySlider = dbcontext.TBTaxiTypes.OrderByDescending(n => n.IdTaxiType).Where(a => a.CurrentState == true).Where(a => a.Active == true).ToList();
            return MySlider;
        }
        public TBTaxiType GetById(int IdTaxiType)
        {
            TBTaxiType sslid = dbcontext.TBTaxiTypes.FirstOrDefault(a => a.IdTaxiType == IdTaxiType);
            return sslid;
        }
        public bool saveData(TBTaxiType savee)
        {
            try
            {
                dbcontext.Add<TBTaxiType>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTaxiType updatss)
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
        public bool deleteData(int IdTaxiType)
        {
            try
            {
                var catr = GetById(IdTaxiType);
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
        public List<TBTaxiType> GetAllv(int IdTaxiType)
        {
            List<TBTaxiType> MySlider = dbcontext.TBTaxiTypes.OrderByDescending(n => n.IdTaxiType == IdTaxiType).Where(a => a.IdTaxiType == IdTaxiType).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public bool DELETPhoto(int IdTaxiType)
        {
            try
            {
                var catr = GetById(IdTaxiType);
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

        // //////////////////////////////////////////API//////////////////////////////////////////////////////

        public async Task<List<TBTaxiType>> GetAllAsync()
        {
            List<TBTaxiType> MySlider = await dbcontext.TBTaxiTypes.OrderByDescending(n => n.IdTaxiType).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<List<TBTaxiType>> GetAllvAsync(int id)
        {
            List<TBTaxiType> MySlider = await  dbcontext.TBTaxiTypes.OrderByDescending(n => n.IdTaxiType == id).Where(a => a.IdTaxiType == id).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<TBTaxiType> GetByIdAsync(int id)
        {
            TBTaxiType sslid = await dbcontext.TBTaxiTypes.FirstOrDefaultAsync(a => a.IdTaxiType == id);
            return sslid;
        }

        public async Task<bool> AddDataAsync(TBTaxiType savee)
        {
            try
            {
                await dbcontext.AddAsync<TBTaxiType>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDataAsync(TBTaxiType updatss)
        {
            try
            {
                dbcontext.Entry(updatss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletDataAsync(int id)
        {
            try
            {
                var catr = await GetByIdAsync(id);
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

        public Task<bool> DeletePhotoAsync(int id)
        {
            var result = deleteData(id);
            return Task.FromResult(result);
        }

        public Task<bool> DeletePhotoWithErrorAsync(string name)
        {
            var result = DELETPhotoWethError(name);
            return Task.FromResult(result);
        }
    }
}
