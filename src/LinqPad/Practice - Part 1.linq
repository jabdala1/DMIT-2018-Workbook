<Query Kind="Expression">
  <Connection>
    <ID>fe29399e-f0c4-4b20-abfe-9bfde3e8f45b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.
/*

A) List all the customer company names for those with more than 5 orders.
B) Get a list of all the region names
C) Get a list of all the territory names
D) List all the regions and the number of territories in each region
E) List all the region and territory names in a "flat" list
F) List all the region and territory names as an "object graph"
   - use a nested query
G) List all the product names that contain the word "chef" in the name.
H) List all the discontinued products, specifying the product name and unit price.
I) List the company names of all Suppliers in North America (Canada, USA, Mexico)

*/

// Part 1E: List all the region and territory names in a "flat" list
from region in Regions
select new
{
   Region = region.RegionDescription,
   Territories = region.Territories.TerritoryDescription
}