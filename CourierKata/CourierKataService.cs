using CourierKata.Model;

namespace CourierKata
{
    public class CourierKataService
    {
        public static Parcel CalculateCost(decimal height, decimal width, decimal depth)
        {
            var dimensions = new[] { height, width, depth };
            var largestDimension = dimensions.Max();

            ParcelSize size;
            decimal cost;

            if (largestDimension < 10)
            {
                size = ParcelSize.Small;
                cost = 3;
            }
            else if (largestDimension < 50)
            {
                size = ParcelSize.Medium;
                cost = 8;
            }
            else if (largestDimension < 100)
            {
                size = ParcelSize.Large;
                cost = 15;
            }
            else
            {
                size = ParcelSize.XL;
                cost = 25;
            }

            return new Parcel
            {
                Height = height,
                Width = width,
                Depth = depth,
                Cost = cost,
                Size = size
            };
        }

        public static decimal CalculateTotalCost(IEnumerable<Parcel> parcels)
        {
            return parcels.Sum(p => p.Cost);
        }

        public static ParcelOrderResponse CalculateOrderCost(ParcelOrder parcelOrder)
        {
            ParcelOrderResponse parcelOrderResponse = new ParcelOrderResponse();
            parcelOrderResponse.Parcels = new List<Parcel>();
            foreach (var parcel in parcelOrder.Parcels)
            {
                Parcel calculatedPacel = new Parcel();
                calculatedPacel = CalculateCost(parcel.Height, parcel.Width, parcel.Depth);
                parcelOrderResponse.Parcels.Add(calculatedPacel);
            }
            if(parcelOrderResponse.Parcels.Count > 0)
            {
               var totalTotalCost =  CalculateTotalCost(parcelOrderResponse.Parcels);
                parcelOrderResponse.TotalCost = totalTotalCost;
            }
            return parcelOrderResponse;
        }
    }
}