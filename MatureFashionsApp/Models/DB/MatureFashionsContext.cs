using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MatureFashionsApp.Models.DB
{
    public partial class MatureFashionsContext : DbContext
    {
        public MatureFashionsContext()
        {
        }

        public MatureFashionsContext(DbContextOptions<MatureFashionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Franchise> Franchise { get; set; }
        public virtual DbSet<FranchisePostcodes> FranchisePostcodes { get; set; }
        public virtual DbSet<Franchisor> Franchisor { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<Hometype> Hometype { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Orderline> Orderline { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Postcode> Postcode { get; set; }
        public virtual DbSet<Saleitem> Saleitem { get; set; }
        public virtual DbSet<Shows> Shows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M6282RS\\SS2019;Database=MatureFashions;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.HasKey(e => e.FranchiseNo)
                    .HasName("PK__franchis__6D39F373A7C33B11");

                entity.ToTable("franchise");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseAddress)
                    .IsRequired()
                    .HasColumnName("franchise_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseFax)
                    .HasColumnName("franchise_fax")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseName)
                    .IsRequired()
                    .HasColumnName("franchise_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisePostcode)
                    .IsRequired()
                    .HasColumnName("franchise_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseStartdate)
                    .HasColumnName("franchise_startdate")
                    .HasColumnType("date");

                entity.Property(e => e.FranchiseTel)
                    .IsRequired()
                    .HasColumnName("franchise_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorNo)
                    .IsRequired()
                    .HasColumnName("franchisor_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchisorNoNavigation)
                    .WithMany(p => p.Franchise)
                    .HasForeignKey(d => d.FranchisorNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__franchise__franc__398D8EEE");
            });

            modelBuilder.Entity<FranchisePostcodes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FRANCHISE_POSTCODES");

                entity.Property(e => e.FranchiseName)
                    .IsRequired()
                    .HasColumnName("franchise_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeArea)
                    .IsRequired()
                    .HasColumnName("postcode_area")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeName)
                    .IsRequired()
                    .HasColumnName("postcode_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Franchisor>(entity =>
            {
                entity.HasKey(e => e.FranchisorNo)
                    .HasName("PK__franchis__3A3BACB7EEBB5251");

                entity.ToTable("franchisor");

                entity.Property(e => e.FranchisorNo)
                    .HasColumnName("franchisor_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorAddress)
                    .IsRequired()
                    .HasColumnName("franchisor_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorFax)
                    .IsRequired()
                    .HasColumnName("franchisor_fax")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorName)
                    .IsRequired()
                    .HasColumnName("franchisor_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorPostcode)
                    .IsRequired()
                    .HasColumnName("franchisor_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorTel)
                    .IsRequired()
                    .HasColumnName("franchisor_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasKey(e => e.HomeNo)
                    .HasName("PK__home__8ECADEFC2E89F4FE");

                entity.ToTable("home");

                entity.Property(e => e.HomeNo)
                    .HasColumnName("home_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasColumnName("home_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeName)
                    .IsRequired()
                    .HasColumnName("home_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HomePostcode)
                    .IsRequired()
                    .HasColumnName("home_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTel)
                    .IsRequired()
                    .HasColumnName("home_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HometypeCode)
                    .IsRequired()
                    .HasColumnName("hometype_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.HometypeCodeNavigation)
                    .WithMany(p => p.Home)
                    .HasForeignKey(d => d.HometypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__home__hometype_c__3A81B327");
            });

            modelBuilder.Entity<Hometype>(entity =>
            {
                entity.HasKey(e => e.HometypeCode)
                    .HasName("PK__hometype__4FE16C0AC34FCBF4");

                entity.ToTable("hometype");

                entity.Property(e => e.HometypeCode)
                    .HasColumnName("hometype_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HometypeDescription)
                    .IsRequired()
                    .HasColumnName("hometype_description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__invoice__F58CA1E3DC8A1E35");

                entity.ToTable("invoice");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoice_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .IsRequired()
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDateDue)
                    .HasColumnName("invoice_date_due")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceNet)
                    .HasColumnName("invoice_net")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invoice__franchi__3B75D760");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invoice__order_n__3C69FB99");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemNo)
                    .HasName("PK__item__5202274E5E989176");

                entity.ToTable("item");

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.ItemColour)
                    .HasColumnName("item_colour")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("item_description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemGender)
                    .HasColumnName("item_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemRetailPrice)
                    .HasColumnName("item_retail_price")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ItemSize)
                    .HasColumnName("item_size")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ItemWholesalePrice)
                    .HasColumnName("item_wholesale_price")
                    .HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Orderline>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ItemNo })
                    .HasName("PK__orderlin__B37CA3CDF41E7AAA");

                entity.ToTable("orderline");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.HasOne(d => d.ItemNoNavigation)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.ItemNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderline__item___3E52440B");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderline__order__3D5E1FD2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__orders__465C81B98E1FFA5F");

                entity.ToTable("orders");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .IsRequired()
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__franchis__3F466844");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.PartnerName })
                    .HasName("PK__partner__0FB114D31402B568");

                entity.ToTable("partner");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerName)
                    .HasColumnName("partner_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Partner)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__partner__franchi__403A8C7D");
            });

            modelBuilder.Entity<Postcode>(entity =>
            {
                entity.HasKey(e => e.PostcodeArea)
                    .HasName("PK__postcode__891BAE9878FD0DD1");

                entity.ToTable("postcode");

                entity.Property(e => e.PostcodeArea)
                    .HasColumnName("postcode_area")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeName)
                    .IsRequired()
                    .HasColumnName("postcode_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Postcode)
                    .HasForeignKey(d => d.FranchiseNo)
                    .HasConstraintName("FK__postcode__franch__412EB0B6");
            });

            modelBuilder.Entity<Saleitem>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.HomeNo, e.ShowDate, e.ItemNo })
                    .HasName("PK__saleitem__11533B758D492F59");

                entity.ToTable("saleitem");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo).HasColumnName("home_no");

                entity.Property(e => e.ShowDate)
                    .HasColumnName("show_date")
                    .HasColumnType("date");

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.SaleQuantity).HasColumnName("sale_quantity");

                entity.HasOne(d => d.ItemNoNavigation)
                    .WithMany(p => p.Saleitem)
                    .HasForeignKey(d => d.ItemNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saleitem__item_n__4316F928");

                entity.HasOne(d => d.Shows)
                    .WithMany(p => p.Saleitem)
                    .HasForeignKey(d => new { d.FranchiseNo, d.HomeNo, d.ShowDate })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saleitem__4222D4EF");
            });

            modelBuilder.Entity<Shows>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.HomeNo, e.ShowDate })
                    .HasName("PK__shows__65A61B57801590AB");

                entity.ToTable("shows");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo).HasColumnName("home_no");

                entity.Property(e => e.ShowDate)
                    .HasColumnName("show_date")
                    .HasColumnType("date");

                entity.Property(e => e.ShowTime)
                    .IsRequired()
                    .HasColumnName("show_time")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ShowTotalSale)
                    .HasColumnName("show_total_sale")
                    .HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__franchise__440B1D61");

                entity.HasOne(d => d.HomeNoNavigation)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.HomeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__home_no__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
