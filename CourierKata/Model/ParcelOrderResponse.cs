using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata.Model
{
    public class ParcelOrderResponse
    {
        public List<Parcel> Parcels { get; set; }
        public decimal TotalCost { get; set; }
        public decimal SpeedyDeliveryCost { get; set; }
    }
}
