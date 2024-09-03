

namespace Infarstuructre.BL
{
    public interface IIlatestNewsBlogHomeContent
    {
        List<TBlatestNewsBlogHomeContent> GetAll();
        TBlatestNewsBlogHomeContent GetById(int IdlatestNewsBlogHomeContent);
        bool saveData(TBlatestNewsBlogHomeContent savee);
        bool UpdateData(TBlatestNewsBlogHomeContent updatss);
        bool deleteData(int IdlatestNewsBlogHomeContent);
    }
    public class CLSTBlatestNewsBlogHomeContent: IIlatestNewsBlogHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBlatestNewsBlogHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBlatestNewsBlogHomeContent> GetAll()
        {
            List<TBlatestNewsBlogHomeContent> MySlider = dbcontext.TBlatestNewsBlogHomeContents.OrderByDescending(n => n.IdlatestNewsBlogHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBlatestNewsBlogHomeContent GetById(int IdlatestNewsBlogHomeContent)
        {
            TBlatestNewsBlogHomeContent sslid = dbcontext.TBlatestNewsBlogHomeContents.FirstOrDefault(a => a.IdlatestNewsBlogHomeContent == IdlatestNewsBlogHomeContent);
            return sslid;
        }
        public bool saveData(TBlatestNewsBlogHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBlatestNewsBlogHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBlatestNewsBlogHomeContent updatss)
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
        public bool deleteData(int IdlatestNewsBlogHomeContent)
        {
            try
            {
                var catr = GetById(IdlatestNewsBlogHomeContent);
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
        public List<TBlatestNewsBlogHomeContent> GetAllv(int IdlatestNewsBlogHomeContent)
        {
            List<TBlatestNewsBlogHomeContent> MySlider = dbcontext.TBlatestNewsBlogHomeContents.OrderByDescending(n => n.IdlatestNewsBlogHomeContent == IdlatestNewsBlogHomeContent).Where(a => a.IdlatestNewsBlogHomeContent == IdlatestNewsBlogHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
