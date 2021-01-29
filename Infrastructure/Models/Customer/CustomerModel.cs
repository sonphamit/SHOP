namespace Infrastructure.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            ApplicationUser = new ApplicationUserModel();
        }
        public string Id { get; set; }
        public virtual ApplicationUserModel ApplicationUser { get; set; }
    }
}
