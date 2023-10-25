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
                new Patient { PatientId = 1, UserName = "Patient-P-Hansen", Name="Peter Hansen", BirthDay = new DateTime(1959, 1, 22) },
                new Patient { PatientId = 2, UserName = "Patient-O-Jensen", Name="Ole Jensen", BirthDay = new DateTime(1976, 5, 11) }
                );
            modelBuilder.Entity<GP>().HasData(

                new GP { GPId = 1, UserName ="Læge-B-Ordrup", License="AB3532Z", Name ="Børge Ordrup"},
                new GP { GPId = 2, UserName ="Læge-K-Spellenberg", License="ZZ9922B", Name="Klaus Spellenberg"}
             );

            modelBuilder.Entity<Appointment>().HasData(

                new Appointment { AppointmentId=1, GPId=1, PatientId=2, AppointmentTime = new DateTime(2023, 11,11,9,0,0), Category=Category.Samtale, AppointmentMessage = "Jævnligt meget ondt i hovedet" },
                 new Appointment { AppointmentId=2, GPId = 1, PatientId = 1, AppointmentTime = new DateTime(2023, 11, 11, 9, 30, 0), Category = Category.Samtale, AppointmentMessage = "Smerter i lysken når jeg bukker mig ned, venstre side" },
                 new Appointment { AppointmentId = 3, GPId = 2, PatientId = 2, AppointmentTime = new DateTime(2023, 11, 1, 12, 30, 0), Category = Category.Blodprøve, AppointmentMessage = "" }
              );
            modelBuilder.Entity<EConsultation>().HasData(

               new EConsultation { EConsultationId = 1, GPId = 1, PatientId = 2, Question="Kan du se om der kommet svar fra Riget?" , QuestionTime=new DateTime(2023,7,7, 15,0,0) },
               new EConsultation { EConsultationId = 2, GPId = 2, PatientId = 1, Question = "Jeg har meget ondt i min venstre skulder efter et uheld på job - kan jeg evt få recept eller skal du se mig først?", QuestionTime = new DateTime(2023, 7, 6, 11, 30, 0) },
               new EConsultation { EConsultationId = 3, GPId = 2, PatientId = 2, Question = "Min høfeber er helt enorm lige nu - måske skal jeg op i dosis?", QuestionTime = new DateTime(2023, 9 , 21, 12, 30, 0) },
                new EConsultation { EConsultationId = 4, GPId = 2, PatientId = 2, Question = "Jeg har meget svært ved at komme op af sengen om mandagen - kan man gøre noget?", QuestionTime = new DateTime(2023, 10, 11), Answer="Det er helt normalt - ikke så meget vi kan gøre her fra. Det skal løbes væk", AnswerTime=new DateTime(2023,10,11, 13,30,0) }
             );
        }
    }
}
