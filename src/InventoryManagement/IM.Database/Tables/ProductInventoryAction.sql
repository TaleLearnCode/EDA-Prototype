CREATE TABLE Inventory.ProductInventoryAction
(
  ProductInventoryActionId   INT NOT NULL,
  ProductInventoryActionName NVARCHAR(100),
  CONSTRAINT pkcProductInventoryAction PRIMARY KEY CLUSTERED (ProductInventoryActionId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryAction',                                            @value=N'Represents a type of action taken on the inventory of a product.',                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryAction', @level2name=N'ProductInventoryActionId',   @value=N'Identifier for the product inventory action.',                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryAction', @level2name=N'ProductInventoryActionName', @value=N'Name for the product inventory action.',                                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryAction', @level2name=N'pkcProductInventoryAction',  @value=N'Defines the primary key for the ProductInventoryAction record using the ProductInventoryActionId column.',  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO