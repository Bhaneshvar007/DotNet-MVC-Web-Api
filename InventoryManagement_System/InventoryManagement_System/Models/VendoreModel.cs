namespace InventoryManagement_System.Models
{
    public class VendoreModel
    {
        public int v_id { get; set; }
        public string vendor_name { get; set; }
        public string vendor_email { get; set; }
        public string vendor_address { get; set; }
        public DateTime date_of_sale { get; set; }
        public int quantity { get; set; } //stock
        public decimal billing_amount { get; set; }
        public ProductModel ProductModel { get; set; }
        public CetegoryModel CetegoryModel { get; set; }
                
    }
}
