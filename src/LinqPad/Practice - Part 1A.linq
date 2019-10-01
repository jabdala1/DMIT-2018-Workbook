<Query Kind="Expression">
  <Connection>
    <ID>fe29399e-f0c4-4b20-abfe-9bfde3e8f45b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Part 1A: List all the customer company names for those with more than 5 orders.
from customer in Customers
where customer.Orders.Count >= 5
select customer.CompanyName