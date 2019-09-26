<Query Kind="Expression">
  <Connection>
    <ID>ccfcabb9-6041-4093-b5a2-79fbd988885a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from cat in Categories
 select new //ProductCategory
 {
     CategoryName = cat.CategoryName,
     Description = cat.Description,
     Picture = cat.Picture.ToImage(), // Note: remove .ToImage() for Visual Studio 2019
     MimeType = cat.PictureMimeType,
     Products = from item in cat.Products
                select new //ProductSummary
                {
                    Name = item.ProductName,
                    Price = item.UnitPrice,
                    Quantity = item.QuantityPerUnit
                }
 }