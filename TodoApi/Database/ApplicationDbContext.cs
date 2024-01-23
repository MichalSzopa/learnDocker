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

			entity.HasOne(p => p.Category)
				  .WithMany(c => c.Projects)
				  .HasForeignKey(p => p.CategoryId);

			entity.HasOne(p => p.User)
				  .WithMany(u => u.Projects)
				  .HasForeignKey(p => p.UserId);
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.ToTable("Category");

			entity.HasOne(c => c.User)
				  .WithMany(u => u.Categories)
				  .HasForeignKey(c => c.UserId);

		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("User");
		});

		modelBuilder.Entity<TodoTask>(entity =>
		{
			entity.ToTable("TodoTask");

			entity.HasOne(t => t.Category)
				  .WithMany(c => c.TodoTasks)
				  .HasForeignKey(t => t.CategoryId);

			entity.HasOne(t => t.User)
				  .WithMany(u => u.TodoTasks)
				  .HasForeignKey(t => t.UserId);

			entity.HasOne(t => t.Project)
				  .WithMany(p => p.TodoTasks)
				  .HasForeignKey(t => t.ProjectId);

			entity.HasOne(t => t.ParentTask)
				  .WithMany(p => p.ChildTasks)
				  .HasForeignKey(t => t.ParentId);
		});
	}
}
