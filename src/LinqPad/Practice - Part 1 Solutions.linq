<Query Kind="Expression">
  <Connection>
    <ID>86ce6529-c094-4670-9408-244ea44707bb</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// A) List all the customer company names for those with more than 5 orders.
from customer in Customers
where customer.Orders.Count > 5
select customer.CompanyName

// B) Get a list of all the region names
from regions in Regions
select regions.RegionDescription

// C) Get a list of all the territory names
from territory in Territories
select territory.TerritoryDescription

// D) List all the regions and the number of territories in each region
from region in Regions
select new
{
	Regions = region.RegionDescription,
	Territories = region.Territories.Count()
}

// E) List all the region and territory names in a "flat" list
from place in Territories
select new
{
	Region = place.Region.RegionDescription,
	Territory = place.TerritoryDescription
}

// F) List all the region and territory names as an "object graph" - use a nested query
from place in Regions
select new
{
	Region = place.RegionDescription,
	Territories = from area in place.Territories
					select area.TerritoryDescription
}

// G) List all the product names that contain the word "chef" in the name.
from item in Products
where item.ProductName.Contains("chef")
select item.ProductName

// H) List all the discontinued products, specifying the product name and unit price.
from item in Products
where item.Discontinued
select new
{
	item.ProductName,
	item.UnitPrice
}

// I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from vendor in Suppliers
where vendor.Address.Country == "Canada" || vendor.Address.Country == "USA" || vendor.Address.Country == "Mexico"
select vendor.CompanyName