
namespace Infarstuructre.BL
{
    public interface IITaxiRatesHomeContent
    {
        List<TBTaxiRatesHomeContent> GetAll();
        TBTaxiRatesHomeContent GetById(int IdTaxiRatesHomeContent);
        bool saveData(TBTaxiRatesHomeContent savee);
        bool UpdateData(TBTaxiRatesHomeContent updatss);
        bool deleteData(int IdTaxiRatesHomeContent);
        List<TBTaxiRatesHomeContent> GetAllv(int IdTaxiRatesHomeContent);
    }
    public class CLSTBTaxiRatesHomeContent: IITaxiRatesHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBTaxiRatesHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }

        public List<TBTaxiRatesHomeContent> GetAll()
        {
            List<TBTaxiRatesHomeContent> MySlider = dbcontext.TBTaxiRatesHomeContents.OrderByDescending(n => n.IdTaxiRatesHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTaxiRatesHomeContent GetById(int IdTaxiRatesHomeContent)
        {
            TBTaxiRatesHomeContent sslid = dbcontext.TBTaxiRatesHomeContents.FirstOrDefault(a => a.IdTaxiRatesHomeContent == IdTaxiRatesHomeContent);
            return sslid;
        }
        public bool saveData(TBTaxiRatesHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBTaxiRatesHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTaxiRatesHomeContent updatss)
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
        public bool deleteData(int IdTaxiRatesHomeContent)
        {
            try
            {
                var catr = GetById(IdTaxiRatesHomeContent);
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
        public List<TBTaxiRatesHomeContent> GetAllv(int IdTaxiRatesHomeContent)
        {
            List<TBTaxiRatesHomeContent> MySlider = dbcontext.TBTaxiRatesHomeContents.OrderByDescending(n => n.IdTaxiRatesHomeContent == IdTaxiRatesHomeContent).Where(a => a.IdTaxiRatesHomeContent == IdTaxiRatesHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
