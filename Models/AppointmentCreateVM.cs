using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoktormandenDk.Models
{
    public class AppointmentCreateVM
    {
        public Appointment Appointment { get; set; }
        public SelectList AvailableTimes { get; set; }    
    }
}
