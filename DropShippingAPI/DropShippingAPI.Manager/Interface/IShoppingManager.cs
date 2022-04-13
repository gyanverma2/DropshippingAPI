using DropShippingAPI.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingAPI.Manager.Interface
{
    public interface IShoppingManager
    {
        Task<APIResponse> GetCategoryListAsync(string apiName,int page, int itemsPerPage);
        Task<APIResponse> GetProductByCategoryAsync(string apiName, string categoryId, int page, int pageSize);
        Task<APIResponse> GetProductDetailsAsync(string apiName, string productId);
        
    }
}
