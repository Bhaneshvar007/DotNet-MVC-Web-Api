namespace InventoryManagement_System.Models
{
    public class CustomerModel
    {


        public int cust_id { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }

        public string customer_address { get; set; }
        public string product_name { get; set; }
        public string cetegory_type { get; set; }
        public DateTime date_of_sale { get; set; }
        public int quantity { get; set; }
        public decimal  billing_amount { get; set; }
      
    }
}
