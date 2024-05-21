using Microsoft.EntityFrameworkCore;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1.Context
{
    public class MacAssignmentContext : DbContext
    {
        public MacAssignmentContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Humans> Humans { get; set; }
        public DbSet<Pets> Pets { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pets>().HasKey(x => x.id); // Assuming Id is the primary key
            modelBuilder.Entity<Pets>().Property(b => b.timestamp)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("current_timestamp()");
            modelBuilder.Entity<Pets>().Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValue("unknown");

            modelBuilder.Entity<Humans>().HasKey(x => x.human_id); // Assuming HumanId is the primary key
            modelBuilder.Entity<Humans>().Property(b => b.name)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValue("unknown");
                
            modelBuilder.Entity<Humans>().Property(b => b.responsibilities)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValue("Parent");
                
        }
    }
}