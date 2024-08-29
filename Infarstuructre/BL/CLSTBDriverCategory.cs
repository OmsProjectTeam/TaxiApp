

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
    }
}
