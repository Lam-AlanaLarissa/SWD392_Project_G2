using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.DatabaseConnection;

public partial class BookingBadmintonContext : DbContext
{
    public BookingBadmintonContext()
    {
    }

    public BookingBadmintonContext(DbContextOptions<BookingBadmintonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingType> BookingTypes { get; set; }

    public virtual DbSet<CardProvider> CardProviders { get; set; }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtManager> CourtManagers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Revenue> Revenues { get; set; }

    public virtual DbSet<RevenueDetail> RevenueDetails { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }
    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true).Build();

        return configuration["ConnectionStrings:DefaultConnection"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD065D9FCD");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BookingID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");
            entity.Property(e => e.DateOfWeek)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TypeID");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Court).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__CourtID__29572725");

            entity.HasOne(d => d.Type).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Booking__TypeID__2A4B4B5E");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__UserID__2B3F6F97");
        });

        modelBuilder.Entity<BookingType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__BookingT__516F03951782CAD4");

            entity.Property(e => e.TypeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TypeID");
            entity.Property(e => e.TypeDesc).HasMaxLength(255);
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<CardProvider>(entity =>
        {
            entity.HasKey(e => e.CardProviderName).HasName("PK__CardProv__3B8DEBCC6A161FB4");

            entity.Property(e => e.CardProviderName).HasMaxLength(255);
            entity.Property(e => e.CpfullName)
                .HasMaxLength(255)
                .HasColumnName("CPFullName");
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__CheckIn__73951ACD7C80B79A");

            entity.ToTable("CheckIn");

            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BookingID");
            entity.Property(e => e.CheckInTime).HasColumnType("datetime");
            entity.Property(e => e.CheckedBy)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Booking).WithOne(p => p.CheckIn)
                .HasForeignKey<CheckIn>(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckIn__Booking__2C3393D0");

            entity.HasOne(d => d.CheckedByNavigation).WithMany(p => p.CheckIns)
                .HasForeignKey(d => d.CheckedBy)
                .HasConstraintName("FK__CheckIn__Checked__2D27B809");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Courts__C3A67CFA32930F96");

            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");
            entity.Property(e => e.CourtName).HasMaxLength(255);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Courts)
                .HasForeignKey(d => d.CreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Courts__CreateBy__300424B4");
        });

        modelBuilder.Entity<CourtManager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__CourtMan__3BA2AA8172A70D30");

            entity.Property(e => e.ManagerId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ManagerID");
            entity.Property(e => e.CardName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CardNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CardProviderName).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.CardProviderNameNavigation).WithMany(p => p.CourtManagers)
                .HasForeignKey(d => d.CardProviderName)
                .HasConstraintName("FK__CourtMana__CardP__2E1BDC42");

            entity.HasOne(d => d.User).WithMany(p => p.CourtManagers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourtMana__UserI__2F10007B");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6F70E9C8E");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Court).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Court__30F848ED");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Creat__31EC6D26");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A588157B28B");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PaymentID");
            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BookingID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(255);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Bookin__32E0915F");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD48E5918B089F");

            entity.Property(e => e.ReportId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ReportID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Issue).HasMaxLength(255);

            entity.HasOne(d => d.Court).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__CourtID__33D4B598");
        });

        modelBuilder.Entity<Revenue>(entity =>
        {
            entity.HasKey(e => e.RevenueId).HasName("PK__Revenue__275F173DEFFCB2AA");

            entity.ToTable("Revenue");

            entity.Property(e => e.RevenueId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RevenueID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");

            entity.HasOne(d => d.Court).WithMany(p => p.Revenues)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Revenue__CourtID__34C8D9D1");
        });

        modelBuilder.Entity<RevenueDetail>(entity =>
        {
            entity.HasKey(e => e.RdetailId).HasName("PK__RevenueD__922A73D58E68D9BE");

            entity.Property(e => e.RdetailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RDetailID");
            entity.Property(e => e.RevenueId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RevenueID");

            entity.HasOne(d => d.Revenue).WithMany(p => p.RevenueDetails)
                .HasForeignKey(d => d.RevenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RevenueDe__Reven__35BCFE0A");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slots__0A124A4FC59CBF39");

            entity.Property(e => e.SlotId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SlotID");
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");

            entity.HasOne(d => d.Court).WithMany(p => p.Slots)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Slots__CourtID__36B12243");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3B6111A0");

            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.WishId).HasName("PK__WishList__64BA65415BFC18D5");

            entity.ToTable("WishList");

            entity.Property(e => e.WishId)
                .ValueGeneratedNever()
                .HasColumnName("WishID");
            entity.Property(e => e.AddBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CourtId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CourtID");

            entity.HasOne(d => d.AddByNavigation).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.AddBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WishList__AddBy__37A5467C");

            entity.HasOne(d => d.Court).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WishList__CourtI__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
