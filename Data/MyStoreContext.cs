using System;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.Data
{
    public class MyStoreContext : DbContext
    {
        public MyStoreContext(DbContextOptions<MyStoreContext> options
            ) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<TimeSheet> TimeSheets { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuItem> Items { get; set; }
    }
}
