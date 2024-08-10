

namespace Infarstuructre.BL
{
    public interface IIChooseUsHomeContent
    {
        List<TBChooseUsHomeContent> GetAll();
        TBChooseUsHomeContent GetById(int IdChooseUsHomeContent);
        bool saveData(TBChooseUsHomeContent savee);
        bool UpdateData(TBChooseUsHomeContent updatss);
        bool deleteData(int IdChooseUsHomeContent);
        List<TBChooseUsHomeContent> GetAllv(int IdChooseUsHomeContent);
    }
    public class CLSTBChooseUsHomeContent: IIChooseUsHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBChooseUsHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext= dbcontext1;
        }
        public List<TBChooseUsHomeContent> GetAll()
        {
            List<TBChooseUsHomeContent> MySlider = dbcontext.TBChooseUsHomeContents.OrderByDescending(n => n.IdChooseUsHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBChooseUsHomeContent GetById(int IdChooseUsHomeContent)
        {
            TBChooseUsHomeContent sslid = dbcontext.TBChooseUsHomeContents.FirstOrDefault(a => a.IdChooseUsHomeContent == IdChooseUsHomeContent);
            return sslid;
        }
        public bool saveData(TBChooseUsHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBChooseUsHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBChooseUsHomeContent updatss)
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
        public bool deleteData(int IdChooseUsHomeContent)
        {
            try
            {
                var catr = GetById(IdChooseUsHomeContent);
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
        public List<TBChooseUsHomeContent> GetAllv(int IdChooseUsHomeContent)
        {
            List<TBChooseUsHomeContent> MySlider = dbcontext.TBChooseUsHomeContents.OrderByDescending(n => n.IdChooseUsHomeContent == IdChooseUsHomeContent).Where(a => a.IdChooseUsHomeContent == IdChooseUsHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
