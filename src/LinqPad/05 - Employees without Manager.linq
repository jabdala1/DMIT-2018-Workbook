<Query Kind="Expression">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person in Employees
//   Employee      Table[Employees] 
where person.ReportsToEmployee == null
//   Employee      Employee
select new // Creating an anonymous data type
// The curly braces section below is called the Initializer list
{
  Name = person.FirstName + " " + person.LastName
}