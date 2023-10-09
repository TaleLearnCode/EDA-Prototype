CREATE TABLE Purchase.PurchaseLineItem
(
  PurchaseLineItemId INT       NOT NULL IDENTITY(1,1),
  CustomerPurchaseId CHAR(36)  NOT NULL,
  ProductId          CHAR(5)   NOT NULL,
  Quantity           INT       NOT NULL,
  OrderStatusId      INT       NOT NULL CONSTRAINT dfOrderItem_OrderStatusId DEFAULT(1),
  DateTimeAdded      DATETIME2 NOT NULL CONSTRAINT dfOrderItem_DateTimeAdded DEFAULT(GETUTCDATE()),
  DateTimeModified   DATETIME2     NULL,
  CONSTRAINT pkcOrderItme PRIMARY KEY CLUSTERED (PurchaseLineItemId),
  CONSTRAINT fkOrderItem_CustomerOrder FOREIGN KEY (CustomerPurchaseId) REFERENCES Purchase.CustomerPurchase (CustomerPurchaseId),
  CONSTRAINT fkOrderItem_Product       FOREIGN KEY (ProductId)          REFERENCES Product.Product (ProductId),
  CONSTRAINT fkOrderItem_OrderStatus   FOREIGN KEY (OrderStatusId)      REFERENCES Purchase.PurchaseStatus (PurchaseStatusId)
)