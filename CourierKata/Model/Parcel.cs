using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata.Model
{
    public  class Parcel
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }
        public decimal Cost { get; set; }
        public decimal OverWeightCost { get; set; }
        public ParcelSize Size { get; set; }
     
    }

    public enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL,
        Heavy
    }
}
