

namespace Infarstuructre.BL
{
    public interface IITaxizAppHomeContent
    {
        List<TBTaxizAppHomeContent> GetAll();
        TBTaxizAppHomeContent GetById(int IdTaxizAppHomeContent);
        bool saveData(TBTaxizAppHomeContent savee);
        bool UpdateData(TBTaxizAppHomeContent updatss);
        bool deleteData(int IdTaxizAppHomeContent);
        List<TBTaxizAppHomeContent> GetAllv(int IdTaxizAppHomeContent);

    }
    public class CLSTBTaxizAppHomeContent: IITaxizAppHomeContent
    {
        MasterDbcontext dbcontext;
        public CLSTBTaxizAppHomeContent(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBTaxizAppHomeContent> GetAll()
        {
            List<TBTaxizAppHomeContent> MySlider = dbcontext.TBTaxizAppHomeContents.OrderByDescending(n => n.IdTaxizAppHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBTaxizAppHomeContent GetById(int IdTaxizAppHomeContent)
        {
            TBTaxizAppHomeContent sslid = dbcontext.TBTaxizAppHomeContents.FirstOrDefault(a => a.IdTaxizAppHomeContent == IdTaxizAppHomeContent);
            return sslid;
        }
        public bool saveData(TBTaxizAppHomeContent savee)
        {
            try
            {
                dbcontext.Add<TBTaxizAppHomeContent>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBTaxizAppHomeContent updatss)
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
        public bool deleteData(int IdTaxizAppHomeContent)
        {
            try
            {
                var catr = GetById(IdTaxizAppHomeContent);
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
        public List<TBTaxizAppHomeContent> GetAllv(int IdTaxizAppHomeContent)
        {
            List<TBTaxizAppHomeContent> MySlider = dbcontext.TBTaxizAppHomeContents.OrderByDescending(n => n.IdTaxizAppHomeContent == IdTaxizAppHomeContent).Where(a => a.IdTaxizAppHomeContent == IdTaxizAppHomeContent).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
