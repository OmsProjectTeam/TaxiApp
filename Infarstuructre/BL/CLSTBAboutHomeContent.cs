

namespace Infarstuructre.BL
{
    public interface IIAboutHomeContent
    {
        List<TBAboutHomeContent> GetAll();
        TBAboutHomeContent GetById(int IdAboutHomeContent);
        bool saveData(TBAboutHomeContent savee);
        bool UpdateData(TBAboutHomeContent updatss);
        bool deleteData(int IdAboutHomeContent);
        List<TBAboutHomeContent> GetAllv(int IdAboutHomeContent);
    }
    public class CLSTBAboutHomeContent: IIAboutHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBAboutHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }
        public List<TBAboutHomeContent> GetAll()
        {
            List<TBAboutHomeContent> MySlider = dbcontext.TBAboutHomeContents.OrderByDescending(n => n.IdAboutHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBAboutHomeContent GetById(int IdAboutHomeContent)
        {
            TBAboutHomeContent sslid = dbcontext.TBAboutHomeContents.FirstOrDefault(a => a.IdAboutHomeContent == IdAboutHomeContent);
            return sslid;
        }
        public bool saveData(TBAboutHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBAboutHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBAboutHomeContent updatss)
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
        public bool deleteData(int IdAboutHomeContent)
        {
            try
            {
                var catr = GetById(IdAboutHomeContent);
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
        public List<TBAboutHomeContent> GetAllv(int IdAboutHomeContent)
        {
            List<TBAboutHomeContent> MySlider = dbcontext.TBAboutHomeContents.OrderByDescending(n => n.IdAboutHomeContent == IdAboutHomeContent).Where(a => a.IdAboutHomeContent == IdAboutHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
