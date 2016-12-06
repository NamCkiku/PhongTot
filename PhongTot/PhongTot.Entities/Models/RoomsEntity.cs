namespace PhongTot.Entities.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class RoomsEntity : IdentityDbContext<ApplicationUser>
    {
        public RoomsEntity()
            : base("name=RoomsEntity")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<CategoryInfo> CategoryInfoes { get; set; }
        public virtual DbSet<CategoryOtherInfo> CategoryOtherInfoes { get; set; }
        public virtual DbSet<Districtid> Districtids { get; set; }
        public virtual DbSet<Info> Infoes { get; set; }
        public virtual DbSet<OtherInfo> OtherInfoes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Wardid> Wardids { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<SysPara> SysParas { set; get; }
        
        public static RoomsEntity Create()
        {
            return new RoomsEntity();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryInfo>()
                .HasMany(e => e.Infoes)
                .WithRequired(e => e.CategoryInfo)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Districtid>()
                .HasMany(e => e.Infoes)
                .WithOptional(e => e.Districtid1)
                .HasForeignKey(e => e.Districtid);

            modelBuilder.Entity<Districtid>()
                .HasMany(e => e.Wardids)
                .WithOptional(e => e.Districtid1)
                .HasForeignKey(e => e.districtid);

            modelBuilder.Entity<Wardid>()
                .HasMany(e => e.Infoes)
                .WithOptional(e => e.Wardid1)
                .HasForeignKey(e => e.Wardid);

            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
