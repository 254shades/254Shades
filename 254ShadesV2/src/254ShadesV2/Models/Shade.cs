using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _254ShadesV2.Models
{
    public class Shade : TableEntity, IShade
    {
        public const string DefaultPartitionKey = "254Shades";

        public Shade()
        {
            PartitionKey = DefaultPartitionKey;
        }

        public int NumericValue { get { return Convert.ToInt32(RowKey); } set { RowKey = value.ToString(); } }
        public string HexValue { get; set; }
        public string LongHexValue { get; set; }
        public string Name { get; set; }
        public string NamedBy { get; set; }
    }

    public interface IShade
    {
        int NumericValue { get; set; }
        string HexValue { get; set; }
        string LongHexValue { get; set; }
        string Name { get; set; }
        string NamedBy { get; set; }
    }
}
