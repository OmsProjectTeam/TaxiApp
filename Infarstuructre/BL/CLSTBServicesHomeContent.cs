

namespace Infarstuructre.BL
{
    public interface IIServicesHomeContent
    {
        List<TBServicesHomeContent> GetAll();
        TBServicesHomeContent GetById(int IdServicesHomeContent);
        bool saveData(TBServicesHomeContent savee);
        bool UpdateData(TBServicesHomeContent updatss);
        bool deleteData(int IdServicesHomeContent);
        List<TBServicesHomeContent> GetAllv(int IdServicesHomeContent);
    }
    public class CLSTBServicesHomeContent: IIServicesHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBServicesHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBServicesHomeContent> GetAll()
        {
            List<TBServicesHomeContent> MySlider = dbcontext.TBServicesHomeContents.OrderByDescending(n => n.IdServicesHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBServicesHomeContent GetById(int IdServicesHomeContent)
        {
            TBServicesHomeContent sslid = dbcontext.TBServicesHomeContents.FirstOrDefault(a => a.IdServicesHomeContent == IdServicesHomeContent);
            return sslid;
        }
        public bool saveData(TBServicesHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBServicesHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBServicesHomeContent updatss)
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
        public bool deleteData(int IdServicesHomeContent)
        {
            try
            {
                var catr = GetById(IdServicesHomeContent);
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
        public List<TBServicesHomeContent> GetAllv(int IdServicesHomeContent)
        {
            List<TBServicesHomeContent> MySlider = dbcontext.TBServicesHomeContents.OrderByDescending(n => n.IdServicesHomeContent == IdServicesHomeContent).Where(a => a.IdServicesHomeContent == IdServicesHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
