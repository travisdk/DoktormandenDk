namespace DoktormandenDk.Models
{
    public class CreateAppointmentViewModel
    {
        public Appointment Appointment { get; set; }    
        public  List<DateTime> AvailableTimes { get; set; } // populated when user changes GP in form
    }
}
