<Query Kind="Expression">
  <Connection>
    <ID>86ce6529-c094-4670-9408-244ea44707bb</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */
from place in Regions
select new
{
	Region = place.RegionDescription,
	// Getting employees and removing duplicates
	// Using .Distinct()
	Employees = (from area in place.Territories
				from manager in area.EmployeeTerritories
				select manager.Employee.FirstName + " " + manager.Employee.LastName).Distinct(),
	// Using group by
	Employees2 = from area in place.Territories
					from manager in area.EmployeeTerritories
					group manager by manager.Employee into areaManagers
					select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
}

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from company in Customers
select new
{
	CompanyName = company.CompanyName,
	Contact = new 
				{
					Name = company.ContactName,
					Title = company.ContactTitle,
					Email = company.ContactEmail,
					Phone = company.Phone,
					Fax = company.Fax
				}
}

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
from person in Employees
orderby person.LastName, person.FirstName
select new
{
	person.FirstName,
	person.LastName,
	OrderCount = person.SalesRepOrders.Count()
}

// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.


// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.
from company in Customers
group company by company.Address.City into customersByCity
select new
{
	City = customersByCity.Key,
	Customers = from buyer in customersByCity
				select new
				{
					buyer.CompanyName,
					buyer.ContactName,
					buyer.ContactTitle,
					buyer.Phone
				}
}

// F) List all the Suppliers, by Country
from vendor in Suppliers
group vendor by vendor.Address.Country into nationalSuppliers
select new
{
	Country = nationalSuppliers.Key,
	Suppliers = from company in nationalSuppliers
				select company.CompanyName
}