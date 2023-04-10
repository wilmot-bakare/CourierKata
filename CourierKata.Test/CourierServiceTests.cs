using CourierKata.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace CourierKata.Test
{
    public class CourierServiceTests
    {
        [Test]
        public void CalculateCost_ReturnsSmallParcel_WhenAllDimensionsLessThan10cm()
        {
            var parcel = CourierKataService.CalculateCost(8, 8, 9);

            Assert.AreEqual(ParcelSize.Small, parcel.Size);
            Assert.AreEqual(3, parcel.Cost);
        }

        [Test]
        public void CalculateCost_ReturnsMediumParcel_WhenAllDimensionsLessThan50cm()
        {
            var parcel = CourierKataService.CalculateCost(36, 36, 36);

            Assert.AreEqual(ParcelSize.Medium, parcel.Size);
            Assert.AreEqual(8, parcel.Cost);
        }

        [Test]
        public void CalculateCost_ReturnsLargeParcel_WhenAllDimensionsLessThan100cm()
        {
            var parcel = CourierKataService.CalculateCost(99, 99, 99);

            Assert.AreEqual(ParcelSize.Large, parcel.Size);
            Assert.AreEqual(15, parcel.Cost);
        }

        [Test]
        public void CalculateCost_ReturnsXLParcel_WhenAnyDimensionGreaterThanOrEqualTo100cm()
        {
            var parcel = CourierKataService.CalculateCost(100, 100, 100);

            Assert.AreEqual(ParcelSize.XL, parcel.Size);
            Assert.AreEqual(25, parcel.Cost);
        }

        [Test]
        public void CalculateOrderCost_ReturnsCorrectTotalCost_ForMultipleParcels()
        {
            ParcelOrder parcelOrder = new ParcelOrder();
            parcelOrder.Parcels = new List<Parcel>
            {
            new Parcel { Height = 9, Width = 9, Depth = 9 }, //USD 3
            new Parcel { Height = 49, Width = 49, Depth = 49 }, //USD 8
            new Parcel { Height = 99, Width = 99, Depth = 99 },//USD 15
            new Parcel { Height = 100, Width = 100, Depth = 100 }, //USD 25
            };
            var totalOrderCost = CourierKataService.CalculateOrderCost(parcelOrder);
            Assert.NotZero(totalOrderCost.TotalCost);
            Assert.AreEqual(51, totalOrderCost.TotalCost);
        }

        [Test]
        public void CalculateOrderCost_ReturnsSpeedyDeliveryFee()
        {
            ParcelOrder parcelOrder = new ParcelOrder();
            parcelOrder.Parcels = new List<Parcel>
            {
            new Parcel { Height = 9, Width = 9, Depth = 9 }, //USD 3
            new Parcel { Height = 49, Width = 49, Depth = 49 }, //USD 8
            new Parcel { Height = 99, Width = 99, Depth = 99 },//USD 15
            new Parcel { Height = 100, Width = 100, Depth = 100 }, //USD 25
            };
            var totalOrderCost = CourierKataService.CalculateOrderCost(parcelOrder);

            Assert.NotZero(totalOrderCost.SpeedyDeliveryCost);
            Assert.AreEqual(totalOrderCost.TotalCost *2, totalOrderCost.SpeedyDeliveryCost);
        }


    }
}