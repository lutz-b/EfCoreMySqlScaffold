using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1.sakila
{
    public partial class MyContext : DbContext
    {
        public virtual DbSet<actor> actor { get; set; }
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<film> film { get; set; }
        public virtual DbSet<film_actor> film_actor { get; set; }
        public virtual DbSet<film_category> film_category { get; set; }
        public virtual DbSet<film_text> film_text { get; set; }
        public virtual DbSet<inventory> inventory { get; set; }
        public virtual DbSet<language> language { get; set; }
        public virtual DbSet<payment> payment { get; set; }
        public virtual DbSet<rental> rental { get; set; }
        public virtual DbSet<staff> staff { get; set; }
        public virtual DbSet<store> store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=192.168.20.20;Database=sakila;Port=3306;SSL Mode=None;User Id=queens;Password=queens");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<actor>(entity =>
            {
                entity.HasIndex(e => e.LastName)
                    .HasName("idx_actor_last_name");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<address>(entity =>
            {
                entity.HasIndex(e => e.CityId)
                    .HasName("idx_fk_city_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.address)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_city");
            });

            modelBuilder.Entity<category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<city>(entity =>
            {
                entity.HasIndex(e => e.CountryId)
                    .HasName("idx_fk_country_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.city)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_city_country");
            });

            modelBuilder.Entity<country>(entity =>
            {
                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_address_id");

                entity.HasIndex(e => e.LastName)
                    .HasName("idx_last_name");

                entity.HasIndex(e => e.StoreId)
                    .HasName("idx_fk_store_id");

                entity.Property(e => e.Active).HasDefaultValueSql("'1'");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_address");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.customer)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_store");
            });

            modelBuilder.Entity<film>(entity =>
            {
                entity.HasIndex(e => e.LanguageId)
                    .HasName("idx_fk_language_id");

                entity.HasIndex(e => e.OriginalLanguageId)
                    .HasName("idx_fk_original_language_id");

                entity.HasIndex(e => e.Title)
                    .HasName("idx_title");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.RentalDuration).HasDefaultValueSql("'3'");

                entity.Property(e => e.RentalRate).HasDefaultValueSql("'4.99'");

                entity.Property(e => e.ReplacementCost).HasDefaultValueSql("'19.99'");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.filmLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_language");

                entity.HasOne(d => d.OriginalLanguage)
                    .WithMany(p => p.filmOriginalLanguage)
                    .HasForeignKey(d => d.OriginalLanguageId)
                    .HasConstraintName("fk_film_language_original");
            });

            modelBuilder.Entity<film_actor>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.FilmId });

                entity.HasIndex(e => e.ActorId)
                    .HasName("fk_film_actor_actor_idx");

                entity.HasIndex(e => e.FilmId)
                    .HasName("idx_fk_film_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.film_actor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_actor");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.film_actor)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_film");
            });

            modelBuilder.Entity<film_category>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId });

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_film_category_category_idx");

                entity.HasIndex(e => e.FilmId)
                    .HasName("fk_film_category_film_idx");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.film_category)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_category");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.film_category)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_film");
            });

            modelBuilder.Entity<film_text>(entity =>
            {
                entity.HasIndex(e => new { e.Title, e.Description })
                    .HasName("idx_title_description");
            });

            modelBuilder.Entity<inventory>(entity =>
            {
                entity.HasIndex(e => e.FilmId)
                    .HasName("idx_fk_film_id");

                entity.HasIndex(e => e.StoreId)
                    .HasName("fk_inventory_store_idx");

                entity.HasIndex(e => new { e.StoreId, e.FilmId })
                    .HasName("idx_store_id_film_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.inventory)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_film");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_store");
            });

            modelBuilder.Entity<language>(entity =>
            {
                entity.Property(e => e.LanguageId).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("idx_fk_customer_id");

                entity.HasIndex(e => e.RentalId)
                    .HasName("fk_payment_rental_idx");

                entity.HasIndex(e => e.StaffId)
                    .HasName("idx_fk_staff_id");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.payment)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_customer");

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.payment)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_payment_rental");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.payment)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_staff");
            });

            modelBuilder.Entity<rental>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("idx_fk_customer_id");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_inventory_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("idx_fk_staff_id");

                entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId })
                    .HasName("idx_rental")
                    .IsUnique();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.rental)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_customer");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.rental)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_inventory");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.rental)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_staff");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_address_id");

                entity.HasIndex(e => e.StoreId)
                    .HasName("idx_fk_store_id");

                entity.Property(e => e.StaffId).ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasDefaultValueSql("'1'");

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_address");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_store");
            });

            modelBuilder.Entity<store>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("idx_fk_address_id");

                entity.HasIndex(e => e.ManagerStaffId)
                    .HasName("idx_unique_manager")
                    .IsUnique();

                entity.Property(e => e.StoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdate).HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.store)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_address");

                entity.HasOne(d => d.ManagerStaff)
                    .WithOne(p => p.store)
                    .HasForeignKey<store>(d => d.ManagerStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_staff");
            });
        }
    }
}
