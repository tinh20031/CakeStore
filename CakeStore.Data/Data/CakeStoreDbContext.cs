using CakeStore.Data.Entities;
using CakeStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CakeStoreAPI.Data
{
    public class CakeStoreDbContext : DbContext
    {
        public CakeStoreDbContext(DbContextOptions<CakeStoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<PromotionProducts> PromotionProducts { get; set; }
        public DbSet<PromotionHistory> PromotionHistories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User – Orders (1–N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User – Cart (1–1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cart – CartItems (1–N)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // Products – OrderDetails (1–N)
            modelBuilder.Entity<Products>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category – Products (1–N)
            modelBuilder.Entity<Category>()
                .HasMany<Products>()
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Promotions – PromotionProducts (1–N)
            modelBuilder.Entity<PromotionProducts>()
                .HasOne(pp => pp.Promotion)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.PromotionId);

            modelBuilder.Entity<PromotionProducts>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.ProductId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Bánh Kem", Description = "Các loại bánh kem sinh nhật, tiệc cưới" },
                new Category { CategoryId = 2, Name = "Bánh Ngọt", Description = "Bánh ngọt, cupcake, tiramisu" },
                new Category { CategoryId = 3, Name = "Bánh Mì", Description = "Bánh mì tươi và sandwich" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { ProductId = 1, Name = "Bánh Kem Socola", Description = "Bánh kem phủ socola hảo hạng", Price = 250000, StockQuantity = 10, ImageUrl = "banh-kem-socola.jpg", CategoryId = 1, Available = true },
                new Products { ProductId = 2, Name = "Bánh Kem Dâu Tây", Description = "Bánh kem trang trí dâu tây tươi", Price = 280000, StockQuantity = 8, ImageUrl = "banh-kem-dau.jpg", CategoryId = 1, Available = true },
                new Products { ProductId = 3, Name = "Bánh Tiramisu", Description = "Bánh tiramisu hương vị Ý", Price = 120000, StockQuantity = 15, ImageUrl = "tiramisu.jpg", CategoryId = 2, Available = true },
                new Products { ProductId = 4, Name = "Cupcake Vani", Description = "Cupcake nhỏ gọn hương vani", Price = 35000, StockQuantity = 30, ImageUrl = "cupcake-vani.jpg", CategoryId = 2, Available = true },
                new Products { ProductId = 5, Name = "Bánh Mì Baguette", Description = "Bánh mì baguette giòn thơm", Price = 20000, StockQuantity = 50, ImageUrl = "baguette.jpg", CategoryId = 3, Available = true },
                new Products { ProductId = 6, Name = "Bánh Mì Sandwich", Description = "Bánh mì sandwich mềm xốp", Price = 25000, StockQuantity = 40, ImageUrl = "sandwich.jpg", CategoryId = 3, Available = true }
            );

            modelBuilder.Entity<Promotions>().HasData(
                new Promotions { PromotionId = 1, Name = "Khuyến Mãi Hè", Description = "Giảm 10% cho bánh kem", DiscountPercentage = 10, Code = "HE10", StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)) }
            );

            modelBuilder.Entity<PromotionProducts>().HasData(
                new PromotionProducts { PromotionProductsId = 1, PromotionId = 1, ProductId = 1 },
                new PromotionProducts { PromotionProductsId = 2, PromotionId = 1, ProductId = 2 }
            );
        }
    }
}
