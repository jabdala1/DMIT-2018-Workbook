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
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here

public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            // TODO: Get all the shippers from the Db
			var result = from shipper in Shippers
							orderby shipper.CompanyName
							select new ShipperSelection
							{
								ShipperId = shipper.ShipperID,
								Shipper = shipper.CompanyName,
							};
			return result.ToList();
        }
		
public class ShipperSelection
    {
        public int ShipperId { get; set; }
        public string Shipper { get; set; }
    }
