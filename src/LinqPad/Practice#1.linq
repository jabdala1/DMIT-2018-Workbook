<Query Kind="Statements">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//Orders.Max(sale => sale.OrderDate).Value.Month
from sale in Orders
where sale.OrderDate.Value.Month == 5 
	&& sale.OrderDate.Value.Year == 2018
select new //sale
{
	Customer = sale.Customer.CompanyName,
	ResponseTime = sale.RequiredDate.Value - sale.OrderDate.Value,
	PaymentDueOn = sale.PaymentDueDate,
	FirstPayment = sale.Payments.First().PaymentDate,
	PaymentResponseTime = sale.Payments.First().PaymentDate - sale.PaymentDueDate.Value
}

//C# Statements
//DateTime.DaysInMonth(2020, 2).Dump("Days in Feb, 2020");
//DateTime today = DateTime.Today;
//var fiveDaysLater = today.AddDays(5);
//fiveDaysLater.Dump();
//var delay = new TimeSpan(49, 15, 22);
//delay.Dump();
//today.Add(delay).Dump();
//today.ToString("MMM dd yyyy").Dump();