using InventoryManagement_System.Interface;

namespace InventoryManagement_System.Models
{
    public class ProductModel
    {
     
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductBrand { get; set; }
        public CetegoryModel CetegoryModel { get; set; }


    }
}
