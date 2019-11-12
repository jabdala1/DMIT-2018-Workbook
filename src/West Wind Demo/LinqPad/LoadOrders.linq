<Query Kind="Program">
  <Connection>
    <ID>86ce6529-c094-4670-9408-244ea44707bb</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	int supplier = 8;// 2, 7, 8, 16, 19
	var output = LoadOrders(supplier);
	output.Dump();
}

// Define other methods and classes here
public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public int DaysRemaining { get; } // TODO: Calculated
        public IEnumerable<OrderItem> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
public class OrderItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; } // Calculated as OD.Quantity - Sum(Shipped qty)
    }
public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            //throw new NotImplementedException();
			
			var result = from sale in Orders
			where !sale.Shipped && sale.OrderDate.HasValue
			select new OutstandingOrder
			{
				OrderId = sale.OrderID,
				ShipToName = sale.ShipName,
				OrderDate = sale.OrderDate.Value,
				RequiredBy = sale.RequiredDate.Value,
				OutstandingItems = from item in sale.OrderDetails
									where item.Product.SupplierID == supplierId
									select new OrderItem
									{
										ProductID = item.ProductID,
										ProductName = item.Product.ProductName,
										Qty = item.Quantity,
										QtyPerUnit = item.Product.QuantityPerUnit,
										//TODO: Figure out the OutStandind quantity
										//Outstanding = (from ship in item.Order.Shipments
										//				from shipItem in ship.ManifestItems
										//				where shipItem.ProductID == item.ProductID
										//				select shipItem.ShipQuantity).Sum()
									},
				FullShippingAddress = // TODO: how to use sale.ShipAddressID
										sale.Customer.Address.Address + Environment.NewLine + 
										sale.Customer.Address.City + ", " +
										sale.Customer.Address.Region + Environment.NewLine +
										sale.Customer.Address.Country + " " + 
										sale.Customer.Address.PostalCode,
				Comments = sale.Comments
			};
			return result.ToList();
            //TODO: Implement this method with the following
            /*
             * Validation:
                    Make sure the supplier ID exists, otherwise throw an exception
                    [Advanced:] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                    TODO: List table names
             */
        }


