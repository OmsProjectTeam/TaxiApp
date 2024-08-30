

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIDriverCategory
    {
        List<TBDriverCategory> GetAll();
        TBDriverCategory GetById(int IdDriverCategory);
        bool saveData(TBDriverCategory savee);
        bool UpdateData(TBDriverCategory updatss);
        bool deleteData(int IdDriverCategory);
        List<TBDriverCategory> GetAllv(int IdDriverCategory);

        /// //////////////////////////API//////////////////////////

        Task<List<TBDriverCategory>> GetAllAsync();
        Task<List<TBDriverCategory>> GetAllvAsync(int id);
        Task<TBDriverCategory> GetByIdAsync(int id);
        Task<bool> AddDataAsync(TBDriverCategory savee);
        Task<bool> UpdateDataAsync(TBDriverCategory updatss);
        Task<bool> DeletDataAsync(int id);

    }
    public class CLSTBDriverCategory: IIDriverCategory
    {
        MasterDbcontext dbcontext;
        public CLSTBDriverCategory(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }

        public List<TBDriverCategory> GetAll()
        {
            List<TBDriverCategory> MySlider = dbcontext.TBDriverCategorys.OrderByDescending(n => n.IdDriverCategory).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBDriverCategory GetById(int IdDriverCategory)
        {
            TBDriverCategory sslid = dbcontext.TBDriverCategorys.FirstOrDefault(a => a.IdDriverCategory == IdDriverCategory);
            return sslid;
        }
        public bool saveData(TBDriverCategory savee)
        {
            try
            {
                dbcontext.Add<TBDriverCategory>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBDriverCategory updatss)
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
        public bool deleteData(int IdDriverCategory)
        {
            try
            {
                var catr = GetById(IdDriverCategory);
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
        public List<TBDriverCategory> GetAllv(int IdDriverCategory)
        {
            List<TBDriverCategory> MySlider = dbcontext.TBDriverCategorys.OrderByDescending(n => n.IdDriverCategory == IdDriverCategory).Where(a => a.IdDriverCategory == IdDriverCategory).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }


        // //////////////////////////////////////////API//////////////////////////////////////////////////////

        public async Task<List<TBDriverCategory>> GetAllAsync()
        {
            List<TBDriverCategory> MySlider = await dbcontext.TBDriverCategorys.OrderByDescending(n => n.IdDriverCategory).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<List<TBDriverCategory>> GetAllvAsync(int id)
        {
            List<TBDriverCategory> MySlider = await dbcontext.TBDriverCategorys.OrderByDescending(n => n.IdDriverCategory == id).Where(a => a.IdDriverCategory == id).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<TBDriverCategory> GetByIdAsync(int id)
        {
            TBDriverCategory sslid = await dbcontext.TBDriverCategorys.FirstOrDefaultAsync(a => a.IdDriverCategory == id);
            return sslid;
        }

        public async Task<bool> AddDataAsync(TBDriverCategory savee)
        {
            try
            {
                await dbcontext.AddAsync<TBDriverCategory>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDataAsync(TBDriverCategory updatss)
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
    }
}
