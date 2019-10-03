<Query Kind="Expression">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

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
// Try to finish Pratice
from vendor in Suppliers
select new
{
	CompanyName = vendor.CompanyName,
	Contact = vendor.ContactName,
	Phone = vendor.Phone,
	Products = from item in vendor.Products
				select new
				{
					Name = item.ProductName,
					Category = item.Category.CategoryName,
					Price = item.UnitPrice,
					PerUnityQuanitity = item.QuantityPerUnit
				}
}