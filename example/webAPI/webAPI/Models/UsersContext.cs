using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne<UserDetail>(b => b.UserDetail)
                .WithOne(ad => ad.Users)
              .HasForeignKey<UserDetail>(ad => ad.UserId);

            modelBuilder.Entity<Users>().HasData(new Users
            {
                ID = 1,
                UserName = "Bobun",
                Name = "Uncle",
                Surname = "Bob",
                IsDeleted = false

            }, new Users

            {

                ID = 2,
                UserName = "Janki",
                Name = "Jan",
                Surname = "Kirsten",
                IsDeleted = false

            });




        }
    }
}

