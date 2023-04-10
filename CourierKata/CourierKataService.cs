using CourierKata.Model;

namespace CourierKata
{
    public class CourierKataService
    {
        public static readonly decimal SmallMaxWeight = 1;
        public static readonly decimal MediumMaxWeight = 3;
        public static readonly decimal LargeMaxWeight = 6;
        public static readonly decimal XLMaxWeight = 10;
        public static readonly decimal OverWeightBaseCharge = 2;
        public static Parcel CalculateCost(decimal height, decimal width, decimal depth, decimal weight)
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
                Size = size,
                Weight = weight
            };
        }

        public static decimal CalculateTotalCost(IEnumerable<Parcel> parcels)
        {
            return parcels.Sum(p => p.Cost + p.OverWeightCost);
        }

        public static decimal CalculateSpeedyDeliveryCost(decimal totalCost)
        {
            return totalCost *2;
        }

        public static ParcelOrderResponse CalculateOrderCost(ParcelOrder parcelOrder)
        {
            ParcelOrderResponse parcelOrderResponse = new ParcelOrderResponse();
            parcelOrderResponse.Parcels = new List<Parcel>();
            foreach (var parcel in parcelOrder.Parcels)
            {
                Parcel calculatedPacel = new Parcel();
                calculatedPacel = CalculateCost(parcel.Height, parcel.Width, parcel.Depth,parcel.Weight);
                if (CheckOverWeightParcel(parcel))
                {
                    calculatedPacel.OverWeightCost = GetOverWeightCharge(parcel);
                }
                parcelOrderResponse.Parcels.Add(calculatedPacel);
               
            }
            if(parcelOrderResponse.Parcels.Count > 0)
            {
               var totalTotalCost =  CalculateTotalCost(parcelOrderResponse.Parcels);
                parcelOrderResponse.TotalCost = totalTotalCost;

                parcelOrderResponse.SpeedyDeliveryCost =  CalculateSpeedyDeliveryCost(parcelOrderResponse.TotalCost);
            }
            return parcelOrderResponse;
        }

        public static bool CheckOverWeightParcel(Parcel parcel)
        {
            bool isOverweight = false;
            if (parcel.Size == ParcelSize.Small && parcel.Weight > 1)
            {
                isOverweight =  true;
            }
            else if (parcel.Size == ParcelSize.Medium && parcel.Weight > 3)
            {
                isOverweight =  true;
            }
            else if (parcel.Size == ParcelSize.Large && parcel.Weight > 6)
            {
                isOverweight =  true;
            }
            else if (parcel.Size == ParcelSize.XL && parcel.Weight > 10)
            {
                isOverweight =  true;
            }

            return isOverweight;
        }
        public static decimal  GetOverWeightCharge(Parcel parcel)
        {
            decimal overWeightCharge = 0;
            decimal weightDifference = 0;
            if (parcel.Size == ParcelSize.Small)
            {
                weightDifference =  parcel.Weight - SmallMaxWeight;
                overWeightCharge = OverWeightBaseCharge * weightDifference;
            }
            else if (parcel.Size == ParcelSize.Medium )
            {
                weightDifference =  parcel.Weight - MediumMaxWeight;
                overWeightCharge = OverWeightBaseCharge * weightDifference;
            }
            else if (parcel.Size == ParcelSize.Large)
            {
                weightDifference =  parcel.Weight - LargeMaxWeight;
                overWeightCharge = OverWeightBaseCharge * weightDifference;
            }
            else if (parcel.Size == ParcelSize.XL )
            {
                weightDifference =  parcel.Weight - XLMaxWeight;
                overWeightCharge = OverWeightBaseCharge * weightDifference;
            }

            return overWeightCharge;

        }
    }
}