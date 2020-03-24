using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AFEService.Models
{
    public partial class familyessentialsContext : DbContext
    {
        public familyessentialsContext()
        {
        }

        public familyessentialsContext(DbContextOptions<familyessentialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<EssentialItem> EssentialItem { get; set; }
        public virtual DbSet<ItemCategoryFilter> ItemCategoryFilter { get; set; }
        public virtual DbSet<LuAmazonCategory> LuAmazonCategory { get; set; }
        public virtual DbSet<LuSearchFilter> LuSearchFilter { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileItem> ProfileItem { get; set; }
        public virtual DbSet<ProfileItemIgnoreProduct> ProfileItemIgnoreProduct { get; set; }
        public virtual DbSet<ProfileNotification> ProfileNotification { get; set; }
        public virtual DbSet<ProfileSearchHistory> ProfileSearchHistory { get; set; }
        public virtual DbSet<SearchHistoryFilterState> SearchHistoryFilterState { get; set; }
        public virtual DbSet<ShelterInPlaceTemplate> ShelterInPlaceTemplate { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<VwEssentialItems> VwEssentialItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("{YOUR DB CONTEXT}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Template");
            });

            modelBuilder.Entity<EssentialItem>(entity =>
            {
                entity.Property(e => e.EssentialItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SearchText).HasMaxLength(1000);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EssentialItem)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EssentialItem_Category");
            });

            modelBuilder.Entity<ItemCategoryFilter>(entity =>
            {
                entity.HasOne(d => d.AmazonCategory)
                    .WithMany(p => p.ItemCategoryFilter)
                    .HasForeignKey(d => d.AmazonCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemCategoryFilter_lu_AmazonCategory");

                entity.HasOne(d => d.EssentialItem)
                    .WithMany(p => p.ItemCategoryFilter)
                    .HasForeignKey(d => d.EssentialItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemCategoryFilter_EssentialItem");
            });

            modelBuilder.Entity<LuAmazonCategory>(entity =>
            {
                entity.HasKey(e => e.AmazonCategoryId)
                    .HasName("PK_lu_AmazonCategories");

                entity.ToTable("lu_AmazonCategory");

                entity.Property(e => e.CategoryNodeId).HasColumnName("CategoryNodeID");

                entity.Property(e => e.InventoryTemplateName).HasColumnName("Inventory_Template_Name");
            });

            modelBuilder.Entity<LuSearchFilter>(entity =>
            {
                entity.HasKey(e => e.SearchFilterId);

                entity.ToTable("lu_SearchFilter");

                entity.Property(e => e.SearchFilter)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProfileGuid)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProfileItem>(entity =>
            {
                entity.Property(e => e.DtNeededBy)
                    .HasColumnName("dtNeededBy")
                    .HasColumnType("date");

                entity.Property(e => e.SearchTextOverride).HasMaxLength(1024);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.ProfileItem)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileItem_Profile");
            });

            modelBuilder.Entity<ProfileItemIgnoreProduct>(entity =>
            {
                entity.Property(e => e.AmazonProductId).HasMaxLength(100);

                entity.HasOne(d => d.ProfileItem)
                    .WithMany(p => p.ProfileItemIgnoreProduct)
                    .HasForeignKey(d => d.ProfileItemId)
                    .HasConstraintName("FK_ProfileItemIgnoreProduct_ProfileItem");
            });

            modelBuilder.Entity<ProfileNotification>(entity =>
            {
                entity.Property(e => e.DtLastSearch)
                    .HasColumnName("dtLastSearch")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtNotificationSent)
                    .HasColumnName("dtNotificationSent")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtSearchResultsFound).HasColumnName("dtSearchResultsFound");

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ProfileSearchHistory)
                    .WithMany(p => p.ProfileNotification)
                    .HasForeignKey(d => d.ProfileSearchHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileNotification_ProfileSearchHistory");
            });

            modelBuilder.Entity<ProfileSearchHistory>(entity =>
            {
                entity.Property(e => e.CategoryScopeFilterOverrided)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SearchDateTimeUtc).HasColumnName("SearchDateTimeUTC");

                entity.Property(e => e.SearchText)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.HasOne(d => d.EssentialItem)
                    .WithMany(p => p.ProfileSearchHistory)
                    .HasForeignKey(d => d.EssentialItemId)
                    .HasConstraintName("FK_ProfileSearchHistory_EssentialItem");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.ProfileSearchHistory)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileSearchHistory_Profile");
            });

            modelBuilder.Entity<SearchHistoryFilterState>(entity =>
            {
                entity.HasOne(d => d.ProfileSearchHistory)
                    .WithMany(p => p.SearchHistoryFilterState)
                    .HasForeignKey(d => d.ProfileSearchHistoryId)
                    .HasConstraintName("FK_SearchHistoryFilterState_ProfileSearchHistory1");

                entity.HasOne(d => d.SearchFilter)
                    .WithMany(p => p.SearchHistoryFilterState)
                    .HasForeignKey(d => d.SearchFilterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SearchHistoryFilterState_lu_SearchFilter");
            });

            modelBuilder.Entity<ShelterInPlaceTemplate>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Category).HasMaxLength(1024);

                entity.Property(e => e.EssentialItem).HasMaxLength(1024);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VwEssentialItems>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EssentialItems");

                entity.Property(e => e.AmazonCategories)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EssentialItemName).HasMaxLength(100);

                entity.Property(e => e.SearchText).HasMaxLength(1000);

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
