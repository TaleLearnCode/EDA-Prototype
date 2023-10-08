CREATE VIEW Inventory.vwProductInventory
AS
SELECT Product.ProductId                                         ProductId,
       Product.ProductName                                       ProductName,
       Inventory.ufnGetProductInventoryOnHand(Product.ProductId) ProductInventoryOnHand,
       Inventory.ufnGetReservedProductCount(Product.ProductId)   ReservedCount
  FROM Inventory.Product
GO