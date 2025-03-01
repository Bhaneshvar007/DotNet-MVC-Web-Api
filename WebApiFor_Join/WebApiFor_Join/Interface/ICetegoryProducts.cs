using WebApiFor_Join.Models;

namespace WebApiFor_Join.Interface
{
    public interface ICetegoryProducts
    {
        Task<List<Products>> GetProductsAsync();
    }
}
