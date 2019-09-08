using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ToDoList>()
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();
            //modelBuilder.Entity<ToDoListItem>()
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();
        }

        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<ToDoListItem> ToDoListItem { get; set; }
    }
}
