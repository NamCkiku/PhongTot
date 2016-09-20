namespace PhongTot.Entities.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhongTot : DbContext
    {
        public PhongTot()
            : base("name=PhongTotEntity")
        {
        }

        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DanhMucThongTinThem> DanhMucThongTinThems { get; set; }
        public virtual DbSet<HuongNha> HuongNhas { get; set; }
        public virtual DbSet<Phuongxa> Phuongxas { get; set; }
        public virtual DbSet<Quanhuyen> Quanhuyens { get; set; }
        public virtual DbSet<SoPhongNgu> SoPhongNgus { get; set; }
        public virtual DbSet<SoPhongVeSinh> SoPhongVeSinhs { get; set; }
        public virtual DbSet<SoTang> SoTangs { get; set; }
        public virtual DbSet<ThongTin> ThongTins { get; set; }
        public virtual DbSet<ThongTinThem> ThongTinThems { get; set; }
        public virtual DbSet<TienNghi> TienNghis { get; set; }
        public virtual DbSet<Tinhthanh> Tinhthanhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.ThongTins)
                .WithRequired(e => e.DanhMuc)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucThongTinThem>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.DanhMucThongTinThem)
                .HasForeignKey(e => e.InformatinAddCategory);

            modelBuilder.Entity<HuongNha>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.HuongNha)
                .HasForeignKey(e => e.CompassID);

            modelBuilder.Entity<SoPhongNgu>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.SoPhongNgu)
                .HasForeignKey(e => e.BedroomNumberID);

            modelBuilder.Entity<SoPhongVeSinh>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.SoPhongVeSinh)
                .HasForeignKey(e => e.ToiletNumberID);

            modelBuilder.Entity<SoTang>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.SoTang)
                .HasForeignKey(e => e.FloorNumberID);

            modelBuilder.Entity<ThongTinThem>()
                .HasMany(e => e.ThongTins)
                .WithOptional(e => e.ThongTinThem)
                .HasForeignKey(e => e.InformationAddID);

            modelBuilder.Entity<TienNghi>()
                .HasMany(e => e.ThongTinThems)
                .WithOptional(e => e.TienNghi)
                .HasForeignKey(e => e.ConvenientID);
        }
    }
}
