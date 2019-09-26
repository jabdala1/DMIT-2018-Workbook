<Query Kind="Expression">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not manage anyone.
from person in Employees
//   Employee      Table<Employee> 
where person.ReportsToChildren.Count == 0
//     Employee    IEnumerable<Employee>
select new
{
  Name = person.FirstName + " " + person.LastName,
  Manager = person.ReportsToEmployee.FirstName + " " + person.ReportsToEmployee.LastName
}