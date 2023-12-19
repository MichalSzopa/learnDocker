namespace TodoApi.Database;

using Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("Data Source=databaza.db");
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Project> Projects { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<TodoTask> TodoTasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
			{
				entity.ToTable("Project");
			});

			modelBuilder.Entity<Category>(entity =>
			{
				entity.ToTable("Category");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("User");
			});

			modelBuilder.Entity<TodoTask>(entity =>
			{
				entity.ToTable("TodoTask");
			});
		}
	}