using System;
using System.Collections.Generic;
using System.Text;

namespace DropShippingAPI.ThirdPartyAPI.CJ
{
    public class Product
    {
        public bool code { get; set; }
        public int countSize { get; set; }
        public List<ProductData> data { get; set; }
        public int pageNum { get; set; }
    }
    public class CommodityData
    {
        public int packWerght { get; set; }
        public string img { get; set; }
        public string price { get; set; }
        public List<string> varietyCommodityDifferenceOption { get; set; }
        public double weight { get; set; }
        public string id { get; set; }
        public string sku { get; set; }
        public string commodityDifferenceOption { get; set; }
        public List<string> specifications { get; set; }
        public string STANDARD { get; set; }
        public string parentID { get; set; }
    }

    public class ProductData
    {
        public string description { get; set; }
        public List<string> materialOption { get; set; }
        public List<string> commodityDifferenceOption { get; set; }
        public string bigImg { get; set; }
        public string unit { get; set; }
        public List<string> packingOption { get; set; }
        public List<CommodityData> commodityData { get; set; }
        public List<string> commodityProperty { get; set; }
        public string name { get; set; }
        public List<string> imgOption { get; set; }
        public string id { get; set; }
        public string category { get; set; }
        public string sku { get; set; }
        public string categoryId { get; set; }
    }

    public class ProductRequest
    {
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public string categoryId { get; set; }
    }
}
