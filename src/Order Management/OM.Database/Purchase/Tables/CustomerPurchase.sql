CREATE TABLE Purchase.CustomerPurchase
(
  CustomerPurchaseId CHAR(36)  NOT NULL,
  CustomerId         INT       NOT NULL,
  OrderStatusId      INT       NOT NULL CONSTRAINT dfCustomerPurchase_OrderStatusId DEFAULT(1),
  OrderDateTime      DATETIME2 NOT NULL CONSTRAINT dfCustomerPurchase_OrderDateTime DEFAULT(GETUTCDATE()),
  ReserveDateTime    DATETIME2     NULL,
  ShipDateTime       DATETIME2     NULL,
  CompleteDateTime   DATETIME2     NULL,
  CONSTRAINT pkcCustomerPurchase PRIMARY KEY CLUSTERED (CustomerPurchaseId)
)