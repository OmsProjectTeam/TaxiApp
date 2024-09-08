

namespace Infarstuructre.BL
{
    public interface IIContentHomeBookNow
    {
        List<TBContentHomeBookNow> GetAll();
        TBContentHomeBookNow GetById(int IdContentHomeBookNow);
        bool saveData(TBContentHomeBookNow savee);
        bool UpdateData(TBContentHomeBookNow updatss);
        bool deleteData(int IdContentHomeBookNow);
        List<TBContentHomeBookNow> GetAllv(int IdContentHomeBookNow);
    }
    public class CLSTBContentHomeBookNow: IIContentHomeBookNow
    {
        MasterDbcontext dbcontext;
        public CLSTBContentHomeBookNow(MasterDbcontext dbcontex1)
        {
            dbcontext= dbcontex1;
        }
        public List<TBContentHomeBookNow> GetAll()
        {
            List<TBContentHomeBookNow> MySlider = dbcontext.TBContentHomeBookNows.OrderByDescending(n => n.IdContentHomeBookNow).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBContentHomeBookNow GetById(int IdContentHomeBookNow)
        {
            TBContentHomeBookNow sslid = dbcontext.TBContentHomeBookNows.FirstOrDefault(a => a.IdContentHomeBookNow == IdContentHomeBookNow);
            return sslid;
        }
        public bool saveData(TBContentHomeBookNow savee)
        {
            try
            {
                dbcontext.Add<TBContentHomeBookNow>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBContentHomeBookNow updatss)
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
        public bool deleteData(int IdContentHomeBookNow)
        {
            try
            {
                var catr = GetById(IdContentHomeBookNow);
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
        public List<TBContentHomeBookNow> GetAllv(int IdContentHomeBookNow)
        {
            List<TBContentHomeBookNow> MySlider = dbcontext.TBContentHomeBookNows.OrderByDescending(n => n.IdContentHomeBookNow == IdContentHomeBookNow).Where(a => a.IdContentHomeBookNow == IdContentHomeBookNow).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
