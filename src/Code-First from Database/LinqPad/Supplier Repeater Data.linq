<Query Kind="Program">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	var result = from vendor in Suppliers
	select new SupplierSummary
	{
		CompanyName = vendor.CompanyName,
		Contact = vendor.ContactName,
		Phone = vendor.Phone,
		Products = from item in vendor.Products
					select new SupplierProduct
					{
						Name = item.ProductName,
						Category = item.Category.CategoryName,
						Price = item.UnitPrice,
						PerUnityQuanitity = item.QuantityPerUnit
					}
	};
	result.Dump();
}

// Define other methods and classes here
	/*
	Supplier:
		Company Name
		Phone Number
		Product Summary:
			Product Name
			Category Name
			Unit Price
			Quantity/Unit
	*/
public class SupplierSummary
{
	public string ComapnyName {get; set;}
	public string Contact {get; set;}
	public string Phone {get; set;}
	public IEnumerable<SupplierProduct> Products {get; set;}	
}

public class SupplierProduct
{
	public string Name {get; set;}
	public string Category {get; set;}
	public decimal Price {get; set;}
	public string PerUnitQuantity {get; set;}
}