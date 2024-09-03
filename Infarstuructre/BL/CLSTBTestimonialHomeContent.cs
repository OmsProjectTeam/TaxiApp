
namespace Infarstuructre.BL
{
	public interface IITestimonialHomeContent
	{
		List<TBTestimonialHomeContent> GetAll();
		TBTestimonialHomeContent GetById(int IdTestimonialHomeContent);
		bool saveData(TBTestimonialHomeContent savee);
		bool UpdateData(TBTestimonialHomeContent updatss);
		bool deleteData(int IdTestimonialHomeContent);
		List<TBTestimonialHomeContent> GetAllv(int IdTestimonialHomeContent);
	}
	public class CLSTBTestimonialHomeContent: IITestimonialHomeContent
	{
		MasterDbcontext dbcontext;
		public CLSTBTestimonialHomeContent(MasterDbcontext dbcontext1)
        {
			dbcontext = dbcontext1; 
		}
		public List<TBTestimonialHomeContent> GetAll()
		{
			List<TBTestimonialHomeContent> MySlider = dbcontext.TBTestimonialHomeContents.OrderByDescending(n => n.IdTestimonialHomeContent).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
		public TBTestimonialHomeContent GetById(int IdTestimonialHomeContent)
		{
			TBTestimonialHomeContent sslid = dbcontext.TBTestimonialHomeContents.FirstOrDefault(a => a.IdTestimonialHomeContent == IdTestimonialHomeContent);
			return sslid;
		}
		public bool saveData(TBTestimonialHomeContent savee)
		{
			try
			{
				dbcontext.Add<TBTestimonialHomeContent>(savee);
				dbcontext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool UpdateData(TBTestimonialHomeContent updatss)
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
		public bool deleteData(int IdTestimonialHomeContent)
		{
			try
			{
				var catr = GetById(IdTestimonialHomeContent);
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
		public List<TBTestimonialHomeContent> GetAllv(int IdTestimonialHomeContent)
		{
			List<TBTestimonialHomeContent> MySlider = dbcontext.TBTestimonialHomeContents.OrderByDescending(n => n.IdTestimonialHomeContent == IdTestimonialHomeContent).Where(a => a.IdTestimonialHomeContent == IdTestimonialHomeContent).Where(a => a.CurrentState == true).ToList();
			return MySlider;
		}
	
	}
}
