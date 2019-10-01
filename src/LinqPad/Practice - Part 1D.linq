<Query Kind="Expression">
  <Connection>
    <ID>fe29399e-f0c4-4b20-abfe-9bfde3e8f45b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Part 1D: List all the regions and the number of territories in each region
from region in Regions
select new
{
	Regions = region.RegionDescription,
	Territories = region.Territories.Count
}