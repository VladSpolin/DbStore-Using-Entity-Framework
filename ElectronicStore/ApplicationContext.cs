using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ElectronicStore
{
    class ApplicationContext: DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<ShopAssistant> ShopAssistants { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductInStock> ProductsInStock { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public ApplicationContext()
        {
           Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasData(new Store { Id = 1, Name = "Electronics Store", Destination = "Minsk, Belarus" });
            modelBuilder.Entity<Personnel>().HasData(new Personnel[]{
            new Personnel{Name="Alex", Age=22, Salary=1200, Id=1,StoreId=1, },
            new Personnel{Name="Vlad", Age=20, Salary=1100, Id=2,StoreId=1, },
            new Personnel{Name="Sofia", Age=31, Salary=1000, Id=3, StoreId = 1, },
            new Personnel{Name="Andrey", Age=28, Salary=1300, Id=4, StoreId = 1, },
            });
            modelBuilder.Entity<Manager>().HasData(new Manager { Id = 8, Name = "John", Age = 45, StoreId = 1, Salary = 2000, Departament = "IT" });
            modelBuilder.Entity<DeliveryMan>().HasData(new DeliveryMan[]{
            new DeliveryMan {Id = 6, Name ="Maksim", Age=18, Salary=800, StoreId = 1, IsDeliveringNow=true },
            new DeliveryMan {Id = 7, Name ="Igor", Age=18, Salary=800, StoreId = 1, IsDeliveringNow=false },
            });
            modelBuilder.Entity<Client>().Property(p => p.Number).HasMaxLength(12);
            modelBuilder.Entity<Client>().HasData(new Client[] {
            new Client{Id=1, Name="Mikhail",Number=375293232333},
            new Client{Id=2, Name="Pavel",Number=375293232324},
            });


            modelBuilder.Entity<Producer>().HasData(new Producer[] {
            new Producer{Id=1, Name="Intel"},
            new Producer{Id=2, Name="Nvidia"},
            new Producer{Id=3, Name="Kingston"},
            new Producer{Id=4, Name="AMD"},
            });

            var first = new Provider { Id = 1, Name = "Asbis", Number = 375291111111, };
            var second = new Provider { Id = 2, Name = "Kosmotech", };
            var third = new Provider { Id = 3, Name = "IrsenGroup", };
            modelBuilder.Entity<Provider>().Property(p => p.Number).HasMaxLength(12);
            modelBuilder.Entity<Provider>().HasData(new Provider[] { first, second, third, });

            modelBuilder.Entity<Product>().HasData(new Product[] {
            new Product{Id=1, Name="GeForce GTX 1050Ti", ProducerId = 2, ProductCategoryId=1, ProviderId=1},
            new Product{Id=2, Name="I5 8300h", ProducerId = 1, ProductCategoryId=2, ProviderId=2},
            new Product{Id=3, Name="I7 8700k", ProducerId = 1, ProductCategoryId=2, ProviderId=3},
            new Product{Id=4, Name="Ryzen5 5600x", ProducerId = 4, ProductCategoryId=2, ProviderId=1},
            new Product{Id=5, Name="GeForce RTX 3050 Ti ", ProducerId = 2, ProductCategoryId=1, ProviderId=2},
            new Product{Id=6, Name="DDR4 KF432C16BBK2/16", ProducerId = 3, ProductCategoryId=3, ProviderId=3},
            new Product{Id=7, Name="DDR4 KVR32S22S8/8", ProducerId = 3, ProductCategoryId=3, ProviderId=1},
            });


            var VideoCard = new ProductCategory { Name = "Video Graphic Card", Id = 1, };
            var CPU = new ProductCategory { Name = "CPU", Id = 2, };
            var RAM = new ProductCategory { Name = "RAM", Id = 3, };
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory[] { VideoCard, CPU, RAM, });

            //===============================================================================================================

            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, ClientId = 1, ProductId = 1, ShopAssistantId = 5, Date = new DateTime(2022, 07, 20), Adress = "IPD,20, Pinsk, Brest region, Belarus" });
            modelBuilder.Entity<ShopAssistant>().HasData(new ShopAssistant { Id = 5, Name = "Kate", Age = 36, Salary = 1400, StoreId = 1 });

            modelBuilder.Entity<Supply>().HasData(new Supply[]{
            new Supply {Id=1, Amount=10, ProviderId=1, Date=new DateTime(2022,08,08)},
            new Supply {Id=2, Amount=15, ProviderId=2, Date=new DateTime(2022,09,09)},
            new Supply {Id=3, Amount=20, ProviderId=3, Date=new DateTime(2022,10,10)},
            });


            modelBuilder.Entity<Delivery>().HasData(new Delivery { Id = 1, DeliveryManId = 6, OrderId = 1, Date = new DateTime(2022, 07, 21) });


            modelBuilder.Entity<Review>().HasData(new Review { Id = 1, ClientId = 1, DeliveryId = 1, Comment = "Cool!" });


            modelBuilder.Entity<ProductInStock>().HasData(new ProductInStock[]{
            new ProductInStock {ProductId=1,Id=1, Amount=10 },
            new ProductInStock {ProductId=2,Id=2, Amount=12 },
            new ProductInStock {ProductId=3,Id=3, Amount=20 },
            new ProductInStock {ProductId=4, Id = 4, Amount=25 },
            new ProductInStock {ProductId=5, Id = 5, Amount=15 },
            new ProductInStock {ProductId=6, Id = 6, Amount=8 },
            new ProductInStock {ProductId=7, Id = 7, Amount=17 },
            });
        }

    }
}
