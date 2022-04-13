using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DropShippingAPI.ThirdPartyAPI.CJ
{
    public class ProductDetails
    {
        public bool code { get; set; }
        public string listingMessage { get; set; }
        public Data data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class INVENTORY
    {
        [JsonProperty("85742FBC-38D7-4DC4-9496-296186FFEED8")]
        public int _85742FBC38D74DC49496296186FFEED8 { get; set; }

        [JsonProperty("{6709CCD7-0DC7-43B1-B310-17AB499E9B0A}")]
        public int _6709CCD70DC743B1B31017AB499E9B0A { get; set; }

        [JsonProperty("738A09F1-2834-43CC-85A8-2FE5610C2599")]
        public int _738A09F1283443CC85A82FE5610C2599 { get; set; }
    }

    public class A0C84CC688714A24BAD326059864CDEF
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class CUSTOMERTAGS
    {
        [JsonProperty("{A0C84CC6-8871-4A24-BAD3-26059864CDEF}")]
        public A0C84CC688714A24BAD326059864CDEF A0C84CC688714A24BAD326059864CDEF { get; set; }
    }

    public class CountryInvs
    {
        public int USA { get; set; }
        public int CHINA { get; set; }
    }

    public class StanProduct
    {
        public CountryInvs countryInvs { get; set; }
        public string IMG { get; set; }
        public string shopMethod { get; set; }
        public string NAMEEN { get; set; }
        public int PACKWEIGHT { get; set; }
        public string PID { get; set; }
        public string VARIANTKEY { get; set; }
        public string SELLPRICE { get; set; }
        public int sellDiscount { get; set; }
        public int freightDiscount { get; set; }
        public string ID { get; set; }
        public string SKU { get; set; }
        public int WEIGHT { get; set; }
        public string STANDARD { get; set; }
    }

    public class INVENTORCOUNTRY
    {
        public int China { get; set; }
        public int US { get; set; }
    }

    public class Data
    {
        public string BIGIMG { get; set; }
        public string PACKINGEN { get; set; }
        public string BUYTIME { get; set; }
        public string PACKWEIGHT { get; set; }
        public string PROPERTYEN { get; set; }
        public string VARIANTKEY { get; set; }
        public string VARIANTKEYEN { get; set; }
        public INVENTORY INVENTORY { get; set; }
        public string DESCRIPTION { get; set; }
        public string CATEGORY { get; set; }
        public string ID { get; set; }
        public string WEIGHT { get; set; }
        public string MATERIAL { get; set; }
        public CUSTOMERTAGS CUSTOMERTAGS { get; set; }
        public string IMG { get; set; }
        public List<StanProduct> stanProducts { get; set; }
        public string UNIT { get; set; }
        public string MATERIALKEY { get; set; }
        public string PACKINGKEY { get; set; }
        public string NAMEEN { get; set; }
        public string PROPERTY { get; set; }
        public string CATEGORYID { get; set; }
        public string MATERIALEN { get; set; }
        public string isCollect { get; set; }
        public string CategoryIds { get; set; }
        public INVENTORCOUNTRY INVENTORCOUNTRY { get; set; }
        public string isHaveVideo { get; set; }
        public string AUTHORITYSTATUS { get; set; }
        public string NAME { get; set; }
        public string SELLPRICE { get; set; }
        public string listed { get; set; }
        public string PROPERTYKEY { get; set; }
        public string entryName { get; set; }
        public string PACKING { get; set; }
        public string SKU { get; set; }
    }


}
