namespace Infrastructure.Models
{
    public class ResourceModel
    {
        public string Id { get; set; }
         public bool IsDeleted { get; set; }
        public string PathName { get; set; }
        public string ProductId { get; set; }
        //public virtual ProductModel Product { get; set; }
    }
}
