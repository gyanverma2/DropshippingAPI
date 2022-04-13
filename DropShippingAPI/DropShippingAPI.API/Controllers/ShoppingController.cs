using DropShippingAPI.Manager.Interface;
using DropShippingAPI.Utility;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropShippingAPI.API.Controllers
{
    [ApiController]
    public class ShoppingController : Controller
    {
        ILog log4Net;
        IShoppingManager Manager;
        public ShoppingController(IShoppingManager manager)
        {
            log4Net = this.Log<ShoppingController>();
            Manager = manager;
        }
        [HttpGet]
        [Route(APIEndpoint.DefaultRoute + "/{apiName}/category")]
        public async Task<ActionResult> GetCategoryAsync(string apiName, int page = 1, int itemsPerPage = 20)
        {
            try
            {
                var result = await Manager.GetCategoryListAsync(apiName, page, itemsPerPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse(ResponseCode.ERROR, "Exception", ex.Message));
            }
        }
        [HttpGet]
        [Route(APIEndpoint.DefaultRoute + "/{apiName}/category/products/{categoryId}")]
        public async Task<ActionResult> GetProductByCategoryAsync(string apiName,string categoryId, int page = 1, int itemsPerPage = 20)
        {
            try
            {
                var result = await Manager.GetProductByCategoryAsync(apiName,categoryId, page, itemsPerPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse(ResponseCode.ERROR, "Exception", ex.Message));
            }
        }

        [HttpGet]
        [Route(APIEndpoint.DefaultRoute + "/{apiName}/product/{pId}")]
        public async Task<ActionResult> GetProductDetailsAsync(string apiName, string pId)
        {
            try
            {
                var result = await Manager.GetProductDetailsAsync(apiName,pId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse(ResponseCode.ERROR, "Exception", ex.Message));
            }
        }

        
    }
}
