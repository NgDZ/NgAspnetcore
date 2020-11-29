using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Northwind
{
    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCustomerDemographic> CustomerCustomerDemographics { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=Northwind.db;Cache=Shared");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Category");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("categoryName");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Picture).HasColumnName("picture");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Customer");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.Address)
                    .HasColumnType("VARCHAR(60)")
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("companyName");

                entity.Property(e => e.ContactName)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("contactName");

                entity.Property(e => e.ContactTitle)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("contactTitle");

                entity.Property(e => e.Country)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasColumnType("VARCHAR(225)")
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("fax");

                entity.Property(e => e.Mobile)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("mobile");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("postalCode");

                entity.Property(e => e.Region)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("region");
            });

            modelBuilder.Entity<CustomerCustomerDemographic>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.HasIndex(e => new { e.CustomerId, e.CustomerTypeId }, "IDX_CustomerId_CustomerTypeId")
                    .IsUnique();

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("customerId");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnType("INT")
                    .HasColumnName("customerTypeId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerDemographics)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.CustomerCustomerDemographics)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CustomerDemographic>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CustomerDesc).HasColumnName("customerDesc");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Employee");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.Address)
                    .HasColumnType("VARCHAR(60)")
                    .HasColumnName("address");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("birthDate");

                entity.Property(e => e.City)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasColumnType("VARCHAR(225)")
                    .HasColumnName("email");

                entity.Property(e => e.Extension)
                    .HasColumnType("VARCHAR(4)")
                    .HasColumnName("extension");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("firstname");

                entity.Property(e => e.HireDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("hireDate");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("lastname");

                entity.Property(e => e.MgrId)
                    .HasColumnType("INT")
                    .HasColumnName("mgrId");

                entity.Property(e => e.Mobile)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("mobile");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("phone");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.PhotoPath)
                    .HasColumnType("VARCHAR(255)")
                    .HasColumnName("photoPath");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("postalCode");

                entity.Property(e => e.Region)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("region");

                entity.Property(e => e.Title)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("title");

                entity.Property(e => e.TitleOfCourtesy)
                    .HasColumnType("VARCHAR(25)")
                    .HasColumnName("titleOfCourtesy");
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("EmployeeTerritory");

                entity.HasIndex(e => new { e.EmployeeId, e.TerritoryCode }, "IDX_EmployeeId_TerritoryCode")
                    .IsUnique();

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("INT")
                    .HasColumnName("employeeId");

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("territoryCode");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TerritoryCodeNavigation)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasPrincipalKey(p => p.TerritoryCode)
                    .HasForeignKey(d => d.TerritoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("OrderDetail");

                entity.HasIndex(e => new { e.OrderId, e.ProductId }, "IDX_OrderId_ProductId")
                    .IsUnique();

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.Discount)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.OrderId)
                    .HasColumnType("INT")
                    .HasColumnName("orderId");

                entity.Property(e => e.ProductId)
                    .HasColumnType("INT")
                    .HasColumnName("productId");

                entity.Property(e => e.Quantity)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("quantity");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10, 2)")
                    .HasColumnName("unitPrice");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Product");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("INT")
                    .HasColumnName("categoryId");

                entity.Property(e => e.Discontinued)
                    .IsRequired()
                    .HasColumnType("CHAR(1)")
                    .HasColumnName("discontinued");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("productName");

                entity.Property(e => e.QuantityPerUnit)
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("quantityPerUnit");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("reorderLevel");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("INT")
                    .HasColumnName("supplierId");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("DECIMAL(10, 2)")
                    .HasColumnName("unitPrice");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("unitsInStock");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("SMALLINT")
                    .HasColumnName("unitsOnOrder");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Region");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.Regiondescription)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("regiondescription");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("SalesOrder");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("customerId");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("INT")
                    .HasColumnName("employeeId");

                entity.Property(e => e.Freight)
                    .HasColumnType("DECIMAL(10, 2)")
                    .HasColumnName("freight");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("orderDate");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("requiredDate");

                entity.Property(e => e.ShipAddress)
                    .HasColumnType("VARCHAR(60)")
                    .HasColumnName("shipAddress");

                entity.Property(e => e.ShipCity)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("shipCity");

                entity.Property(e => e.ShipCountry)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("shipCountry");

                entity.Property(e => e.ShipName)
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("shipName");

                entity.Property(e => e.ShipPostalCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("shipPostalCode");

                entity.Property(e => e.ShipRegion)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("shipRegion");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("shippedDate");

                entity.Property(e => e.ShipperId)
                    .HasColumnType("INT")
                    .HasColumnName("shipperId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.ShipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Shipper");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("companyName");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(44)")
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Supplier");

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.Address)
                    .HasColumnType("VARCHAR(60)")
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasColumnName("companyName");

                entity.Property(e => e.ContactName)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("contactName");

                entity.Property(e => e.ContactTitle)
                    .HasColumnType("VARCHAR(30)")
                    .HasColumnName("contactTitle");

                entity.Property(e => e.Country)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasColumnType("VARCHAR(225)")
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("fax");

                entity.Property(e => e.Phone)
                    .HasColumnType("VARCHAR(24)")
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("VARCHAR(10)")
                    .HasColumnName("postalCode");

                entity.Property(e => e.Region)
                    .HasColumnType("VARCHAR(15)")
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("Territory");

                entity.HasIndex(e => new { e.TerritoryCode, e.RegionId }, "IDX_TerritoryCode_RegionId")
                    .IsUnique();

                entity.HasIndex(e => e.TerritoryCode, "IDX_TerrytoryCode")
                    .IsUnique();

                entity.Property(e => e.EntityId)
                    .HasColumnType("INT AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("entityId");

                entity.Property(e => e.RegionId)
                    .HasColumnType("INT")
                    .HasColumnName("regionId");

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)")
                    .HasColumnName("territoryCode");

                entity.Property(e => e.Territorydescription)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("territorydescription");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
