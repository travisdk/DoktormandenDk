using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<GP> GPs { get; set; }  
        public DbSet<EConsultation> EConsultations { get; set; }
     

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, UserName = "Patient A", Name="Peter Hansen", BirthDay = new DateTime(1959, 1, 22) },
                new Patient { PatientId = 2, UserName = "Patient B", Name="Ole Jensen", BirthDay = new DateTime(1976, 5, 11) }
                );
            modelBuilder.Entity<GP>().HasData(

                new GP { GPId = 1, UserName ="Læge 1", License="AB3532Z", Name ="Børge Ordrup"},
                new GP { GPId = 2, UserName ="Læge 2", License="ZZ9922B", Name="Klaus Spellenberg"}
             );

            modelBuilder.Entity<Appointment>().HasData(

                new Appointment { AppointmentId=1, GPId=1, PatientId=2, AppointmentTime = new DateTime(2023, 11,11,9,0,0), Category=Category.Samtale, AppointmentMessage = "Hul i hovedet" },
                 new Appointment { AppointmentId=2, GPId = 1, PatientId = 1, AppointmentTime = new DateTime(2023, 11, 11, 9, 30, 0), Category = Category.Samtale, AppointmentMessage = "Smerter i lysken når jeg bukker mig ned, venstre side" },
                 new Appointment { AppointmentId = 3, GPId = 2, PatientId = 2, AppointmentTime = new DateTime(2023, 11, 1, 12, 30, 0), Category = Category.Blodprøve, AppointmentMessage = "" }
              );

        }
    }
}
