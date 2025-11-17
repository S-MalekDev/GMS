using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(tb => tb.HasTrigger("Trg_Users_SoftDelete"));
            modelBuilder.Entity<Employee>().ToTable(tb => tb.HasTrigger("Trg_Employees_SoftDelete"));
            modelBuilder.Entity<Trainer>().ToTable(tb => tb.HasTrigger("Trg_Trainers_SoftDelete"));
            modelBuilder.Entity<Member>().ToTable(tb => tb.HasTrigger("Trg_Members_SoftDelete"));
            modelBuilder.Entity<Subscription>().ToTable(tb => tb.HasTrigger("Trg_Subscriptions_InsteadOfUpdate"));

        }

        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionDetail> SubscriptionDetails { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<SubscriptionOffer> SubscriptionOffers { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }


    }
}
