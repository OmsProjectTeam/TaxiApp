using Domin.Entity;

using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Infarstuructre.Data
{
	public class MasterDbcontext : IdentityDbContext<ApplicationUser>
	{
		public MasterDbcontext(DbContextOptions<MasterDbcontext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            //***********************************************************


			builder.Entity<VwUser>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("VwUsers");
			}); 
            //***********************************************************


			builder.Entity<TBViewPhotoSliderHomeContent>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("ViewPhotoSliderHomeContent");
			});   //***********************************************************


			builder.Entity<TBViewDriverInformation>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("ViewDriverInformation");
			});









            //---------------------------------	
            builder.Entity<TBAboutHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBAboutHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBPhotoAboutHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoAboutHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBSliderHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBSliderHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBPhotoSliderHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoSliderHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBTaxiInfoStep>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTaxiInfoStep>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBServicesHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBServicesHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBService>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBService>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))"); 
            builder.Entity<TBService>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------
            //---------------------------------	
            builder.Entity<TBChooseUsHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBChooseUsHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBBointChooseUsHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBBointChooseUsHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBCarCategorie>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCarCategorie>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))"); 
            builder.Entity<TBCarCategorie>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBTaxiRatesHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTaxiRatesHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))"); 
      
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBPhotoBookYourRideContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoBookYourRideContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBTaxiType>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTaxiType>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBTaxiType>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBTaxizAppHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTaxizAppHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBDriverCategory>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBDriverCategory>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");  
            builder.Entity<TBDriverCategory>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	  
            //---------------------------------	
            builder.Entity<TBPhotoTaxizAppHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoTaxizAppHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");  
          
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBTestimonialHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTestimonialHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");  
          
            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBPhotoTestimonialHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoTestimonialHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");  
          
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBDrivingLicenseCategory>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBDrivingLicenseCategory>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBDrivingLicenseCategory>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");  
          
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBContentHomeBookNow>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBContentHomeBookNow>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
        
          
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBPhotoContentHomeBookNow>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoContentHomeBookNow>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
        
          
            //---------------------------------	
            builder.Entity<TBDriverInformation>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBDriverInformation>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
        
          
            //---------------------------------	
        }




        //***********************************
        public DbSet<VwUser> VwUsers { get; set; }
        public DbSet<TBAboutHomeContent> TBAboutHomeContents { get; set; }
        public DbSet<TBPhotoAboutHomeContent> TBPhotoAboutHomeContents { get; set; }
        public DbSet<TBSliderHomeContent> TBSliderHomeContents { get; set; }
        public DbSet<TBPhotoSliderHomeContent> TBPhotoSliderHomeContents { get; set; }
        public DbSet<TBViewPhotoSliderHomeContent> ViewPhotoSliderHomeContent { get; set; }
        public DbSet<TBTaxiInfoStep> TBTaxiInfoSteps { get; set; }
        public DbSet<TBServicesHomeContent> TBServicesHomeContents { get; set; }
        public DbSet<TBService> TBServices { get; set; }
        public DbSet<TBChooseUsHomeContent> TBChooseUsHomeContents { get; set; }
        public DbSet<TBBointChooseUsHomeContent> TBBointChooseUsHomeContents { get; set; }
        public DbSet<TBCarCategorie> TBCarCategories { get; set; }
        public DbSet<TBTaxiRatesHomeContent> TBTaxiRatesHomeContents { get; set; }
        public DbSet<TBPhotoBookYourRideContent> TBPhotoBookYourRideContents { get; set; }
        public DbSet<TBTaxiType> TBTaxiTypes { get; set; }
        public DbSet<TBTaxizAppHomeContent> TBTaxizAppHomeContents { get; set; }
        public DbSet<TBDriverCategory> TBDriverCategorys { get; set; }
        public DbSet<TBPhotoTaxizAppHomeContent> TBPhotoTaxizAppHomeContents { get; set; }
        public DbSet<TBTestimonialHomeContent> TBTestimonialHomeContents { get; set; }
        public DbSet<TBPhotoTestimonialHomeContent> TBPhotoTestimonialHomeContents { get; set; }
        public DbSet<TBlatestNewsBlogHomeContent> TBlatestNewsBlogHomeContents { get; set; }
        public DbSet<TBDrivingLicenseCategory> TBDrivingLicenseCategorys { get; set; }
        public DbSet<TBContentHomeBookNow> TBContentHomeBookNows { get; set; }
        public DbSet<TBPhotoContentHomeBookNow> TBPhotoContentHomeBookNows { get; set; }
        public DbSet<TBDriverInformation> TBDriverInformations { get; set; }
        public DbSet<TBViewDriverInformation>ViewDriverInformation { get; set; }
      



    }
}
