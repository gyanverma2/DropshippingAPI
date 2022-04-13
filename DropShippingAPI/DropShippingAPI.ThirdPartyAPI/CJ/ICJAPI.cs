using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingAPI.ThirdPartyAPI.CJ
{
    public interface ICJAPI
    {
        Task<Category> GetCategoryAsync(Pagination p);
        Task<Product> GetProductByCategoryAsync(ProductRequest p);
        Task<ProductDetails> GetProductDetailsAsync(string pId);
    }
}
