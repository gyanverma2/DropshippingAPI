using DropShippingAPI.Manager.Interface;
using DropShippingAPI.ThirdPartyAPI.CJ;
using DropShippingAPI.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingAPI.Manager.Impl
{
    public class ShoppingManager : IShoppingManager
    {
        private readonly ICJAPI CJ_API = null;
        public ShoppingManager(ICJAPI cjAPI)
        {
            CJ_API = cjAPI;
        }
        public async Task<APIResponse> GetCategoryListAsync(string apiName,int page, int pageSize)
        {
            switch (apiName)
            {
                case "cj":
                    var result = await CJ_API.GetCategoryAsync(new Pagination() { pageNum = page, pageSize = pageSize });
                    if(result!=null && result.code && result.data != null)
                    {
                        return new APIResponse(ResponseCode.SUCCESS, "Record Found", result);
                    }
                    break;
            }
            return new APIResponse(ResponseCode.ERROR, "Record Not Found");
        }

        public async Task<APIResponse> GetProductByCategoryAsync(string apiName,string categoryId, int page, int pageSize)
        {
            switch (apiName)
            {
                case "cj":
                    var result = await CJ_API.GetProductByCategoryAsync(new ProductRequest() {categoryId=categoryId, pageNum = page, pageSize = pageSize });
                    if (result != null && result.code && result.data != null)
                    {
                        return new APIResponse(ResponseCode.SUCCESS, "Record Found", result);
                    }
                    break;
            }
            return new APIResponse(ResponseCode.ERROR, "Record Not Found");
        }

        public async Task<APIResponse> GetProductDetailsAsync(string apiName, string productId)
        {
            switch (apiName)
            {
                case "cj":
                    var result = await CJ_API.GetProductDetailsAsync(productId);
                    if (result != null && result.code && result.data != null)
                    {
                        return new APIResponse(ResponseCode.SUCCESS, "Record Found", result);
                    }
                    break;
            }
            return new APIResponse(ResponseCode.ERROR, "Record Not Found");
        }
    }
}
