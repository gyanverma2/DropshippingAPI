using System;
using System.Collections.Generic;
using System.Text;

namespace DropShippingAPI.ThirdPartyAPI.CJ
{
    public class Category
    {
        public bool code { get; set; }
        public int countSize { get; set; }
        public List<CategoryData> data { get; set; }
        public int pageNum { get; set; }
    }

    public class SubsetJson
    {
        public string name { get; set; }
        public string id { get; set; }
        public string parentPid { get; set; }
        public List<SubsetJson> subsetJson { get; set; }
    }

    public class CategoryData
    {
        public string name { get; set; }
        public List<SubsetJson> subsetJson { get; set; }
        public string id { get; set; }
    }
}
