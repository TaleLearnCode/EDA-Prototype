CREATE TABLE Inventory.ProductInventoryTransaction
(
  ProductInventoryId       INT          NOT NULL IDENTITY(1,1),
  ProductId                CHAR(5)      NOT NULL,
  ProductInventoryActionId INT          NOT NULL,
  ActionDateTime           DATETIME2    NOT NULL CONSTRAINT dfProductInventory_ActionDateTime DEFAULT(GETUTCDATE()),
  InventoryCredit          INT          NOT NULL CONSTRAINT dfProductInventory_InventoryCredit DEFAULT(0),
  InventoryDebit           INT          NOT NULL CONSTRAINT dfProductInventory_InventoryDebit DEFAULT(0),
  InventoryReserve         INT          NOT NULL CONSTRAINT dfProductInventory_InventoryReserve DEFAULT(0),
  OrderNumber              VARCHAR(100)     NULL,
  CONSTRAINT pkcProductInventory PRIMARY KEY CLUSTERED (ProductInventoryId),
  CONSTRAINT fkProductInventory_Product FOREIGN KEY (ProductId) REFERENCES Inventory.Product (ProductId),
  CONSTRAINT fkProductInventory_ProductInventoryAction FOREIGN KEY (ProductInventoryActionId) REFERENCES Inventory.ProductInventoryAction (ProductInventoryActionId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction',                                                           @value=N'Represents the inventory status of a product.',                                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'ProductInventoryId',                        @value=N'Identifier for the product inventory transaction.',                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'ProductId',                                 @value=N'Identifier for the product.',                                                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'ProductInventoryActionId',                  @value=N'Identifier for the associated product inventory action.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'ActionDateTime',                            @value=N'The date and time of the product inventory transaction.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'InventoryCredit',                           @value=N'The number of items to credit the product inventory by.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'InventoryDebit',                            @value=N'The number of items to debit the product inventory by.',                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'InventoryReserve',                          @value=N'The number of items to put on product inventory hold.',                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'OrderNumber',                               @value=N'Identifier for any associated product.',                                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'pkcProductInventory',                       @value=N'Defines the primary key for the ProductInventory record using the ProductInventoryId column.',                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'fkProductInventory_Product',                @value=N'Defines the relationship between the ProductInventory and Product tables using the ProductId column.',                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'fkProductInventory_ProductInventoryAction', @value=N'Defines the relationship between the ProductInventory and ProductInventoryAction tables using the ProductInventoryActionId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'dfProductInventory_ActionDateTime',         @value=N'Sets the default date/time of the transaction to the current UTC date/time.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'dfProductInventory_InventoryCredit',        @value=N'Sets the default transaction credit value to 0.',                                                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'dfProductInventory_InventoryDebit',         @value=N'Sets the default transaction debit value to 0.',                                                                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'ProductInventoryTransaction', @level2name=N'dfProductInventory_InventoryReserve',       @value=N'Sets the default transaction reserve value to 0.',                                                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO