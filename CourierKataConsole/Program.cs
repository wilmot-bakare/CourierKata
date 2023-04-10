// See https://aka.ms/new-console-template for more information
using CourierKata;
using CourierKata.Model;

CourierKataService courierKataService = new CourierKataService();
ParcelOrder parcelOrder = new ParcelOrder();
parcelOrder.Parcels = new List<Parcel>
            {
           new Parcel { Height = 9, Width = 9, Depth = 9 , Weight = 1}, //USD 3
            new Parcel { Height = 49, Width = 49, Depth = 49 , Weight = 3}, //USD 8
            new Parcel { Height = 99, Width = 99, Depth = 99, Weight = 6 },//USD 15
            new Parcel { Height = 100, Width = 100, Depth = 100 , Weight = 10}, //USD 25
            };
ParcelOrderResponse res = CourierKataService.CalculateOrderCost(parcelOrder);
//Console.WriteLine(result); // Output: 5
Console.WriteLine("Hello, World!");
