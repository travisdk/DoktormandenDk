namespace DoktormandenDk.Models.ViewModels

{
    public class UserVM
    {
        public IEnumerable<IUser> DemoUsers { get; set; }
        public IUser? CurrentUser { get; set; }
    }
}
