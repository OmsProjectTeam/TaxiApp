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
      



    }
}
