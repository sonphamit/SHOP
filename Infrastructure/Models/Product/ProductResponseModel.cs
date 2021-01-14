namespace Infrastructure.Models
{
    public class ProductResponseModel : ProductModel
    {
        public ProductResponseModel() : base()
        {
            Category = new CategoryModel();
            Supplier = new SupplierModel();
        }

        public CategoryModel Category { get; set; }
        public SupplierModel Supplier { get; set; }

    }

}
