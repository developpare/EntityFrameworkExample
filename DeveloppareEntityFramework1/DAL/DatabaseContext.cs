using Microsoft.EntityFrameworkCore;

namespace DeveloppareEntityFramework.DAL;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "IX_Categories_CategoryName").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("TEXT (255)");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasIndex(e => e.ColorName, "IX_Colors_ColorName").IsUnique();

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName).HasColumnType("TEXT (255)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ProductName).HasColumnType("TEXT (255)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Color).WithMany(p => p.Products).HasForeignKey(d => d.ColorId);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ProductId });

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasIndex(e => e.WarehouseName, "IX_Warehouses_WarehouseName").IsUnique();

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.WarehouseName).HasColumnType("TEXT (255)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
