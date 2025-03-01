using InventoryManagement_System.Models;

namespace InventoryManagement_System.Interface
{
    public interface IVendor
    {
        Task<List<VendoreModel>> GetVendorAsync();
        Task<string> InsertVendorAsync(VendoreModel vendor);
    }
}
