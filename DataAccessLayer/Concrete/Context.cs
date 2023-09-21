using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;database=CoreDemo;user=admin_coredb;password=_58vk0J0r;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("server = DESKTOP-28FHEV5; database = CoreDemo; integrated security = true; Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Message>()
            //    .HasOne(x => x.MessageSender)
            //    .WithMany(y => y.WriterSender)
            //    .HasForeignKey(z => z.MessageSenderID)
            //    .OnDelete(DeleteBehavior.ClientSetNull);


            //modelBuilder.Entity<Message2>()
            //    .HasOne(x => x.ReceiverUser)
            //    .WithMany(y => y.WriterReceiver)
            //    .HasForeignKey(z => z.MessageReceiverID)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> BLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
