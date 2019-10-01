<Query Kind="Expression">
  <Connection>
    <ID>fe29399e-f0c4-4b20-abfe-9bfde3e8f45b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Part 1C: Get a list of all the territory names
from territory in Territories
select territory.TerritoryDescription
