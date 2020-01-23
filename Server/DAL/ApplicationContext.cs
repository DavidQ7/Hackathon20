using Common.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> Users { set; get; }
        public DbSet<Game> Games { set; get; }
        public DbSet<Attempt> Attempts { set; get; }
    }
}
