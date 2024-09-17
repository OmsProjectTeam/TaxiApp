

using Microsoft.EntityFrameworkCore;

namespace Infarstuructre.BL
{
    public interface IIDriverInformation
    {
        List<TBViewDriverInformation> GetAll();
        TBDriverInformation GetById(int IdDriverInformation);
        bool saveData(TBDriverInformation savee);
        bool UpdateData(TBDriverInformation updatss);
        bool deleteData(int IdDriverInformation);
        List<TBViewDriverInformation> GetAllv(int IdDriverInformation);
        // ////////////////////////API/////////////////////////////////////
        Task<List<TBViewDriverInformation>> GetAllAsync();
        Task<TBDriverInformation> GetByIdAsync(int IdDriverInformation);
        Task<bool> AddDataAsync(TBDriverInformation savee);
        Task<bool> UpdateDataAsync(TBDriverInformation updatss);
        Task<bool> DeleteDataAsync(int IdDriverInformation);
        Task<List<TBViewDriverInformation>> GetAllvAsync(int IdDriverInformation);
    }

    public class CLSTBDriverInformation: IIDriverInformation
    {
        MasterDbcontext dbcontext;
        public CLSTBDriverInformation(MasterDbcontext  dbcontext1)
        {
            dbcontext=dbcontext1;
        }

        public List<TBViewDriverInformation> GetAll()
        {
            List<TBViewDriverInformation> MySlider = dbcontext.ViewDriverInformation.OrderByDescending(n => n.IdDriverInformation).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBDriverInformation GetById(int IdDriverInformation)
        {
            TBDriverInformation sslid = dbcontext.TBDriverInformations.FirstOrDefault(a => a.IdDriverInformation == IdDriverInformation);
            return sslid;
        }
        public bool saveData(TBDriverInformation savee)
        {
            try
            {
                dbcontext.Add<TBDriverInformation>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBDriverInformation updatss)
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
        public List<TBViewDriverInformation> GetAllv(int IdDriverInformation)
        {
            List<TBViewDriverInformation> MySlider = dbcontext.ViewDriverInformation.OrderByDescending(n => n.IdDriverInformation == IdDriverInformation).Where(a => a.IdDriverInformation == IdDriverInformation).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }

        // /////////////////////////////////////////API//////////////////////////////////

        public async Task<List<TBViewDriverInformation>> GetAllAsync()
        {
            List<TBViewDriverInformation> MySlider = await dbcontext.ViewDriverInformation.OrderByDescending(n => n.IdDriverInformation).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }

        public async Task<TBDriverInformation> GetByIdAsync(int IdDriverInformation)
        {
            TBDriverInformation sslid = await dbcontext.TBDriverInformations.FirstOrDefaultAsync(a => a.IdDriverInformation == IdDriverInformation);
            return sslid;
        }

        public async Task<bool> AddDataAsync(TBDriverInformation savee)
        {
            try
            {
                await dbcontext.AddAsync<TBDriverInformation>(savee);
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDataAsync(TBDriverInformation updatss)
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

        public async Task<bool> DeleteDataAsync(int IdDriverInformation)
        {
            try
            {
                var catr = await GetByIdAsync(IdDriverInformation);
                catr.CurrentState = false;
                //TbSubCateegoory dele = dbcontex.TbSubCateegoorys.Where(a => a.IdBrand == IdBrand).FirstOrDefault();
                //dbcontex.TbSubCateegoorys.Remove(dele);
                dbcontext.Entry(catr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<TBViewDriverInformation>> GetAllvAsync(int IdDriverInformation)
        {
            List<TBViewDriverInformation> MySlider = await dbcontext.ViewDriverInformation.OrderByDescending(n => n.IdDriverInformation == IdDriverInformation).Where(a => a.IdDriverInformation == IdDriverInformation).Where(a => a.CurrentState == true).ToListAsync();
            return MySlider;
        }
    }
}
