namespace DoktormandenDk.Models
{
    // Interface for our demo users. 
    // Both Patient and GP (General Practitioners)
    // implements this. (Requires UserName)
    // Only meant for demo usage to simulate different user profiles logged in

    public interface IUser
    {
        public string UserName { get; set; }
    }
}
