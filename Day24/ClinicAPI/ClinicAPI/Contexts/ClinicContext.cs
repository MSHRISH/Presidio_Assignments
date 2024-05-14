using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class ClinicContext:DbContext
    {
        public ClinicContext(DbContextOptions options):base(options) { }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() {Id=100,Name="Shrish",Experience=5,Speciality="ENT" },
                new Doctor() { Id = 101, Name = "Naresh", Experience = 5, Speciality = "ENT" },
                new Doctor() { Id = 102, Name = "Raghul", Experience = 5, Speciality = "Heart" },
                new Doctor() { Id = 103, Name = "Revs", Experience = 5, Speciality = "Heart" },
                new Doctor() { Id = 104, Name = "Raks", Experience = 5, Speciality = "Bone" }
                );
        }
    }
}
