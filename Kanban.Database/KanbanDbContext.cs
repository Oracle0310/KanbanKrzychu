using Kanban.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Database
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<DBUser> Users { get; set; }
        public DbSet<DBItemTask> Tasks { get; set; }
        public DbSet<DBBacklogItem> BacklogItems { get; set; }
        public DbSet<DBSprint> Sprints { get; set; }

        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBSprint>()
                .HasMany(sprint => sprint.BacklogItems)
                .WithOne(backlogItem => backlogItem.Sprint);

            modelBuilder.Entity<DBBacklogItem>()
                .HasMany(backlogItem => backlogItem.Tasks)
                .WithOne(task => task.BacklogItem);

            modelBuilder.Entity<DBItemTask>()
                .HasOne(task => task.User)
                .WithMany(user => user.Tasks);
        }
    }
}
