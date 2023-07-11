using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using scada.Models;
using System.Reflection.Metadata;

namespace scada.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
    
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<AlarmActivation> AlarmActivations { get; set; }
        public DbSet<AnalogInput> AnalogInputs { get; set; }
        public DbSet<AnalogOutput> AnalogOutputs { get; set; }
        public DbSet<DigitalInput> DigitalInputs { get; set; }
        public DbSet<DigitalOutput> DigitalOutputs { get; set; }
        public DbSet<PastTagValues> PastTagValues { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<AnalogInput>()
            .HasMany(e => e.Alarms)
            .WithOne(e => e.analogInput)
            .HasForeignKey(e => e.analogId);

            //modelBuilder.Entity<Alarm>().HasOne(ai => ai.analogInput).WithMany(a => a.Alarms);



            modelBuilder.Entity<PastTagValues>()
               .HasKey(a => a.Id);
            modelBuilder.Entity<PastTagValues>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PastTagValues>()
        .HasOne(p => p.tag)
        .WithMany()
        .HasForeignKey(p => p.tagId)
        .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Alarm>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<Alarm>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AlarmActivation>()
               .HasKey(a => a.Id);
            modelBuilder.Entity<AlarmActivation>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<AlarmActivation>()
            .HasOne(p => p.alarm)
            .WithMany()
            .HasForeignKey(p => p.alarmId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tag>()
               .HasKey(t => t.id);

            modelBuilder.Entity<AnalogInput>()
                .HasBaseType<Tag>();

            

        }


    }
}
