namespace Shop_Nhi.Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnect : DbContext
    {
        public DBConnect()
            : base("name=DBConnect")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<HelpBuy> HelpBuys { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<HelpBuy>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<HelpBuy>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.typeID);

            modelBuilder.Entity<Notification>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.totalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.productCode)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.productPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.tag)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.code)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.promotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.size)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.createByID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.modifiedByID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Theme>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
