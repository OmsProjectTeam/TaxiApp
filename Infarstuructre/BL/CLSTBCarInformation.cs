

namespace Infarstuructre.BL
{
	public interface IICarInformation
	{
		List<TBViewCarInformation> GetAll();
		TBCarInformation GetById(int IdCarInformation);
		bool saveData(TBCarInformation savee);
		bool UpdateData(TBCarInformation updatss);
		bool deleteData(int IdCarInformation);
		List<TBViewCarInformation> GetAllv(int IdCarInformation);
	}
	public class CLSTBCarInformation: IICarInformation
	{
		MasterDbcontext dbcontext;
		public CLSTBCarInformation(MasterDbcontext dbcontext1)
        {
			dbcontext=dbcontext1;

		}

		public List<TBViewCarInformation> GetAll()
		{
			List<TBViewCarInformation> MySlider = dbcontext.ViewCarInformation.OrderByDescending(n => n.IdCarInformation).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBCarInformation GetById(int IdCarInformation)
		{
			TBCarInformation sslid = dbcontext.TBCarInformations.FirstOrDefault(a => a.IdCarInformation == IdCarInformation);
			return sslid;
		}
		public bool saveData(TBCarInformation savee)
		{
			try
			{
				dbcontext.Add<TBCarInformation>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBCarInformation updatss)
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
		public bool deleteData(int IdCarInformation)
		{
			try
			{
				var catr = GetById(IdCarInformation);
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
		public List<TBViewCarInformation> GetAllv(int IdCarInformation)
		{
			List<TBViewCarInformation> MySlider = dbcontext.ViewCarInformation.OrderByDescending(n => n.IdCarInformation == IdCarInformation).Where(a => a.IdCarInformation == IdCarInformation).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}

	}
}
