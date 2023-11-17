using Microsoft.EntityFrameworkCore;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Category>().HasData(
                new Entities.Category
                {
                    Id = 1,
                    Title = "Camera"
                }); 
            modelBuilder.Entity<Entities.Product>().HasData(
                new Entities.Product
                {
                    Id = 1,
                    Title = "CP PLUS 3MP",
                    Price = 1999,
                    Description = "CP PLUS 3MP Full HD Smart Wi-fi CCTV Home Security Camera | 360° View | 2 Way Talk | Cloud Monitor | Motion Detect | Night Vision | Supports SD Card, Alexa & Ok Google | 15 Mtr, White- CP-E31A",
                    ImageUrl = "https://m.media-amazon.com/images/I/31jX+aam1nL._SL1000_.jpg",
                    CategoryId = 1
                });
            modelBuilder.Entity<Entities.Product>().HasData(
                new Entities.Product
                {
                    Id = 2,
                    Title = "Tapo",
                    Price = 2299,
                    Description = "TP-Link Tapo 360° 2MP 1080p Full HD Pan/Tilt Home Security Wi-Fi Smart Camera| Alexa Enabled| 2-Way Audio| Night Vision| Motion Detection| Sound and Light Alarm| Indoor CCTV (Tapo C200) White",
                    ImageUrl = "https://m.media-amazon.com/images/I/41KuE9NipqL._SL1000_.jpg",
                    CategoryId = 1
                });
            modelBuilder.Entity<Entities.Product>().HasData(
                new Entities.Product
                {
                    Id = 3,
                    Title = "FUJIFILM",
                    Price = 6999,
                    Description = "Fujifilm Instax Mini 12 Instant Camera-Pink",
                    ImageUrl = "https://m.media-amazon.com/images/I/61+5Ld-oc1L._SL1500_.jpg",
                    CategoryId = 1
                });
            modelBuilder.Entity<Entities.Product>().HasData(
                new Entities.Product
                {
                    Id = 4,
                    Title = "Travel Camera",
                    Price = 2199,
                    Description = "ROCKTECH® Action Camera for Vlogging, Mountain Biking,Travelling, Scuba Diving,Motor Vlogging (4K @ 30FPS Action Camera)",
                    ImageUrl = "https://m.media-amazon.com/images/I/51Bp3mZIcZL._SX569_.jpg",
                    CategoryId = 1
                });
        }
    }
}
