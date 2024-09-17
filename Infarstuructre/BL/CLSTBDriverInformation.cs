

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
    }
}
