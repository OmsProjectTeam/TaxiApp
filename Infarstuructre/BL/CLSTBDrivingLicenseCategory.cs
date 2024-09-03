

namespace Infarstuructre.BL
{
    public interface IIDrivingLicenseCategory
    {
        List<TBDrivingLicenseCategory> GetAll();
        TBDrivingLicenseCategory GetById(int IdDrivingLicenseCategory);
        bool saveData(TBDrivingLicenseCategory savee);
        bool UpdateData(TBDrivingLicenseCategory updatss);
        bool deleteData(int IdDrivingLicenseCategory);
        List<TBDrivingLicenseCategory> GetAllv(int IdDrivingLicenseCategory);
    }
    public class CLSTBDrivingLicenseCategory: IIDrivingLicenseCategory
    {
        MasterDbcontext dbcontext;
        public CLSTBDrivingLicenseCategory(MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
        }
        public List<TBDrivingLicenseCategory> GetAll()
        {
            List<TBDrivingLicenseCategory> MySlider = dbcontext.TBDrivingLicenseCategorys.OrderByDescending(n => n.IdDrivingLicenseCategory).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
        public TBDrivingLicenseCategory GetById(int IdDrivingLicenseCategory)
        {
            TBDrivingLicenseCategory sslid = dbcontext.TBDrivingLicenseCategorys.FirstOrDefault(a => a.IdDrivingLicenseCategory == IdDrivingLicenseCategory);
            return sslid;
        }
        public bool saveData(TBDrivingLicenseCategory savee)
        {
            try
            {
                dbcontext.Add<TBDrivingLicenseCategory>(savee);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(TBDrivingLicenseCategory updatss)
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
        public bool deleteData(int IdDrivingLicenseCategory)
        {
            try
            {
                var catr = GetById(IdDrivingLicenseCategory);
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
        public List<TBDrivingLicenseCategory> GetAllv(int IdDrivingLicenseCategory)
        {
            List<TBDrivingLicenseCategory> MySlider = dbcontext.TBDrivingLicenseCategorys.OrderByDescending(n => n.IdDrivingLicenseCategory == IdDrivingLicenseCategory).Where(a => a.IdDrivingLicenseCategory == IdDrivingLicenseCategory).Where(a => a.CurrentState == true).ToList();
            return MySlider;
        }
    }
}
